using System;
using System.Net;
using Common;
using PingPong.ExceptionHandler;
using PingPong.Writer;

namespace PingPong
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                var ipAddress = IPAddress.Parse(ApplicationSettings.Ip);
                var writer = new ConsoleWriter();
                var exceptonHandler = new ConsoleExceptionHandler();

                using (var client = new Client(ipAddress, ConsoleReadUtilitys.GetPort(), writer, exceptonHandler))
                {
                    client.Start();
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
        }
    }
}
