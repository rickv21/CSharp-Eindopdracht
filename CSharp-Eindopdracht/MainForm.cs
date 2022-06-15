using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Eindopdracht2
{
    public partial class MainForm : Form
    {
        private TaxiCompany taxiCompany;
        About aboutForm = null;


        public MainForm()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(3000);
            taxiCompany = new TaxiCompany();
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Activate();

            startTimePicker.CustomFormat = "HH:mm";
            startTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.ShowUpDown = true;

            endTimePicker.CustomFormat = "HH:mm";
            endTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.ShowUpDown = true;

            dayBox.SelectedIndex = 0;

            dayBox.SelectedItem = "Monday";

            companyBox.Text = taxiCompany.companyName;
            taxiCompany.addTaxi(0, new Taxi(0));

            /*foreach(Taxi taxi in taxiCompany.taxis.Values)
            {
                taxiDropdown.Items.Add(taxi);
            }*/
            foreach (int taxiID in taxiCompany.taxis.Keys)
            {
                taxiDropdown.Items.Add(taxiID);
                comboBox1.Items.Add(taxiID);
            }
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openWindow(-1);
        }

        private void trayCompanyMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(2);
        }

        private void trayAboutMenuItem_Click(object sender, EventArgs e)
        {
            //If there is already a About window open, use this instead of opening a new instance.
            if(aboutForm != null)
            {
                this.aboutForm.WindowState = FormWindowState.Normal;
                this.aboutForm.Activate();
            } 
            else
            {
                this.aboutForm = new About();
                this.aboutForm.FormClosing += about_FormClosing;
                this.aboutForm.Show();
            }

        }

        private void about_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Set aboutForm to null if it is closed.
            this.aboutForm = null;
        }

        private void trayOpenMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(-1);
        }

        private void trayExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trayTaxiMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(0);
        }

        private void trayRideMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(1);
        }

        private void openWindow(int tab)
        {
            Console.WriteLine(this.tabControl.SelectedIndex);
            if (tab != -1)
            {
                this.tabControl.SelectedIndex = tab;
            }
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void companySaveButton_Click(object sender, EventArgs e)
        {
            this.taxiCompany.companyName = companyBox.Text;
        }

        private void addTaxiButton_Click(object sender, EventArgs e)
        {
            int id = taxiCompany.taxis.Keys.Count == 0 ? 0 : taxiCompany.taxis.Keys.Max() + 1;
            taxiCompany.addTaxi(id, new Taxi(id));
            int index = taxiDropdown.Items.Add(id);
            comboBox1.Items.Add(id);
            taxiDropdown.SelectedIndex = index;
            updateTable(0);
        }

        private void deleteTaxiButton_Click(object sender, EventArgs e)
        {
            int taxiID = (int)taxiDropdown.SelectedItem;
            int selectedIndex = taxiDropdown.SelectedIndex;
            taxiCompany.removeTaxi(taxiID);
            taxiDropdown.SelectedIndex = selectedIndex - 1;
            comboBox1.SelectedIndex = selectedIndex - 1;
            taxiDropdown.Items.Remove(taxiID);
            comboBox1.Items.Remove(taxiID);
   
        }

        private void rideAddButton_Click(object sender, EventArgs e)
        {
            DateTime startTime = startTimePicker.Value;
            DateTime endTime = endTimePicker.Value;

            int timeDiff = DateTime.Compare(endTime, startTime);
            if(timeDiff < 0)
            {
                //TODO: Popup.
                return;
            }

            int day = dayBox.SelectedIndex;
            double distance = -1;
            if(!double.TryParse(distanceBox.Text, out distance))
            {
                //TODO: Popup.
                return;
            }
            int taxiID = (int)taxiDropdown.SelectedItem;
            //TODO: Get ID from AI DB.
            TaxiRide taxiRide = new TaxiRide(distance, startTime, endTime, day, 0);
            taxiCompany.taxis[taxiID].addRide(taxiRide);

            rideCountLabelValue.Text = taxiCompany.taxis[taxiID].rides.Count().ToString();
            totalIncomeLabel.Text = "€" + Math.Round(taxiCompany.taxis[taxiID].getTotalIncome(), 2).ToString();
            averageDistanceLabel.Text = taxiCompany.taxis[taxiID].getAverageDistance().ToString() + "km";
            //Reset inputs.
            startTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            endTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            distanceBox.Text = "";
            dayBox.SelectedIndex = 0;

            if(taxiDropdown.SelectedIndex == comboBox1.SelectedIndex)
            {
                clearTable();
                updateTable(taxiID);
            }

        }

        //Clears the table.
        private void clearTable()
        {
            for (int row = 1; row <= tableLayoutPanel1.RowCount - 1; row++)
            {
                for (int col = 0; col <= tableLayoutPanel1.ColumnCount; col++)
                {
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(col, row));
                }
            }
        }

        private void updateTable(int taxiID)
        {
            int rowCount = 1;
            foreach(TaxiRide ride in taxiCompany.taxis[taxiID].rides)
            {
                String startTime = ride.startTime.ToString("HH:mm");
                String endTime = ride.endTime.ToString("HH:mm");
                String day = getDayName(ride.day);
                double dueMoney = -1; ;

                tableLayoutPanel1.Controls.Add(new Label() { Text = ride.rideID.ToString(), Anchor = AnchorStyles.None }, 0, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = startTime }, 1, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = endTime }, 2, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = ride.distance.ToString() + "km" }, 3, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = day }, 4, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = dueMoney.ToString() }, 5, rowCount);
                rowCount++;
            }
        }

        private String getDayName(int day)
        {
            switch(day)
            {
                case 0: return "Monday";
                case 1: return "Tuesday";
                case 2: return "Wednesday";
                case 3: return "Thursday";
                case 4: return "Friday";
                case 5: return "Saturday";
                case 6: return "Sunday";
                default: return "Invalid";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearTable();
            if(comboBox1.SelectedIndex == -1)
            {
                return;
            }
            updateTable((int)comboBox1.SelectedItem);
        }

        private void taxiDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(taxiDropdown.SelectedIndex);
            if(taxiDropdown.SelectedIndex == -1)
            {
                startTimePicker.Enabled = false;
                endTimePicker.Enabled = false;
                distanceBox.Enabled = false;
                dayBox.Enabled = false;
                deleteTaxiButton.Enabled = false;
                rideAddButton.Enabled = false;
                return;
            }
            Taxi taxi = taxiCompany.taxis[(int)taxiDropdown.SelectedItem];
            taxiIDLabel.Text = taxi.taxiID.ToString();
            rideCountLabelValue.Text = taxi.rides.Count().ToString();
            totalIncomeLabel.Text = "€" + Math.Round(taxi.getTotalIncome(), 2).ToString();
            averageDistanceLabel.Text = taxi.getAverageDistance().ToString() + "km";


            startTimePicker.Enabled = true;
            endTimePicker.Enabled = true;
            distanceBox.Enabled = true;
            dayBox.Enabled = true;
            deleteTaxiButton.Enabled = true;
            rideAddButton.Enabled = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Fix tray icon staying in the tray after exiting application.
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }
    }
}
