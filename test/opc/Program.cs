using System;

using Dade.Dms.Opc;

namespace Dade.Test.Opc
{
    class Program
    {
        static void Main(string[] args)
        {
            var opcServer = new OpcServerObject("server ip", "server name");
            opcServer.Connect();

            Console.ReadKey();
        }
    }
}