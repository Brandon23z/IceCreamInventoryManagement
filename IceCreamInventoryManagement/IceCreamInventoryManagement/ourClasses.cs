using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace IceCreamInventoryManagement
{
    class ourClasses
    {

        public class DefaultOrder
        {
            public static DefaultItem[] defaults = new DefaultItem[5];
        }

        public class DefaultItem
        {
            public int productID { get; set; }
            public int amount { get; set; }

            public DefaultItem(int productID_, int amount_)
            {
                productID = productID_;
                amount = amount_;
            }
        }


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
            try {
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
                    addToLog("Message Sent: " + messageBody);
                }
            }
            catch
            {
                addToLog("Message Failed to Send!");
            }
        }

        public class LogVariable
        {
            public static List<string> log = new List<string>();

        }

        public static void addToLog(string x)
        {
            DateTime now = DateTime.Now;

            string dateTimeFormat = "M/d/yy - h:mm";
            string logString = "[" + now.ToString(dateTimeFormat) + "] " + x;
            try {
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    sw.WriteLine(logString);
                }
            }
            catch { }
            LogVariable.log.Add(logString + "\n");
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
            public string[] cityLabels = { };

            public Route(int routenumber_, string[] cityLabels_)
            {
                routenumber = routenumber_;
                cityLabels = cityLabels_;
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

            public Truck(int trucknumber_)
            {
                trucknumber = trucknumber_;
            }
        }

        public class TruckInventory
        {
            public int trucknumber;
            public Dictionary<int,TruckInventoryItem> items = new Dictionary<int, TruckInventoryItem>();
            public TruckInventory(int trucknumber_, Dictionary<int, TruckInventoryItem> items_)
            {
                trucknumber = trucknumber_;
                items = items_;
            }

            public TruckInventory(int trucknumber_)
            {
                trucknumber = trucknumber_;
            }

            public void addUpdateItem(TruckInventoryItem addItem)
            {
                if(items.ContainsKey(addItem.itemnumber))
                {
                    items[addItem.itemnumber].quantity += addItem.quantity;
                }
                else
                {
                    items.Add(addItem.itemnumber, addItem);
                }
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
            public double initialprice;
            public double saleprice;
            public string description;

            public InventoryItem(int itemnumber_, int quantity_, double initialprice_, double saleprice_, string description_)
            {
                itemnumber = itemnumber_;
                quantity = quantity_;
                initialprice = initialprice_;
                saleprice = saleprice_;
                description = description_;
            }
        }

        public class Sale
        {
            public int itemnumber;
            public int quantity;
            public double initialprice;
            public double saleprice;
            public DateTime saledate;
            public int trucknumber;
            public int routenumber;
            public int drivernumber;

            public Sale(int itemnumber_, int quantity_, double initialprice_, double saleprice_, DateTime saledate_, int trucknumber_, int routenumber_, int drivernumber_)
            {
                itemnumber = itemnumber_;
                quantity = quantity_;
                initialprice = initialprice_;
                saleprice = saleprice_;
                saledate = saledate_;
                trucknumber = trucknumber_;
                routenumber = routenumber_;
                drivernumber = drivernumber_;
            }
        }

        public class Driver
        {
            public int trucknumber;
            public int drivernumber;

            public Driver(int drivernumber_, int trucknumber_)
            {
                drivernumber = drivernumber_;
                trucknumber = trucknumber_;
            }

            public Driver(int drivernumber_)
            {
                drivernumber = drivernumber_;
            }
        }
    }
}
