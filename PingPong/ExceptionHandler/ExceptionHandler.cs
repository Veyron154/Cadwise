using System;

namespace PingPong.ExceptionHandler
{
    internal class ConsoleExceptionHandler : IExceptionHandler
    {
        public void Handle(Exception exception)
        {
            Console.WriteLine(exception.Message);
            Console.ReadLine();
        }
    }
}
