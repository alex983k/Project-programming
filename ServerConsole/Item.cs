using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    public class Item
    {
        public string Name;
        public int Starting_Price;
        public int Current_Price;
        public string Bidder_Name;

        public Item(string name, int sp)
        {
            Name = name;
            Starting_Price = sp;
            Current_Price = sp;
            Bidder_Name = "Auction House";
        }
    }
}
