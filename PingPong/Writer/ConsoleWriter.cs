using System;

namespace PingPong.Writer
{
    internal sealed class ConsoleWriter : IWriter
    {
        public void WriteCountOfInstances(string message)
        {
            const int leftPosition = 0;
            const int topPosition = 1;

            Console.SetCursorPosition(leftPosition, topPosition);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(leftPosition, topPosition);
            Console.WriteLine(message);
        }

        public void WritePort(string portString)
        {
            Console.Clear();
            Console.WriteLine(portString);
        }
    }
}
