using System;

namespace Common
{
    public sealed class ConsoleReadUtilitys
    {
        public static int GetPort()
        {
            while (true)
            {
                Console.WriteLine(Strings.EnterNumberOfPort);

                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    return 0;
                }

                int port;
                if (!int.TryParse(input, out port) && (port < ApplicationSettings.MinPort || port > ApplicationSettings.MaxPort))
                {
                    Console.Clear();
                    Console.WriteLine(Strings.PortMustBeWithin);
                    continue;
                }
                return port;
            }
        }
    }
}
