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

namespace IceCreamInventoryManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCityUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] cityUploadFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cityUploadFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
            }

            regexClass r = checkRegex(cityUploadFile[0], @"^(HD) (\d\d\d\d)      (\d{4}-\d{2}-\d{2})( )*$");
            if (r.valid)
            {
                string seqNum = r.groupValues[2];
                string dateString = r.groupValues[3];
                DateTime date = DateTime.Parse(dateString);
            }

            r = checkRegex(cityUploadFile[cityUploadFile.Length - 1], @"^(T) (\d\d\d\d)( )*$");

            int numOfRows = 0;
            string[] cityLabels = { "" };
            string[] cityNames = { "" };
            string[] states = { "" };

            if (r.valid)
            {
                string numOfRowsString = r.groupValues[2];
                numOfRows = Int32.Parse(numOfRowsString); 
            }

            for (int i = 1; i < numOfRows; i++)
            {
                r = checkRegex(cityUploadFile[i], @"^(.{20})(.{20})(.{2})( )*$");
                if (r.valid)
                {
                    cityLabels[i - 1] = r.groupValues[1];
                    cityNames[i - 1] = r.groupValues[2];
                    states[i - 1] = r.groupValues[3];
                }
            }
            string x = "change";

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
            }
        }

        private void btnTruckUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select an Input File";

            string[] inventoryUpdateFile = { "" };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inventoryUpdateFile = System.IO.File.ReadAllLines(openFileDialog1.FileName.ToString());
            }
        }
    }
}




//string input = "HD 0103      2016-03-01";
//regexClass r = checkRegex(input, @"^(HD) (\d\d\d\d)      (\d{4}-\d{2}-\d{2})");
//            if (r.valid)
//            {
//                MessageBox.Show("Header is valid");
//                string sequence = r.groupValues[2];
//string dateString = r.groupValues[3];
//DateTime date = DateTime.Parse(dateString);
//            }
//            else
//            {
//                MessageBox.Show("Header is invalid");
//            }

/*
//UNIVERSAL HEADER//
    HD 0103      2016-03-01
    ^(HD) (\d\d\d\d)      (\d{4}-\d{2}-\d{2})( )*$

//UNIVERSAL TRAILER//
    T 0003
    ^(T) (\d\d\d\d)( )*$

//CITY UPLOAD//
    Dearborn 1          Dearborn            MI          
    ^(.{20})(.{20})(.{2})( )*$                

//LOAD ICE CREAM TRUCK//
    TR |Truck Number|
    ^(TR) (\d\d\d\d)( )*$

    |Item Number||Adjustment Quantity|
    ^(\d\d\d\d)(((\d)|-)\d\d\d)( )*$

//LOAD ICE CREAM TRUCK SALES//



//LOAD INVENTORY UPDATE//


//LOAD TRUCK ROUTE//


//ROUTE UPLOAD//


//TRUCK UPLOAD//


*/