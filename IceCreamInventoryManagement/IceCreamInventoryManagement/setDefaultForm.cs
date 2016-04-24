using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IceCreamInventoryManagement.ourClasses;
using static IceCreamInventoryManagement.Settings;

namespace IceCreamInventoryManagement
{
    public partial class setDefaultForm : Form
    {
        public setDefaultForm()
        {
            InitializeComponent();
            nudItem1Product.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem1Quantity.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem2Product.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem2Quantity.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem3Product.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem3Quantity.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem4Product.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem4Quantity.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem5Product.Click += new System.EventHandler(this.NumericUpDown_Click);
            nudItem5Quantity.Click += new System.EventHandler(this.NumericUpDown_Click);
        }

        private void NumericUpDown_Click(object sender, EventArgs e)
        {
            NumericUpDown nud = ((NumericUpDown)sender);
            nud.Select(0, 4);
        }

        private void setDefault_Click(object sender, EventArgs e)
        {
            DefaultItem[] defaultA = new DefaultItem[5];
            defaultA[0] = new DefaultItem(Convert.ToInt32(nudItem1Product.Value), Convert.ToInt32(nudItem1Quantity.Value));
            defaultA[1] = new DefaultItem(Convert.ToInt32(nudItem2Product.Value), Convert.ToInt32(nudItem2Quantity.Value));
            defaultA[2] = new DefaultItem(Convert.ToInt32(nudItem3Product.Value), Convert.ToInt32(nudItem3Quantity.Value));
            defaultA[3] = new DefaultItem(Convert.ToInt32(nudItem4Product.Value), Convert.ToInt32(nudItem4Quantity.Value));
            defaultA[4] = new DefaultItem(Convert.ToInt32(nudItem5Product.Value), Convert.ToInt32(nudItem5Quantity.Value));
            string value = nudItem1Product.Value.ToString() + ":" + nudItem1Quantity.Value.ToString();
            DefaultOrder.defaults = defaultA;

            DefaultItemsSettings settings = new DefaultItemsSettings();
            settings.defaultItem1ID = Convert.ToInt32(nudItem1Product.Value);
            settings.defaultItem1Quantity = Convert.ToInt32(nudItem1Quantity.Value);
            settings.defaultItem2ID = Convert.ToInt32(nudItem2Product.Value);
            settings.defaultItem2Quantity = Convert.ToInt32(nudItem2Quantity.Value);
            settings.defaultItem3ID = Convert.ToInt32(nudItem3Product.Value);
            settings.defaultItem3Quantity = Convert.ToInt32(nudItem3Quantity.Value);
            settings.defaultItem4ID = Convert.ToInt32(nudItem4Product.Value);
            settings.defaultItem4Quantity = Convert.ToInt32(nudItem4Quantity.Value);
            settings.defaultItem5ID = Convert.ToInt32(nudItem5Product.Value);
            settings.defaultItem5Quantity = Convert.ToInt32(nudItem5Quantity.Value);
            saveDefaultItemsSettings(settings);
            this.Close();
        }
        //needs error handling

        private void setDefaultForm_Load(object sender, EventArgs e)
        {
            DefaultItemsSettings settings = getDefaultItemsSettings();
            nudItem1Product.Value = settings.defaultItem1ID;
            nudItem1Quantity.Value = settings.defaultItem1Quantity;
            nudItem2Product.Value = settings.defaultItem2ID;
            nudItem2Quantity.Value = settings.defaultItem2Quantity;
            nudItem3Product.Value = settings.defaultItem3ID;
            nudItem3Quantity.Value = settings.defaultItem3Quantity;
            nudItem4Product.Value = settings.defaultItem4ID;
            nudItem4Quantity.Value = settings.defaultItem4Quantity;
            nudItem5Product.Value = settings.defaultItem5ID;
            nudItem5Quantity.Value = settings.defaultItem5Quantity;
        }
    }
}
