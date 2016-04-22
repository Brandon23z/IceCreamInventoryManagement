namespace IceCreamInventoryManagement
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRouteUpload = new System.Windows.Forms.Button();
            this.btnTruckUpload = new System.Windows.Forms.Button();
            this.btnTruckRouteUpload = new System.Windows.Forms.Button();
            this.btnChangeTruckInventory = new System.Windows.Forms.Button();
            this.btnIceCreamFromTrucks = new System.Windows.Forms.Button();
            this.btnInventoryUpdate = new System.Windows.Forms.Button();
            this.btnCityUpload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDriverUpload = new System.Windows.Forms.Button();
            this.btnAutoOrder = new System.Windows.Forms.Button();
            this.btnLoadIceCreamToTrucks = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCustomerRequests = new System.Windows.Forms.Button();
            this.zoneGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeGridView = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.truckGridView = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverGridView = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleGridView = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryGridView = new System.Windows.Forms.DataGridView();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.truckInventoryGridView = new System.Windows.Forms.DataGridView();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.zoneGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.truckGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.truckInventoryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Load City Upload File: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Load Route Upload File: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Load Truck Upload File: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Load Truck-Route Upload File: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Change Truck Inventory: ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Load Inventory Update File: ";
            // 
            // btnRouteUpload
            // 
            this.btnRouteUpload.Location = new System.Drawing.Point(741, 63);
            this.btnRouteUpload.Name = "btnRouteUpload";
            this.btnRouteUpload.Size = new System.Drawing.Size(75, 23);
            this.btnRouteUpload.TabIndex = 8;
            this.btnRouteUpload.Text = "Browse";
            this.btnRouteUpload.UseVisualStyleBackColor = true;
            this.btnRouteUpload.Click += new System.EventHandler(this.btnRouteUpload_Click);
            // 
            // btnTruckUpload
            // 
            this.btnTruckUpload.Location = new System.Drawing.Point(741, 101);
            this.btnTruckUpload.Name = "btnTruckUpload";
            this.btnTruckUpload.Size = new System.Drawing.Size(75, 23);
            this.btnTruckUpload.TabIndex = 9;
            this.btnTruckUpload.Text = "Browse";
            this.btnTruckUpload.UseVisualStyleBackColor = true;
            this.btnTruckUpload.Click += new System.EventHandler(this.btnTruckUpload_Click);
            // 
            // btnTruckRouteUpload
            // 
            this.btnTruckRouteUpload.Location = new System.Drawing.Point(210, 58);
            this.btnTruckRouteUpload.Name = "btnTruckRouteUpload";
            this.btnTruckRouteUpload.Size = new System.Drawing.Size(75, 23);
            this.btnTruckRouteUpload.TabIndex = 10;
            this.btnTruckRouteUpload.Text = "Browse";
            this.btnTruckRouteUpload.UseVisualStyleBackColor = true;
            this.btnTruckRouteUpload.Click += new System.EventHandler(this.btnTruckRouteUpload_Click);
            // 
            // btnChangeTruckInventory
            // 
            this.btnChangeTruckInventory.Location = new System.Drawing.Point(459, 25);
            this.btnChangeTruckInventory.Name = "btnChangeTruckInventory";
            this.btnChangeTruckInventory.Size = new System.Drawing.Size(75, 23);
            this.btnChangeTruckInventory.TabIndex = 11;
            this.btnChangeTruckInventory.Text = "Browse";
            this.btnChangeTruckInventory.UseVisualStyleBackColor = true;
            this.btnChangeTruckInventory.Click += new System.EventHandler(this.btnChangeTruckInventory_Click);
            // 
            // btnIceCreamFromTrucks
            // 
            this.btnIceCreamFromTrucks.Location = new System.Drawing.Point(210, 128);
            this.btnIceCreamFromTrucks.Name = "btnIceCreamFromTrucks";
            this.btnIceCreamFromTrucks.Size = new System.Drawing.Size(75, 23);
            this.btnIceCreamFromTrucks.TabIndex = 12;
            this.btnIceCreamFromTrucks.Text = "Browse";
            this.btnIceCreamFromTrucks.UseVisualStyleBackColor = true;
            this.btnIceCreamFromTrucks.Click += new System.EventHandler(this.btnIceCreamFromTrucks_Click);
            // 
            // btnInventoryUpdate
            // 
            this.btnInventoryUpdate.Location = new System.Drawing.Point(210, 22);
            this.btnInventoryUpdate.Name = "btnInventoryUpdate";
            this.btnInventoryUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnInventoryUpdate.TabIndex = 13;
            this.btnInventoryUpdate.Text = "Browse";
            this.btnInventoryUpdate.UseVisualStyleBackColor = true;
            this.btnInventoryUpdate.Click += new System.EventHandler(this.btnInventoryUpdate_Click);
            // 
            // btnCityUpload
            // 
            this.btnCityUpload.Location = new System.Drawing.Point(741, 25);
            this.btnCityUpload.Name = "btnCityUpload";
            this.btnCityUpload.Size = new System.Drawing.Size(75, 23);
            this.btnCityUpload.TabIndex = 14;
            this.btnCityUpload.Text = "Browse";
            this.btnCityUpload.UseVisualStyleBackColor = true;
            this.btnCityUpload.Click += new System.EventHandler(this.btnCityUpload_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Calculate Sales of Day:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.Location = new System.Drawing.Point(354, 79);
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(138, 23);
            this.btnSetDefault.TabIndex = 16;
            this.btnSetDefault.Text = "Set Default Inventory";
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(389, 118);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 17;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(580, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Load Driver Upload File: ";
            // 
            // btnDriverUpload
            // 
            this.btnDriverUpload.Location = new System.Drawing.Point(741, 138);
            this.btnDriverUpload.Name = "btnDriverUpload";
            this.btnDriverUpload.Size = new System.Drawing.Size(75, 23);
            this.btnDriverUpload.TabIndex = 21;
            this.btnDriverUpload.Text = "Browse";
            this.btnDriverUpload.UseVisualStyleBackColor = true;
            this.btnDriverUpload.Click += new System.EventHandler(this.btnDriverUpload_Click);
            // 
            // btnAutoOrder
            // 
            this.btnAutoOrder.Location = new System.Drawing.Point(390, 195);
            this.btnAutoOrder.Name = "btnAutoOrder";
            this.btnAutoOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAutoOrder.TabIndex = 22;
            this.btnAutoOrder.Text = "Auto Order";
            this.btnAutoOrder.UseVisualStyleBackColor = true;
            this.btnAutoOrder.Click += new System.EventHandler(this.btnAutoOrder_Click);
            // 
            // btnLoadIceCreamToTrucks
            // 
            this.btnLoadIceCreamToTrucks.Location = new System.Drawing.Point(99, 96);
            this.btnLoadIceCreamToTrucks.Name = "btnLoadIceCreamToTrucks";
            this.btnLoadIceCreamToTrucks.Size = new System.Drawing.Size(153, 23);
            this.btnLoadIceCreamToTrucks.TabIndex = 23;
            this.btnLoadIceCreamToTrucks.Text = "Load Ice Cream to Trucks";
            this.btnLoadIceCreamToTrucks.UseVisualStyleBackColor = true;
            this.btnLoadIceCreamToTrucks.Click += new System.EventHandler(this.btnLoadIceCreamToTrucks_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Load Customer Requests: ";
            // 
            // btnCustomerRequests
            // 
            this.btnCustomerRequests.Location = new System.Drawing.Point(210, 163);
            this.btnCustomerRequests.Name = "btnCustomerRequests";
            this.btnCustomerRequests.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerRequests.TabIndex = 25;
            this.btnCustomerRequests.Text = "Browse";
            this.btnCustomerRequests.UseVisualStyleBackColor = true;
            this.btnCustomerRequests.Click += new System.EventHandler(this.btnCustomerRequests_Click);
            // 
            // zoneGridView
            // 
            this.zoneGridView.AllowUserToAddRows = false;
            this.zoneGridView.AllowUserToDeleteRows = false;
            this.zoneGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zoneGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.zoneGridView.Location = new System.Drawing.Point(34, 264);
            this.zoneGridView.Name = "zoneGridView";
            this.zoneGridView.ReadOnly = true;
            this.zoneGridView.Size = new System.Drawing.Size(344, 150);
            this.zoneGridView.TabIndex = 26;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "City Label";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "City Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "State";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // routeGridView
            // 
            this.routeGridView.AllowUserToAddRows = false;
            this.routeGridView.AllowUserToDeleteRows = false;
            this.routeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.routeGridView.Location = new System.Drawing.Point(34, 443);
            this.routeGridView.Name = "routeGridView";
            this.routeGridView.ReadOnly = true;
            this.routeGridView.Size = new System.Drawing.Size(645, 165);
            this.routeGridView.TabIndex = 27;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Route Number";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "City Label 1";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "City Label 2";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "City Label 3";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "City Label 4";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "City Label 5";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // truckGridView
            // 
            this.truckGridView.AllowUserToAddRows = false;
            this.truckGridView.AllowUserToDeleteRows = false;
            this.truckGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.truckGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11});
            this.truckGridView.Location = new System.Drawing.Point(418, 264);
            this.truckGridView.Name = "truckGridView";
            this.truckGridView.ReadOnly = true;
            this.truckGridView.Size = new System.Drawing.Size(244, 150);
            this.truckGridView.TabIndex = 28;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Truck Number";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Route Number";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // driverGridView
            // 
            this.driverGridView.AllowUserToAddRows = false;
            this.driverGridView.AllowUserToDeleteRows = false;
            this.driverGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.driverGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column13});
            this.driverGridView.Location = new System.Drawing.Point(697, 264);
            this.driverGridView.Name = "driverGridView";
            this.driverGridView.ReadOnly = true;
            this.driverGridView.Size = new System.Drawing.Size(246, 150);
            this.driverGridView.TabIndex = 29;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Driver Number";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Truck number";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // saleGridView
            // 
            this.saleGridView.AllowUserToAddRows = false;
            this.saleGridView.AllowUserToDeleteRows = false;
            this.saleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.Column17,
            this.Column15,
            this.Column16,
            this.Column18,
            this.Column19,
            this.Column20});
            this.saleGridView.Location = new System.Drawing.Point(12, 628);
            this.saleGridView.Name = "saleGridView";
            this.saleGridView.ReadOnly = true;
            this.saleGridView.Size = new System.Drawing.Size(745, 150);
            this.saleGridView.TabIndex = 30;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Item Number";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Quantity";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Initial Price";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Sale Price";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Truck Number";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Driver Number";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "Route Number";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // inventoryGridView
            // 
            this.inventoryGridView.AllowUserToAddRows = false;
            this.inventoryGridView.AllowUserToDeleteRows = false;
            this.inventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24});
            this.inventoryGridView.Location = new System.Drawing.Point(697, 443);
            this.inventoryGridView.Name = "inventoryGridView";
            this.inventoryGridView.ReadOnly = true;
            this.inventoryGridView.Size = new System.Drawing.Size(445, 150);
            this.inventoryGridView.TabIndex = 31;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "Item Number";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "Quantity";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            // 
            // Column23
            // 
            this.Column23.HeaderText = "Initial Price";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            // 
            // Column24
            // 
            this.Column24.HeaderText = "Sale Price";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            // 
            // truckInventoryGridView
            // 
            this.truckInventoryGridView.AllowUserToAddRows = false;
            this.truckInventoryGridView.AllowUserToDeleteRows = false;
            this.truckInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.truckInventoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column25,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.truckInventoryGridView.Location = new System.Drawing.Point(763, 628);
            this.truckInventoryGridView.Name = "truckInventoryGridView";
            this.truckInventoryGridView.ReadOnly = true;
            this.truckInventoryGridView.Size = new System.Drawing.Size(522, 150);
            this.truckInventoryGridView.TabIndex = 32;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "Truck Number";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Item Number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Initial Price";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Sale Price";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 802);
            this.Controls.Add(this.truckInventoryGridView);
            this.Controls.Add(this.inventoryGridView);
            this.Controls.Add(this.saleGridView);
            this.Controls.Add(this.driverGridView);
            this.Controls.Add(this.truckGridView);
            this.Controls.Add(this.routeGridView);
            this.Controls.Add(this.zoneGridView);
            this.Controls.Add(this.btnCustomerRequests);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnLoadIceCreamToTrucks);
            this.Controls.Add(this.btnAutoOrder);
            this.Controls.Add(this.btnDriverUpload);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnSetDefault);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCityUpload);
            this.Controls.Add(this.btnInventoryUpdate);
            this.Controls.Add(this.btnIceCreamFromTrucks);
            this.Controls.Add(this.btnChangeTruckInventory);
            this.Controls.Add(this.btnTruckRouteUpload);
            this.Controls.Add(this.btnTruckUpload);
            this.Controls.Add(this.btnRouteUpload);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoneGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.truckGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.truckInventoryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRouteUpload;
        private System.Windows.Forms.Button btnTruckUpload;
        private System.Windows.Forms.Button btnTruckRouteUpload;
        private System.Windows.Forms.Button btnChangeTruckInventory;
        private System.Windows.Forms.Button btnIceCreamFromTrucks;
        private System.Windows.Forms.Button btnInventoryUpdate;
        private System.Windows.Forms.Button btnCityUpload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetDefault;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDriverUpload;
        private System.Windows.Forms.Button btnAutoOrder;
        private System.Windows.Forms.Button btnLoadIceCreamToTrucks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCustomerRequests;
        private System.Windows.Forms.DataGridView zoneGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView routeGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridView truckGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridView driverGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridView saleGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridView inventoryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridView truckInventoryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}

