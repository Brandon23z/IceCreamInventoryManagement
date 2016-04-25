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
    public partial class DateSelect : Form
    {

        public DateTime dateSelected;
        public DateSelect()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DateTime selected = monthCalendar1.SelectionStart;
            dateSelected = selected;
            this.Close();
        }
    }
}
