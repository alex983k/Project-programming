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
        public int Price;

        public Item(string name, int sp)
        {
            Name = name;
            Price = sp;
        }
        static public List<Item> Example()
        {
            Item i1 = new Item("apple", 10);
            Item i2 = new Item("orange", 1000);
            Item i3 = new Item("melon", 50);
            List<Item> list = new List<Item>();
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            return list;
        }
    }
}
