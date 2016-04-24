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
using static IceCreamInventoryManagement.InputFileMethods;

namespace IceCreamInventoryManagement
{
    public partial class Form1 : Form
    {

        DateTime now = DateTime.Now;

        string dateTimeFormat = "M/d/yy - h:mm ";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializeDatabase();
            clearDatabase();
            Settings.saveDefaults(true);
            tabPage1.Text = "Populate System";
            tabPage2.Text = "Run Simulation";
            tabPage3.Text = "Settings";
            tabPage4.Text = "Display Sales";
            refreshSalesView();
        }

        private void btnCityUpload_Click(object sender, EventArgs e)
        {
            string[] cityUploadFile = { "" };
            string fileName = "City Upload File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceCityUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out cityUploadFile, fileName, seqNum, Settings.keys.sequenceCityUploadFile))
            {
                return;
            }

            //Empty Cities and Routes Tables
            clearRoutes();
            clearZones();

            //process the city upload file, adding any zones to database
            processCityUploadFileBody(cityUploadFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshZonesView();
        }

        private void refreshZonesView()
        {
            List<Zone> myZones = new List<Zone>();
            myZones = getAllZones();
            zoneGridView.Rows.Clear();
            for (int i = 0; i < myZones.Count(); i++)
            {
                zoneGridView.Rows.Add(myZones[i].citylabel, myZones[i].cityname, myZones[i].state);
            }
        }

        private void btnRouteUpload_Click(object sender, EventArgs e)
        {
            string[] routeUploadFile = { "" };
            string fileName = "Route Upload File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceRouteUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out routeUploadFile, fileName, seqNum, Settings.keys.sequenceRouteUploadFile))
            {
                return;
            }

            //process the city upload file, adding any zones to database
            processRouteUploadFileBody(routeUploadFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshRoutesView();
        }

        private void refreshRoutesView()
        {
            List<Route> myRoutes = new List<Route>();
            myRoutes = getAllRoutes();
            routeGridView.Rows.Clear();
            for (int i = 0; i < myRoutes.Count(); i++)
            {
                routeGridView.Rows.Add(myRoutes[i].routenumber, myRoutes[i].cityLabels[0], myRoutes[i].cityLabels[1], myRoutes[i].cityLabels[2], myRoutes[i].cityLabels[3], myRoutes[i].cityLabels[4]);
            }
        }

        private void btnIceCreamFromTrucks_Click(object sender, EventArgs e)
        {
            string[] salesFile = { "" };
            string fileName = "Sales File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceTruckSalesUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out salesFile, fileName, seqNum, Settings.keys.sequenceTruckSalesUploadFile, false))
            {
                return;
            }

            //process the city upload file, adding any zones to database
            processSalesFileBody(salesFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshRoutesView();
            refreshSalesView();


            if (TextSetting.dailyInventoryCalculated == true)
                sendTextMessage("Warehouse Inventory has been calculated.");
        }

        private void refreshSalesView()
        {
            List<Sale> mySales = new List<Sale>();
            mySales = getAllSales();
            salesGridView.Rows.Clear();
            salesGridView1.Rows.Clear();
            for (int i = 0; i < mySales.Count(); i++)
            {
                salesGridView.Rows.Add(mySales[i].itemnumber, mySales[i].quantity, mySales[i].saledate, mySales[i].initialprice, mySales[i].saleprice, mySales[i].trucknumber, mySales[i].routenumber, mySales[i].drivernumber);
                salesGridView1.Rows.Add(mySales[i].itemnumber, mySales[i].quantity, mySales[i].saledate, mySales[i].initialprice, mySales[i].saleprice, mySales[i].trucknumber, mySales[i].routenumber, mySales[i].drivernumber);

            }
        }

        private void btnChangeTruckInventory_Click(object sender, EventArgs e)
        {
            string[] iceCreamtoTrucksFile = { "" };
            string fileName = "Make Changes to Default Truck Inventory File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceTruckInventoryUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out iceCreamtoTrucksFile, fileName, seqNum, Settings.keys.sequenceTruckInventoryUploadFile, false))
            {
                return;
            }

            //check trailer here


            //process the city upload file, adding any zones to database
            processTruckInventoryUploadFileBody(iceCreamtoTrucksFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshTruckInvView();
            refreshInventoryView();

            SQLMethods.insertSetting(Settings.keys.truckInventoryUploadFile, "1", true);


        }

        private void refreshTruckInvView()
        {
            truckInventoryGridView.Rows.Clear();
            List<Truck> myTrucks = new List<Truck>();
            myTrucks = getAllTrucks();
            Dictionary<int, TruckInventoryItem> myInventory = new Dictionary<int, TruckInventoryItem>();
            for (int k = 0; k < myTrucks.Count(); k++)
            {
                myInventory = getTruckInventory(myTrucks[k].trucknumber);
                foreach (KeyValuePair<int, TruckInventoryItem> item in myInventory)
                {
                    truckInventoryGridView.Rows.Add(myTrucks[k].trucknumber, item.Value.itemnumber, item.Value.quantity, item.Value.initialprice, item.Value.saleprice);
                }
            }
        }

        private void refreshInventoryView()
        {
            inventoryGridView.Rows.Clear();
            List<InventoryItem> myInventory1 = new List<InventoryItem>();
            myInventory1 = getInventory();
            for (int i = 0; i < myInventory1.Count(); i++)
            {
                inventoryGridView.Rows.Add(myInventory1[i].itemnumber, myInventory1[i].quantity, myInventory1[i].initialprice, myInventory1[i].saleprice);
            }
        }

        private void btnTruckRouteUpload_Click(object sender, EventArgs e)
        {
            string[] truckRouteFile = { "" };
            string fileName = "Truck-Route-Driver Assignment File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceTruckRouteDriverUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out truckRouteFile, fileName, seqNum, Settings.keys.sequenceTruckRouteDriverUploadFile))
            {
                return;
            }

            //process the upload file
            processTruckRouteDriverUploadFileBody(truckRouteFile);
            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshTrucksView();
            refreshDriversView();
        }

        private void refreshTrucksView()
        {
            List<Truck> myTrucks = new List<Truck>();
            myTrucks = getAllTrucks();
            truckGridView.Rows.Clear();
            for (int i = 0; i < myTrucks.Count(); i++)
            {
                truckGridView.Rows.Add(myTrucks[i].trucknumber, myTrucks[i].routenumber);
            }
        }

        private void refreshDriversView()
        {
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
            string[] inventoryUpdateFile = { "" };
            string fileName = "Warehouse Inventory Update File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceWarehouseUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out inventoryUpdateFile, fileName, seqNum, Settings.keys.sequenceWarehouseUploadFile))
            {
                return;
            }

            //process the upload file
            processInventoryUpdateBody(inventoryUpdateFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshInventoryView();

        }

        private void btnTruckUpload_Click(object sender, EventArgs e)
        {
            string[] truckUploadFile = { "" };
            string fileName = "Truck Upload File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceTruckUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out truckUploadFile, fileName, seqNum, Settings.keys.sequenceTruckUploadFile))
            {
                return;
            }

            //process the upload file
            processTruckUploadBody(truckUploadFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshTrucksView();
        }

        private void btnDriverUpload_Click(object sender, EventArgs e)
        {
            string[] driverUploadFile = { "" };
            string fileName = "Driver Upload File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceDriverUploadFile;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out driverUploadFile, fileName, seqNum, Settings.keys.sequenceDriverUploadFile))
            {
                return;
            }

            //process the upload file
            processDriverUploadBody(driverUploadFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshDriversView();

        }

        private void btnCustomerRequests_Click(object sender, EventArgs e)
        {
            string[] customerRequestFile = { "" };
            string fileName = "Customer Request File";
            Settings.SequenceNumberSettings sequenceSettings = Settings.getSequenceNumberSettings();
            int seqNum = sequenceSettings.sequenceCustomerRequest;
            //if anything is invalid to where the file is invalid
            if (!checkFileGeneric(out customerRequestFile, fileName, seqNum, Settings.keys.sequenceCustomerRequest))
            {
                return;
            }

            //process the upload file
            processCustomerRequestBody(customerRequestFile);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshInventoryView();

            //send text
            if (TextSetting.itemAddedToAutoOrder == true)
            {
                sendTextMessage("New Products added to Automatic Order List");
                addToLog("Text Message Sent: " + "New Products added to Automatic Order List");
            }

        }

        private void btnLoadIceCreamToTrucks_Click(object sender, EventArgs e)
        {
            //If loadTruck.txt("change the default" file) has NOT been uploaded
            Settings.FileUploadSettings settings = Settings.getFileUploadSettings();

            if (settings.truckInventoryUploadFile)
            {
                //add default inventory to each truck
                List<Truck> myTrucks = new List<Truck>();

                myTrucks = getAllTrucks();

                for (int i = 0; i < myTrucks.Count(); i++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        InventoryItem temp = getInventoryItem(DefaultOrder.defaults[k].productID);
                        int change = DefaultOrder.defaults[k].amount * (-1);
                        int myTest = moveItem(temp.itemnumber, myTrucks[i].trucknumber, change);
                    }
                }
                addToLog("Loading default items to trucks");
            }

            refreshInventoryView();


            if (TextSetting.truckInventoryReset == true)
            {
                sendTextMessage("Truck inventories have been loaded.");
            }
        }

        setDefaultForm setDefaultForm = new setDefaultForm();
        settingsForm settingsForm = new settingsForm();
        autoOrderForm autoOrderForm = new autoOrderForm();

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            setDefaultForm.StartPosition = FormStartPosition.CenterParent;
            setDefaultForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsForm.StartPosition = FormStartPosition.CenterParent;
            settingsForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logForm logForm = new logForm();
            logForm.StartPosition = FormStartPosition.CenterParent;
            logForm.Show();
        }


        private void btnAutoOrder_Click(object sender, EventArgs e)
        {
            autoOrderForm.StartPosition = FormStartPosition.CenterParent;
            autoOrderForm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sortSales(string startDateString = "", string endDateString = "", int drivernumber = 0, int routenumber = 0, int trucknumber = 0, int itemnumber = 0)
        {
            List<Sale> result1 = new List<Sale>();
            List<Sale> result2 = new List<Sale>();
            List<Sale> result3 = new List<Sale>();
            List<Sale> result4 = new List<Sale>();
            List<Sale> result5 = new List<Sale>();

            List<Sale> mySales = new List<Sale>();

            DateTime startDate = Convert.ToDateTime(startDateString);
            DateTime endDate = Convert.ToDateTime(endDateString);

            mySales = getAllSales();

            for (int i = 0; i < mySales.Count(); i++)
            {
                if (drivernumber != 0)
                {
                    if (mySales[i].drivernumber == drivernumber)
                        result1.Add(mySales[i]);
                }
                else
                {
                    result1 = mySales;
                    break;
                }
            }

            for (int i = 0; i < result1.Count(); i++)
            {
                if (trucknumber != 0)
                {
                    if (result1[i].trucknumber == trucknumber)
                        result2.Add(result1[i]);
                }
                else
                {
                    result2 = result1;
                    break;
                }
            }

            for (int i = 0; i < result2.Count(); i++)
            {
                if (routenumber != 0)
                {
                    if (result2[i].routenumber == routenumber)
                        result3.Add(result2[i]);
                }
                else
                {
                    result3 = result2;
                    break;
                }
            }

            for (int i = 0; i < result3.Count(); i++)
            {
                if (itemnumber != 0)
                {
                    if (result3[i].itemnumber == itemnumber)
                        result4.Add(result3[i]);
                }
                else
                {
                    result4 = result3;
                    break;
                }
            }

            for (int i = 0; i < result4.Count(); i++)
            {
                if (startDateString != "" && endDateString != "")
                {
                    if (result4[i].saledate >= startDate && result4[i].saledate <= endDate)
                        result5.Add(result4[i]);
                }
                else
                {
                    result5 = result4;
                    break;
                }
            }

            salesGridView1.Rows.Clear();
            for (int i = 0; i < mySales.Count(); i++)
            {
                salesGridView1.Rows.Add(result5[i].itemnumber, result5[i].quantity, result5[i].saledate, result5[i].initialprice, result5[i].saleprice, result5[i].trucknumber, result5[i].routenumber, result5[i].drivernumber);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
