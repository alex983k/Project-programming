using System;
using System.Collections.Generic;
using System.Text;

namespace ServerConsole
{
    public class Logic
    {
        static public string CheckPrice(Item i, int price)
        {
            if (price < i.Current_Price)
                return "Input smaller than the actual price.";
            else
                if (price == i.Current_Price)
                return "Input is equal with the actual price.";
            else
            {
                UpdatePrice(i, price);
                return "Bid added.";
            }
        }
        static public Item UpdatePrice(Item i, int price)
        {
            i.Current_Price = price;
            return i;
        }
    }
}
