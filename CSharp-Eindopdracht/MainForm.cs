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
        private SplashScreen splashScreen;
        private bool loading = true;
        private About aboutForm = null;
        private DatabaseHandler databaseHandler;


        public MainForm()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(2000);
            databaseHandler = new DatabaseHandler(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TaxiApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

            taxiCompany = new TaxiCompany();

            List<Taxi> taxiList = databaseHandler.getData();
            foreach (Taxi taxi in taxiList)
            {
                taxiCompany.addTaxi(taxi.taxiID, taxi);
            }
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            splashScreen = new SplashScreen();
            Application.Run(splashScreen);
        }

        //When the MainForm is loaded.
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Focus.
            this.Activate();

            //Setup datetime inputs with correct values and formats.
            startTimePicker.CustomFormat = "HH:mm";
            startTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.ShowUpDown = true;

            endTimePicker.CustomFormat = "HH:mm";
            endTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.ShowUpDown = true;

            //Set day dropdown to the first entry.
            dayBox.SelectedIndex = 0;
            dayBox.SelectedItem = "Monday";

            //Set the company textbox to the current companyName value.
            companyBox.Text = taxiCompany.companyName;

            foreach (int taxiID in taxiCompany.taxis.Keys)
            {
                taxiDropdown.Items.Add(taxiID);
                tableTaxiBox.Items.Add(taxiID);
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

        //Tray about window action.
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

        //When the about form is closing.
        private void about_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Set aboutForm to null if it is closed.
            //This is used to only allow one instance of the about window.
            this.aboutForm = null;
        }

        //Tray open action.
        private void trayOpenMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(-1);
        }

        //Tray double click action.
        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openWindow(-1);
        }

        //Tray open Company Menu action.
        private void trayCompanyMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(2);
        }

        //Tray exit action.
        private void trayExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Tray open ManageTaxis menu.
        private void trayTaxiMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(0);
        }

        //Tray open Ride Overview menu.
        private void trayRideMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(1);
        }

        //If the application is opened from the tray.
        private void openWindow(int tab)
        {
            //If -1 is passed, the tab won't be changed.
            //Is used for the open and double click action to stay on the current tab.
            if (tab != -1)
            {
                this.tabControl.SelectedIndex = tab;
            }
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        //When the Company name is saved.
        private void companySaveButton_Click(object sender, EventArgs e)
        {
            this.taxiCompany.companyName = companyBox.Text;
        }

        //When a Taxi is added, add it to the dropdowns and the Taxi company.
        private void addTaxiButton_Click(object sender, EventArgs e)
        {
            int id = databaseHandler.addTaxi();
            //int id = taxiCompany.taxis.Keys.Count == 0 ? 0 : taxiCompany.taxis.Keys.Max() + 1;
            taxiCompany.addTaxi(id, new Taxi(id));
            int index = taxiDropdown.Items.Add(id);
            tableTaxiBox.Items.Add(id);
            taxiDropdown.SelectedIndex = index;
            updateTable(id);
        }

        //When a Taxi is deleted, remove it from both dropdowns and the TaxiCompany.
        private void deleteTaxiButton_Click(object sender, EventArgs e)
        {
            int taxiID = (int)taxiDropdown.SelectedItem;
            int selectedIndex = taxiDropdown.SelectedIndex;
            taxiCompany.removeTaxi(taxiID);
            databaseHandler.deleteTaxi(taxiID);
            //Update both the dropdowns.
            taxiDropdown.SelectedIndex = selectedIndex - 1;
            tableTaxiBox.SelectedIndex = selectedIndex - 1;
            taxiDropdown.Items.Remove(taxiID);
            tableTaxiBox.Items.Remove(taxiID);
   
        }
        //When a Ride is added to a Taxi.
        private void rideAddButton_Click(object sender, EventArgs e)
        {
            //First validate the input.
            DateTime startTime = startTimePicker.Value;
            DateTime endTime = endTimePicker.Value;

            int timeDiff = DateTime.Compare(endTime, startTime);
            if(timeDiff < 0)
            {
                new Popup("The start time cannot be before the end time.", this);
                return;
            }

            int day = dayBox.SelectedIndex;
            double distance = -1;
            if(!double.TryParse(distanceBox.Text, out distance))
            {
                new Popup("The distance should be a number.", this);
                return;
            }
            int taxiID = (int)taxiDropdown.SelectedItem;
            //TODO: Get ID from AI DB.
            TaxiRide taxiRide = new TaxiRide(distance, startTime, endTime, day, 0);
            taxiCompany.taxis[taxiID].addRide(taxiRide);

            updateTaxiLabels(taxiCompany.taxis[taxiID]);
            //Reset the inputs if the Ride was added correctly.
            resetInputs();

            //If a Ride was added to the Taxi that is currently selected in the Ride Overview,
            //refresh the table.
            if(taxiDropdown.SelectedIndex == tableTaxiBox.SelectedIndex)
            {
                clearTable();
                updateTable(taxiID);
            }
        }

        //Resets Ride form inputs.
        private void resetInputs()
        {
            startTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            endTimePicker.Value = new DateTime(2022, 01, 01, 12, 00, 00);
            distanceBox.Text = "";
            dayBox.SelectedIndex = 0;
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

        //Rebuilds the Ride Overview table with the currently selected Taxi data.
        private void updateTable(int taxiID)
        {
            int rowCount = 1;
            foreach(TaxiRide ride in taxiCompany.taxis[taxiID].rides)
            {
                String startTime = ride.startTime.ToString("HH:mm");
                String endTime = ride.endTime.ToString("HH:mm");
                String day = ride.getDayName();
                double dueMoney = ride.getDueMoney();

                //Create cells and put data in them.
                tableLayoutPanel1.Controls.Add(new Label() { Text = ride.rideID.ToString(), Anchor = AnchorStyles.None }, 0, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = startTime }, 1, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = endTime }, 2, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = ride.distance.ToString() + "km" }, 3, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = day }, 4, rowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "€" +  dueMoney.ToString("0.00") }, 5, rowCount);
                rowCount++;
            }
        }
        //A Taxi is selected in the Ride Overview dropdown.
        private void tableTaxiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearTable();
            if(tableTaxiBox.SelectedIndex == -1)
            {
                return;
            }
            updateTable((int)tableTaxiBox.SelectedItem);
        }

        //A Taxi is selected in the Manage Taxis dropdown.
        private void taxiDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the dropdown is empty, disable the form inputs.
            if(taxiDropdown.SelectedIndex == -1)
            {
                startTimePicker.Enabled = false;
                endTimePicker.Enabled = false;
                distanceBox.Enabled = false;
                dayBox.Enabled = false;
                deleteTaxiButton.Enabled = false;
                rideAddButton.Enabled = false;
            }
            else
            {
                //Update all labels with the data of the newly selected Taxi.;
                updateTaxiLabels(taxiCompany.taxis[(int)taxiDropdown.SelectedItem]);

                //Enable all form inputs in case they where disabled if the previous input was the empty selection.
                startTimePicker.Enabled = true;
                endTimePicker.Enabled = true;
                distanceBox.Enabled = true;
                dayBox.Enabled = true;
                deleteTaxiButton.Enabled = true;
                rideAddButton.Enabled = true;
            }
        }

        //Updates the Taxi labels with new current Taxi information.
        private void updateTaxiLabels(Taxi taxi)
        {
            taxiIDLabel.Text = taxi.taxiID.ToString();
            rideCountLabelValue.Text = taxi.rides.Count().ToString();
            totalIncomeLabel.Text = "€" + Math.Round(taxi.getTotalIncome(), 2).ToString();
            averageDistanceLabel.Text = taxi.getAverageDistance().ToString() + "km";
            longestRideLabel.Text = taxi.getLongestRideDistance().ToString() + "km";
        }

        //Fixes tray icon staying in the tray after exiting application.
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }
    }
}
