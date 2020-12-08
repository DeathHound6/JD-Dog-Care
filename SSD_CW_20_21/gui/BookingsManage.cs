using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using Nager.Date;
using System.Linq;

namespace SSD_CW_20_21.gui
{
    public partial class BookingsManage : Template
    {
        #region Local Variables
        private OrderDBAccess orderAccess = Globals.orderAccess;
        private DogDBAccess dogAccess = Globals.dogAccess;
        private StaffDBAccess staffAccess = Globals.staffAccess;
        private CustomerDBAccess custAccess = Globals.custAccess;
        private ServiceDBAccess serviceAccess = Globals.serviceAccess;
        private ServiceOrderDBAccess servOrderAccess = Globals.serviceOrderAccess;
        private List<Dog> dogs;
        private List<Orders> orders;
        private List<Staff> staffs;
        private List<Customer> custs;
        private Orders order;
        private Service serv;
        private string mode = "";
        private string type = "";
        private List<Service> services;
        #endregion

        public BookingsManage() : base()
        {
            InitializeComponent();
            staffs = staffAccess.getAllStaff().FindAll(e => e.Deleted == 0);
            orders = orderAccess.getAllOrders().FindAll(e => Convert.ToDateTime(e.Date) > DateTime.Now);
            services = serviceAccess.getAllServices();
            serv = services.ToArray()[0];
            dogs = dogAccess.getAllDogs();
            custs = custAccess.getAllCustomers().FindAll(e => e.Deleted == 0);

            dtpDateTime.Value = DateTime.Now;

            Text = "JD Dog Care - Add Bookings";

            changeMode("view");
            populateComboBox();
            txtStaff.Enabled = false;
            txtTime.Enabled = false;
            txtDate.Enabled = false;
        }

        #region Custom Methods
        private void populateComboBox()
        {
            populateServCbox();
            populateCustCbox();
            populateDogCbox();
        }

        private void populateCustCbox(bool del = false)
        {
            cboxCust.Items.Clear();
            if (del) custs = custs.FindAll(e => e.Deleted == 0);
            foreach (Customer cust in custs)
            {
                cboxCust.Items.Add($"{cust.Id} - {cust.Forename} {cust.Surname}");
            }
            cboxCust.Text = cboxCust.Items[0].ToString();
        }

        private void populateDogCbox(bool del = false)
        {
            List<Dog> dogs = dogAccess.getAllDogs();
            cboxDog.Items.Clear();
            if (del) dogs = dogs.FindAll(e => e.Deleted == 0);
            dogs = dogs.FindAll(e => e.OwnerId == Convert.ToInt32(cboxCust.Text.Replace(" ", "").Split('-')[0]));
            foreach (Dog dog in dogs)
            {
                cboxDog.Items.Add($"{dog.Id} - {dog.Name}");
            }
            try
            {
                cboxDog.Text = cboxDog.Items[0].ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                cboxDog.Items.Add("None Available");
                cboxDog.Text = cboxDog.Items[0].ToString();
            }
        }

        private void populateServCbox()
        {
            List<Service> services = serviceAccess.getAllServices();
            cboxServices.Items.Clear();
            foreach (Service srv in services)
            {
                cboxServices.Items.Add($"{srv.ServiceID} - {srv.Description}");
            }
            cboxServices.Text = cboxServices.Items[0].ToString();
        }

        private void changeMode(string newMode)
        {
            if (newMode == "add")
            {
                order = new Orders();
                mode = newMode;

                dgvDateTime.Columns.Clear();
                dgvDateTime.Rows.Clear();

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
                btnView.Enabled = true;
                btnSelectDate.Enabled = true;
                btnSelectStaff.Enabled = false;
                btnSelectTime.Enabled = false;
                checkDelDog.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;
                checkPaid.Enabled = true;

                cboxCust.Enabled = true;
                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                checkEars.Checked = false;
                checkNails.Checked = false;
                checkTeeth.Checked = false;
                lblOrderCancelled.Visible = false;

                cboxCust.Text = "";
                cboxDog.Text = "";
                cboxServices.Text = "";
            }
            else if (newMode == "edit")
            {
                mode = newMode;

                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnView.Enabled = true;
                btnSelectDate.Enabled = true;
                btnSelectStaff.Enabled = true;
                btnSelectTime.Enabled = true;
                checkDelDog.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;
                checkPaid.Enabled = true;

                cboxCust.Enabled = true;
                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                lblOrderCancelled.Visible = order.Cancelled == 0 ? false : true;

                checkEars.Checked = order.Ears == 0 ? false : true;
                checkNails.Checked = order.Nails == 0 ? false : true;
                checkTeeth.Checked = order.Teeth == 0 ? false : true;

                cboxCust.Text = $"{dogAccess.getDogById(order.DogId).OwnerId} - {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Forename} {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Surname}";
                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceID} - {serv.Description}";
            }
            else if (newMode == "view")
            {
                if (orders.Count > 0) order = orders.ToArray()[0];
                else order = new Orders(1, 1, 1, dtpDateTime.Value.ToShortDateString(), dtpDateTime.Value.ToShortTimeString(), dtpDateTime.Value.AddMinutes(serv.Time).ToShortTimeString(), 0, 0, 0, 1, 0);
                mode = newMode;

                dgvDateTime.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnView.Enabled = false;
                btnSelectDate.Enabled = false;
                btnSelectStaff.Enabled = false;
                btnSelectTime.Enabled = false;

                cboxCust.Enabled = false;
                cboxDog.Enabled = false;
                cboxServices.Enabled = false;
                checkDelDog.Enabled = false;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                checkPaid.Enabled = false;
                checkTeeth.Enabled = false;

                cboxCust.Text = $"{dogAccess.getDogById(order.DogId).OwnerId} - {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Forename} {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Surname}";
                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceID} - {serv.Description}";
                checkDelDog.Checked = false;
                checkEars.Checked = false;
                checkNails.Checked = false;
                checkPaid.Checked = false;
                checkTeeth.Checked = false;

                type = "orders";
                populateDataGrid();
            }
        }

        private int getIdFromString(string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]", ""));
        }

        private void populateDataGrid()
        {
            dgvDateTime.Columns.Clear();
            dgvDateTime.Rows.Clear();

            if (type == "time")
            {
                dgvDateTime.ColumnCount = 2;
                string[] rows = new string[dgvDateTime.ColumnCount];
                dgvDateTime.Columns[0].Name = "Time";
                dgvDateTime.Columns[1].Name = "Availabilty";

                dtpDateTime.Value = DateTime.Now;
                DateTime startTimedateTime = Convert.ToDateTime("09:00:00");
                int time = serv.Time;
                if (checkEars.Checked) time += Globals.extraEarsMinute;
                if (checkNails.Checked) time += Globals.extraNailsMinute;
                if (checkTeeth.Checked) time += Globals.extraTeethMinute;
                DateTime endTime = startTimedateTime.AddMinutes(time);

                while (startTimedateTime.Hour < 17 && endTime.Hour <= 17)
                {
                    rows[0] = startTimedateTime.ToShortTimeString();
                    rows[1] = "Yes";
                    foreach (Orders odr in orders)
                    {
                        if (odr.Date == order.Date)
                        {
                            if (Convert.ToDateTime(odr.StartTime) >= startTimedateTime && Convert.ToDateTime(odr.EndTime) <= endTime) rows[1] = "No (Another booking is taking place)";
                            else continue;
                        }
                        else continue;
                    }
                    dgvDateTime.Rows.Add(rows);
                    startTimedateTime = startTimedateTime.AddMinutes(15.0);
                    endTime = startTimedateTime.AddMinutes(serv.Time);
                }
                foreach(DataGridViewRow row in dgvDateTime.Rows)
                {
                    string rowStr = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    if (rowStr.Contains("No"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            else if (type == "date")
            {
                dgvDateTime.ColumnCount = 2;
                string[] rows = new string[dgvDateTime.ColumnCount];
                dgvDateTime.Columns[0].Name = "Date";
                dgvDateTime.Columns[1].Name = "Availabilty";

                dtpDateTime.Value = DateTime.Now;
                DateTime date = dtpDateTime.Value;
                DateTime min = dtpDateTime.MinDate;
                DateTime max = dtpDateTime.MaxDate;

                while (min < max)
                {
                    rows[0] = date.ToShortDateString();
                    if (!orders.Any()) rows[1] = "Yes";
                    if (DateSystem.IsPublicHoliday(date, CountryCode.GB)) rows[1] = "No - Public Holiday";
                    if (DateSystem.IsWeekend(date, CountryCode.GB)) rows[1] = "No - Weekend";
                    else
                    {
                        foreach (Orders order in orders)
                        {
                            if (date.ToShortDateString() == order.Date && getIdFromString(cboxDog.Text) == order.DogId)
                            {
                                rows[1] = $"No - {dogAccess.getDogById(order.DogId).Name} is already booked in for this day";
                                break;
                            }
                            else rows[1] = "Yes";
                        }
                    }
                    rows[0] += $"({date.DayOfWeek})";
                    dgvDateTime.Rows.Add(rows);
                    date = date.AddDays(1);
                    min = min.AddDays(1);
                }
                foreach (DataGridViewRow row in dgvDateTime.Rows)
                {
                    string rowStr = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    if (rowStr.Contains("No"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            else if (type == "staff")
            {
                dgvDateTime.ColumnCount = 2;
                string[] rows = new string[dgvDateTime.ColumnCount];
                dgvDateTime.Columns[0].Name = "Staff Member";
                dgvDateTime.Columns[1].Name = "Availabilty";

                DateTime date = Convert.ToDateTime(order.Date);
                DateTime start = Convert.ToDateTime(order.StartTime);
                DateTime end = getEndTime(start);

                foreach (Staff staff in staffAccess.getAllStaff().FindAll(e => e.Deleted == 0))
                {
                    rows[0] = $"{staff.Name}";
                    rows[1] = "Yes";
                    foreach (Orders order in orders.FindAll(e => e.Cancelled == 0))
                    {
                        if (order.StaffId == staff.Id)
                        {
                            if (Convert.ToDateTime(order.Date) == date)
                            {
                                if (Convert.ToDateTime(order.StartTime) == start && Convert.ToDateTime(order.EndTime) == end)
                                {
                                    rows[1] = $"No - Booking with {dogAccess.getDogById(order.DogId).Name}";
                                }
                                else rows[1] = "Yes";
                            }
                            else rows[1] = "Yes";
                        }
                        else rows[1] = "Yes";
                    }
                    dgvDateTime.Rows.Add(rows);
                }
                foreach (DataGridViewRow row in dgvDateTime.Rows)
                {
                    string rowStr = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    if (rowStr.Contains("No"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            else if (type == "orders")
            {
                List<Orders> orders = orderAccess.getAllOrders();
                dgvDateTime.ColumnCount = 10;
                string[] rows = new string[dgvDateTime.ColumnCount];
                dgvDateTime.Columns[0].Name = "Order ID";
                dgvDateTime.Columns[1].Name = "Dog";
                dgvDateTime.Columns[2].Name = "Date";
                dgvDateTime.Columns[3].Name = "Starting Time";
                dgvDateTime.Columns[4].Name = "Staff Assigned";
                dgvDateTime.Columns[5].Name = "Service";
                dgvDateTime.Columns[6].Name = "Extra Ears";
                dgvDateTime.Columns[7].Name = "Extra Nails";
                dgvDateTime.Columns[8].Name = "Extra Teeth";
                dgvDateTime.Columns[9].Name = "Customer has Paid?";

                foreach (Orders order in orders.FindAll(e => e.Cancelled == 0))
                {
                    rows[0] = order.Id.ToString();
                    Dog dog = dogAccess.getDogById(order.DogId);
                    rows[1] = dog.Name;
                    rows[2] = order.Date;
                    rows[3] = order.StartTime;
                    rows[4] = staffAccess.getStaffById(order.StaffId).Name;
                    Service serv = serviceAccess.getServiceById(servOrderAccess.getObjectByOrderID(order.Id).ServiceID);
                    rows[5] = serv.Description;
                    rows[6] = order.Ears == 0 ? "No" : "Yes";
                    rows[7] = order.Nails == 0 ? "No" : "Yes";
                    rows[8] = order.Teeth == 0 ? "No" : "Yes";
                    rows[9] = order.Paid == 0 ? "No" : "Yes";
                    dgvDateTime.Rows.Add(rows);
                }
            }
        }

        private DateTime getEndTime(DateTime start = new DateTime(), bool add = false)
        {
            string[] date = txtDate.Text.Split('/');
            string[] time = txtTime.Text.Split(':');
            dtpDateTime.Value = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]), Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 00);
            int hours = dtpDateTime.Value.AddMinutes(serv.Time).Hour;
            DateTime min = dtpDateTime.Value;
            if (order.Nails == 1) min = min.AddMinutes(Globals.extraNailsMinute);
            if (order.Teeth == 1) min = min.AddMinutes(Globals.extraTeethMinute);
            if (order.Ears == 1) min = min.AddMinutes(Globals.extraEarsMinute);
            if (add) // if we are adding a record
            {
                List<Orders> tempOrders = orderAccess.getAllOrders().FindAll(e => e.DogId == order.DogId);
                if (tempOrders.Count >= 1) min = min.AddMinutes(Globals.firstTimeMinute);
            }
            return min;
        }
        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mode != "view")
            {
                changeMode("view");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mode != "add") changeMode("add");
            else
            {
                order.Id = orderAccess.getAllOrders().Count + 1;
                order.DogId = Convert.ToInt32(cboxDog.Text.Replace(" ", "").Split('-')[0]);
                order.StaffId = staffAccess.getStaffByName(txtStaff.Text.Replace(" ", "").Split('-')[0]).Id;
                order.Cancelled = 0;
                order.Paid = checkPaid.Checked ? 1 : 0;
                order.Date = txtDate.Text;
                order.StartTime = txtTime.Text;
                

                order.Ears = checkEars.Checked ? 1 : 0;
                order.Nails = checkNails.Checked ? 1 : 0;
                order.Teeth = checkTeeth.Checked ? 1 : 0;
                order.EndTime = getEndTime().ToShortTimeString();

                ServiceOrder so = new ServiceOrder(order.Id, serv.ServiceID);

                DialogResult opt = MessageBox.Show("Are you sure these details are correct?", "Add Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    if (orderAccess.insertOrder(order) && servOrderAccess.insertServiceOrder(so))
                    {
                        changeMode("view");
                        MessageBox.Show("The order has been recorded successfully", "Order Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong when recording the order. Please try again in a few minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs ev)
        {
            if (mode != "edit") changeMode("edit");
            else
            {
                if (cboxDog.Text == string.Empty)
                {
                    MessageBox.Show("Select the dog for the booking", "Select Dog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboxServices.Text == string.Empty)
                {
                    MessageBox.Show("Select a service for the dog", "Select Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtDate.Text == string.Empty)
                {
                    MessageBox.Show("Select a date for the booking", "Select Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(txtTime.Text == string.Empty)
                {
                    MessageBox.Show("Select the start time for the booking", "Select Start Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(txtStaff.Text == string.Empty)
                {
                    MessageBox.Show("Select the staff for the booking", "Select Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                order.Date = txtDate.Text;
                order.StartTime = txtTime.Text;
                order.EndTime = getEndTime().ToShortTimeString();

                DialogResult res = MessageBox.Show("Are you sure you want to update this order's details?", "Update Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (orderAccess.updateOrder(order) && serviceAccess.updateService(serv))
                    {
                        changeMode("view");
                        MessageBox.Show("Successfully updated the order details", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong while saving the order details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult opt = MessageBox.Show("Are you sure you want to cancel this order? This is permanent and cannot be reversed", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opt == DialogResult.Yes)
            {
                order.Cancelled = 1;
                if (orderAccess.updateOrder(order))
                    MessageBox.Show("This order has been cancelled. It will now be refunded the amount that has already been paid for", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelectDate_Click(object sender, EventArgs e)
        {
            type = "date";
            populateDataGrid();
        }

        private void btnSelectStaff_Click(object sender, EventArgs e)
        {
            type = "staff";
            populateDataGrid();
        }

        private void btnSelectTime_Click(object sender, EventArgs e)
        {
            type = "time";
            populateDataGrid();
        }

        private void checkDelDog_CheckedChanged(object sender, EventArgs e)
        {
            populateDogCbox(true);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            changeMode("view");
        }

        private void dgvDateTime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (type == "orders")
            {
                btnUpdate.Enabled = true;
                order = orderAccess.getOrderById(Convert.ToInt32(dgvDateTime.Rows[e.RowIndex].Cells[0].Value));
            }
            else if (type == "date")
            {
                if (dgvDateTime.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                {
                    MessageBox.Show("This date is not available to select a booking for. Please select another date", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string date = Convert.ToString(dgvDateTime.Rows[e.RowIndex].Cells[0].Value).Split('(')[0];
                order.Date = date;
                txtDate.Text = date;
                type = "";
                populateDataGrid();
                btnSelectTime.Enabled = true;
            }
            else if (type == "time")
            {
                if (dgvDateTime.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                {
                    MessageBox.Show("This time is not available to select a booking for. Please select another time", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string time = Convert.ToString(dgvDateTime.Rows[e.RowIndex].Cells[0].Value);
                txtTime.Text = time;
                order.StartTime = time;
                order.EndTime = getEndTime().ToShortTimeString();
                type = "";
                populateDataGrid();
                btnSelectStaff.Enabled = true;
            }
            else if (type == "staff")
            {
                if (dgvDateTime.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                {
                    MessageBox.Show("This staff member is not available at this time", "Invalid Staff Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = Convert.ToString(dgvDateTime.Rows[e.RowIndex].Cells[0].Value);
                order.StaffId = staffAccess.getStaffByName(name).Id;
                txtStaff.Text = name;
                type = "";
                populateDataGrid();
            }
        }

        private void cboxCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDogCbox();
        }
        #endregion

        private void checkNails_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNails.Checked)
            {
                DateTime end = getEndTime(Convert.ToDateTime(order.StartTime), true);
                if (end.Hour > 17 || (end.Hour == 17 && end.Minute > 00))
                {
                    MessageBox.Show("You cannot add the Extra Nails as it finishes after closing time", "Cannot add extra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    checkNails.Checked = false;
                    order.Nails = 0;
                }
                else
                {
                    order.EndTime = end.ToString();
                    order.Nails = 1;
                }
            }
        }

        private void checkTeeth_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTeeth.Checked)
            {
                DateTime end = getEndTime(Convert.ToDateTime(order.StartTime), true);
                if (end.Hour > 17 || (end.Hour == 17 && end.Minute > 00))
                {
                    MessageBox.Show("You cannot add the Extra Teeth as it finishes after closing time", "Cannot add extra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    checkTeeth.Checked = false;
                    order.Teeth = 0;
                }
                else
                {
                    order.EndTime = end.ToString();
                    order.Teeth = 1;
                }
            }
        }

        private void checkEars_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEars.Checked)
            {
                DateTime end = getEndTime(Convert.ToDateTime(order.StartTime), true);
                if (end.Hour > 17 || (end.Hour == 17 && end.Minute > 00))
                {
                    MessageBox.Show("You cannot add the Extra Ears as it finishes after closing time", "Cannot add extra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    checkEars.Checked = false;
                    order.Ears = 0;
                }
                else
                {
                    order.EndTime = end.ToString();
                    order.Ears = 1;
                }
            }
        }
    }
}
