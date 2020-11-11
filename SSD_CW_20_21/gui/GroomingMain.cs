using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSD_CW_20_21.gui
{
    public partial class GroomingMain : Template
    {
        public GroomingMain() : base()
        {
            InitializeComponent();
            Text = "JD Dog Care - Grooming";
        }

        private void btnDogs_Click(object sender, EventArgs e)
        {
            lastForm = currentForm;
            new DogManage().Show();
            Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            lastForm = currentForm;
            new BookingsManage().Show();
            Hide();
        }
    }
}
