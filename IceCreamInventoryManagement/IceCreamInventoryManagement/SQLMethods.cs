﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using static IceCreamInventoryManagement.ourClasses;
using static IceCreamInventoryManagement.SQL;

namespace IceCreamInventoryManagement
{
    class SQLMethods
    {
        public static void initializeDatabase()
        {
            if (!File.Exists("database.FDB"))
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();

                cs.Database = "database.FDB";
                cs.UserID = "SYSDBA";
                cs.Password = "masterkey";
                cs.ServerType = FbServerType.Embedded;
                FbConnection.CreateDatabase(cs.ToString());
                SQL.sqlnonquery("CREATE TABLE ZONES(citylabel VARCHAR(20) NOT NULL PRIMARY KEY, cityname VARCHAR(20) NOT NULL, state VARCHAR(2) NOT NULL);");
                SQL.sqlnonquery("CREATE TABLE ROUTES(routenumber int NOT NULL PRIMARY KEY, citylabel1 VARCHAR(20) NOT NULL, citylabel2 VARCHAR(20), citylabel3 VARCHAR(20), citylabel4 VARCHAR(20), citylabel5 VARCHAR(20), citylabel6 VARCHAR(20), citylabel7 VARCHAR(20), citylabel8 VARCHAR(20), citylabel9 VARCHAR(20), citylabel10 VARCHAR(20));");
                SQL.sqlnonquery("CREATE TABLE TRUCKS(trucknumber int NOT NULL PRIMARY KEY, routenumber int);");
                SQL.sqlnonquery("CREATE TABLE TRUCKINVENTORY(trucknumber int NOT NULL PRIMARY KEY, itemnumber int NOT NULL, quantity int NOT NULL, initialprice float NOT NULL, saleprice float NOT NULL);");
                SQL.sqlnonquery("CREATE TABLE INVENTORY(itemnumber int NOT NULL PRIMARY KEY, quantity int NOT NULL, initialprice float NOT NULL, saleprice float NOT NULL, description VARCHAR(30));");
                SQL.sqlnonquery("CREATE TABLE DRIVERS(drivernumber int NOT NULL PRIMARY KEY, trucknumber int);");
                SQL.sqlnonquery("CREATE TABLE SALES(itemnumber int NOT NULL, quantity int NOT NULL, saledate timestamp NOT NULL, initialprice float NOT NULL, saleprice float NOT NULL, trucknumber int NOT NULL, routenumber int NOT NULL, drivernumber int NOT NULL);");
                SQL.sqlnonquery("CREATE TABLE settings(key VARCHAR(30) NOT NULL PRIMARY KEY, val VARCHAR(300))");
            }
        }

        //ZONE//
        #region ZONE
        public static Zone getZone(string getCityLabel)
        {
            SQLResult result = sqlquery("SELECT * FROM ZONES WHERE citylabel = @zone;",
                new Dictionary<string, string>() { { "@zone", getCityLabel } });
            if (result.error == SQLError.none && result.data != null && result.data.data.Count == 1)
            {
                string citylabel = result.data.getField(0, "citylabel");
                string cityname = result.data.getField(0, "cityname");
                string state = result.data.getField(0, "state");
                return new Zone(citylabel, cityname, state);
            }
            else
            {
                return null;
            }
        }

        public static List<Zone> getAllZones()
        {
            List<Zone> zoneList = new List<Zone>();
            SQLResult result = sqlquery("SELECT * FROM ZONES;");
            if (result.error == SQLError.none && result.data != null)
            {
                for (int i = 0; i < result.data.data.Count; i++)
                {
                    string citylabel = result.data.getField(i, "citylabel");
                    string cityname = result.data.getField(i, "cityname");
                    string state = result.data.getField(i, "state");
                    Zone tempZone = new Zone(citylabel, cityname, state);
                    zoneList.Add(tempZone);
                }
                return zoneList;
            }
            else
            {
                return null;
            }
        }

        public static bool addZone(Zone addCityLabel)
        {
            SQLResult result = sqlquery("INSERT INTO ZONES (citylabel, cityname, state) VALUES (@citylabel, @cityname, @state);",
                new Dictionary<string, string>() { { "@citylabel", addCityLabel.citylabel }, { "@cityname", addCityLabel.cityname }, { "@state", addCityLabel.state } });
            if(result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool clearZones()
        {
            SQLResult result = sqlquery("DELETE FROM ZONES;");
            if (result.error == SQLError.none)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //ZONE//

        //ROUTE//
        #region ROUTE
        public static Route getRoute(int getRouteNumber)
        {
            SQLResult result = sqlquery("SELECT * FROM ROUTES WHERE routenumber = @route;",
                new Dictionary<string, string>() { { "@route", getRouteNumber.ToString() } });
            if (result.error == SQLError.none && result.data != null && result.data.data.Count == 1)
            {
                string[] cityLabels = new string[10];
                int routenumber = Convert.ToInt32(result.data.getField(0, "routenumber"));
                cityLabels[0] = result.data.getField(0, "citylabel1");
                cityLabels[1] = result.data.getField(0, "citylabel2");
                cityLabels[2] = result.data.getField(0, "citylabel3");
                cityLabels[3] = result.data.getField(0, "citylabel4");
                cityLabels[4] = result.data.getField(0, "citylabel5");
                cityLabels[5] = result.data.getField(0, "citylabel6");
                cityLabels[6] = result.data.getField(0, "citylabel7");
                cityLabels[7] = result.data.getField(0, "citylabel8");
                cityLabels[8] = result.data.getField(0, "citylabel9");
                cityLabels[9] = result.data.getField(0, "citylabel10");
                return new Route(routenumber, cityLabels);
            }
            else
            {
                return null;
            }
        }

        public static List<Route> getAllRoutes()
        {
            List<Route> routeList = new List<Route>();
            SQLResult result = sqlquery("SELECT * FROM ROUTES;");
            if (result.error == SQLError.none && result.data != null)
            {
                for (int i = 0; i < result.data.data.Count; i++)
                {
                    int routenumber = Convert.ToInt32(result.data.getField(i, "routenumber"));
                    string citylabel1 = result.data.getField(i, "citylabel1");
                    string citylabel2 = result.data.getField(i, "citylabel2");
                    string citylabel3 = result.data.getField(i, "citylabel3");
                    string citylabel4 = result.data.getField(i, "citylabel4");
                    string citylabel5 = result.data.getField(i, "citylabel5");
                    string citylabel6 = result.data.getField(i, "citylabel6");
                    string citylabel7 = result.data.getField(i, "citylabel7");
                    string citylabel8 = result.data.getField(i, "citylabel8");
                    string citylabel9 = result.data.getField(i, "citylabel9");
                    string citylabel10 = result.data.getField(i, "citylabel10");

                    string[] citylabels = { citylabel1, citylabel2, citylabel3, citylabel4, citylabel5, citylabel6, citylabel7, citylabel8, citylabel9 };
                    Route tempRoute = new Route(routenumber, citylabels);
                    routeList.Add(tempRoute);
                }
                return routeList;
            }
            else
            {
                return null;
            }
        }

        public static bool addRoute(Route addRoute)
        {
            SQLResult result = sqlquery("INSERT INTO ROUTES VALUES (@routenumber, @citylabel1, @citylabel2, @citylabel3, @citylabel4, @citylabel5, @citylabel6, @citylabel7, @citylabel8, @citylabel9, @citylabel10);",
                new Dictionary<string, string>() { { "@routenumber", addRoute.routenumber.ToString() }, { "@citylabel1", addRoute.cityLabels[0] }, { "@citylabel2", addRoute.cityLabels[1] }
                                                , { "@citylabel3", addRoute.cityLabels[2] }, { "@citylabel4", addRoute.cityLabels[3] }, { "@citylabel5", addRoute.cityLabels[4] }
                                                , { "@citylabel6", addRoute.cityLabels[5] }, { "@citylabel7", addRoute.cityLabels[6] }, { "@citylabel8", addRoute.cityLabels[7] }
                                                , { "@citylabel9", addRoute.cityLabels[8] }, { "@citylabel10", addRoute.cityLabels[9] }});
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool updateRoute(Route addRoute)
        {
            SQLResult result = sqlquery("UPDATE ROUTES set citylabel1 = @citylabel1, citylabel2 = @citylabel2, " +
                                        "citylabel3 = @citylabel3, citylabel4 = @citylabel4, citylabel5 = @citylabel5, citylabel6 = @citylabel6, " +
                                        "citylabel7 = @citylabel7, citylabel8 = @citylabel8, citylabel9 = @citylabel9, citylabel10 = @citylabel10 where routenumber = @routenumber;",
                new Dictionary<string, string>() { { "@routenumber", addRoute.routenumber.ToString() }, { "@citylabel1", addRoute.cityLabels[0] }, { "@citylabel2", addRoute.cityLabels[1] }
                                                , { "@citylabel3", addRoute.cityLabels[2] }, { "@citylabel4", addRoute.cityLabels[3] }, { "@citylabel5", addRoute.cityLabels[4] }
                                                , { "@citylabel6", addRoute.cityLabels[5] }, { "@citylabel7", addRoute.cityLabels[6] }, { "@citylabel8", addRoute.cityLabels[7] }
                                                , { "@citylabel9", addRoute.cityLabels[8] }, { "@citylabel10", addRoute.cityLabels[9] }});
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool clearRoutes()
        {
            SQLResult result = sqlquery("DELETE FROM ROUTES;");
            if (result.error == SQLError.none)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool deleteRoute(int routeID)
        {
            SQLResult result = sqlquery("DELETE FROM ROUTES WHERE routenumber=@routenumber;", new Dictionary<string, string>() { { "@routenumber", routeID.ToString() } });
            if (result.error == SQLError.none)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //ROUTE//

        //TRUCK//
        #region TRUCK
        public static Truck getTruck(int getTruckNumber)
        {
            SQLResult result = sqlquery("SELECT * FROM TRUCKS WHERE trucknumber = @truck;",
                new Dictionary<string, string>() { { "@truck", getTruckNumber.ToString() } });
            if (result.error == SQLError.none && result.data != null && result.data.data.Count == 1)
            {
                int trucknumber = Convert.ToInt32(result.data.getField(0, "trucknumber"));
                int routenumber = Convert.ToInt32(result.data.getField(0, "routenumber"));
                return new Truck(trucknumber, routenumber);
            }
            else
            {
                return null;
            }
        }

        public static List<Truck> getAllTrucks()
        {
            List<Truck> truckList = new List<Truck> ();
            SQLResult result = sqlquery("SELECT * FROM TRUCKS;");
            if (result.error == SQLError.none && result.data != null)
            {
                for (int i = 0; i < result.data.data.Count; i++)
                {
                    int trucknumber = Convert.ToInt32(result.data.getField(i, "trucknumber"));
                    int routenumber = Convert.ToInt32(result.data.getField(i, "routenumber"));
                    truckList.Add(new Truck(trucknumber, routenumber));
                }
                return truckList;
            }
            else
            {
                return null;
            }
        }

        public static bool addTruck(Truck addTruck)
        {
            SQLResult result = sqlquery("INSERT INTO TRUCKS VALUES (@trucknumber, @routenumber);",
                new Dictionary<string, string>() { { "@trucknumber", addTruck.trucknumber.ToString() }, { "@routenumber", addTruck.routenumber.ToString() } });
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool assignTruckToRoute(int trucknumber, int routenumber)
        {
            SQLResult result = sqlquery("UPDATE TRUCKS set routenumber = @routenumber WHERE trucknumber = @trucknumber;",
                new Dictionary<string, string>() { { "@trucknumber", trucknumber.ToString() }, { "@routenumber", routenumber.ToString() } });
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool clearTrucks()
        {
            SQLResult result = sqlquery("DELETE FROM TRUCKS;");
            if (result.error == SQLError.none)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //TRUCK//

        //TRUCK INVENTORY//
        #region TRUCK INVENTORY
        public static Dictionary<int,TruckInventoryItem> getTruckInventory(int getTruckNumber)
        {
            Dictionary<int, TruckInventoryItem> itemList = new Dictionary<int, TruckInventoryItem>();
            SQLResult result = sqlquery("SELECT * FROM TRUCKINVENTORY WHERE trucknumber = @trucknumber;", 
                new Dictionary<string, string>() { { "@trucknumber", getTruckNumber.ToString() } });
            if (result.error == SQLError.none && result.data != null)
            {
                for (int i = 0; i < result.data.data.Count; i++)
                {
                    int itemnumber = Convert.ToInt32(result.data.getField(i, "itemnumber"));
                    int quantity = Convert.ToInt32(result.data.getField(i, "quantity"));
                    double initialprice = Convert.ToDouble(result.data.getField(i, "initialprice"));
                    double saleprice = Convert.ToDouble(result.data.getField(i, "saleprice"));
                    string description = result.data.getField(i, "description");
                    TruckInventoryItem item = new TruckInventoryItem(itemnumber, quantity, initialprice, saleprice);
                    itemList.Add(item.itemnumber, item);
                }
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public static bool addTruckInventoryItem(int truckNumber, TruckInventoryItem addItem)
        {
            SQLResult result = sqlquery("INSERT INTO TRUCKINVENTORY VALUES (@trucknumber, @itemnumber, @quantity, @initialprice, @saleprice);",
                new Dictionary<string, string>() { { "@trucknumber", truckNumber.ToString() }, { "@itemnumber", addItem.itemnumber.ToString() }
                , { "@quantity", addItem.quantity.ToString() }, { "@initialprice", addItem.initialprice.ToString() }, { "@saleprice", addItem.saleprice.ToString() }});
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool clearAllTruckInventory()
        {
            SQLResult result = sqlquery("DELETE FROM TRUCKINVENTORY;");
            if (result.error == SQLError.none)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //TRUCK INVENTORY//

        //INVENTORY//
        #region INVENTORY
        public static InventoryItem getInventoryItem(int getItemNumber)
        {
            SQLResult result = sqlquery("SELECT * FROM INVENTORY WHERE itemnumber = @itemnumber;",
                new Dictionary<string, string>() { { "@itemnumber", getItemNumber.ToString() } });
            if (result.error == SQLError.none && result.data != null && result.data.data.Count == 1)
            {
                int itemnumber = Convert.ToInt32(result.data.getField(0, "itemnumber"));
                int quantity = Convert.ToInt32(result.data.getField(0, "quantity"));
                double initialprice = Convert.ToDouble(result.data.getField(0, "initialprice"));
                double saleprice = Convert.ToDouble(result.data.getField(0, "saleprice"));
                string description = result.data.getField(0, "description");
                return new InventoryItem(itemnumber, quantity, initialprice, saleprice, description);
            }
            else
            {
                return null;
            }
        }

        public static List<InventoryItem> getInventory()
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            SQLResult result = sqlquery("SELECT * FROM INVENTORY;");
            if (result.error == SQLError.none && result.data != null)
            {
                for (int i = 0; i < result.data.data.Count; i++)
                {
                    int itemnumber = Convert.ToInt32(result.data.getField(i, "itemnumber"));
                    int quantity = Convert.ToInt32(result.data.getField(i, "quantity"));
                    double initialprice = Convert.ToDouble(result.data.getField(i, "initialprice"));
                    double saleprice = Convert.ToDouble(result.data.getField(i, "saleprice"));
                    string description = result.data.getField(i, "description");
                    InventoryItem item = new InventoryItem(itemnumber, quantity, initialprice, saleprice, description);
                    itemList.Add(item);
                }
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public static bool addInventoryItem(InventoryItem addItem)
        {
            //INVENTORY(itemnumber int NOT NULL PRIMARY KEY, quantity int NOT NULL, initialprice float NOT NULL, saleprice float NOT NULL, description VARCHAR(20));
            SQLResult result = sqlquery("INSERT INTO INVENTORY VALUES (@itemnumber, @quantity, @initialprice, @saleprice, @description);",
                new Dictionary<string, string>() { { "@itemnumber", addItem.itemnumber.ToString() }, { "@quantity", addItem.quantity.ToString() }
                    , { "@initialprice", addItem.initialprice.ToString() }, { "@saleprice", addItem.saleprice.ToString() }, { "@description", addItem.description }});
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool clearInventory()
        {
            SQLResult result = sqlquery("DELETE FROM INVENTORY;");
            if (result.error == SQLError.none)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //INVENTORY//

        //DRIVERS//
        #region DRIVERS
        public static Driver getDriver(int getDriverNumber)
        {
            SQLResult result = sqlquery("SELECT * FROM DRIVERS WHERE drivernumber = @drivernumber;",
                new Dictionary<string, string>() { { "@drivernumber", getDriverNumber.ToString() } });
            if (result.error == SQLError.none && result.data != null && result.data.data.Count == 1)
            {
                int drivernumber = Convert.ToInt32(result.data.getField(0, "drivernumber"));
                int trucknumber = Convert.ToInt32(result.data.getField(0, "trucknumber"));
                return new Driver(drivernumber, trucknumber);
            }
            else
            {
                return null;
            }
        }

        public static List<Driver> getAllDrivers()
        {
            List<Driver> driverList = new List<Driver>();
            SQLResult result = sqlquery("SELECT * FROM DRIVERS;");
            if (result.error == SQLError.none && result.data != null)
            {
                for (int i = 0; i < result.data.data.Count; i++)
                {
                    int drivernumber = Convert.ToInt32(result.data.getField(i, "drivernumber"));
                    int trucknumber = Convert.ToInt32(result.data.getField(i, "trucknumber"));
                    Driver driver = new Driver(drivernumber, trucknumber);
                    driverList.Add(driver);
                }
                return driverList;
            }
            else
            {
                return null;
            }
        }

        public static bool addDriver(Driver addDriver)
        {
            //SQL.sqlnonquery("CREATE TABLE DRIVERS(drivernumber int NOT NULL PRIMARY KEY, int trucknumber);");

            SQLResult result = sqlquery("INSERT INTO DRIVERS VALUES (@drivernumber, @trucknumber);",
                new Dictionary<string, string>() { { "@drivernumber", addDriver.drivernumber.ToString() }, { "@trucknumber", addDriver.trucknumber.ToString() } });
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool assignDriverToTruck(int drivernumber, int trucknumber)
        {
            SQLResult result = sqlquery("UPDATE DRIVERS set trucknumber = @trucknumber WHERE drivernumber = @drivernumber;",
                new Dictionary<string, string>() { { "@drivernumber", drivernumber.ToString() }, { "@trucknumber", trucknumber.ToString() } });
            if (result.error == SQLError.none && result.rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool clearDrivers()
        {
            SQLResult result = sqlquery("DELETE FROM DRIVERS;");
            if (result.error == SQLError.none)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //DRIVERS//

        //SETTINGS/
        #region SETTINGS
        public static bool insertSetting(string setting, string value, bool overwrite = true)
        {
            string sql = "UPDATE or INSERT INTO SETTINGS (key, val) VALUES (@setting, @value)";
            if (overwrite == false)
            {
                sql = "INSERT INTO SETTINGS (key, val) VALUES (@setting, @value)";
            }
            SQLResult queryResult = sqlnonquery(sql,
                new Dictionary<string, string>() { { "@setting", setting }, { "@value", value } });
            if (queryResult.rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public static string retrieveSetting(string setting)
        {
            string value = "";
            string sql = "SELECT val FROM SETTINGS WHERE key = @setting";
            SQLResult queryResult = sqlquery(sql,
                new Dictionary<string, string>() { { "@setting", setting } });
            if (queryResult.error == SQLError.none && queryResult.data != null && queryResult.data.data.Count == 1)
            {
                value = queryResult.data.getField(0, "val");
            }

            return value;
        }
        #endregion
        //SETTINGS//
    }
}
