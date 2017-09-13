using System;
using System.Collections.Generic;
using System.Text;

namespace ServerConsole
{

    public class Logic
    {
        static string[,] UserList = new string[3, 2] { { "user", "pass" }, { "one", "two" },
                                        { "admin", "admin" } };
        //static public string CheckPrice(Item i, int price)
        //{
        //    if (price < i.Current_Price)
        //        return "Input smaller than the actual price.";
        //    else
        //        if (price == i.Current_Price)
        //        return "Input is equal with the actual price.";
        //    else
        //    {
        //        UpdatePrice(i, price);
        //        return "Bid added.";
        //    }
        //}

        static public Bidding UpdatePrice(Item i, Client c)
        {
            Bidding b = new Bidding(i.Name, i.Price, c.Username, c.IP);
            return b;
        }
        static public bool CheckClient(Client c)
        {
            bool check= false;
            for (int i=0; i<3; i++)
            {
                if ((c.Username == UserList[i, 0]) && (c.Password == UserList[i, 1]))
                    check = true;
            }
            return check;
        }
    }
}
