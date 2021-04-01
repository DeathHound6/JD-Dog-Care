using System;

namespace SSD_CW_20_21.gui
{
    public partial class Main : Template
    {
        public Main() : base()
        {
            InitializeComponent();
            showDbConn();
            Text = "JD Dog Care - Main Menu";
        }

        #region Events
        private void btnGrooming_Click(object sender, EventArgs e)
        {
            toolstripTxtGrooming_Click(sender, e);
        }

        private void btnWalking_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void btnDaycare_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }

        private void btnMobile_Click(object sender, EventArgs e)
        {
            CannotOpenForm();
        }
        #endregion
    }
}
