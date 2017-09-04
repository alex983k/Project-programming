using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ClientConsole
{
    class Auction
    {

        public TcpClient Server;
        public NetworkStream Stream;
        public StreamReader Reader;
        public StreamWriter Writer;

        public Auction ()
        {
            Server = new TcpClient("localhost", 11000);
            Stream = Server.GetStream();
            Reader = new StreamReader(Stream);
            Writer = new StreamWriter(Stream);
        }
    }
}
