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



            #region StartAucion
            //static public void StartAuction(Item b)
            //{
            //    TimeSpan basetime = TimeSpan.FromMinutes(1);
            //    TcpListener server = new TcpListener(IPAddress.Any, 11000);
            //    server.Start();
            //    while (basetime > TimeSpan.Zero)
            //    {
            //        Socket client = server.AcceptSocket();
            //        NetworkStream stream = new NetworkStream(client);
            //        Console.WriteLine("Ready!");
            //        StreamReader reader = new StreamReader(stream);
            //        StreamWriter writer = new StreamWriter(stream);
            //        int price = int.Parse(reader.ReadLine());
            //        if (price < b.Current_Price)
            //        {
            //            writer.Write(Logic.CheckPrice(b, price));
            //        }
            //        else
            //        {
            //            b = Logic.UpdatePrice(b, price);
            //            basetime = basetime + TimeSpan.FromSeconds(10);
            //}
            #endregion
        }
    }
}
