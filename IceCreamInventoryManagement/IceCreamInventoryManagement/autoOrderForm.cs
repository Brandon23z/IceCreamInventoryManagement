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

namespace IceCreamInventoryManagement
{
    public partial class autoOrderForm : Form
    {
        public autoOrderForm()
        {
            InitializeComponent();

            for (int i = 0; i < AutoOrder.ProductID.Count(); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = AutoOrder.ProductID[i];
                row.Cells[1].Value = AutoOrder.amount[i];
                dataGridView1.Rows.Add(row);
            }

        }

        private void autoOrderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
