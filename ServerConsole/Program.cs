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
            bool acceptUsers = true;
            Socket client;
            ClientHandler c;

            while (acceptUsers)
            {
                client = server.AcceptSocket();
                c = new ClientHandler(client);
                Thread m = new Thread(new ThreadStart(c.Comunication));
                m.Start();
                Thread a = new Thread(new ThreadStart(c.Auction));
                a.Start(c);
            }
            List<Item> list = Item.Example();
        }

        public void Auction()
        {

        }
    }
}
