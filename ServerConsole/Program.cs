using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 11000);
            server.Start();
            while (true)
            {
                Socket client = server.AcceptSocket();
                ClientHandler c = new ClientHandler(client);
                Thread m = new Thread(new ThreadStart(c.Comunication));
                m.Start();
            }
        }
    }
}
