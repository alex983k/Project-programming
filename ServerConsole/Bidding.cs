using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    public class Bidding
    {
        string Item_Name;
        int Item_Price;
        string Client_Name;
        string Client_IP;

        public Bidding (string item_name, int item_price, string client_name, string client_IP)
        {
            Item_Name = item_name;
            Item_Price = item_price;
            Client_Name = client_name;
            Client_IP = client_IP;
        }
    }
}
