using System;
using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;
using System.Collections.Generic;

namespace SSD_CW_20_21.gui
{
    public partial class GroomingMain : Template
    {
        private OrderDBAccess orderAccess = Globals.orderAccess;
        private DogDBAccess dogAccess = Globals.dogAccess;
        private ServiceDBAccess servAccess = Globals.serviceAccess;
        private StaffDBAccess staffAccess = Globals.staffAccess;
        private List<Orders> orders;
        private List<Dog> dogs;

        public GroomingMain() : base()
        {
            InitializeComponent();
            Text = "JD Dog Care - Grooming";

            dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0);
            orders = orderAccess.getAllOrders().FindAll(e => e.Cancelled == 0 && Convert.ToDateTime(e.Date).CompareTo(DateTime.Now) > 0);

            if (dogs.Count == 0) btnBooking.Enabled = false;
            else btnBooking.Enabled = true;

            dgvOrders.ColumnCount = 4;
            string[] rows = new string[4];
            dgvOrders.Columns[0].Name = "Dog";
            dgvOrders.Columns[1].Name = "Staff";
            dgvOrders.Columns[2].Name = "Date";
            dgvOrders.Columns[3].Name = "Start Time";

            orders.Sort(SortOrders);
            foreach (Orders order in orders)
            {
                rows[0] = dogAccess.getDogById(order.DogId).Name;
                rows[1] = staffAccess.getStaffById(order.StaffId).Name;
                rows[2] = order.Date;
                rows[3] = order.StartTime;
                dgvOrders.Rows.Add(rows);
            }
        }

        private static int SortOrders(Orders o1, Orders o2)
        {
            DateTime time2 = Convert.ToDateTime(o1.Date);
            DateTime time1 = Convert.ToDateTime(o2.Date);

            return time1.CompareTo(time2);
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
