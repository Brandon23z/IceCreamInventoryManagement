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

        private void btnTestRegex_Click(object sender, EventArgs e)
        {
            string input = "HD 0103      2016-03-01";
            regexClass r = checkRegex(input, @"^(HD) (\d\d\d\d)      (\d{4}-\d{2}-\d{2})");
            if (r.valid)
            {
                MessageBox.Show("Header is valid");
                string sequence = r.groupValues[2];
                string dateString = r.groupValues[3];
                DateTime date = DateTime.Parse(dateString);
            }
            else
            {
                MessageBox.Show("Header is invalid");
            }
        }
    }
}
