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

            DisplayTableForm d = new DisplayTableForm();
            d.Show();

        }

        private void btnRouteUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] routeUploadFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                routeUploadFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Route Upload File Read");
            }
        }

        private void btnIceCreamFromTrucks_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] salesFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                salesFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Sales File Read");
            }
        }

        private void btnIceCreamToTrucks_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] iceCreamtoTrucksFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                iceCreamtoTrucksFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Ice Cream to Trucks File Read");
            }
        }

        private void btnTruckRouteUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] truckRouteFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                truckRouteFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Truck-Route File Read"); 
            }
        }

        private void btnInventoryUpdate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] inventoryUpdateFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inventoryUpdateFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Inventory Update File Read");
            }
        }

        private void btnTruckUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] truckUploadFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                truckUploadFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
                addToLog("Truck Upload File Read");
            }
        }

        setDefaultForm secondForm = new setDefaultForm();
        settingsForm thirdForm = new settingsForm();
        logForm fourthForm = new logForm();

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            secondForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            thirdForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fourthForm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}