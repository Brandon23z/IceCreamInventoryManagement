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
