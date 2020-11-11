using System;
using System.Drawing;
using System.Windows.Forms;
using SSD_CW_20_21.Objects;

namespace SSD_CW_20_21.gui
{
    public partial class Template : Form
    {
        protected Database DB = Globals.database; 

        protected string lastForm;
        protected string currentForm;

        public Template()
        {
            InitializeComponent();
            showDbConn();
        }

        protected void toolstripTxtGrooming_Click(object sender, EventArgs e)
        {
            DB.Connect();
            showDbConn();
            if (DB.Connected)
            {
                Globals.initDBAccess();
                MessageBox.Show("The database successfully connected", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastForm = currentForm;
                new GroomingMain().Show();
                Hide();
            } else
            {
                MessageBox.Show("The database failed to connect", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolstripMenuMain_Click(object sender, EventArgs e)
        {
            lastForm = currentForm;
            new Main().Show();
            Hide();
        }

        private void Template_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void toolstripTxtWalking_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void Template_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult option = MessageBox.Show("Do you wish to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.No == option) e.Cancel = true;
        }

        private void toolstripTxtTraining_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void toolstripTxtDaycare_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void toolstripTxtMobile_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        protected void CannotOpenForm()
        {
            MessageBox.Show("This sub system has not been created as I am focusing on creating the Grooming Sub System", "Cannot Open Sub System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected void showDbConn()
        {
            if (DB.Connected)
            {
                lblDbConn.ForeColor = Color.Green;
                lblDbConn.Text = "Database Connected";
            }
            else
            {
                lblDbConn.ForeColor = Color.Red;
                lblDbConn.Text = "Database Disconnected";
            }
        }
    }
}
