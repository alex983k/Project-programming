using System;
using System.Collections.Generic;
using System.Text;

namespace ServerConsole
{
    public class Logic
    {
        static public string CompareBid(Bid b, int price)
        {
            if (price < b.Price)
                return "Input smaller than the actual price.";
            else
                if (price == b.Price)
                return "Input is equal with the actual price.";
            else
            {
                UpdatePrice(b, price);
                return "Bid added.";
            }
        }
        static public Bid UpdatePrice(Bid b, int price)
        {
            b.Price = price;
            return b;
        }
    }
}
