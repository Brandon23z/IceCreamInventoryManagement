using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IceCreamInventoryManagement.RegexMethods;
using static IceCreamInventoryManagement.RegexStr;
using static IceCreamInventoryManagement.ourClasses;
using static IceCreamInventoryManagement.SQLMethods;
using System.Globalization;

namespace IceCreamInventoryManagement
{
    public partial class Form1 : Form
    {
        //public List<string> log = new List<string>();

        DateTime now = DateTime.Now;

        string dateTimeFormat = "M/d/yy - h:mm ";




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializeDatabase();
        }

        private void btnCityUpload_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] cityUploadFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cityUploadFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("City Upload File Read");
            }

            //Check and parse header
            RegexClass r = checkRegex(cityUploadFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(cityUploadFile[cityUploadFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString); 
            }


            if (numOfRows != cityUploadFile.Length - 2)
            {
                addToLog("City Upload File Invalid: Trailer # does not match Actual # of Rows");
            }


            clearRoutes();
            clearZones();
            for (int i = 1; i < cityUploadFile.Length - 1; i++)
            {
                r = checkRegex(cityUploadFile[i], cityEx);
                if (r.valid)
                {
                    string citylabel = r.groupValues[1];
                    string cityname = r.groupValues[2];
                    string state = r.groupValues[3];
                    bool test = addZone(new Zone(citylabel, cityname, state));
                }
            }
            

            addToLog("City Upload File Valid");
            //MessageBox.Show("file read succesfully");

            //temporary form

            //DisplayTableForm d = new DisplayTableForm();
            //d.Show();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            List<Zone> myZones = new List<Zone>();

            myZones = getAllZones();
            zoneGridView.Rows.Clear();
            for (int i = 0; i < myZones.Count(); i++)
            {
                //DataGridViewRow row = new DataGridViewRow();
                zoneGridView.Rows.Add(myZones[i].citylabel, myZones[i].cityname, myZones[i].state);
                //row.Cells[0].Value = myZones[i].citylabel;
                //row.Cells[1].Value = myZones[i].cityname;
                //row.Cells[2].Value = myZones[i].state;
                //zoneGridView.Rows.Add(row);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void btnRouteUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] routeUploadFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                routeUploadFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Route Upload File Read");
            }

            //Check and parse header
            RegexClass r = checkRegex(routeUploadFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(routeUploadFile[routeUploadFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                numOfRows = Int32.Parse(r.groupValues[2]);
            }


            if (numOfRows != routeUploadFile.Length - 2)
            {
                addToLog("Route Upload File Invalid: Trailer # does not match Actual # of Rows");
            }


            for (int i = 1; i < routeUploadFile.Length - 1; i++)
            {
                r = checkRegex(routeUploadFile[i], routeCitys);
                if (r.valid)
                {
                    if (r.groupValues[1] == "A")
                    {
                        int routenumber = Int32.Parse(r.groupValues[2]);
                        string[] citylabels = new string[10];
                        citylabels[0] = r.groupValues[3];
                        int temp = 4;
                        for (int k = 1; k < 10; k++)
                        {
                            if (r.groupValues[temp] == "")
                                break;
                            else
                                citylabels[k] = r.groupValues[temp];
                            temp++;
                        }

                        bool test = addRoute(new Route(routenumber, citylabels));
                    }
                    if (r.groupValues[1] == "C")
                    {
                        int routenumber = Int32.Parse(r.groupValues[2]);
                        string[] citylabels = new string[10];
                        citylabels[0] = r.groupValues[3];
                        int temp = 4;
                        for (int k = 1; k < 10; k++)
                        {
                            if (r.groupValues[temp] == "")
                                break;
                            else
                                citylabels[k] = r.groupValues[temp];
                            temp++;
                        }

                        bool test = updateRoute(new Route(routenumber, citylabels));
                        if(!test)
                            addToLog("Route # " + routenumber + "failed to update.");
                    }
                    if (r.groupValues[13] == "D")
                    {
                        int routenumber = Int32.Parse(r.groupValues[14]);
                        bool test = deleteRoute(routenumber);
                    }
                }
            }


            addToLog("Route Upload File Valid");


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            List<Route> myRoutes = new List<Route>();

            myRoutes = getAllRoutes();

            routeGridView.Rows.Clear();
            for (int i = 0; i < myRoutes.Count(); i++)
            {
                //DataGridViewRow row = (DataGridViewRow)zoneGridView.Rows[0].Clone();
                routeGridView.Rows.Add(myRoutes[i].routenumber, myRoutes[i].cityLabels[0], myRoutes[i].cityLabels[1], myRoutes[i].cityLabels[2], myRoutes[i].cityLabels[3], myRoutes[i].cityLabels[4]);
                //row.Cells[0].Value = myRoutes[i].routenumber;
                //row.Cells[1].Value = myRoutes[i].cityLabels[0];
                //row.Cells[2].Value = myRoutes[i].cityLabels[1];
                //row.Cells[3].Value = myRoutes[i].cityLabels[2];
                //row.Cells[4].Value = myRoutes[i].cityLabels[3];
                //row.Cells[5].Value = myRoutes[i].cityLabels[4];
                //zoneGridView.Rows.Add(row);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void btnIceCreamFromTrucks_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] salesFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                salesFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Sales File Read");
            }else
            {
                return;
            }

            //Check and parse header
            RegexClass r = checkRegex(salesFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(salesFile[salesFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString);
            }


            if (numOfRows != salesFile.Length - 2)
            {
                addToLog("Ice Cream from Trucks File Invalid: Trailer # does not match Actual # of Rows");
            }


            if (TextSetting.dailyInventoryCalculated == true)
                sendTextMessage("Warehouse Inventory has been calculated.");
        }

        private void btnChangeTruckInventory_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] iceCreamtoTrucksFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                iceCreamtoTrucksFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Ice Cream to Trucks File Read");
            }else
            {
                return;
            }

            //Check and parse header
            RegexClass r = checkRegex(iceCreamtoTrucksFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(iceCreamtoTrucksFile[iceCreamtoTrucksFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString);
            }


            if (numOfRows != iceCreamtoTrucksFile.Length - 2)
            {
                addToLog("Ice Cream to Trucks File Invalid: Trailer # does not match Actual # of Rows");
            }

            int trucknumber = 0;
            bool inTruck = false;
            int itemsAdded = 0;
            for (int i = 1; i < iceCreamtoTrucksFile.Length - 1; i++)
            {
                if (checkRegex(iceCreamtoTrucksFile[i], truckHeaderEx).valid && inTruck == false)
                {
                    r = checkRegex(iceCreamtoTrucksFile[i], truckHeaderEx);
                    trucknumber = Int32.Parse(r.groupValues[2]);
                    inTruck = true;
                    Console.WriteLine("Filling truck " + trucknumber.ToString());
                }
                else if (checkRegex(iceCreamtoTrucksFile[i], truckItemEx).valid && inTruck == true)
                {
                    r = checkRegex(iceCreamtoTrucksFile[i], truckItemEx);
                    int itemnumber = Int32.Parse(r.groupValues[1]);
                    int amount = Int32.Parse(r.groupValues[2]);
                    itemsAdded++;
                    Console.WriteLine("Adding " + amount.ToString() + " of item " + itemnumber + " to truck " + trucknumber);
                    //update amount
                }
                else if (checkRegex(iceCreamtoTrucksFile[i], truckItemsTrailerEx).valid && inTruck == true)
                {
                    r = checkRegex(iceCreamtoTrucksFile[i], truckItemsTrailerEx);
                    int numberOfItems = Int32.Parse(r.groupValues[2]);
                    if(numberOfItems != itemsAdded)
                    {
                        Console.WriteLine("Number of items in trailer does not match the number of items added");
                    }

                    inTruck = false;
                    itemsAdded = 0;
                    Console.WriteLine("Done filling truck " + trucknumber);
                }
                else
                {
                    //file is invalid in format
                    Console.WriteLine("File is invalid in format");
                }
            }


            addToLog("Ice Cream to Trucks File Valid");
        }

        private void btnTruckRouteUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] truckRouteFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                truckRouteFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                //addToLog("Truck-Route File Read"); 
            }

            //Check and parse header
            RegexClass r = checkRegex(truckRouteFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(truckRouteFile[truckRouteFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString);
            }


            if (numOfRows != truckRouteFile.Length - 2)
            {
                //addToLog("Truck Upload File Invalid: Trailer # does not match Actual # of Rows");
            }

            for (int i = 1; i < truckRouteFile.Length - 1; i++)
            {
                r = checkRegex(truckRouteFile[i], truckRouteEx);
                if (r.valid)
                {
                    int trucknumber = Int32.Parse(r.groupValues[1]);
                    int routenumber = Int32.Parse(r.groupValues[2]);
                    int drivernumber = Int32.Parse(r.groupValues[3]);
                    assignTruckToRoute(trucknumber, routenumber);
                    assignDriverToTruck(drivernumber, trucknumber);
                }
            }
            //addToLog("Truck Upload File Valid");

            List<Truck> myTrucks = new List<Truck>();

            myTrucks = getAllTrucks();
            truckGridView.Rows.Clear();
            for (int i = 0; i < myTrucks.Count(); i++)
            {
                truckGridView.Rows.Add(myTrucks[i].trucknumber, myTrucks[i].routenumber);
            }

            List<Driver> myDrivers = new List<Driver>();

            myDrivers = getAllDrivers();

            driverGridView.Rows.Clear();
            for (int i = 0; i < myDrivers.Count(); i++)
            {
                driverGridView.Rows.Add(myDrivers[i].drivernumber, myDrivers[i].trucknumber);
            }

        }

        private void btnInventoryUpdate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] inventoryUpdateFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inventoryUpdateFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Inventory Update File Read");
            }

            //Check and parse header
            RegexClass r = checkRegex(inventoryUpdateFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(inventoryUpdateFile[inventoryUpdateFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString);
            }


            if (numOfRows != inventoryUpdateFile.Length - 2)
            {
                addToLog("Inventory Upload File Invalid: Trailer # does not match Actual # of Rows");
            }

            clearInventory();
            for (int i = 1; i < inventoryUpdateFile.Length - 1; i++)
            {
                r = checkRegex(inventoryUpdateFile[i], inventoryItemEx);
                if (r.valid)
                {
                    int itemnumber = Int32.Parse(r.groupValues[1]);
                    int quantity = Int32.Parse(r.groupValues[2]);
                    double initialprice = Convert.ToDouble(r.groupValues[3] + "." + r.groupValues[4]);
                    double saleprice = Int32.Parse(r.groupValues[5]);
                    string description = r.groupValues[6];
                    bool test = addInventoryItem(new InventoryItem(itemnumber, quantity, initialprice, saleprice, description));
                }
            }


            addToLog("Inventory Upload File Valid");

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            List<InventoryItem> myInventory = new List<InventoryItem>();

            myInventory = getInventory();

            saleGridView.Rows.Clear();
            for (int i = 0; i < myInventory.Count(); i++)
            {
                saleGridView.Rows.Add(myInventory[i].itemnumber, myInventory[i].quantity, myInventory[i].initialprice, myInventory[i].saleprice);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        }

        private void btnTruckUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] truckUploadFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                truckUploadFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Truck Upload File Read");
            }

            //Check and parse header
            RegexClass r = checkRegex(truckUploadFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(truckUploadFile[truckUploadFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString);
            }


            if (numOfRows != truckUploadFile.Length - 2)
            {
                addToLog("Truck Upload File Invalid: Trailer # does not match Actual # of Rows");
            }


            clearTrucks();
            for (int i = 1; i < truckUploadFile.Length - 1; i++)
            {
                r = checkRegex(truckUploadFile[i], trucksEx);
                if (r.valid)
                {
                    int trucknumber = Int32.Parse(r.groupValues[1]);
                    bool test = addTruck(new Truck(trucknumber));
                }
            }
            addToLog("Truck Upload File Valid");


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            List<Truck> myTrucks = new List<Truck>();

            myTrucks = getAllTrucks();
            truckGridView.Rows.Clear();
            for (int i = 0; i < myTrucks.Count(); i++)
            {
                truckGridView.Rows.Add(myTrucks[i].trucknumber, myTrucks[i].routenumber);
                //DataGridViewRow row = (DataGridViewRow)zoneGridView.Rows[0].Clone();
                //row.Cells[0].Value = myTrucks[i].trucknumber;
                //row.Cells[1].Value = myTrucks[i].routenumber;
                //zoneGridView.Rows.Add(row);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void btnDriverUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] driverUploadFile = { "" };
            DateTime date = Convert.ToDateTime("1970-01-01");
            string seqNum = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                driverUploadFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Driver Upload File Read");
            }

            //Check and parse header
            RegexClass r = checkRegex(driverUploadFile[0], headerEx);
            if (r.valid)
            {
                seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                date = Convert.ToDateTime(dateString);
            }

            //check and parse trailer
            r = checkRegex(driverUploadFile[driverUploadFile.Length - 1], trailerEx);

            int numOfRows = 0;

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString);
            }


            if (numOfRows != driverUploadFile.Length - 2)
            {
                addToLog("Driver Upload File Invalid: Trailer # does not match Actual # of Rows");
            }

            clearDrivers();
            for (int i = 1; i < driverUploadFile.Length - 1; i++)
            {
                r = checkRegex(driverUploadFile[i], trucksEx);
                if (r.valid)
                {
                    int drivernumber = Int32.Parse(r.groupValues[1]);
                    bool test = addDriver(new Driver(drivernumber));
                }
            }


            addToLog("Driver Upload File Valid");

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            List<Driver> myDrivers = new List<Driver>();

            myDrivers = getAllDrivers();

            driverGridView.Rows.Clear();
            for (int i = 0; i < myDrivers.Count(); i++)
            {
                driverGridView.Rows.Add(myDrivers[i].drivernumber, myDrivers[i].trucknumber);
                //DataGridViewRow row = (DataGridViewRow)zoneGridView.Rows[0].Clone();
                //row.Cells[0].Value = myDrivers[i].drivernumber;
                //row.Cells[1].Value = myDrivers[i].trucknumber;
                //zoneGridView.Rows.Add(row);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void btnCustomerRequests_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] customerRequestFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                customerRequestFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Customer Request File Read");
            }

            if (TextSetting.itemAddedToAutoOrder == true)
            {
                sendTextMessage("New Products added to Automatic Order List");
                addToLog("Text Message Sent: " + "New Products added to Automatic Order List");
            }

        }

        setDefaultForm setDefaultForm = new setDefaultForm();
        settingsForm settingsForm = new settingsForm();
        logForm logForm = new logForm();
        autoOrderForm autoOrderForm = new autoOrderForm();

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            setDefaultForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logForm.ShowDialog();
        }


        private void btnAutoOrder_Click(object sender, EventArgs e)
        {
            autoOrderForm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadIceCreamToTrucks_Click(object sender, EventArgs e)
        {
            if (TextSetting.truckInventoryReset == true)
            {
                sendTextMessage("Truck inventories have been loaded.");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


    }
}