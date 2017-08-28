using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient server = new TcpClient("127.0.0.1", 11000);
            NetworkStream stream = server.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine(Console.ReadLine());
            Console.ReadKey();

        }
        static public void SendBid (string firstname, string lastname, int price)
        {
            // Send bid
            // Check the last price with the last sent one
            // 
            //
            //
            //
            //
            //

        }
        static public void ReceiveStatus()
        {
            // Send bid
            // Check the last price with the last sent one
            // 
            //
            //
            //
            //
            //

        }
    }
}
