using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public static void Main(string[] args)
        {

            //Task.Delay(1000).Wait();
            var client = new NamedPipeClientStream("WDE");
            try
            {

                client.Connect();
                StreamWriter writer = new StreamWriter(client);

                while (true)
                {
                    string input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input)) break;

                    if (input.Equals("exit"))
                    {
                        client.Close();
                        client.Dispose();
                        Environment.Exit(1);
                    }
                    writer.WriteLine(input);
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                e = e;
            }
        }

    }
}
