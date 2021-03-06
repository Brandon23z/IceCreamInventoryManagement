﻿using System;
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
    public partial class logForm : Form
    {
        public logForm()
        {
            InitializeComponent();
        }

        private void logForm_Load(object sender, EventArgs e)
        {
          
            for (int i = 0; i < LogVariable.log.Count; i++)
            {
                richTextBox1.AppendText(LogVariable.log[i]);
            }
        }

        private void logForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            richTextBox1.Clear();
        }

        private List<string> lastLog = new List<string>();
        private void timerRefreshLog_Tick(object sender, EventArgs e)
        {
            if (lastLog.Count != LogVariable.log.Count)
            {
                richTextBox1.Clear();
                for (int i = 0; i < LogVariable.log.Count; i++)
                {
                    richTextBox1.AppendText(LogVariable.log[i]);
                }
                lastLog = new List<string>(LogVariable.log);
            }
        }
    }
}
