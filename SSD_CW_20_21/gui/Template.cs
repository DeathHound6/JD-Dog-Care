using System;
using System.Drawing;
using System.Windows.Forms;
using SSD_CW_20_21.Objects;

namespace SSD_CW_20_21.gui
{
    public partial class Template : Form
    {
        #region Local Variables
        protected Database DB = Globals.database;
        #endregion

        public Template()
        {
            InitializeComponent();
            showDbConn();

            toolstripMenuSubsystems.Text = "Grooming";
            tsMenu.Text = "Grooming Menu";
            tsDogs.Text = "Dogs";
            tsBookings.Text = "Bookings";
            viewReportsToolStripMenuItem.Text = "View Reports";

            dayCareToolStripMenuItem.Text = "Day Care";
            dogWalkingToolStripMenuItem.Text = "Dog Walking";
            dogTrainingToolStripMenuItem.Text = "Dog Training";
            collectionToolStripMenuItem.Text = "Collection, Delivery and Mobile Grooming";
            exitToolStripMenuItem.Text = "Exit";
        }

        #region Events
        protected void toolstripTxtGrooming_Click(object sender, EventArgs e)
        {
            if (DB.Connected)
            {
                new GroomingMain().Show();
                Hide();
            } 
        }

        private void viewReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Reports().Show();
            Hide();
        }

        private void toolstripMenuMain_Click(object sender, EventArgs e)
        {
            new Main().Show();
            Hide();
        }

        private void Template_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void Template_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult option = MessageBox.Show("Do you wish to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.No == option) e.Cancel = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void collectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void dogTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void dogWalkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void dayCareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void tsDogs_Click(object sender, EventArgs e)
        {
            new DogManage().Show();
            Hide();
        }

        private void tsMenu_Click(object sender, EventArgs e)
        {
            new GroomingMain().Show();
            Hide();
        }

        private void tsBookings_Click(object sender, EventArgs e)
        {
            new BookingsManage().Show();
            Hide();
        }
        #endregion

        #region Custom Methods
        protected void CannotOpenForm()
        {
            MessageBox.Show("This sub system has not been created as I am focusing on creating the Grooming Sub System", "Cannot Open Sub System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void showDbConn()
        {
            if (DB.Connected)
            {
                lblDbConn.ForeColor = Color.Lime;
                lblDbConn.Text = "Database Connected";
            }
            else
            {
                lblDbConn.ForeColor = Color.Red;
                lblDbConn.Text = "Database Disconnected";
            }
        }
        #endregion
    }
}
