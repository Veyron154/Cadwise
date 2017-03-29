namespace PingPong.Writer
{
    internal interface IWriter
    {
        void WriteCountOfInstances(string message);
        void WritePort(string portString);
    }
}
