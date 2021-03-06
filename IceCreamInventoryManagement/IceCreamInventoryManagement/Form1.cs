﻿using System;
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
            //clearDatabase();
            Settings.saveDefaults(false);
            /*
            Settings.SequenceNumberSettings snSettings = new Settings.SequenceNumberSettings();
            snSettings.sequenceCityUploadFile = 0102;
            snSettings.sequenceCustomerRequest = 0001;//
            snSettings.sequenceDriverUploadFile = 0001;//
            snSettings.sequenceRouteUploadFile = 0052;
            snSettings.sequenceTruckInventoryUploadFile = 9999;
            snSettings.sequenceTruckRouteDriverUploadFile = 9999;
            snSettings.sequenceTruckSalesUploadFile = 9998;
            snSettings.sequenceTruckUploadFile = 0001;
            snSettings.sequenceWarehouseUploadFile = 9997;
            Settings.saveSequenceNumberSettings(snSettings);
            */
            //Settings.SequenceNumberSettings s = Settings.getSequenceNumberSettings();
            refreshButtonStates();
        }

        private void refreshButtonStates()
        {
            Settings.DaySettings daySettings = Settings.getDaySettings();
            if (daySettings.dayStatus > 0)
            {
                lblCurrentDay.Text = "Current Day: " + daySettings.currentDate.ToString("yyyy-MM-dd");
            }
            else
            {
                lblCurrentDay.Text = "Current Day: Not Started";
            }
            switch (daySettings.dayStatus)
            {
                case 0:
                    lblCurrentStatus.Text = "Status: Awaiting Files";
                    break;
                case 1:
                    lblCurrentStatus.Text = "Status: Day Started, Awaiting Files";
                    break;
                case 2:
                    lblCurrentStatus.Text = "Status: Trucks Sent Out, Awaiting Sales File";
                    break;
            }

            Settings.FileUploadSettings settings = Settings.getFileUploadSettings();

            if (daySettings.dayStatus == 2)
            {
                btnIceCreamFromTrucks.Enabled = true;
                btnCustomerRequests.Enabled = true;
                btnRouteUpload.Enabled = false;
                btnCityUpload.Enabled = false;
                btnDriverUpload.Enabled = false;
                btnTruckUpload.Enabled = false;
                btnInventoryUpdate.Enabled = false;
            }
            else
            {
                btnIceCreamFromTrucks.Enabled = false;
                btnCustomerRequests.Enabled = false;
                btnRouteUpload.Enabled = true;
                btnCityUpload.Enabled = true;
                btnDriverUpload.Enabled = true;
                btnTruckUpload.Enabled = true;
                btnInventoryUpdate.Enabled = true;
            }
            if (settings.cityUploadFile && daySettings.dayStatus <= 1)
            {
                btnRouteUpload.Enabled = true;
            }
            else
            {
                btnRouteUpload.Enabled = false;
            }

            if (settings.cityUploadFile && settings.routeUploadFile && settings.truckUploadFile &&
                settings.driverUploadFile && daySettings.dayStatus <= 1)
            {
                btnTruckRouteUpload.Enabled = true;
                groupTruckRouteDriver.Enabled = true;
            }
            else
            {
                btnTruckRouteUpload.Enabled = false;
                groupTruckRouteDriver.Enabled = false;
            }

            if (settings.truckRouteDriverUploadFile && settings.warehouseUploadFile && settings.loadTruckDefaults && daySettings.dayStatus <= 1)
            {
                if (settings.truckInventoryUploadFile)
                {
                    btnChangeTruckInventory.Enabled = false;
                }
                else
                {
                    btnChangeTruckInventory.Enabled = true;
                }
                btnSendOutTrucks.Enabled = true;
            }
            else
            {
                btnChangeTruckInventory.Enabled = false;
                btnSendOutTrucks.Enabled = false;
            }
            if (settings.truckRouteDriverUploadFile && settings.warehouseUploadFile && daySettings.dayStatus <= 1)
            {
                if (settings.loadTruckDefaults)
                {
                    btnLoadIceCreamToTrucks.Enabled = false;
                }
                else
                {
                    btnLoadIceCreamToTrucks.Enabled = true;
                }
            }
            else
            {
                btnLoadIceCreamToTrucks.Enabled = false;
            }
            if (daySettings.dayStatus == 2 && settings.salesUploadFile)
            {
                btnEndDay.Enabled = true;
            }
            else
            {
                btnEndDay.Enabled = false;
            }

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

            SQLMethods.insertSetting(Settings.keys.cityUploadFile, "1", true);
            SQLMethods.insertSetting(Settings.keys.routeUploadFile, "0", true);
            SQLMethods.insertSetting(Settings.keys.truckRouteDriverUploadFile, "0", true);

            refreshButtonStates();
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

            SQLMethods.insertSetting(Settings.keys.routeUploadFile, "1", true);
            SQLMethods.insertSetting(Settings.keys.truckRouteDriverUploadFile, "0", true);
            refreshButtonStates();
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

            SQLMethods.insertSetting(Settings.keys.salesUploadFile, "1", true);

            if (TextSetting.dailyInventoryCalculated == true)
                sendTextMessage("Warehouse Inventory has been calculated.");

            refreshButtonStates();
        }

        /*
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
        */

        private void btnChangeTruckInventory_Click(object sender, EventArgs e)
        {
            string[] iceCreamtoTrucksFile = { "" };
            string fileName = "Change Truck Inventory File";
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

            SQLMethods.insertSetting(Settings.keys.truckInventoryUploadFile, "1", true);

            addToLog(fileName + " Processed Successfully");

            refreshButtonStates();
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

            SQLMethods.insertSetting(Settings.keys.truckRouteDriverUploadFile, "1", true);

            addToLog(fileName + " Processed Successfully");

            //refresh datagridview
            refreshButtonStates();
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

            SQLMethods.insertSetting(Settings.keys.warehouseUploadFile, "1", true);
            SQLMethods.insertSetting(Settings.keys.truckInventoryUploadFile, "0", true);
            SQLMethods.insertSetting(Settings.keys.loadTruckDefaults, "0", true);

            addToLog(fileName + " Processed Successfully");

            refreshButtonStates();
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

            SQLMethods.insertSetting(Settings.keys.truckUploadFile, "1", true);
            SQLMethods.insertSetting(Settings.keys.truckRouteDriverUploadFile, "0", true);

            addToLog(fileName + " Processed Successfully");

            refreshButtonStates();
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

            SQLMethods.insertSetting(Settings.keys.driverUploadFile, "1", true);
            SQLMethods.insertSetting(Settings.keys.truckRouteDriverUploadFile, "0", true);

            addToLog(fileName + " Processed Successfully");

            refreshButtonStates();
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


            //send text
            if (TextSetting.itemAddedToAutoOrder == true)
            {
                sendTextMessage("Customer Requests added to Automatic Order List");
                addToLog("Text Message Sent: " + "Customer Requests added to Automatic Order List");
            }
            refreshButtonStates();
        }



        private void btnLoadIceCreamToTrucks_Click(object sender, EventArgs e)
        {
            addToLog("Loading default items to trucks");
            //add default inventory to each truck
            List<Truck> myTrucks = new List<Truck>();

            myTrucks = getAllTrucks();

            for (int i = 0; i < myTrucks.Count(); i++)
            {
                Settings.DefaultItemsSettings mySettings = Settings.getDefaultItemsSettings();
                moveDefaultToTruck(mySettings.defaultItem1ID, mySettings.defaultItem1Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem2ID, mySettings.defaultItem2Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem3ID, mySettings.defaultItem3Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem4ID, mySettings.defaultItem4Quantity, myTrucks[i].trucknumber);

                moveDefaultToTruck(mySettings.defaultItem5ID, mySettings.defaultItem5Quantity, myTrucks[i].trucknumber);
                addToLog("Loaded Truck " + myTrucks[i].trucknumber + " with default inventory");
            }
            
            
            SQLMethods.insertSetting(Settings.keys.loadTruckDefaults, "1", true);

            if (TextSetting.truckInventoryReset == true)
            {
                sendTextMessage("Truck inventories have been loaded.");
            }
            refreshButtonStates();
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((rbSalesDate1.Checked || rbSalesDate1andDate2.Checked) && txtBeginningDate.Text == "")
            {
                MessageBox.Show("Invalid Date!");
                return;
            }
            if (rbSalesDate1andDate2.Checked && txtEndDate.Text == "")
            {
                MessageBox.Show("Invalid Date!");
                return;
            }
            SalesSpecifics specs = new SalesSpecifics();

            specs.date1 = txtBeginningDate.Text;
            specs.date2 = txtEndDate.Text;
            specs.truck = chkSalesTruck.Checked;
            specs.route = chkSalesRoute.Checked;
            specs.driver = chkSalesDriver.Checked;
            specs.item = chkSalesItem.Checked;
            specs.trucknumber = Convert.ToInt32(nudSalesTruck.Value);
            specs.routenumber = Convert.ToInt32(nudSalesRoute.Value);
            specs.drivernumber = Convert.ToInt32(nudSalesDriver.Value);
            specs.itemnumber = Convert.ToInt32(nudSalesItem.Value);

            if (rbSalesAnyDate.Checked)
            {
                specs.datetype = 0;
            }
            if (rbSalesDate1.Checked)
            {
                specs.datetype = 1;
            }
            if (rbSalesDate1andDate2.Checked)
            {
                specs.datetype = 2;
            }

            List<Sale> mySales = new List<Sale>();
            mySales = getAllSalesSpecific(specs);
            salesGridView1.Rows.Clear();
            double totalsales = 0;
            double totalprofit = 0;
            for (int i = 0; i < mySales.Count(); i++)
            {
                double profit = (mySales[i].quantity*mySales[i].saleprice) - (mySales[i].quantity*mySales[i].initialprice);
                double sales = (mySales[i].quantity*mySales[i].saleprice);
                totalprofit += profit;
                totalsales += sales;
                salesGridView1.Rows.Add(mySales[i].itemnumber, mySales[i].quantity, mySales[i].saledate, mySales[i].initialprice, mySales[i].saleprice, mySales[i].trucknumber, mySales[i].routenumber, mySales[i].drivernumber, sales, profit);
            }
            lblSales.Text = "Total Sales in Table: $" + totalsales;
            lblProfit.Text = "Total Profit in Table: $" + totalprofit;
        }

        private void txtBeginningDate_Click(object sender, EventArgs e)
        {
            DateSelect ds = new DateSelect();
            ds.ShowDialog();
            DateTime dtDate = ds.dateSelected;
            txtBeginningDate.Text = dtDate.ToString("yyyy-MM-dd");
        }

        private void txtEndDate_Click(object sender, EventArgs e)
        {
            DateSelect ds = new DateSelect();
            ds.ShowDialog();
            DateTime dtDate = ds.dateSelected;
            txtEndDate.Text = dtDate.ToString("yyyy-MM-dd");
        }

        private void btnRefreshCompanyInventory_Click(object sender, EventArgs e)
        {
            dgvCompanyInventory.Rows.Clear();
            List<InventoryItem> myInventory1 = new List<InventoryItem>();
            myInventory1 = getInventory();
            for (int i = 0; i < myInventory1.Count(); i++)
            {
                dgvCompanyInventory.Rows.Add(myInventory1[i].itemnumber, myInventory1[i].quantity, myInventory1[i].initialprice, myInventory1[i].saleprice, myInventory1[i].description);
            }
        }

        private void btnRefreshTruckInventory_Click(object sender, EventArgs e)
        {
            dgvTruckInventory.Rows.Clear();

            Dictionary<int, TruckInventoryItem> myInventory = new Dictionary<int, TruckInventoryItem>();
            int truckNum = Convert.ToInt32(nudTruckNumberInventory.Value);
            if (doesTruckExist(truckNum))
            {
                myInventory = getTruckInventory(truckNum);
                foreach (KeyValuePair<int, TruckInventoryItem> item in myInventory)
                {
                    dgvTruckInventory.Rows.Add(truckNum, item.Value.itemnumber, item.Value.quantity, item.Value.initialprice, item.Value.saleprice);
                }
            }
        }

        private int logLines = 0;
        private void timerLog_Tick(object sender, EventArgs e)
        {
            try
            {
                if (LogVariable.log.Count > logLines)
                {
                    rtbLog.Clear();
                    for (int i = 0; i < LogVariable.log.Count; i++)
                    {
                        rtbLog.AppendText(LogVariable.log[i]);
                    }
                    logLines = LogVariable.log.Count;
                    if (rtbLog.Text.Length > 2)
                    {
                        rtbLog.SelectionStart = rtbLog.Text.Length;
                        rtbLog.ScrollToCaret();
                    }
                }
            }
            catch { }
        }

        private void btnAssignTruckRouteDriver_Click(object sender, EventArgs e)
        {
            string[] file = new string[3];
            file[0] = "";
            file[2] = "";
            string trucknumber = Convert.ToInt32(nudAssignTrucknum.Value).ToString().PadLeft(4, '0');
            string routenumber = Convert.ToInt32(nudAssignRoutenum.Value).ToString().PadLeft(4, '0');
            string drivernumber = Convert.ToInt32(nudAssignDrivernum.Value).ToString().PadLeft(4, '0');
            file[1] = trucknumber + "" + routenumber + "" + drivernumber;
            processTruckRouteDriverUploadFileBody(file);
        }

        private void btnUpdateInventoryItem_Click(object sender, EventArgs e)
        {
            int itemnumber = Convert.ToInt32(nudCompanyInventoryItemNumber.Value);
            int quantity = Convert.ToInt32(nudCompanyInventoryQuantity.Value);
            double initialprice = Convert.ToDouble(nudCompanyInventoryIPrice.Value);
            double saleprice = Convert.ToDouble(nudCompanyInventorySPrice.Value);
            string description = txtCompanyInventoryDescription.Text;
            if (itemnumber != 0)
            {
                InventoryItem addItem = new InventoryItem(itemnumber, quantity, initialprice, saleprice, description);
                addInventoryItem(addItem);
            }
            else
            {
                addToLog("Item Number Can Not be 0");
            }

            dgvCompanyInventory.Rows.Clear();
            List<InventoryItem> myInventory1 = new List<InventoryItem>();
            myInventory1 = getInventory();
            for (int i = 0; i < myInventory1.Count(); i++)
            {
                dgvCompanyInventory.Rows.Add(myInventory1[i].itemnumber, myInventory1[i].quantity, myInventory1[i].initialprice, myInventory1[i].saleprice, myInventory1[i].description);
            }
        }

        private void btnTRDSearch_Click(object sender, EventArgs e)
        {
            dgvRouteCities.Rows.Clear();
            dgvTRD.Rows.Clear();
            int type = 0;
            int number = 0;
            if (rbTRDTruckNumber.Checked)
            {
                type = 0;
                number = Convert.ToInt32(nudTRDTruckNumber.Value);
            }
            if (rbTRDRouteNumber.Checked)
            {
                type = 1;
                number = Convert.ToInt32(nudTRDRouteNumber.Value);
            }
            if (rbTRDDriverNumber.Checked)
            {
                type = 2;
                number = Convert.ToInt32(nudTRDDriverNumber.Value);
            }
            TruckRouteDriver trd = getTRD(type, number);
            if (trd != null)
            {
                Route r = getRoute(trd.routenumber);
                dgvTRD.Rows.Add(trd.trucknumber, trd.routenumber, trd.drivernumber, r.cityLabels[0], r.cityLabels[1],
                    r.cityLabels[2], r.cityLabels[3], r.cityLabels[4], r.cityLabels[5], r.cityLabels[6], r.cityLabels[7],
                    r.cityLabels[8], r.cityLabels[9]);
                foreach (string s in r.cityLabels)
                {
                    if (s != null && s != "")
                    {
                        Zone z = getZone(s);
                        dgvRouteCities.Rows.Add(z.citylabel, z.cityname, z.state);
                    }
                }
            }
            
        }

        private void btnTRDShowAllRouteCities_Click(object sender, EventArgs e)
        {
            try {
                dgvRouteCities.Rows.Clear();
                dgvTRD.Rows.Clear();

                List<Route> allRoutes = getAllRoutes();
                foreach (Route route in allRoutes)
                {
                    string[] cityLabels = new string[10];
                    cityLabels[0] = "";
                    cityLabels[1] = "";
                    cityLabels[2] = "";
                    cityLabels[3] = "";
                    cityLabels[4] = "";
                    cityLabels[5] = "";
                    cityLabels[6] = "";
                    cityLabels[7] = "";
                    cityLabels[8] = "";
                    cityLabels[9] = "";

                    for (int i = 0; i < route.cityLabels.Length; i++)
                    {
                        cityLabels[i] = route.cityLabels[i];
                    }


                    TruckRouteDriver trd = getTRD(1, route.routenumber);
                    if (trd != null)
                    {
                        dgvTRD.Rows.Add(trd.trucknumber, trd.routenumber, trd.drivernumber, cityLabels[0], cityLabels[1],
                            cityLabels[2], cityLabels[3], cityLabels[4], cityLabels[5], cityLabels[6], cityLabels[7],
                            cityLabels[8], cityLabels[9]);
                    }
                    else
                    {
                        dgvTRD.Rows.Add(0, route.routenumber, 0, cityLabels[0], cityLabels[1],
                            cityLabels[2], cityLabels[3], cityLabels[4], cityLabels[5], cityLabels[6], cityLabels[7],
                            cityLabels[8], cityLabels[9]);
                    }
                }

                List<Zone> allZones = getAllZones();

                foreach (Zone zone in allZones)
                {
                    dgvRouteCities.Rows.Add(zone.citylabel, zone.cityname, zone.state);
                }

                dgvTrucks.Rows.Clear();
                List<Truck> allTrucks = getAllTrucks();
                foreach (Truck t in allTrucks)
                {
                    dgvTrucks.Rows.Add(t.trucknumber.ToString());
                }

                dgvDrivers.Rows.Clear();
                List<Driver> allDrivers = getAllDrivers();
                foreach (Driver d in allDrivers)
                {
                    dgvDrivers.Rows.Add(d.drivernumber.ToString());
                }
            }
            catch { }
        }

        private void btnTruckInventoryShowAll_Click(object sender, EventArgs e)
        {
            dgvTruckInventory.Rows.Clear();
            List<Truck> trucks = getAllTrucks();
            foreach (Truck t in trucks)
            {
                Dictionary<int, TruckInventoryItem> myInventory = new Dictionary<int, TruckInventoryItem>();
                myInventory = getTruckInventory(t.trucknumber);
                foreach (KeyValuePair<int, TruckInventoryItem> item in myInventory)
                {
                    dgvTruckInventory.Rows.Add(t.trucknumber, item.Value.itemnumber, item.Value.quantity, item.Value.initialprice, item.Value.saleprice);
                }
            }
        }

        private void btnEndDay_Click(object sender, EventArgs e)
        {
            SQLMethods.clearRTDAssignment();
            SQLMethods.clearAllTruckInventory();
            SQLMethods.insertSetting(Settings.keys.warehouseUploadFile, "0", true);
            SQLMethods.insertSetting(Settings.keys.truckRouteDriverUploadFile, "0", true);
            SQLMethods.insertSetting(Settings.keys.salesUploadFile, "0", true);
            SQLMethods.insertSetting(Settings.keys.loadTruckDefaults, "0", true);
            SQLMethods.insertSetting(Settings.keys.truckInventoryUploadFile, "0", true);
            
                
            SQLMethods.insertSetting(Settings.keys.dayStatus, "0", true);

            addToLog("Day has ended");

            if (TextSetting.autoOrderGenerated == true)
            {
                sendTextMessage("Auto Order has been generated.");
            }

            addToLog("Auto Order has been generated.");
            autoOrderForm.StartPosition = FormStartPosition.CenterParent;
            autoOrderForm.ShowDialog();
            refreshButtonStates();
        }

        private void btnSendOutTrucks_Click(object sender, EventArgs e)
        {
            SQLMethods.insertSetting(Settings.keys.dayStatus, "2", true);
            addToLog("Trucks have been sent out!");
            refreshButtonStates();
        }

        private void SettingsTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SettingsTab.SelectedIndex)
            {
                case 1:
                    dgvCompanyInventory.Rows.Clear();
                    List<InventoryItem> myInventory1 = new List<InventoryItem>();
                    myInventory1 = getInventory();
                    for (int i = 0; i < myInventory1.Count(); i++)
                    {
                        dgvCompanyInventory.Rows.Add(myInventory1[i].itemnumber, myInventory1[i].quantity, myInventory1[i].initialprice, myInventory1[i].saleprice, myInventory1[i].description);
                    }

                    dgvTruckInventory.Rows.Clear();
                    List<Truck> trucks = getAllTrucks();
                    foreach (Truck t in trucks)
                    {
                        Dictionary<int, TruckInventoryItem> myInventory = new Dictionary<int, TruckInventoryItem>();
                        myInventory = getTruckInventory(t.trucknumber);
                        foreach (KeyValuePair<int, TruckInventoryItem> item in myInventory)
                        {
                            dgvTruckInventory.Rows.Add(t.trucknumber, item.Value.itemnumber, item.Value.quantity, item.Value.initialprice, item.Value.saleprice);
                        }
                    }
                    break;
                case 2:

                    break;
                case 3:
                    try {
                        btnSearch.PerformClick();
                    }
                    catch { }
                    break;
            }
        }
    }
}
