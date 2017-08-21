using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Bid
    {
        public string Name;
        public int Price;
        public string Seller;

        Bid(string name, int price, string seller)
        {
            Name = name;
            Price = price;
            Seller = seller;
        }
    }
}
