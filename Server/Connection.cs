using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Connection
    {
        static public int GetOffer()
        {
            int price;
            TimeSpan basetime = TimeSpan.FromMinutes(1);
            TcpListener server = new TcpListener(IPAddress.Any, 11000);
            server.Start();
            while (basetime > TimeSpan.Zero)
            {
                Socket client = server.AcceptSocket();
                NetworkStream stream = new NetworkStream(client);
                //READY
                StreamReader reader = new StreamReader(stream);
                price = int.Parse(reader.ReadLine());
            }
            server.Stop();
            return 1;
        }
        public int Send(int price)
        {
            return price;
        }
    }

}
