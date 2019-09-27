using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerNamespace
{
    class Server
    {
        static void Main(string[] args)
        {
            var server = new NamedPipeServerStream("WDE");
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            while (true)
            {
                if (server.IsConnected)
                {
                    var line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                        Console.WriteLine(line);
                }
                else
                {
                    server.Disconnect();
                    server.Close();
                    server.Dispose();
                    server = new NamedPipeServerStream("WDE");
                    server.WaitForConnection();
                    reader = new StreamReader(server);


                }
            }
        }
    }
}
