using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class Client
    {
        private string Firstname;
        private string Lastname;
        private string IP;
        private string Username;
        private string Password;

        Client(string firstname, string lastname, string username, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Password = password;
        }
    }
}
