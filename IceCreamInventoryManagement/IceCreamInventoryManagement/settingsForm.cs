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
using static IceCreamInventoryManagement.Settings;

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
            TextSetting.phoneNumber = txtPhoneNumber.Text;
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
            if (cboCarrier.SelectedIndex == 0)
                TextSetting.carrier = "@txt.att.net"; //AT & T
            if (cboCarrier.SelectedIndex == 1)
                TextSetting.carrier = "@vtext.com"; //Verizon
            if (cboCarrier.SelectedIndex == 2)
                TextSetting.carrier = "@messaging.sprintpcs.com"; //Sprint
            if (cboCarrier.SelectedIndex == 3)
                TextSetting.carrier = "@tmomail.net"; //T - Mobile
            if (cboCarrier.SelectedIndex == 4)
                TextSetting.carrier = "@vmobl.com"; //Virgin Mobile
            if (cboCarrier.SelectedIndex == 5)
                TextSetting.carrier = "@myboostmobile.com"; //Boost Mobile
            if (cboCarrier.SelectedIndex == 6)
                TextSetting.carrier = "@sms.mycricket.com"; //Cricket
            if (cboCarrier.SelectedIndex == 7)
                TextSetting.carrier = "@mymetropcs.com"; //Metro PCS
            if (cboCarrier.SelectedIndex == 8)
                TextSetting.carrier = "@mmst5.tracfone.com"; //Tracfone
            if (cboCarrier.SelectedIndex == 9)
                TextSetting.carrier = "@messaging.nextel.com"; //Nextel
        }

        private string[] carriers = { "@txt.att.net", "@vtext.com", "@messaging.sprintpcs.com", "@tmomail.net", "@vmobl.com", "@myboostmobile.com", "@sms.mycricket.com", "@mymetropcs.com", "@mmst5.tracfone.com" , "@messaging.nextel.com" };

        private int findCarrier(string c)
        {
            List<string> providers = carriers.ToList();
            int index = 0;
            foreach (string s in providers)
            {
                if (s.StartsWith(c)) { return index; }
                index ++;
            }
            return 0;
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            NotificationSettings settings = getNotificationSettings();
            truckInvReset.Checked = settings.notifTruckInventoryReset;
            dailyInvCalc.Checked = settings.notifDailyInventoryCalculated;
            itemAddedAutoOrder.Checked = settings.notifItemAddedToAutoOrder;
            autoOrderGen.Checked = settings.notifAutoOrderGenerated;
            txtPhoneNumber.Text = settings.notifPhoneNumber;
            cboCarrier.SelectedIndex = findCarrier(settings.notifCarrier);
            numericUpDown1.Value = settings.setDefaultQuantity;
        }

        private void setDefault_Click(object sender, EventArgs e)
        {
            NotificationSettings settings = new NotificationSettings();
            settings.notifTruckInventoryReset = truckInvReset.Checked;
            settings.notifDailyInventoryCalculated = dailyInvCalc.Checked;
            settings.notifItemAddedToAutoOrder = itemAddedAutoOrder.Checked;
            settings.notifAutoOrderGenerated = autoOrderGen.Checked;
            settings.notifPhoneNumber = txtPhoneNumber.Text;
            settings.notifCarrier = carriers[cboCarrier.SelectedIndex];
            int setDefaultQ = Convert.ToInt32(numericUpDown1.Value);
            settings.setDefaultQuantity = setDefaultQ;
            saveNotificationSettings(settings);
            this.Close();
        }
    }
}
