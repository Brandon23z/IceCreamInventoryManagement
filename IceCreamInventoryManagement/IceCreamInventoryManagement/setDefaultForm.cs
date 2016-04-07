using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Close();
        }
    }
}
