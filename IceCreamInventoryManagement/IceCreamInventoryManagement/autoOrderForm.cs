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
using static IceCreamInventoryManagement.SQLMethods;
using static IceCreamInventoryManagement.InputFileMethods;

namespace IceCreamInventoryManagement
{
    public partial class autoOrderForm : Form
    {
        public autoOrderForm()
        {
            InitializeComponent();
        }

        private void autoOrderForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SalesSpecifics specs = new SalesSpecifics();


            Settings.DaySettings daySettings = Settings.getDaySettings();

            specs.date1 = daySettings.currentDate.ToString();

            specs.datetype = 1;
            specs.driver = false;
            specs.route = false;
            specs.truck = false;
            specs.item = false;

            List<Sale> mySales = new List<Sale>();
            mySales = getAllSalesSpecific(specs);

            for (int i = 0; i < mySales.Count(); i++)
            {
                dataGridView1.Rows.Add(mySales[i].itemnumber, mySales[i].quantity);
            }


            List<InventoryItem> myInventory1 = new List<InventoryItem>();
            myInventory1 = getInventory();

            Settings.NotificationSettings settings = Settings.getNotificationSettings();

            int quantitySuggested = settings.setDefaultQuantity;

            for (int i = 0; i < myInventory1.Count(); i++)
            {
                if (myInventory1[i].quantity == 0 && myInventory1[i].saleprice == 0 && myInventory1[i].initialprice == 0)
                {
                    dataGridView1.Rows.Add(myInventory1[i].itemnumber, quantitySuggested);
                }
            }
        }
    }
}
