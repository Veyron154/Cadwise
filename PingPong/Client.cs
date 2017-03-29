using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using JetBrains.Annotations;
using PingPong.ExceptionHandler;
using PingPong.Writer;

namespace PingPong
{
    internal sealed class Client : Disposable
    {
        private static readonly HashSet<int> Signals = new HashSet<int> { 0, 1, 2, 5, 6 };

        private readonly IPAddress _address;
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _endPoint;
        private readonly IWriter _writer;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly bool _isAutomaticalyDeterminedPort;

        private readonly CancellationTokenSource _cancellationTokenSource;
        private int _countOfInstances;
        private Timer _refreshTimer;

        internal Client([NotNull]IPAddress address, int port, [NotNull]IWriter writer, [NotNull]IExceptionHandler exceptionHandler)
        {
            ThrowIfNull(address);
            ThrowIfNull(writer);
            ThrowIfNull(exceptionHandler);

            _cancellationTokenSource = new CancellationTokenSource();
            var realPort = port;

            if (port == 0)
            {
                _isAutomaticalyDeterminedPort = true;
            }
            else if (realPort < ApplicationSettings.MinPort || realPort > ApplicationSettings.MaxPort)
            {
                exceptionHandler.Handle(new ArgumentException(Strings.PortMustBeWithin));
            }

            _writer = writer;
            _address = address;

            try
            {
                _udpClient = new UdpClient(realPort);
            }
            catch (SocketException)
            {
                _udpClient = new UdpClient(0);
                _isAutomaticalyDeterminedPort = true;
            }

            realPort = ((IPEndPoint)_udpClient.Client.LocalEndPoint).Port;
            _endPoint = new IPEndPoint(_address, realPort);
            _exceptionHandler = exceptionHandler;
        }

        internal void Start()
        {
            try
            {
                var cancellationToken = _cancellationTokenSource.Token;

                _udpClient.JoinMulticastGroup(_address, ApplicationSettings.TimeToLive);

                var timerCallback = new TimerCallback(Refresh);
                _refreshTimer = new Timer(timerCallback, null, ApplicationSettings.TimerStartTime, ApplicationSettings.TimerInterval);

                ConsoleHelper.SetSignalHandler(HandleConsoleSignal, true);

                var localIp = GetLocalIpAddress();
                IPEndPoint remoteIp = null;

                _countOfInstances = 1;
                var isAutomaticalyDeterminedPortString = _isAutomaticalyDeterminedPort ? Strings.DeterminedAutomatically : string.Empty;
                _writer.WritePort(Strings.PortNumber + _endPoint.Port + isAutomaticalyDeterminedPortString);
                _writer.WriteCountOfInstances(Strings.CountOfInstances + _countOfInstances);

                SendMessage(Message.Ping, _endPoint);

                _udpClient.Client.ReceiveTimeout = ApplicationSettings.ReceiveTimeout;

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var data = _udpClient.Receive(ref remoteIp);

                        var message = Encoding.Unicode.GetString(data);

                        if (remoteIp.Address.ToString().Equals(localIp))
                        {
                            continue;
                        }

                        if (Message.Pong.Equals(message))
                        {
                            ++_countOfInstances;
                            _writer.WriteCountOfInstances(Strings.CountOfInstances + _countOfInstances);
                        }
                        else if (Message.Ping.Equals(message))
                        {
                            ++_countOfInstances;
                            _writer.WriteCountOfInstances(Strings.CountOfInstances + _countOfInstances);
                            SendMessage(Message.Pong, remoteIp);
                        }
                        else if (Message.Out.Equals(message))
                        {
                            --_countOfInstances;
                            _writer.WriteCountOfInstances(Strings.CountOfInstances + _countOfInstances);
                        }
                        else if (Message.Round.Equals(message))
                        {
                            SendMessage(Message.Pong, _endPoint);
                        }
                    }
                    catch (SocketException exception)
                    {
                        if (exception.ErrorCode != ApplicationSettings.SocketErrorCode)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                _exceptionHandler.Handle(exception);
            }
        }

        private void SendMessage(string message, IPEndPoint ipPoint)
        {
            var data = Encoding.Unicode.GetBytes(message);

            if (data.Length > ApplicationSettings.MaxLengthOfUdpData)
            {
                throw new Exception(Strings.DataLengthGreaterThenUDPDatagram);
            }
            _udpClient.Send(data, data.Length, ipPoint);
        }

        private void Refresh(object unused)
        {
            SendMessage(Message.Round, _endPoint);

            _countOfInstances = 1;
            _writer.WriteCountOfInstances(Strings.CountOfInstances + _countOfInstances);
        }

        private static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception(Strings.LocalIPNotFound);
        }

        private void HandleConsoleSignal(int consoleSignal)
        {
            if (Signals.Contains(consoleSignal))
            {
                SendMessage(Message.Out, _endPoint);
                _cancellationTokenSource.Cancel();
            }
        }

        protected override void FreeUnmanagedResources()
        {
            _udpClient?.DropMulticastGroup(_address);
            _udpClient?.Close();
            _refreshTimer?.Dispose();
        }

        private void ThrowIfNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(string.Format(Strings.ParameterCantBeNull, nameof(obj)));
            }
        }
    }
}
