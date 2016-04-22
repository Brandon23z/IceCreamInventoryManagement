using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamInventoryManagement
{
    class Settings
    {
        private static class defaults
        {
            public const string notifTruckInventoryReset = "0";
            public const string notifDailyInventoryCalculated = "0";
            public const string notifItemAddedToAutoOrder = "0";
            public const string notifAutoOrderGenerated = "0";
            public const string notifPhoneNumber = "";
            public const string notifCarrier = "@txt.att.net";

            public const string cityUploadFile = "0";
            public const string truckUploadFile = "0";
            public const string driverUploadFile = "0";
            public const string routeUploadFile = "0";
            public const string truckRouteDriverUploadFile = "0";
            public const string warehouseUploadFile = "0";
            public const string truckInventoryUploadFile = "0";

            public const string dayStatus = "0";
            public const string currentDate = "0";

            //public const string 
        }

        public class settingsContainer
        {
            public bool currencyEnabled { get; set; }
        }

        public static class keys
        {
            public const string currencyEnabled = "currency_enabled";
        }

        public static void saveDefaults(bool overwrite = false)
        {
            //SQL.insertSetting(keys.currencyEnabled, defaults.currencyEnabled, overwrite);
        }
        public static settingsContainer retrieveSettings()
        {
            settingsContainer s = new settingsContainer();

            return s;
        }
        public static int booltoint(bool b)
        {
            return b ? 1 : 0;
        }

        public static bool inttobool(int i)
        {
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
