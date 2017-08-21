using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Bid b = new Bid("Computer", 1000, "Odense Kommune");
            StartAuction(b);
        }


        static public void StartAuction(Bid b)
        {
            TimeSpan basetime = TimeSpan.FromMinutes(1);
            TcpListener server = new TcpListener(IPAddress.Any, 11000);
            server.Start();
            while (basetime > TimeSpan.Zero)
            {
                Socket client = server.AcceptSocket();
                NetworkStream stream = new NetworkStream(client);
                Console.WriteLine("Ready!");
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                int price = int.Parse(reader.ReadLine());
                if (price < b.Price)
                {
                    writer.Write(Logic.CompareBid(b, price));
                }
                else
                {
                    b = Logic.UpdatePrice(b, price);
                    basetime = basetime + TimeSpan.FromSeconds(10);
                }
            }
        }
        static public void Menu()
        {
            Console.WriteLine("1.Insert bid.");
            Console.WriteLine("2.Exit");  
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Insert bid.");
                    break;
                case 2:
                    Console.WriteLine("Exit.");
                    break;
            }
        }
        static public Bid InsertBid()
        {
            Console.WriteLine("Insert bid name:");
            string name=Console.ReadLine();
            Console.WriteLine("Insert bid price:");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert bid seller name:");
            string seller = Console.ReadLine();
            Bid b = new Bid(name, price, seller);
            return b;
        }
    }
}
