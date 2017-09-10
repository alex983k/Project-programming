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
        static public void CheckBidStatus()
        {
            Console.WriteLine("Please wait untill a new bid starts.");
            string text = s.Reader.ReadLine();
            do
            {
                text = s.Reader.ReadLine();
            } while ((text != "open") && (text != "close"));
            if (text == "open")
            {
                Console.WriteLine("Bid found.");
                StartBid();
            }
            else
            {
                Console.WriteLine("There are no more items for sell!");
                Exit();
            }
        }

        private static void StartBid()
        {
            throw new NotImplementedException();
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
        public static void LoginUser()
        {
            Console.WriteLine("Please insert username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please insert password:");
            string password = Console.ReadLine();
            c = new Client(username, password);
            data = c.Username + ";" + c.Password + ";" + c.IP;
            Console.Clear();
            SendLogin();
        }
        public static void SendLogin()
        {
            string text;
            s.Writer.Write(data);
            do
            {
                text = s.Reader.ReadLine();
            } while ((text != "true") && (text != "false"));
            if (text == "true")
            {
                CheckBidStatus();
            }
            else
            {
                Console.WriteLine("Wrong credentials, try again.");
                Console.WriteLine("Do you want to try again? Answer with /yes/ or /no/.");
                string msg = Console.ReadLine();
                if (msg == "yes")
                    LoginUser();
                else
                    Exit();
            }

        }
    }
}
