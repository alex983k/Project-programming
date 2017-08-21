using System;
using System.Collections.Generic;
using System.Text;

namespace ServerConsole
{
    public class Bid
    {
        public string Name;
        public int Price;
        public string Seller;

        public Bid(string name, int price, string seller)
        {
            Name = name;
            Price = price;
            Seller = seller;
        }
    }
}
