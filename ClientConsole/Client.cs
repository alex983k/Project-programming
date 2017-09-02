using System;
using System.Collections.Generic;
using System.Text;

namespace ClientConsole
{
    class Client
    {
        public string Username;
        public string Password;
        public string IP;

        public Client(string username, string password)
        {
            Username = username;
            Password = password;
            IP = Program.GetLocalIPAddress();
        }
    }
}
