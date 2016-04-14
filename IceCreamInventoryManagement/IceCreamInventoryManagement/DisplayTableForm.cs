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

namespace IceCreamInventoryManagement
{
    public partial class DisplayTableForm : Form
    {
        public DisplayTableForm()
        {
            InitializeComponent();
        }

        private void DisplayTableForm_Load(object sender, EventArgs e)
        {
            List<Zone> zoneList = getAllZones();
            if(zoneList != null)
            {
                foreach(Zone z in zoneList)
                {
                    dataGridView1.Rows.Add(z.citylabel, z.cityname, z.state);
                }
            }
            
        }
    }
}
