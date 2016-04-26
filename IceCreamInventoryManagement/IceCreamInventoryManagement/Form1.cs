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
            //clearDatabase();
            Settings.saveDefaults(false);
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

            //refresh datagridview
            refreshZonesView();
            refreshRoutesView();
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

            SQLMethods.insertSetting(Settings.keys.routeUploadFile, "1", true);

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


            if (TextSetting.autoOrderGenerated == true)
            {
                sendTextMessage("Auto Order has been generated.");
            }

            addToLog("Auto Order has been generated.");
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
                sendTextMessage("Customer Requests added to Automatic Order List");
                addToLog("Text Message Sent: " + "Customer Requests added to Automatic Order List");
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
            for (int i = 0; i < mySales.Count(); i++)
            {
                salesGridView1.Rows.Add(mySales[i].itemnumber, mySales[i].quantity, mySales[i].saledate, mySales[i].initialprice, mySales[i].saleprice, mySales[i].trucknumber, mySales[i].routenumber, mySales[i].drivernumber);
            }
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
            InventoryItem addItem = new InventoryItem(itemnumber, quantity, initialprice, saleprice, description);
            addInventoryItem(addItem);

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
            /*
            dgvRouteCities.Rows.Clear();
            dgvTRD.Rows.Clear();
            int type = 0;
            int number = 0;
            get
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
            */
        }

        private void btnTruckInventoryShowAll_Click(object sender, EventArgs e)
        {
            dgvTruckInventory.Rows.Clear();
            List<Truck> trucks = getAllTrucks();
            foreach (Truck t in trucks)
            {
                Dictionary<int, TruckInventoryItem> myInventory = new Dictionary<int, TruckInventoryItem>();
                int truckNum = Convert.ToInt32(nudTruckNumberInventory.Value);
                myInventory = getTruckInventory(truckNum);
                foreach (KeyValuePair<int, TruckInventoryItem> item in myInventory)
                {
                    dgvTruckInventory.Rows.Add(truckNum, item.Value.itemnumber, item.Value.quantity, item.Value.initialprice, item.Value.saleprice);
                }
            }
        }
    }
}
