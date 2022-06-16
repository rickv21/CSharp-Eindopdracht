using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Eindopdracht2
{
    public partial class Popup : Form
    {
        private MainForm mainForm;

        public Popup(String message, MainForm form)
        {
            InitializeComponent();
            this.popupLabel.Text = message;
            this.mainForm = form;
            this.mainForm.Enabled = false;
            ShowDialog();
        }

        private void popupClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formClose(object sender, FormClosedEventArgs e)
        {
            this.mainForm.Enabled = true;
        }
    }
}
