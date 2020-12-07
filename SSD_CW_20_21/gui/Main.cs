using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSD_CW_20_21.Objects;

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

        private void btnGrooming_Click(object sender, EventArgs e)
        {
            lastForm = currentForm;
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
    }
}
