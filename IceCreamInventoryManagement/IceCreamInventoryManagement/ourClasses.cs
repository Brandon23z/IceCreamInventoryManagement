using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamInventoryManagement
{
    class ourClasses
    {


        public class LogVariable
        {
            public static List<string> log = new List<string>();

        }

        public static void addToLog(string x)
        {
            DateTime now = DateTime.Now;

            string dateTimeFormat = "M/d/yy - h:mm ";

            LogVariable.log.Add("(" + now.ToString(dateTimeFormat) + ") "+ x + "\n");
        }

        class City
        {
            public string citylabel;
            public string cityname;
            public string state;
        }

        class Route
        {
            public int routenumber;
            public string citylabel1, citylabel2, citylabel3, citylabel4, citylabel5, citylabel6, citylabel7, citylabel8, citylabel9, citylabel10;
        }

        class Truck
        {
            public int trucknumber;
            public int routenumber;
        }

        class TruckInventory
        {
            public int trucknumber;
            public int itemnumber;
            public int quantity;
            public double intitialprice;
            public double saleprice;
        }

        class Inventory
        {
            public int itemnumber;
            public int quantity;
            public double intitialprice;
            public double saleprice;
            public string description;
        }

        class Sales
        {
            public int itemnumber;
            public int quantity;
            public double intitialprice;
            public double saleprice;
            public TimeSpan saledate;
            public int trucknumber;
            public int routenumber;
        }
    }
}
