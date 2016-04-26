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
            public const string setDefaultQuantity = "10";

            public const string cityUploadFile = "0";
            public const string truckUploadFile = "0";
            public const string driverUploadFile = "0";
            public const string routeUploadFile = "0";
            public const string warehouseUploadFile = "0";
            public const string truckRouteDriverUploadFile = "0";
            public const string truckInventoryUploadFile = "0";

            public const string dayStatus = "0"; //0 = day not started, 1 = first file input day started, 2 = trucks sent out
            public const string currentDate = "2000-01-01";

            public const string sequenceCityUploadFile = "0";
            public const string sequenceTruckUploadFile = "0";
            public const string sequenceDriverUploadFile = "0";
            public const string sequenceRouteUploadFile = "0";
            public const string sequenceWarehouseUploadFile = "0";
            public const string sequenceTruckRouteDriverUploadFile = "0";
            public const string sequenceTruckInventoryUploadFile = "0";
            public const string sequenceTruckSalesUploadFile = "0";
            public const string sequenceCustomerRequest = "0";

            public const string defaultItem1ID = "0";
            public const string defaultItem1Quantity = "0";
            public const string defaultItem2ID = "0";
            public const string defaultItem2Quantity = "0";
            public const string defaultItem3ID = "0";
            public const string defaultItem3Quantity = "0";
            public const string defaultItem4ID = "0";
            public const string defaultItem4Quantity = "0";
            public const string defaultItem5ID = "0";
            public const string defaultItem5Quantity = "0";
        }

        private class settingsContainer
        {
            public bool notifTruckInventoryReset { get; set; }
            public bool notifDailyInventoryCalculated { get; set; }
            public bool notifItemAddedToAutoOrder { get; set; }
            public bool notifAutoOrderGenerated { get; set; }
            public string notifPhoneNumber { get; set; }
            public string notifCarrier { get; set; }
            public int setDefaultQuantity { get; set; }
            

            public bool cityUploadFile { get; set; }
            public bool truckUploadFile { get; set; }
            public bool driverUploadFile { get; set; }
            public bool routeUploadFile { get; set; }
            public bool warehouseUploadFile { get; set; }
            public bool truckRouteDriverUploadFile { get; set; }
            public bool truckInventoryUploadFile { get; set; }

            public int dayStatus { get; set; } //0 = day not started 1 = first file input day started 2 = trucks sent out
            public DateTime currentDate { get; set; }

            public int sequenceCityUploadFile { get; set; }
            public int sequenceTruckUploadFile { get; set; }
            public int sequenceDriverUploadFile { get; set; }
            public int sequenceRouteUploadFile { get; set; }
            public int sequenceWarehouseUploadFile { get; set; }
            public int sequenceTruckRouteDriverUploadFile { get; set; }
            public int sequenceTruckInventoryUploadFile { get; set; }
            public int sequenceTruckSalesUploadFile { get; set; }
            public int sequenceCustomerRequest { get; set; }

            public int defaultItem1ID { get; set; }
            public int defaultItem1Quantity { get; set; }
            public int defaultItem2ID { get; set; }
            public int defaultItem2Quantity { get; set; }
            public int defaultItem3ID { get; set; }
            public int defaultItem3Quantity { get; set; }
            public int defaultItem4ID { get; set; }
            public int defaultItem4Quantity { get; set; }
            public int defaultItem5ID { get; set; }
            public int defaultItem5Quantity { get; set; }
        }

        public static class keys
        {
            public const string notifTruckInventoryReset = "notifTruckInventoryReset";
            public const string notifDailyInventoryCalculated = "notifDailyInventoryCalculated";
            public const string notifItemAddedToAutoOrder = "notifItemAddedToAutoOrder";
            public const string notifAutoOrderGenerated = "notifAutoOrderGenerated";
            public const string notifPhoneNumber = "notifPhoneNumber";
            public const string notifCarrier = "notifCarrier";
            public const string setDefaultQuantity = "setDefaultQuantity";

            public const string cityUploadFile = "cityUploadFile";
            public const string truckUploadFile = "truckUploadFile";
            public const string driverUploadFile = "driverUploadFile";
            public const string routeUploadFile = "routeUploadFile";
            public const string warehouseUploadFile = "warehouseUploadFile";
            public const string truckRouteDriverUploadFile = "truckRouteDriverUploadFile";
            public const string truckInventoryUploadFile = "truckInventoryUploadFile";

            public const string dayStatus = "dayStatus"; //0 = day not started 1 = first file input day started 2 = trucks sent out
            public const string currentDate = "currentDate";

            public const string sequenceCityUploadFile = "sequenceCityUploadFile";
            public const string sequenceTruckUploadFile = "sequenceTruckUploadFile";
            public const string sequenceDriverUploadFile = "sequenceDriverUploadFile";
            public const string sequenceRouteUploadFile = "sequenceRouteUploadFile";
            public const string sequenceWarehouseUploadFile = "sequenceWarehouseUploadFile";
            public const string sequenceTruckRouteDriverUploadFile = "sequenceTruckRouteDriverUploadFile";
            public const string sequenceTruckInventoryUploadFile = "sequenceTruckInventoryUploadFile";
            public const string sequenceTruckSalesUploadFile = "sequenceTruckSalesUploadFile";
            public const string sequenceCustomerRequest = "sequenceCustomerRequest";

            public const string defaultItem1ID = "defaultItem1ID";
            public const string defaultItem1Quantity = "defaultItem1Quantity";
            public const string defaultItem2ID = "defaultItem2ID";
            public const string defaultItem2Quantity = "defaultItem2Quantity";
            public const string defaultItem3ID = "defaultItem3ID";
            public const string defaultItem3Quantity = "defaultItem3Quantity";
            public const string defaultItem4ID = "defaultItem4ID";
            public const string defaultItem4Quantity = "defaultItem4Quantity";
            public const string defaultItem5ID = "defaultItem5ID";
            public const string defaultItem5Quantity = "defaultItem5Quantity";
        }

        public static void saveDefaults(bool overwrite = false)
        {
            SQLMethods.insertSetting(keys.notifTruckInventoryReset, defaults.notifTruckInventoryReset, overwrite);
            SQLMethods.insertSetting(keys.notifDailyInventoryCalculated, defaults.notifDailyInventoryCalculated, overwrite);
            SQLMethods.insertSetting(keys.notifItemAddedToAutoOrder, defaults.notifItemAddedToAutoOrder, overwrite);
            SQLMethods.insertSetting(keys.notifAutoOrderGenerated, defaults.notifAutoOrderGenerated, overwrite);
            SQLMethods.insertSetting(keys.notifPhoneNumber, defaults.notifPhoneNumber, overwrite);
            SQLMethods.insertSetting(keys.notifCarrier, defaults.notifCarrier, overwrite);
            SQLMethods.insertSetting(keys.setDefaultQuantity, defaults.setDefaultQuantity, overwrite);

            SQLMethods.insertSetting(keys.cityUploadFile, defaults.cityUploadFile, overwrite);
            SQLMethods.insertSetting(keys.truckUploadFile, defaults.truckUploadFile, overwrite);
            SQLMethods.insertSetting(keys.driverUploadFile, defaults.driverUploadFile, overwrite);
            SQLMethods.insertSetting(keys.routeUploadFile, defaults.routeUploadFile, overwrite);
            SQLMethods.insertSetting(keys.warehouseUploadFile, defaults.warehouseUploadFile, overwrite);
            SQLMethods.insertSetting(keys.truckRouteDriverUploadFile, defaults.truckRouteDriverUploadFile, overwrite);
            SQLMethods.insertSetting(keys.truckInventoryUploadFile, defaults.truckInventoryUploadFile, overwrite);

            SQLMethods.insertSetting(keys.dayStatus, defaults.dayStatus, overwrite);
            SQLMethods.insertSetting(keys.currentDate, defaults.currentDate, overwrite);

            SQLMethods.insertSetting(keys.sequenceCityUploadFile, defaults.sequenceCityUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceTruckUploadFile, defaults.sequenceTruckUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceDriverUploadFile, defaults.sequenceDriverUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceRouteUploadFile, defaults.sequenceRouteUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceWarehouseUploadFile, defaults.sequenceWarehouseUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceTruckRouteDriverUploadFile, defaults.sequenceTruckRouteDriverUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceTruckInventoryUploadFile, defaults.sequenceTruckInventoryUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceTruckSalesUploadFile, defaults.sequenceTruckSalesUploadFile, overwrite);
            SQLMethods.insertSetting(keys.sequenceCustomerRequest, defaults.sequenceCustomerRequest, overwrite);

            SQLMethods.insertSetting(keys.defaultItem1ID, defaults.defaultItem1ID, overwrite);
            SQLMethods.insertSetting(keys.defaultItem1Quantity, defaults.defaultItem1Quantity, overwrite);
            SQLMethods.insertSetting(keys.defaultItem2ID, defaults.defaultItem2ID, overwrite);
            SQLMethods.insertSetting(keys.defaultItem2Quantity, defaults.defaultItem2Quantity, overwrite);
            SQLMethods.insertSetting(keys.defaultItem3ID, defaults.defaultItem3ID, overwrite);
            SQLMethods.insertSetting(keys.defaultItem3Quantity, defaults.defaultItem3Quantity, overwrite);
            SQLMethods.insertSetting(keys.defaultItem4ID, defaults.defaultItem4ID, overwrite);
            SQLMethods.insertSetting(keys.defaultItem4Quantity, defaults.defaultItem4Quantity, overwrite);
            SQLMethods.insertSetting(keys.defaultItem5ID, defaults.defaultItem5ID, overwrite);
            SQLMethods.insertSetting(keys.defaultItem5Quantity, defaults.defaultItem5Quantity, overwrite);
        }

        public class NotificationSettings
        {
            public bool notifTruckInventoryReset { get; set; }
            public bool notifDailyInventoryCalculated { get; set; }
            public bool notifItemAddedToAutoOrder { get; set; }
            public bool notifAutoOrderGenerated { get; set; }
            public string notifPhoneNumber { get; set; }
            public string notifCarrier { get; set; }
            public int setDefaultQuantity { get; set; }           
        }

        public class FileUploadSettings
        {
            public bool cityUploadFile { get; set; }
            public bool truckUploadFile { get; set; }
            public bool driverUploadFile { get; set; }
            public bool routeUploadFile { get; set; }
            public bool warehouseUploadFile { get; set; }
            public bool truckRouteDriverUploadFile { get; set; }
            public bool truckInventoryUploadFile { get; set; }
        }

        public class DaySettings
        {
            public int dayStatus { get; set; } //0 = day not started 1 = first file input day started 2 = trucks sent out
            public DateTime currentDate { get; set; }
        }

        public class SequenceNumberSettings
        {
            public int sequenceCityUploadFile { get; set; }
            public int sequenceTruckUploadFile { get; set; }
            public int sequenceDriverUploadFile { get; set; }
            public int sequenceRouteUploadFile { get; set; }
            public int sequenceWarehouseUploadFile { get; set; }
            public int sequenceTruckRouteDriverUploadFile { get; set; }
            public int sequenceTruckInventoryUploadFile { get; set; }
            public int sequenceTruckSalesUploadFile { get; set; }
            public int sequenceCustomerRequest { get; set; }
        }

        public class DefaultItemsSettings
        {
            public int defaultItem1ID { get; set; }
            public int defaultItem1Quantity { get; set; }
            public int defaultItem2ID { get; set; }
            public int defaultItem2Quantity { get; set; }
            public int defaultItem3ID { get; set; }
            public int defaultItem3Quantity { get; set; }
            public int defaultItem4ID { get; set; }
            public int defaultItem4Quantity { get; set; }
            public int defaultItem5ID { get; set; }
            public int defaultItem5Quantity { get; set; }
        }

        public static NotificationSettings getNotificationSettings()
        {
            NotificationSettings notifSettings = new NotificationSettings();
            notifSettings.notifTruckInventoryReset = stringtobool(SQLMethods.retrieveSetting(keys.notifTruckInventoryReset));
            notifSettings.notifDailyInventoryCalculated = stringtobool(SQLMethods.retrieveSetting(keys.notifDailyInventoryCalculated));
            notifSettings.notifItemAddedToAutoOrder = stringtobool(SQLMethods.retrieveSetting(keys.notifItemAddedToAutoOrder));
            notifSettings.notifAutoOrderGenerated = stringtobool(SQLMethods.retrieveSetting(keys.notifAutoOrderGenerated));
            notifSettings.notifPhoneNumber = SQLMethods.retrieveSetting(keys.notifPhoneNumber);
            notifSettings.notifCarrier = SQLMethods.retrieveSetting(keys.notifCarrier);
            notifSettings.setDefaultQuantity = Convert.ToInt32(SQLMethods.retrieveSetting(keys.setDefaultQuantity));
           
            return notifSettings;
        }

        public static void saveNotificationSettings(NotificationSettings settings)
        {
            SQLMethods.insertSetting(keys.notifTruckInventoryReset, booltoint(settings.notifTruckInventoryReset).ToString(), true);
            SQLMethods.insertSetting(keys.notifDailyInventoryCalculated, booltoint(settings.notifDailyInventoryCalculated).ToString(), true);
            SQLMethods.insertSetting(keys.notifItemAddedToAutoOrder, booltoint(settings.notifItemAddedToAutoOrder).ToString(), true);
            SQLMethods.insertSetting(keys.notifAutoOrderGenerated, booltoint(settings.notifAutoOrderGenerated).ToString(), true);
            SQLMethods.insertSetting(keys.notifPhoneNumber, settings.notifPhoneNumber, true);
            SQLMethods.insertSetting(keys.notifCarrier, settings.notifCarrier, true);
            SQLMethods.insertSetting(keys.setDefaultQuantity, settings.setDefaultQuantity.ToString(), true);
            
        }

        public static FileUploadSettings getFileUploadSettings()
        {
            FileUploadSettings fuploadSettings = new FileUploadSettings();
            fuploadSettings.cityUploadFile = stringtobool(SQLMethods.retrieveSetting(keys.cityUploadFile));
            fuploadSettings.truckUploadFile = stringtobool(SQLMethods.retrieveSetting(keys.truckUploadFile));
            fuploadSettings.driverUploadFile = stringtobool(SQLMethods.retrieveSetting(keys.driverUploadFile));
            fuploadSettings.routeUploadFile = stringtobool(SQLMethods.retrieveSetting(keys.routeUploadFile));
            fuploadSettings.warehouseUploadFile = stringtobool(SQLMethods.retrieveSetting(keys.warehouseUploadFile));
            fuploadSettings.truckRouteDriverUploadFile = stringtobool(SQLMethods.retrieveSetting(keys.truckRouteDriverUploadFile));
            fuploadSettings.truckInventoryUploadFile = stringtobool(SQLMethods.retrieveSetting(keys.truckInventoryUploadFile));
            return fuploadSettings;
        }

        public static void saveFileUploadSettings(FileUploadSettings settings)
        {
            SQLMethods.insertSetting(keys.cityUploadFile, booltoint(settings.cityUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.truckUploadFile, booltoint(settings.truckUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.driverUploadFile, booltoint(settings.driverUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.routeUploadFile, booltoint(settings.routeUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.warehouseUploadFile, booltoint(settings.warehouseUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.truckRouteDriverUploadFile, booltoint(settings.truckRouteDriverUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.truckInventoryUploadFile, booltoint(settings.truckInventoryUploadFile).ToString(), true);
        }

        public static DaySettings getDaySettings()
        {
            DaySettings daySettings = new DaySettings();
            daySettings.dayStatus = Convert.ToInt32(SQLMethods.retrieveSetting(keys.dayStatus));
            daySettings.currentDate = Convert.ToDateTime(SQLMethods.retrieveSetting(keys.currentDate));
            return daySettings;
        }

        public static void saveDaySettings(DaySettings settings)
        {

            SQLMethods.insertSetting(keys.dayStatus, Convert.ToInt32(settings.dayStatus).ToString(), true);
            SQLMethods.insertSetting(keys.currentDate, settings.currentDate.ToString(), true);
            
        }

        public static SequenceNumberSettings getSequenceNumberSettings()
        {
            SequenceNumberSettings sequenceNSettings = new SequenceNumberSettings();
            sequenceNSettings.sequenceCityUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceCityUploadFile));
            sequenceNSettings.sequenceTruckUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceTruckUploadFile));
            sequenceNSettings.sequenceDriverUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceDriverUploadFile));
            sequenceNSettings.sequenceRouteUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceRouteUploadFile));
            sequenceNSettings.sequenceWarehouseUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceWarehouseUploadFile));
            sequenceNSettings.sequenceTruckRouteDriverUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceTruckRouteDriverUploadFile));
            sequenceNSettings.sequenceTruckInventoryUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceTruckInventoryUploadFile));
            sequenceNSettings.sequenceTruckSalesUploadFile = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceTruckSalesUploadFile));
            sequenceNSettings.sequenceCustomerRequest = Convert.ToInt32(SQLMethods.retrieveSetting(keys.sequenceCustomerRequest));
            return sequenceNSettings;
        }

        public static void saveSequenceNumberSettings(SequenceNumberSettings settings)
        {

            SQLMethods.insertSetting(keys.sequenceCityUploadFile, Convert.ToInt32(settings.sequenceCityUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceTruckUploadFile, Convert.ToInt32(settings.sequenceTruckUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceDriverUploadFile, Convert.ToInt32(settings.sequenceDriverUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceRouteUploadFile, Convert.ToInt32(settings.sequenceRouteUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceWarehouseUploadFile, Convert.ToInt32(settings.sequenceWarehouseUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceTruckRouteDriverUploadFile, Convert.ToInt32(settings.sequenceTruckRouteDriverUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceTruckInventoryUploadFile, Convert.ToInt32(settings.sequenceTruckInventoryUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceTruckSalesUploadFile, Convert.ToInt32(settings.sequenceTruckSalesUploadFile).ToString(), true);
            SQLMethods.insertSetting(keys.sequenceCustomerRequest, Convert.ToInt32(settings.sequenceCustomerRequest).ToString(), true);
            
        }

        public static DefaultItemsSettings getDefaultItemsSettings()
        {
            DefaultItemsSettings defItemsSettings = new DefaultItemsSettings();
            defItemsSettings.defaultItem1ID = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem1ID));
            defItemsSettings.defaultItem1Quantity = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem1Quantity));
            defItemsSettings.defaultItem2ID = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem2ID));
            defItemsSettings.defaultItem2Quantity = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem2Quantity));
            defItemsSettings.defaultItem3ID = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem3ID));
            defItemsSettings.defaultItem3Quantity = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem3Quantity));
            defItemsSettings.defaultItem4ID = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem4ID));
            defItemsSettings.defaultItem4Quantity = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem4Quantity));
            defItemsSettings.defaultItem5ID = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem5ID));
            defItemsSettings.defaultItem5Quantity = Convert.ToInt32(SQLMethods.retrieveSetting(keys.defaultItem5Quantity));
            return defItemsSettings;
        }

        public static void saveDefaultItemsSettings(DefaultItemsSettings settings)
        {
            SQLMethods.insertSetting(keys.defaultItem1ID, Convert.ToInt32(settings.defaultItem1ID).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem1Quantity, Convert.ToInt32(settings.defaultItem1Quantity).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem2ID, Convert.ToInt32(settings.defaultItem2ID).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem2Quantity, Convert.ToInt32(settings.defaultItem2Quantity).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem3ID, Convert.ToInt32(settings.defaultItem3ID).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem3Quantity, Convert.ToInt32(settings.defaultItem3Quantity).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem4ID, Convert.ToInt32(settings.defaultItem4ID).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem4Quantity, Convert.ToInt32(settings.defaultItem4Quantity).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem5ID, Convert.ToInt32(settings.defaultItem5ID).ToString(), true);
            SQLMethods.insertSetting(keys.defaultItem5Quantity, Convert.ToInt32(settings.defaultItem5Quantity).ToString(), true);
        }

        public static bool stringtobool(string s)
        {
            return inttobool(Convert.ToInt32(s));
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
