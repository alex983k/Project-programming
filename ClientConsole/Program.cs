using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ClientConsole
{
    class Program
    {
        static Client c;
        static void Main(string[] args)
        {
            LoginUser();
            if (CheckConnection() == true)
                Console.WriteLine("Connecting");
            else
                Console.WriteLine("Check internet connection.");
            TcpClient server = new TcpClient("localhost", 11000);
            NetworkStream stream = server.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine(c.Username + ";" + c.Password + ";" + c.IP);
            while (true)
            {
                Console.WriteLine(reader.Read());
                break;
            }

            Console.ReadKey();

        }
        static public void SendBid(string firstname, string lastname, int price)
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
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
        public static bool CheckConnection()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }
        public static Client LoginUser()
        {
            Console.WriteLine("Please insert username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please insert password:");
            string password = Console.ReadLine();
            c = new Client(username, password);
            Console.Clear();
            return c;
        }
    }
}
