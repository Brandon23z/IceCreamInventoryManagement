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

        public class Zone
        {
            public string citylabel;
            public string cityname;
            public string state;
            public Zone(string citylabel_, string cityname_, string state_)
            {
                citylabel = citylabel_;
                cityname = cityname_;
                state = state_;
            }
        }

        public class Route
        {
            public int routenumber;
            public string citylabel1, citylabel2, citylabel3, citylabel4, citylabel5, citylabel6, citylabel7, citylabel8, citylabel9, citylabel10;
        }

        public class Truck
        {
            public int trucknumber;
            public int routenumber;
        }

        public class TruckInventory
        {
            public int trucknumber;
            public int itemnumber;
            public int quantity;
            public double intitialprice;
            public double saleprice;
        }

        public class Inventory
        {
            public int itemnumber;
            public int quantity;
            public double intitialprice;
            public double saleprice;
            public string description;
        }

        public class Sale
        {
            public int itemnumber;
            public int quantity;
            public double intitialprice;
            public double saleprice;
            public TimeSpan saledate;
            public int trucknumber;
            public int routenumber;
            public int drivernumber;
        }

        public class Driver
        {
            public int trucknumber;
            public int drivernumber;
        }
    }
}
