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
        static Auction s;
        static Client c;
        static string data;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            CheckConnection();
            Exit();


            #region Old connection inside the main method
            //TcpClient server = new TcpClient("localhost", 11000);
            //NetworkStream stream = server.GetStream();
            //StreamReader reader = new StreamReader(stream);
            //StreamWriter writer = new StreamWriter(stream);
            //writer.AutoFlush = true;
            //writer.WriteLine(c.Username + ";" + c.Password + ";" + c.IP);
            //while (true)
            //{
            //    Console.WriteLine(reader.Read());
            //    break;
            //}
            #endregion

            Console.ReadKey();

        }
        static public void SendBid()
        {
            StreamWriter writer = new StreamWriter(s.Stream);
            Console.WriteLine("Please insert price:");
            string price = Console.ReadLine();
            s.Writer.Write(price);

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
        public static void CheckConnection()
        {
            bool conn = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (conn == true)
            {
                Console.WriteLine("Connecting");
                LoginUser();
            }
            else
            {
                Console.WriteLine("Check internet connection. Type /exit/ or /again/. ");
                string text = Console.ReadLine();
                if (text == "exit")
                    Exit();
                else
                    CheckConnection();
            }
        }
        private static void Exit()
        {
            Console.WriteLine("Press any key to continue...");
        }
        public static Client LoginUser()
        {
            Console.WriteLine("Please insert username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please insert password:");
            string password = Console.ReadLine();
            c = new Client(username, password);
            data = c.Username + ";" + c.Password + ";" + c.IP;
            Console.Clear();
            return c;
        }
        public static void SendLogin()
        {
            s.Writer.Write(data);
            bool k = false;
            while (true)
            {
                string text = s.Reader.Read().ToString();
                if (text == "true")
                    SendBid();
                else
                {
                    Console.WriteLine("Login failed, please insert the credentials again:");
                    LoginUser();
                }
            }
        }
    }
}
