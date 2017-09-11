using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ServerConsole
{
    class ClientHandler
    {
        private Socket Socket;
        private NetworkStream Stream;
        public StreamWriter Writer;
        public StreamReader Reader;

        public ClientHandler(Socket socket)
        {
            Socket = socket;
            Stream = new NetworkStream(Socket);
            Writer = new StreamWriter(Stream);
            Reader = new StreamReader(Stream);
        }

        public void Comunication()
        {
            Console.WriteLine("READY");
            Writer.AutoFlush = true;
            Client client = CreateClient();
            Console.WriteLine("Username: "+ client.Username+ " has joined the auction with IP:"+client.IP);
            bool result = Logic.CheckClient(client);
            if (result == false)
            Writer.WriteLine(result.ToString());

        }
        public void Auction()
        {
            Client c = CreateClient();
            Reader.ReadLine();
            Writer.WriteLine();
            Console.WriteLine("fgfg");
            //return "fdg";
        }

        public Client CreateClient()
        {
            string[] text;
            do
            {
                text = Reader.ReadLine().Split(';');
            } while (text[2] == "");
            Client c = new Client();
            c.Username = text[0];
            c.Password = text[1];
            c.IP = text[2];
            return c;
        }
    }
}
