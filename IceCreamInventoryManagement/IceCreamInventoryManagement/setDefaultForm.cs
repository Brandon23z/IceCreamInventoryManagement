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
            dataGridView1.Rows.Add(5);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void setDefault_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                DefaultOrder.ProductID[i] = Convert.ToString(dataGridView1.Rows[i].Cells["Column1"].Value);
                DefaultOrder.amount[i] = Convert.ToString(dataGridView1.Rows[i].Cells["Column2"].Value);
            }
            this.Close();
        }

        private void setDefaultForm_Load(object sender, EventArgs e)
        {
         
        }
    }
}
