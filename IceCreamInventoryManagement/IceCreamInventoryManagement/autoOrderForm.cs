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
            SalesSpecifics specs = new SalesSpecifics();


            Settings.DaySettings daySettings = Settings.getDaySettings();

            specs.date1 = daySettings.currentDate.ToString();

            specs.datetype = 1;

            List<Sale> mySales = new List<Sale>();
            mySales = getAllSalesSpecific(specs);

            for (int i = 0; i < mySales.Count(); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = mySales[i].itemnumber;
                row.Cells[1].Value = mySales[i].quantity;
                dataGridView1.Rows.Add(row);
            }

            List<Sale> mySales1 = new List<Sale>();
            mySales1 = getAllSales();

            Settings.NotificationSettings settings = Settings.getNotificationSettings();

            int quantitySuggested = settings.setDefaultQuantity;

            for (int i = 0; i < mySales1.Count(); i++)
            {
                if (mySales1[i].quantity == 0 && mySales1[i].saleprice == 0 && mySales1[i].initialprice == 0)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = mySales1[i].itemnumber;
                    row.Cells[1].Value = quantitySuggested;
                    dataGridView1.Rows.Add(row);
                }
            }
        }
    }
}
