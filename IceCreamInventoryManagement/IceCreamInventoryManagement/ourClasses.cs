using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace IceCreamInventoryManagement
{
    class ourClasses
    {
        public class TextSetting
        {
            public static bool truckInventoryReset;

            public static bool dailyInventoryCalculated;

            public static bool itemAddedToAutoOrder;

            public static bool autoOrderGenerated;
             
            public static string phoneNumber;
            public static string carrier;
        }

        public static void sendTextMessage(string messageBody)
        {
            var fromAddress = new MailAddress("winterwaterinteractive@gmail.com", "Winter Water Interactive");
            var toAddress = new MailAddress(TextSetting.phoneNumber + TextSetting.carrier, TextSetting.phoneNumber);
            const string fromPassword = "Cis375WWI";
            const string subject = "Ice Cream Management";
            string body = messageBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

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

            public Route(int routenumber_, string citylabel1_ = "", string citylabel2_ = "", 
                string citylabel3_ = "", string citylabel4_ = "", string citylabel5_ = "",
                string citylabel6_ = "", string citylabel7_ = "", string citylabel8_ = "",
                string citylabel9_ = "", string citylabel10_ = "")
            {
                routenumber = routenumber_;
                citylabel1 = citylabel1_;
                citylabel2 = citylabel2_;
                citylabel3 = citylabel3_;
                citylabel4 = citylabel4_;
                citylabel5 = citylabel5_;
                citylabel6 = citylabel6_;
                citylabel7 = citylabel7_;
                citylabel8 = citylabel8_;
                citylabel9 = citylabel9_;
                citylabel10 = citylabel10_;
            }
        }

        public class Truck
        {
            public int trucknumber;
            public int routenumber;

            public Truck(int trucknumber_, int routenumber_)
            {
                trucknumber = trucknumber_;
                routenumber = routenumber_;
            }
        }

        public class TruckInventory
        {
            public List<TruckInventoryItem> items = new List<TruckInventoryItem>();
            public TruckInventory(List<TruckInventoryItem> items_)
            {
                items = items_;
            }

            public TruckInventory()
            {

            }
            
            public void addItem(TruckInventoryItem item)
            {
                items.Add(item);
            }
        }

        public class TruckInventoryItem
        {
            public int itemnumber;
            public int quantity;
            public double initialprice;
            public double saleprice;
            
            public TruckInventoryItem(int itemnumber_, int quantity_, double initialprice_, double saleprice_)
            {
                itemnumber = itemnumber_;
                quantity = quantity_;
                initialprice = initialprice_;
                saleprice = saleprice_;
            }
        }

        public class Inventory
        {
            public List<InventoryItem> items = new List<InventoryItem>();

            public Inventory(List<InventoryItem> items_)
            {
                items = items_;
            }

            public Inventory()
            {

            }

            public void addItem(InventoryItem item)
            {
                items.Add(item);
            }
        }
        public class InventoryItem
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
