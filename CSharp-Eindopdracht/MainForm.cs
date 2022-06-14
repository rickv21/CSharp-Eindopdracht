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
        public MainForm()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(3000);
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
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.ShowUpDown = true;

            endTimePicker.CustomFormat = "HH:mm";
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.ShowUpDown = true;

            dayBox.SelectedItem = "Monday";
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

        }

        private void trayOpenMenuItem_Click(object sender, EventArgs e)
        {
            openWindow(-1);
        }

        private void trayExitMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Exit");
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
    }
}
