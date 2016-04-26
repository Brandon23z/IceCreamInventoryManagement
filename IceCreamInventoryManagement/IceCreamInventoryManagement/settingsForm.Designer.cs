namespace IceCreamInventoryManagement
{
    partial class settingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.truckInvReset = new System.Windows.Forms.CheckBox();
            this.dailyInvCalc = new System.Windows.Forms.CheckBox();
            this.itemAddedAutoOrder = new System.Windows.Forms.CheckBox();
            this.autoOrderGen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCarrier = new System.Windows.Forms.ComboBox();
            this.setDefault = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // truckInvReset
            // 
            this.truckInvReset.AutoSize = true;
            this.truckInvReset.Location = new System.Drawing.Point(12, 33);
            this.truckInvReset.Name = "truckInvReset";
            this.truckInvReset.Size = new System.Drawing.Size(132, 17);
            this.truckInvReset.TabIndex = 1;
            this.truckInvReset.Text = "Truck Inventory Reset";
            this.truckInvReset.UseVisualStyleBackColor = true;
            this.truckInvReset.CheckedChanged += new System.EventHandler(this.truckInvReset_CheckedChanged);
            // 
            // dailyInvCalc
            // 
            this.dailyInvCalc.AutoSize = true;
            this.dailyInvCalc.Location = new System.Drawing.Point(13, 57);
            this.dailyInvCalc.Name = "dailyInvCalc";
            this.dailyInvCalc.Size = new System.Drawing.Size(149, 17);
            this.dailyInvCalc.TabIndex = 2;
            this.dailyInvCalc.Text = "Daily Inventory Calculated";
            this.dailyInvCalc.UseVisualStyleBackColor = true;
            this.dailyInvCalc.CheckedChanged += new System.EventHandler(this.dailyInvCalc_CheckedChanged);
            // 
            // itemAddedAutoOrder
            // 
            this.itemAddedAutoOrder.AutoSize = true;
            this.itemAddedAutoOrder.Location = new System.Drawing.Point(13, 80);
            this.itemAddedAutoOrder.Name = "itemAddedAutoOrder";
            this.itemAddedAutoOrder.Size = new System.Drawing.Size(218, 17);
            this.itemAddedAutoOrder.TabIndex = 3;
            this.itemAddedAutoOrder.Text = "Customer Requests Added to Auto Order";
            this.itemAddedAutoOrder.UseVisualStyleBackColor = true;
            this.itemAddedAutoOrder.CheckedChanged += new System.EventHandler(this.itemAddedAutoOrder_CheckedChanged);
            // 
            // autoOrderGen
            // 
            this.autoOrderGen.AutoSize = true;
            this.autoOrderGen.Location = new System.Drawing.Point(12, 103);
            this.autoOrderGen.Name = "autoOrderGen";
            this.autoOrderGen.Size = new System.Drawing.Size(130, 17);
            this.autoOrderGen.TabIndex = 4;
            this.autoOrderGen.Text = "Auto Order Generated";
            this.autoOrderGen.UseVisualStyleBackColor = true;
            this.autoOrderGen.CheckedChanged += new System.EventHandler(this.autoOrderGen_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Text Notifications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phone Number: ";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(15, 151);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPhoneNumber.TabIndex = 7;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Carrier: ";
            // 
            // cboCarrier
            // 
            this.cboCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarrier.FormattingEnabled = true;
            this.cboCarrier.Items.AddRange(new object[] {
            "AT&T",
            "Verizon",
            "Sprint",
            "T-Mobile",
            "Virgin Mobile",
            "Boost Mobile",
            "Cricket",
            "Metro PCS",
            "Tracfone",
            "Nextel"});
            this.cboCarrier.Location = new System.Drawing.Point(131, 150);
            this.cboCarrier.Name = "cboCarrier";
            this.cboCarrier.Size = new System.Drawing.Size(121, 21);
            this.cboCarrier.TabIndex = 10;
            this.cboCarrier.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // setDefault
            // 
            this.setDefault.Location = new System.Drawing.Point(12, 226);
            this.setDefault.Name = "setDefault";
            this.setDefault.Size = new System.Drawing.Size(240, 23);
            this.setDefault.TabIndex = 11;
            this.setDefault.Text = "Save Settings";
            this.setDefault.UseVisualStyleBackColor = true;
            this.setDefault.Click += new System.EventHandler(this.setDefault_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = " Amount for Requested Products: ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(16, 201);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 13;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 257);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setDefault);
            this.Controls.Add(this.cboCarrier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoOrderGen);
            this.Controls.Add(this.itemAddedAutoOrder);
            this.Controls.Add(this.dailyInvCalc);
            this.Controls.Add(this.truckInvReset);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox truckInvReset;
        private System.Windows.Forms.CheckBox dailyInvCalc;
        private System.Windows.Forms.CheckBox itemAddedAutoOrder;
        private System.Windows.Forms.CheckBox autoOrderGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCarrier;
        private System.Windows.Forms.Button setDefault;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}