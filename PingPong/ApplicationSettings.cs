namespace PingPong
{
    internal static class ApplicationSettings
    {
        internal const string Ip = "235.5.5.11";
        internal const int TimeToLive = 20;
        internal const int TimerInterval = 3000;
        internal const int TimerStartTime = 3000;
        internal const int MaxLengthOfUdpData = 65507;
        internal const int MinPort = 1024;
        internal const int MaxPort = 65536;
        internal const int ReceiveTimeout = 1000;
        internal const int SocketErrorCode = 10060;
    }
}
