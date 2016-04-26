using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IceCreamInventoryManagement.RegexMethods;
using static IceCreamInventoryManagement.RegexStr;
using static IceCreamInventoryManagement.ourClasses;
using static IceCreamInventoryManagement.SQLMethods;

namespace IceCreamInventoryManagement
{
    class InputFileMethods
    {
        /// <summary>
        /// Asks user for a file then reads and returns the contents
        /// </summary>
        /// <param name="content">Contains File Contents</param>
        /// <returns>Returns true if file was selected and read, false otherwise</returns>
        public static bool getFileContents(out string[] content)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                content = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                return true;
            }
            else
            {
                content = null;
                return false;
            }
        }


        public static bool checkHeader(string[] contents, out checkHeaderResults results)
        {
            if (contents.Length > 0)
            {
                RegexMethods.RegexClass r = checkRegex(contents[0], headerEx);
                if (r.valid)
                {
                    checkHeaderResults temp = new checkHeaderResults();
                    temp.sequenceNumber = Convert.ToInt32(r.groupValues[2]);
                    string dateString = r.groupValues[3];
                    temp.date = Convert.ToDateTime(dateString);
                    results = temp;
                    return true;
                }
                else
                {
                    results = null;
                    return false;
                }
            }
            else
            {
                results = null;
                return false;
            }
        }

        public class checkHeaderResults
        {
            public int sequenceNumber { get; set; }
            public DateTime date { get; set; }
        }

        public static bool checkTrailer(string[] contents, out int numOfRows)
        {
            if (contents.Length > 0)
            {
                RegexMethods.RegexClass r = checkRegex(contents[contents.Length - 1], trailerEx);

                if (r.valid)
                {
                    string numOfRowsString = r.groupValues[2];
                    numOfRows = Int32.Parse(numOfRowsString);
                    return true;
                }
                else
                {
                    numOfRows = 0;
                    return false;
                }
            }
            else
            {
                numOfRows = 0;
                return false;
            }
        }

        public static bool checkFileGeneric(out string[] uploadFile, string fileName, int currentSequenceNum,
            string sequenceKey, bool trailer = true)
        {
            if (!getFileContents(out uploadFile))
            {
                //file was not selected/read
                return false;
            }

            //Check and parse header
            checkHeaderResults header;
            if (!checkHeader(uploadFile, out header))
            {
                //header is invalid
                addToLog(fileName + " Invalid: Header is invalid!");
                return false;
            }

            //if first file of day set current date and daystatus
            if (!checkFirstFileOfDay(header))
            {
                addToLog(fileName + " Invalid: Date must be greater than previous day's file!");
                return false;
            }

            //check correct date here
            Settings.DaySettings daySettings = Settings.getDaySettings();
            if (header.date != daySettings.currentDate)
            {
                addToLog(fileName + " Invalid: Today's date must be the same across all files!");
                return false;
            }

            //Check for correct sequence number here
            if (((header.sequenceNumber == (currentSequenceNum + 1)) && currentSequenceNum != 9999) || (header.sequenceNumber == 1 && currentSequenceNum == 9999))
            {
                //sequence number is 1 greater than old sequence number
                //update new sequence number
                SQLMethods.insertSetting(sequenceKey, header.sequenceNumber.ToString(), true);
            }
            else
            {
                if (currentSequenceNum != 9999)
                {
                    addToLog(fileName + " Invalid: Sequence number is not 1 greater than previous, should be " +
                             (currentSequenceNum + 1).ToString());
                }
                else
                {
                    addToLog(fileName + " Invalid: Sequence number is not 1 greater than previous, should be 1");
                }
                return false;
            }

            //check and parse trailer
            int numOfRows;
            if (trailer)
            {
                if (!checkTrailer(uploadFile, out numOfRows))
                {
                    //trailer is invalid
                    addToLog(fileName + ": Trailer is invalid!");
                }

                if (numOfRows != uploadFile.Length - 2)
                {
                    addToLog(fileName + ": Trailer # " + numOfRows + " does not match Actual # of Rows " +
                             (uploadFile.Length - 2));
                }
            }

            //file was selected and read
            addToLog(fileName + ": Read");

            return true;
        }

        public static bool checkFirstFileOfDay(checkHeaderResults header)
        {
            Settings.DaySettings daySettings = Settings.getDaySettings();
            //if first file of the day
            if (daySettings.dayStatus == 0)
            {
                //if date is ahead of last date
                if (header.date > daySettings.currentDate)
                {
                    SQLMethods.insertSetting(Settings.keys.currentDate, header.date.ToString(), true);
                    SQLMethods.insertSetting(Settings.keys.dayStatus, "1", true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public static void processCityUploadFileBody(string[] contents)
        {
            for (int i = 1; i < contents.Length - 1; i++)
            {
                RegexMethods.RegexClass r = checkRegex(contents[i], cityEx);
                if (r.valid)
                {
                    string citylabel = r.groupValues[1];
                    string cityname = r.groupValues[2];
                    string state = r.groupValues[3];
                    if (!doesZoneExist(citylabel))
                    {
                        bool test = addZone(new Zone(citylabel, cityname, state));
                    }
                    else
                    {
                        addToLog("Failed to add City " + citylabel + " it already exists!");
                    }
                }
                else
                {
                    addToLog("City Upload File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }

        public static void processRouteUploadFileBody(string[] contents)
        {
            for (int i = 1; i < contents.Length - 1; i++)
            {
                RegexMethods.RegexClass r = checkRegex(contents[i], routeCitys);
                if (r.valid)
                {
                    if (r.groupValues[1] == "A")
                    {
                        int routenumber = Int32.Parse(r.groupValues[2]);

                        if (doesRouteExist(routenumber))
                        {
                            addToLog("Route # " + routenumber + " was not added because it already exists");
                        }
                        else
                        {
                            bool zoneIsValid = true;
                            string[] citylabels = new string[10];
                            citylabels[0] = r.groupValues[3];
                            if (!(doesZoneExist(citylabels[0])) || (zoneInUse(citylabels[0])))
                                zoneIsValid = false;
                            if (zoneIsValid)
                            {
                                int k = 1;
                                int temp = 4;
                                for (k = 1; k < 10; k++)
                                {
                                    if (r.groupValues[temp] == "")
                                        break;
                                    else
                                        citylabels[k] = r.groupValues[temp];
                                    if (!(doesZoneExist(citylabels[k])) || (zoneInUse(citylabels[k])))
                                    {
                                        zoneIsValid = false;
                                        break;
                                    }
                                    temp++;
                                }

                                if (zoneIsValid)
                                {
                                    bool test = addRoute(new Route(routenumber, citylabels));
                                    if (!test)
                                        addToLog("Route # " + routenumber + " failed to add.");
                                }
                                else
                                    addToLog("Route # " + routenumber + " was not added because either \"" + citylabels[k] + "\" does not exist as a zone, or it is already in use by another route.");

                            }
                            else
                                addToLog("Route # " + routenumber + " was not added because either \"" + citylabels[0] + "\" does not exist as a zone, or it is already in use by another route.");

                        }

                    }
                    else if (r.groupValues[1] == "C")
                    {
                        int routenumber = Int32.Parse(r.groupValues[2]);

                        if (doesRouteExist(routenumber))
                        {
                            bool zoneIsValid = true;
                            string[] citylabels = new string[10];
                            citylabels[0] = r.groupValues[3];
                            if (!(doesZoneExist(citylabels[0])) || (zoneInUse(citylabels[0])))
                                zoneIsValid = false;
                            if (zoneIsValid)
                            {
                                int k = 1;
                                int temp = 4;
                                for (k = 1; k < 10; k++)
                                {
                                    if (r.groupValues[temp] == "")
                                        break;
                                    else
                                        citylabels[k] = r.groupValues[temp];
                                    if (!(doesZoneExist(citylabels[k])) || (zoneInUse(citylabels[k])))
                                    {
                                        zoneIsValid = false;
                                        break;
                                    }
                                    temp++;
                                }

                                if (zoneIsValid)
                                {
                                    bool test = updateRoute(new Route(routenumber, citylabels));
                                    if (!test)
                                        addToLog("Route # " + routenumber + " failed to update.");
                                }
                                else
                                    addToLog("Route # " + routenumber + " was not changed because either \"" + citylabels[k] + "\" does not exist as a zone, or it is already in use by another route.");

                            }
                            else
                            {
                                addToLog("Route # " + routenumber + " was not changed because either \"" + citylabels[0] + "\" does not exist as a zone, or it is already in use by another route.");
                            }
                            
                        }
                        else
                        {
                            addToLog("Route # " + routenumber + " was not changed because it does not exist");
                        }
                        
                    }
                    else if (r.groupValues[13] == "D")
                    {
                        int routenumber = Int32.Parse(r.groupValues[14]);
                        if(doesRouteExist(routenumber))
                        {
                            bool test = deleteRoute(routenumber);
                        }       
                        else
                            addToLog("Route # " + routenumber + " was not deleted because it does not exist");
                    }
                }
                else
                {
                    addToLog("Route Upload File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }

        public static bool doesZoneExist(string citylabel)
        {
            bool alreadyExists = false;
            List<Zone> myZones = new List<Zone>();

            myZones = getAllZones();

            foreach (Zone zone in myZones)
            {
                if (zone.citylabel == citylabel)
                {
                    alreadyExists = true;
                    break;
                }
            }
            return alreadyExists;
        }

        public static bool doesRouteExist(int routenumber)
        {
            bool alreadyExists = false;
            List<Route> myRoutes = new List<Route>();

            myRoutes = getAllRoutes();

            foreach (Route route in myRoutes)
            {
                if (route.routenumber == routenumber)
                {
                    alreadyExists = true;
                    break;
                }

            }
            return alreadyExists;
        }

        public static bool zoneInUse(string citylabel)
        {
            bool alreadyInUse= false;
            List<Route> myRoutes = new List<Route>();

            myRoutes = getAllRoutes();

            foreach (Route route in myRoutes)
            {
                for (int i = 0; i < route.cityLabels.Count(); i++)
                {
                    if (route.cityLabels[i] == citylabel)
                    {
                        alreadyInUse = true;
                        break;
                    }
                }
                if (alreadyInUse)
                    break;
            }
            return alreadyInUse;
        }
    

        public static void processTruckRouteDriverUploadFileBody(string[] content)
        {
            for (int i = 1; i < content.Length - 1; i++)
            {
                RegexMethods.RegexClass r = checkRegex(content[i], truckRouteEx);
                if (r.valid)
                {
                    int trucknumber = Int32.Parse(r.groupValues[1]);
                    int routenumber = Int32.Parse(r.groupValues[2]);
                    int drivernumber = Int32.Parse(r.groupValues[3]);

                    if (doesTruckExist(trucknumber))
                    {
                        if (doesDriverExist(drivernumber))
                        {
                            if (doesRouteExist(routenumber))
                            {
                                if (driverAssignedToTruck(drivernumber) || truckAssignedToDriver(trucknumber) || routeAssignedToTruck(routenumber))
                                {
                                    addToLog("Unable to assign Driver # " + drivernumber + " Truck # " + trucknumber
                                             + " and Route # " + routenumber + " because one or more is already assigned.");
                                }
                                else
                                {
                                    assignDriverToTruck(drivernumber, trucknumber);
                                    assignTruckToRoute(trucknumber, routenumber);
                                }
                            }
                            else
                            {
                                addToLog("Unable to assign Route # " + routenumber + " to Truck # " + trucknumber
                                            + " because Route # " + routenumber + " does not exist.");
                            }
                        }
                        else
                        {
                            addToLog("Unable to assign Driver # " + drivernumber + " to Truck # " + trucknumber
                            + " because Driver # " + drivernumber + " does not exist.");
                        }
                    }
                    else
                    {
                        addToLog("Unable to assign Route # " + routenumber + ", Driver # " + drivernumber + ", and Truck # " + trucknumber 
                            + " to each other because Truck # " + trucknumber + " does not exist.");
                    }
                    
                    
                }
                else
                {
                    addToLog("Truck Inventory Upload File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }

        public static bool doesDriverExist(int drivernumber)
        {
            bool alreadyExists = false;
            List<Driver> myDrivers = new List<Driver>();

            myDrivers = getAllDrivers();

            foreach (Driver driver in myDrivers)
            {
                if (driver.drivernumber == drivernumber)
                {
                    alreadyExists = true;
                    break;
                }
            }
            return alreadyExists;
        }

        public static bool doesTruckExist(int trucknumber)
        {
            List<Truck> myTrucks = new List<Truck>();

            myTrucks = getAllTrucks();

            foreach (Truck truck in myTrucks)
            {
                if (truck.trucknumber == trucknumber)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool doesItemExist(int itemnumber)
        {
            bool alreadyExists = false;
            List<InventoryItem> myItems = new List<InventoryItem>();

            myItems = getInventory();

            foreach (InventoryItem item in myItems)
            {
                if (item.itemnumber == itemnumber)
                {
                    alreadyExists = true;
                    break;
                }
            }
            return alreadyExists;
        }

        public static bool truckAssignedToDriver(int trucknumber)
        {
            bool alreadyInUse = false;
            List<Driver> myDrivers = new List<Driver>();

            myDrivers = getAllDrivers();

            foreach (Driver driver in myDrivers)
            {
                if (driver.trucknumber == trucknumber)
                {
                    alreadyInUse = true;
                    break;
                }
            }
            return alreadyInUse;
        }
        
        public static bool driverAssignedToTruck(int drivernumber)
        {
            bool alreadyInUse = true;
            Driver myDriver = getDriver(drivernumber);

            if (myDriver.trucknumber == 0)
                alreadyInUse = false;

            return alreadyInUse;
        }

        public static bool routeAssignedToTruck(int routenumber)
        {
            bool alreadyInUse = false;
            List<Truck> myTrucks = new List<Truck>();

            myTrucks = getAllTrucks();

            foreach (Truck truck in myTrucks)
            {
                if (truck.routenumber == routenumber)
                {
                    alreadyInUse = true;
                    break;
                }
            }
            return alreadyInUse;
        }

        public static bool truckAssignedToRoute(int trucknumber)
        {
            bool alreadyInUse = true;
            Truck myTruck = getTruck(trucknumber);

            if (myTruck.routenumber == 0)
                alreadyInUse = false;

            return alreadyInUse;
        }

        public static void processTruckUploadBody(string[] content)
        {
            clearTrucks();
            for (int i = 1; i < content.Length - 1; i++)
            {
                RegexMethods.RegexClass r = checkRegex(content[i], trucksEx);
                if (r.valid)
                {
                    int trucknumber = Int32.Parse(r.groupValues[1]);
                    if (!doesTruckExist(trucknumber))
                    {
                        bool test = addTruck(new Truck(trucknumber));
                    }
                    else
                    {
                        addToLog("Truck " + trucknumber + " already exists!");
                    }
                }
                else
                {
                    addToLog("Truck Upload File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }

        public static void processDriverUploadBody(string[] content)
        {
            clearDrivers();
            for (int i = 1; i < content.Length - 1; i++)
            {
                RegexMethods.RegexClass r = checkRegex(content[i], trucksEx);
                if (r.valid)
                {
                    int drivernumber = Int32.Parse(r.groupValues[1]);
                    if (!doesDriverExist(drivernumber))
                    {
                        bool test = addDriver(new Driver(drivernumber));
                    }
                    else
                    {
                        addToLog("Driver " + drivernumber + " already exists!");
                    }
                    
                }
                else
                {
                    addToLog("Driver Upload File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }


        public static void processInventoryUpdateBody(string[] content)
        {
            setInventoryQuantityToZero();

            for (int i = 1; i < content.Length - 1; i++)
            {
                RegexMethods.RegexClass r = checkRegex(content[i], inventoryItemEx);
                if (r.valid)
                {
                    int itemnumber = Int32.Parse(r.groupValues[1]);
                    int quantity = Int32.Parse(r.groupValues[2]);
                    double initialprice = Convert.ToDouble(r.groupValues[3] + "." + r.groupValues[4]);
                    double saleprice = Convert.ToDouble(r.groupValues[5] + "." + r.groupValues[6]);
                    string description = r.groupValues[7];
                    bool test = addInventoryItem(new InventoryItem(itemnumber, quantity, initialprice, saleprice, description));
                }
                else
                {
                    addToLog("Inventory Upload File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }

        public static void moveDefaultToTruck(int itemID, int quantity, int trucknumber)
        {
            int change = quantity * (-1);
            int myTest = moveItem(itemID, trucknumber, change);
        }

        public static void processTruckInventoryUploadFileBody(string[] contents)
        {
            //add default inventory to each truck
            List<Truck> myTrucks = new List<Truck>();

            myTrucks = getAllTrucks();
            Settings.DefaultItemsSettings mySettings = Settings.getDefaultItemsSettings();
            for (int i = 0; i < myTrucks.Count(); i++)
            {
                
                moveDefaultToTruck(mySettings.defaultItem1ID, mySettings.defaultItem1Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem2ID, mySettings.defaultItem2Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem3ID, mySettings.defaultItem3Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem4ID, mySettings.defaultItem4Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem5ID, mySettings.defaultItem5Quantity, myTrucks[i].trucknumber);
            }
            addToLog("Truck Inventory Upload File: Loading default items to trucks");

            int trucknumber = 0;
            bool inTruck = false;
            int itemsAdded = 0;
            bool truckValid = true;
            for (int i = 1; i < contents.Length - 1; i++)
            {
                if (checkRegex(contents[i], truckHeaderEx).valid && inTruck == false)
                {
                    RegexMethods.RegexClass r = checkRegex(contents[i], truckHeaderEx);
                    trucknumber = Int32.Parse(r.groupValues[2]);
                    truckValid = doesTruckExist(trucknumber);
                    inTruck = true;
                    if (!truckValid)
                    {
                        addToLog("Unable to load Truck # " + trucknumber + " because it does not exist.");
                    }
                    else
                    {
                        addToLog("Filling truck " + trucknumber.ToString());
                    }
                }
                else if (checkRegex(contents[i], truckItemEx).valid && inTruck == true && truckValid)
                {
                    RegexMethods.RegexClass r = checkRegex(contents[i], truckItemEx);
                    int itemnumber = Int32.Parse(r.groupValues[1]);
                    int amount = Int32.Parse(r.groupValues[2]);
                    itemsAdded++;
                    addToLog("Adding " + amount.ToString() + " of item " + itemnumber + " to truck " +
                                      trucknumber);
                    //update amount
                    
                    amount = -amount;
                    if(doesItemExist(itemnumber))
                    {
                        if (amount > 0)
                        {
                            Dictionary<int, TruckInventoryItem> tinv = getTruckInventory(trucknumber);
                            if (!(tinv[itemnumber].quantity >= amount))
                            {
                                addToLog("Unable to move " + amount + " of item " + itemnumber + " from truck " + trucknumber + " to inventory, not enough on the truck!");
                                return;
                            }

                        }
                        int myTest = moveItem(itemnumber, trucknumber, amount);
                    }
                    else
                    {
                        addToLog("Unable to add/subtract Item # " + itemnumber + " to/from Truck # " + trucknumber 
                            + " because Item #" + itemnumber + " does not exist.");
                    }
                }
                else if (checkRegex(contents[i], truckItemsTrailerEx).valid && inTruck == true && truckValid)
                {
                    RegexMethods.RegexClass r = checkRegex(contents[i], truckItemsTrailerEx);
                    int numberOfItems = Int32.Parse(r.groupValues[2]);
                    if (numberOfItems != itemsAdded)
                    {
                        addToLog("Number of items in trailer does not match the number of items added");
                    }

                    inTruck = false;
                    itemsAdded = 0;
                    addToLog("Done filling truck " + trucknumber);
                }
                else if(truckValid)
                {
                    //line is invalid in format
                    addToLog("Truck Inventory Upload File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }

        public static void processCustomerRequestBody(string[] content)
        {
            for (int i = 1; i < content.Length - 1; i++)
            {
                RegexMethods.RegexClass r = checkRegex(content[i], "replace me!");//requestedInventoryItemEx
                // need to create new regex string for this with itemnumber = r.groupValues[1], description = r.groupValues[2]
                if (r.valid)
                {
                    int itemnumber = Int32.Parse(r.groupValues[1]);
                    //int quantityRequested = Int32.Parse(r.groupValues[2]);
                    string description = r.groupValues[2];

                    if (doesItemExist(itemnumber))
                        addToLog("Cannot add Item # " + itemnumber + " as a newly requested item, since it already exists");
                    else
                    {
                        bool test = addInventoryItem(new InventoryItem(itemnumber, 0, 0, 0, description));
                    
                    }

                    // for any new requested item, only the id and the description will be stored in the Inventory table. The other attrubites will be set to 0.
                    // in the settings menu, the user will be able to set the default amount for new products. The Auto Order function will then be able to add the new item to 
                    // the Auto Order list.

                }
                else
                {
                    addToLog("Customer Request File: Line " + (i + 1).ToString() + " is invalid!");
                }
            }
        }

        public static void processSalesFileBody(string[] contents)
        {
            int trucknumber = 0;
            bool inTruck = false;
            int itemsChecked = 0;
            bool truckValid = true;
            for (int i = 1; i < contents.Length - 1; i++)
            {
                if (checkRegex(contents[i], truckHeaderEx).valid && inTruck == false)
                {
                    RegexMethods.RegexClass r = checkRegex(contents[i], truckHeaderEx);
                    trucknumber = Int32.Parse(r.groupValues[2]);
                    truckValid = doesTruckExist(trucknumber);
                    inTruck = true;
                    Console.WriteLine("Gettings sales for truck " + trucknumber.ToString());
                }
                else if (checkRegex(contents[i], truckSalesEx).valid && inTruck == true && truckValid)
                {
                    RegexMethods.RegexClass r = checkRegex(contents[i], truckSalesEx);
                    int itemnumber = Int32.Parse(r.groupValues[1]);
                    int finalquantity = Int32.Parse(r.groupValues[2]);
                    Dictionary<int, TruckInventoryItem> truckInv = getTruckInventory(trucknumber);
                    if (truckInv.ContainsKey(itemnumber))
                    {
                        if (truckInv[itemnumber].quantity < finalquantity)
                        {
                            Console.WriteLine("Truck " + trucknumber + " has " + finalquantity + " of item " +
                                              itemnumber +
                                              " and only left with " + truckInv[itemnumber].quantity);
                            addToLog("Truck " + trucknumber + " has " + finalquantity + " of item " +
                                              itemnumber +
                                              " and only left with " + truckInv[itemnumber].quantity);

                        }
                        else
                        {
                            int quantitySold = -1 * (finalquantity - truckInv[itemnumber].quantity);
                            Settings.DaySettings daySettings = Settings.getDaySettings();
                            TruckRouteDriver temp = getRouteDriverFromTruck(trucknumber);
                            Console.WriteLine("Truck " + trucknumber + " sold " +
                                              (quantitySold));
                            bool test = addSale(itemnumber, trucknumber, temp.routenumber, temp.drivernumber, quantitySold, daySettings.currentDate, truckInv[itemnumber].initialprice, truckInv[itemnumber].saleprice);
                        }
                        Console.WriteLine("Truck " + trucknumber + " has " + finalquantity + "/" +
                                          truckInv[itemnumber].quantity + " of item " + itemnumber);
                    }
                    else
                    {
                        Console.WriteLine("Truck " + trucknumber + " has " + finalquantity + " of item " + itemnumber +
                                          " and it did not leave with that item");
                    }
                    
                    itemsChecked ++;
                }
                else if (checkRegex(contents[i], truckSalesTrailerEx).valid && inTruck == true && truckValid)
                {
                    RegexMethods.RegexClass r = checkRegex(contents[i], truckSalesTrailerEx);
                    int numberOfItems = Int32.Parse(r.groupValues[2]);
                    if (numberOfItems != itemsChecked)
                    {
                        Console.WriteLine("Number of items in trailer does not match the number of items in the truck");
                    }

                    inTruck = false;
                    itemsChecked = 0;
                    Console.WriteLine("Done unloading truck " + trucknumber);
                }
                else if(truckValid)
                {
                    //file is invalid in format
                    addToLog("Sales File: Line " + (i + 1).ToString() + " is invalid!");
                    Console.WriteLine("File is invalid in format");
                }
            }



        }
        //needs error handling

    }
}
