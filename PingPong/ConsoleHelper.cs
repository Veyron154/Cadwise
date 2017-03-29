using System.Runtime.InteropServices;

namespace PingPong
{
    internal static class ConsoleHelper
    {
        [DllImport("kernel32", EntryPoint = "SetConsoleCtrlHandler")]
        public static extern bool SetSignalHandler(SignalHandler handler, bool add);
    }
}
