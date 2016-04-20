using System;
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
                SQL.sqlnonquery("CREATE TABLE ZONES(citylabel VARCHAR(30) NOT NULL PRIMARY KEY, cityname VARCHAR(30) NOT NULL, state VARCHAR(2) NOT NULL);");
                SQL.sqlnonquery("CREATE TABLE ROUTES(routenumber int NOT NULL PRIMARY KEY, citylabel1 VARCHAR(30) NOT NULL, citylabel2 VARCHAR(30) NOT NULL, citylabel3 VARCHAR(30) NOT NULL, citylabel4 VARCHAR(30) NOT NULL, citylabel5 VARCHAR(30) NOT NULL, citylabel6 VARCHAR(30) NOT NULL, citylabel7 VARCHAR(30) NOT NULL, citylabel8 VARCHAR(30) NOT NULL, citylabel9 VARCHAR(30) NOT NULL, citylabel10 VARCHAR(30) NOT NULL);");
                SQL.sqlnonquery("CREATE TABLE TRUCKS(trucknumber int NOT NULL PRIMARY KEY, routenumber int);");
                SQL.sqlnonquery("CREATE TABLE TRUCKINVENTORY(trucknumber int NOT NULL PRIMARY KEY, itemnumber int NOT NULL, quantity int NOT NULL, initialprice decimal NOT NULL, saleprice decimal NOT NULL);");
                SQL.sqlnonquery("CREATE TABLE INVENTORY(itemnumber int NOT NULL PRIMARY KEY, quantity int NOT NULL, initialprice decimal NOT NULL, saleprice decimal NOT NULL, description VARCHAR(30));");
                SQL.sqlnonquery("CREATE TABLE SALES(itemnumber int NOT NULL, quantity int NOT NULL, saledate timestamp NOT NULL, initialprice decimal NOT NULL, saleprice decimal NOT NULL, trucknumber int NOT NULL, routenumber int NOT NULL, drivernumber int NOT NULL);");
                SQL.sqlnonquery("CREATE TABLE DRIVERS(drivernumber int NOT NULL PRIMARY KEY, int trucknumber);");
            }
        }

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



    }
}
