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
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextSetting.phoneNumber = textBox1.Text;
        }

        private void truckInvReset_CheckedChanged(object sender, EventArgs e)
        {
            if (truckInvReset.Checked == true)
                TextSetting.truckInventoryReset = true;
            if (truckInvReset.Checked == false)
                TextSetting.truckInventoryReset = false;
        }

        private void dailyInvCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (dailyInvCalc.Checked == true)
                TextSetting.dailyInventoryCalculated = true;
            if (dailyInvCalc.Checked == false)
                TextSetting.dailyInventoryCalculated = false;
        }
        private void itemAddedAutoOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (itemAddedAutoOrder.Checked == true)
                TextSetting.itemAddedToAutoOrder = true;
            if (itemAddedAutoOrder.Checked == false)
                TextSetting.itemAddedToAutoOrder = false;
        }

        private void autoOrderGen_CheckedChanged(object sender, EventArgs e)
        {
            if (autoOrderGen.Checked == true)
                TextSetting.autoOrderGenerated = true;
            if (autoOrderGen.Checked == false)
                TextSetting.autoOrderGenerated = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                TextSetting.carrier = "@txt.att.net"; //AT & T
            if (comboBox1.SelectedIndex == 1)
                TextSetting.carrier = "@vtext.com"; //Verizon
            if (comboBox1.SelectedIndex == 2)
                TextSetting.carrier = "@messaging.sprintpcs.com"; //Sprint
            if (comboBox1.SelectedIndex == 3)
                TextSetting.carrier = "@tmomail.net"; //T - Mobile
            if (comboBox1.SelectedIndex == 4)
                TextSetting.carrier = "@vmobl.com"; //Virgin Mobile
            if (comboBox1.SelectedIndex == 5)
                TextSetting.carrier = "@myboostmobile.com"; //Boost Mobile
            if (comboBox1.SelectedIndex == 6)
                TextSetting.carrier = "@sms.mycricket.com"; //Cricket
            if (comboBox1.SelectedIndex == 7)
                TextSetting.carrier = "@mymetropcs.com"; //Metro PCS
            if (comboBox1.SelectedIndex == 8)
                TextSetting.carrier = "@mmst5.tracfone.com"; //Tracfone
            if (comboBox1.SelectedIndex == 9)
                TextSetting.carrier = "@messaging.nextel.com"; //Nextel
        }

    }
}
