using System;

namespace PingPong.ExceptionHandler
{
    internal interface IExceptionHandler
    {
        void Handle(Exception exception);
    }
}
