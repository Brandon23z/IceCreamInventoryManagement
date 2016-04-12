using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.IO;

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
    }
}
