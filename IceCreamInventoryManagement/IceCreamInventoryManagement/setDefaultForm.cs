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
    public partial class setDefaultForm : Form
    {
        public setDefaultForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
            this.Close();
        }

        private void setDefaultForm_Load(object sender, EventArgs e)
        {
         
        }
    }
}
