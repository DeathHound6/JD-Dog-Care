using System;
using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSD_CW_20_21.gui
{
    public partial class GroomingMain : Template
    {
        #region Local Variables
        private OrderDBAccess orderAccess = Globals.orderAccess;
        private DogDBAccess dogAccess = Globals.dogAccess;
        private ServiceDBAccess servAccess = Globals.serviceAccess;
        private StaffDBAccess staffAccess = Globals.staffAccess;
        private ServiceOrderDBAccess servorderAccess = Globals.serviceOrderAccess;
        private List<Orders> orders;
        private List<Dog> dogs;
        #endregion

        public GroomingMain() : base()
        {
            InitializeComponent();
            Text = "JD Dog Care - Grooming";

            dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0);
            orders = orderAccess.getAllOrders().FindAll(e => e.Cancelled == 0 && Convert.ToDateTime(e.Date).CompareTo(DateTime.Now) > 0);

            if (dogs.Count == 0) btnBooking.Enabled = false;
            else btnBooking.Enabled = true;
            populateDGV();
        }

        #region Custom Methods
        private static int SortOrders(Orders o1, Orders o2)
        {
            DateTime time2 = Convert.ToDateTime(o1.Date);
            DateTime time1 = Convert.ToDateTime(o2.Date);

            return time1.CompareTo(time2);
        }

        private void populateDGV()
        {
            dgvOrders.ColumnCount = 6;
            string[] rows = new string[6];
            dgvOrders.Columns[0].Name = "Dog";
            dgvOrders.Columns[1].Name = "Staff";
            dgvOrders.Columns[2].Name = "Date";
            dgvOrders.Columns[3].Name = "Start Time";
            dgvOrders.Columns[4].Name = "Service";
            dgvOrders.Columns[5].Name = "Extras";

            orders.Sort(SortOrders);
            Orders[] arr = orders.ToArray();
            for (int i = 0; i < arr.Length && i < 5; i++)
            {
                rows[0] = dogAccess.getDogById(arr[i].DogId).Name;
                rows[1] = staffAccess.getStaffById(arr[i].StaffId).Name;
                rows[2] = arr[i].Date;
                rows[3] = arr[i].StartTime;
                rows[4] = servAccess.getServiceById(servorderAccess.getObjectByOrderID(arr[i].Id).ServiceID).Description;
                string extras = "";
                if (arr[i].Teeth == 1) extras += "Teeth ";
                if (arr[i].Ears == 1) extras += "Ears ";
                if (arr[i].Nails == 1) extras += "Nails";
                extras = extras.Replace(" ", ", ");
                rows[5] = extras;
                dgvOrders.Rows.Add(rows);
            }

            foreach (DataGridViewColumn col in dgvOrders.Columns)
            {
                col.Width = dgvOrders.Size.Width / dgvOrders.Columns.Count;
            }
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                row.Height = dgvOrders.Size.Height / 5;
            }
            dgvOrders.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
        #endregion

        #region Events
        private void btnDogs_Click(object sender, EventArgs e)
        {
            new DogManage().Show();
            Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            new BookingsManage().Show();
            Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            new Main().Show();
            Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new Reports().Show();
            Hide();
        }
        #endregion
    }
}
