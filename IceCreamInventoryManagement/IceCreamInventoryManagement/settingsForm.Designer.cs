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
            this.truckInvReset = new System.Windows.Forms.CheckBox();
            this.dailyInvCalc = new System.Windows.Forms.CheckBox();
            this.itemAddedAutoOrder = new System.Windows.Forms.CheckBox();
            this.autoOrderGen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.itemAddedAutoOrder.Size = new System.Drawing.Size(146, 17);
            this.itemAddedAutoOrder.TabIndex = 3;
            this.itemAddedAutoOrder.Text = "Item Added to Auto Order";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
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
            this.comboBox1.Location = new System.Drawing.Point(131, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoOrderGen);
            this.Controls.Add(this.itemAddedAutoOrder);
            this.Controls.Add(this.dailyInvCalc);
            this.Controls.Add(this.truckInvReset);
            this.Name = "settingsForm";
            this.Text = "settingsForm";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}