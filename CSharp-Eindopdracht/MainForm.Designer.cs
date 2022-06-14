namespace CSharp_Eindopdracht2
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.taxiTab = new System.Windows.Forms.TabPage();
            this.averageDistanceLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.totalIncomeLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.longestRideLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.taxiIDLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rideAddButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dayBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteTaxiButton = new System.Windows.Forms.Button();
            this.addTaxiButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.taxiDropdown = new System.Windows.Forms.ComboBox();
            this.rideTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableRideIDLabel = new System.Windows.Forms.Label();
            this.tableStartLabel = new System.Windows.Forms.Label();
            this.tableEndLabel = new System.Windows.Forms.Label();
            this.tableDayLabel = new System.Windows.Forms.Label();
            this.tableDistanceLabel = new System.Windows.Forms.Label();
            this.tableDueMoneyLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.companyTab = new System.Windows.Forms.TabPage();
            this.companyBox = new System.Windows.Forms.TextBox();
            this.companyLabel = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayContextTabs = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextTaxis = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextRides = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.taxiTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.rideTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.companyTab.SuspendLayout();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.taxiTab);
            this.tabControl.Controls.Add(this.rideTab);
            this.tabControl.Controls.Add(this.companyTab);
            this.tabControl.Location = new System.Drawing.Point(0, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(433, 324);
            this.tabControl.TabIndex = 0;
            // 
            // taxiTab
            // 
            this.taxiTab.Controls.Add(this.averageDistanceLabel);
            this.taxiTab.Controls.Add(this.label14);
            this.taxiTab.Controls.Add(this.totalIncomeLabel);
            this.taxiTab.Controls.Add(this.label12);
            this.taxiTab.Controls.Add(this.longestRideLabel);
            this.taxiTab.Controls.Add(this.label10);
            this.taxiTab.Controls.Add(this.taxiIDLabel);
            this.taxiTab.Controls.Add(this.label8);
            this.taxiTab.Controls.Add(this.panel1);
            this.taxiTab.Controls.Add(this.deleteTaxiButton);
            this.taxiTab.Controls.Add(this.addTaxiButton);
            this.taxiTab.Controls.Add(this.label1);
            this.taxiTab.Controls.Add(this.taxiDropdown);
            this.taxiTab.Location = new System.Drawing.Point(4, 22);
            this.taxiTab.Name = "taxiTab";
            this.taxiTab.Padding = new System.Windows.Forms.Padding(3);
            this.taxiTab.Size = new System.Drawing.Size(425, 298);
            this.taxiTab.TabIndex = 0;
            this.taxiTab.Text = "Manage Taxis";
            this.taxiTab.UseVisualStyleBackColor = true;
            // 
            // averageDistanceLabel
            // 
            this.averageDistanceLabel.AutoSize = true;
            this.averageDistanceLabel.Location = new System.Drawing.Point(391, 134);
            this.averageDistanceLabel.Name = "averageDistanceLabel";
            this.averageDistanceLabel.Size = new System.Drawing.Size(16, 13);
            this.averageDistanceLabel.TabIndex = 12;
            this.averageDistanceLabel.Text = "-1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(284, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Average ride distance:";
            // 
            // totalIncomeLabel
            // 
            this.totalIncomeLabel.AutoSize = true;
            this.totalIncomeLabel.Location = new System.Drawing.Point(351, 117);
            this.totalIncomeLabel.Name = "totalIncomeLabel";
            this.totalIncomeLabel.Size = new System.Drawing.Size(16, 13);
            this.totalIncomeLabel.TabIndex = 10;
            this.totalIncomeLabel.Text = "-1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(284, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Total income:";
            // 
            // longestRideLabel
            // 
            this.longestRideLabel.AutoSize = true;
            this.longestRideLabel.Location = new System.Drawing.Point(391, 102);
            this.longestRideLabel.Name = "longestRideLabel";
            this.longestRideLabel.Size = new System.Drawing.Size(16, 13);
            this.longestRideLabel.TabIndex = 8;
            this.longestRideLabel.Text = "-1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(284, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Longest ride distance: ";
            // 
            // taxiIDLabel
            // 
            this.taxiIDLabel.AutoSize = true;
            this.taxiIDLabel.Location = new System.Drawing.Point(328, 85);
            this.taxiIDLabel.Name = "taxiIDLabel";
            this.taxiIDLabel.Size = new System.Drawing.Size(16, 13);
            this.taxiIDLabel.TabIndex = 6;
            this.taxiIDLabel.Text = "-1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(284, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Taxi ID: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rideAddButton);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dayBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.endTimePicker);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.startTimePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(22, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 219);
            this.panel1.TabIndex = 4;
            // 
            // rideAddButton
            // 
            this.rideAddButton.Location = new System.Drawing.Point(47, 169);
            this.rideAddButton.Name = "rideAddButton";
            this.rideAddButton.Size = new System.Drawing.Size(75, 23);
            this.rideAddButton.TabIndex = 8;
            this.rideAddButton.Text = "Add Ride";
            this.rideAddButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Day:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Distance:";
            // 
            // dayBox
            // 
            this.dayBox.FormattingEnabled = true;
            this.dayBox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.dayBox.Location = new System.Drawing.Point(64, 124);
            this.dayBox.Name = "dayBox";
            this.dayBox.Size = new System.Drawing.Size(88, 21);
            this.dayBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "km";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 4;
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "";
            this.endTimePicker.Location = new System.Drawing.Point(64, 71);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(88, 20);
            this.endTimePicker.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End time:";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "";
            this.startTimePicker.Location = new System.Drawing.Point(64, 42);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(88, 20);
            this.startTimePicker.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ride";
            // 
            // deleteTaxiButton
            // 
            this.deleteTaxiButton.Location = new System.Drawing.Point(323, 18);
            this.deleteTaxiButton.Name = "deleteTaxiButton";
            this.deleteTaxiButton.Size = new System.Drawing.Size(75, 23);
            this.deleteTaxiButton.TabIndex = 3;
            this.deleteTaxiButton.Text = "Delete Taxi";
            this.deleteTaxiButton.UseVisualStyleBackColor = true;
            // 
            // addTaxiButton
            // 
            this.addTaxiButton.Location = new System.Drawing.Point(216, 18);
            this.addTaxiButton.Name = "addTaxiButton";
            this.addTaxiButton.Size = new System.Drawing.Size(75, 23);
            this.addTaxiButton.TabIndex = 2;
            this.addTaxiButton.Text = "Add Taxi";
            this.addTaxiButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Taxi:";
            // 
            // taxiDropdown
            // 
            this.taxiDropdown.FormattingEnabled = true;
            this.taxiDropdown.Location = new System.Drawing.Point(54, 18);
            this.taxiDropdown.Name = "taxiDropdown";
            this.taxiDropdown.Size = new System.Drawing.Size(121, 21);
            this.taxiDropdown.TabIndex = 1;
            // 
            // rideTab
            // 
            this.rideTab.Controls.Add(this.tableLayoutPanel1);
            this.rideTab.Controls.Add(this.label9);
            this.rideTab.Controls.Add(this.comboBox1);
            this.rideTab.Location = new System.Drawing.Point(4, 22);
            this.rideTab.Name = "rideTab";
            this.rideTab.Padding = new System.Windows.Forms.Padding(3);
            this.rideTab.Size = new System.Drawing.Size(425, 298);
            this.rideTab.TabIndex = 1;
            this.rideTab.Text = "Ride Overview";
            this.rideTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.529F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.02581F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.02581F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.02581F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.36775F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.02581F));
            this.tableLayoutPanel1.Controls.Add(this.tableRideIDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableStartLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableEndLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableDayLabel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableDistanceLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableDueMoneyLabel, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(422, 228);
            this.tableLayoutPanel1.TabIndex = 7;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableRideIDLabel
            // 
            this.tableRideIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableRideIDLabel.AutoSize = true;
            this.tableRideIDLabel.Location = new System.Drawing.Point(9, 4);
            this.tableRideIDLabel.Name = "tableRideIDLabel";
            this.tableRideIDLabel.Size = new System.Drawing.Size(43, 13);
            this.tableRideIDLabel.TabIndex = 0;
            this.tableRideIDLabel.Text = "Ride ID";
            // 
            // tableStartLabel
            // 
            this.tableStartLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableStartLabel.AutoSize = true;
            this.tableStartLabel.Location = new System.Drawing.Point(67, 4);
            this.tableStartLabel.Name = "tableStartLabel";
            this.tableStartLabel.Size = new System.Drawing.Size(55, 13);
            this.tableStartLabel.TabIndex = 1;
            this.tableStartLabel.Text = "Start Time";
            // 
            // tableEndLabel
            // 
            this.tableEndLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableEndLabel.AutoSize = true;
            this.tableEndLabel.Location = new System.Drawing.Point(136, 4);
            this.tableEndLabel.Name = "tableEndLabel";
            this.tableEndLabel.Size = new System.Drawing.Size(52, 13);
            this.tableEndLabel.TabIndex = 2;
            this.tableEndLabel.Text = "End Time";
            // 
            // tableDayLabel
            // 
            this.tableDayLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableDayLabel.AutoSize = true;
            this.tableDayLabel.Location = new System.Drawing.Point(294, 4);
            this.tableDayLabel.Name = "tableDayLabel";
            this.tableDayLabel.Size = new System.Drawing.Size(26, 13);
            this.tableDayLabel.TabIndex = 4;
            this.tableDayLabel.Text = "Day";
            // 
            // tableDistanceLabel
            // 
            this.tableDistanceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableDistanceLabel.AutoSize = true;
            this.tableDistanceLabel.Location = new System.Drawing.Point(204, 4);
            this.tableDistanceLabel.Name = "tableDistanceLabel";
            this.tableDistanceLabel.Size = new System.Drawing.Size(49, 13);
            this.tableDistanceLabel.TabIndex = 3;
            this.tableDistanceLabel.Text = "Distance";
            // 
            // tableDueMoneyLabel
            // 
            this.tableDueMoneyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableDueMoneyLabel.AutoSize = true;
            this.tableDueMoneyLabel.Location = new System.Drawing.Point(355, 4);
            this.tableDueMoneyLabel.Name = "tableDueMoneyLabel";
            this.tableDueMoneyLabel.Size = new System.Drawing.Size(62, 13);
            this.tableDueMoneyLabel.TabIndex = 5;
            this.tableDueMoneyLabel.Text = "Due Money";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Taxi:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // companyTab
            // 
            this.companyTab.Controls.Add(this.companyBox);
            this.companyTab.Controls.Add(this.companyLabel);
            this.companyTab.Location = new System.Drawing.Point(4, 22);
            this.companyTab.Name = "companyTab";
            this.companyTab.Padding = new System.Windows.Forms.Padding(3);
            this.companyTab.Size = new System.Drawing.Size(425, 298);
            this.companyTab.TabIndex = 2;
            this.companyTab.Text = "Company Information";
            this.companyTab.UseVisualStyleBackColor = true;
            // 
            // companyBox
            // 
            this.companyBox.Location = new System.Drawing.Point(135, 29);
            this.companyBox.Name = "companyBox";
            this.companyBox.Size = new System.Drawing.Size(100, 20);
            this.companyBox.TabIndex = 9;
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new System.Drawing.Point(44, 32);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(85, 13);
            this.companyLabel.TabIndex = 8;
            this.companyLabel.Text = "Company Name:";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Test";
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Taxi Program";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayContextTabs,
            this.trayContextAbout,
            this.trayContextOpen,
            this.trayContextExit});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(108, 92);
            // 
            // trayContextTabs
            // 
            this.trayContextTabs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayContextTaxis,
            this.trayContextRides,
            this.trayContextCompany});
            this.trayContextTabs.Name = "trayContextTabs";
            this.trayContextTabs.Size = new System.Drawing.Size(107, 22);
            this.trayContextTabs.Text = "Tab";
            // 
            // trayContextTaxis
            // 
            this.trayContextTaxis.Name = "trayContextTaxis";
            this.trayContextTaxis.Size = new System.Drawing.Size(192, 22);
            this.trayContextTaxis.Text = "Manage Taxi\'s";
            this.trayContextTaxis.Click += new System.EventHandler(this.trayTaxiMenuItem_Click);
            // 
            // trayContextRides
            // 
            this.trayContextRides.Name = "trayContextRides";
            this.trayContextRides.Size = new System.Drawing.Size(192, 22);
            this.trayContextRides.Text = "Ride Overview";
            this.trayContextRides.Click += new System.EventHandler(this.trayRideMenuItem_Click);
            // 
            // trayContextCompany
            // 
            this.trayContextCompany.Name = "trayContextCompany";
            this.trayContextCompany.Size = new System.Drawing.Size(192, 22);
            this.trayContextCompany.Text = "Company Information";
            this.trayContextCompany.Click += new System.EventHandler(this.trayCompanyMenuItem_Click);

            // 
            // trayContextAbout
            // 
            this.trayContextAbout.Name = "trayContextAbout";
            this.trayContextAbout.Size = new System.Drawing.Size(107, 22);
            this.trayContextAbout.Text = "About";
            this.trayContextAbout.Click += new System.EventHandler(this.trayAboutMenuItem_Click);
            // 
            // trayContextOpen
            // 
            this.trayContextOpen.Name = "trayContextOpen";
            this.trayContextOpen.Size = new System.Drawing.Size(107, 22);
            this.trayContextOpen.Text = "Open";
            this.trayContextOpen.Click += new System.EventHandler(this.trayOpenMenuItem_Click);
            // 
            // trayContextExit
            // 
            this.trayContextExit.Name = "trayContextExit";
            this.trayContextExit.Size = new System.Drawing.Size(107, 22);
            this.trayContextExit.Text = "Exit";
            this.trayContextExit.Click += new System.EventHandler(this.trayExitMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 336);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taxi Program";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl.ResumeLayout(false);
            this.taxiTab.ResumeLayout(false);
            this.taxiTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rideTab.ResumeLayout(false);
            this.rideTab.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.companyTab.ResumeLayout(false);
            this.companyTab.PerformLayout();
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage taxiTab;
        private System.Windows.Forms.TabPage rideTab;
        private System.Windows.Forms.TabPage companyTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox taxiDropdown;
        private System.Windows.Forms.Button deleteTaxiButton;
        private System.Windows.Forms.Button addTaxiButton;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dayBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button rideAddButton;
        private System.Windows.Forms.Label longestRideLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label taxiIDLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label totalIncomeLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label averageDistanceLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label tableRideIDLabel;
        private System.Windows.Forms.TextBox companyBox;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label tableStartLabel;
        private System.Windows.Forms.Label tableEndLabel;
        private System.Windows.Forms.Label tableDistanceLabel;
        private System.Windows.Forms.Label tableDayLabel;
        private System.Windows.Forms.Label tableDueMoneyLabel;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem trayContextTabs;
        private System.Windows.Forms.ToolStripMenuItem trayContextTaxis;
        private System.Windows.Forms.ToolStripMenuItem trayContextRides;
        private System.Windows.Forms.ToolStripMenuItem trayContextCompany;
        private System.Windows.Forms.ToolStripMenuItem trayContextAbout;
        private System.Windows.Forms.ToolStripMenuItem trayContextOpen;
        private System.Windows.Forms.ToolStripMenuItem trayContextExit;
    }
}

