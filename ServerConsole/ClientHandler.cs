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

        public ClientHandler(Socket socket)
        {
            Socket = socket;
        }

        public void Comunication()
        {
            NetworkStream stream = new NetworkStream(Socket);
            Console.WriteLine("READY");
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            string[] text;
            do
            {
                text = reader.ReadLine().Split(';');
            } while (text[2]=="");
            
            Client c = new Client();
            c.Username = text[0];
            c.Password = text[1];
            c.IP = text[2];

            Console.WriteLine(Logic.CheckClient(c));
            while(true)
            writer.Write(Logic.CheckClient(c).ToString());

        }
    }
}
