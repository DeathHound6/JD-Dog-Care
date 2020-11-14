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
        private Orders order;
        private Service serv;
        private string mode = "";
        private string type = "";

        private DataTable datasource = new DataTable();

        private string[] services = { "Wash, shampoo, brush", "Wash, shampoo, brush, trim", "Wash, shampoo, brush, full-trim" };
        #endregion

        public BookingsManage() : base()
        {
            InitializeComponent();
            dtpDateTime.Value = DateTime.Now;
            orders = orderAccess.getAllOrders();
            if (orders.Count > 0) order = orders.ToArray()[0];
            else order = new Orders(1, 1, 1, dtpDateTime.Value.ToShortDateString(), dtpDateTime.Value.ToShortTimeString(), dtpDateTime.Value.AddHours(Globals.defBookingLengthHour).ToShortTimeString(), 0);
            if (serviceAccess.getAllServices().Count > 0) serv = serviceAccess.getAllServices().ToArray()[0];
            else serv = new Service(1, 1, 0, 0, 0);

            Text = "JD Dog Care - Add Bookings";
            
            populateComboBox();
            txtStaff.Enabled = false;
            txtTime.Enabled = false;
            txtDate.Enabled = false;
            changeMode("view");
        }

        #region Custom Methods
        private void populateListBoxes()
        {
            dogs = dogAccess.getAllDogs();
            if (checkDelDog.Checked) dogs = dogs.FindAll(e => e.Deleted == 0);
            foreach (Dog dog in dogs)
            {
                cboxDog.Items.Add($"{dog.Id} - {dog.Name}");
            }

            for (int i = 0; i < services.Length; i++)
            {
                cboxServices.Items.Add($"{i + 1} - {services[i]}");
            }
        }

        private void populateComboBox(bool del = false)
        {
            cboxServices.Items.Clear();
            int optionNo = 1;
            foreach(string option in services)
            {
                cboxServices.Items.Add($"{optionNo} - {option}");
                optionNo++;
            }

            cboxDog.Items.Clear();
            List<Dog> dogs = dogAccess.getAllDogs();
            if (del) dogs = dogs.FindAll(e => e.Deleted == 0);
            foreach(Dog dog in dogs)
            {
                cboxDog.Items.Add($"{dog.Id} - {dog.Name}");
            }
        }

        private void changeMode(string newMode)
        {
            if (newMode == "add")
            {
                mode = newMode;

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
                btnView.Enabled = true;
                btnSelectDate.Enabled = true;
                btnSelectStaff.Enabled = true;
                btnSelectTime.Enabled = true;
                checkDelDog.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;
                checkPaid.Enabled = true;

                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                checkEars.Checked = false;
                checkNails.Checked = false;
                checkTeeth.Checked = false;
                lblOrderCancelled.Visible = false;

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

                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                lblOrderCancelled.Visible = order.Cancelled == 0 ? false : true;

                checkEars.Checked = serv.Ears == 0 ? false : true;
                checkNails.Checked = serv.Nails == 0 ? false : true;
                checkTeeth.Checked = serv.Teeth == 0 ? false : true;

                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceOption} - {services[serv.ServiceOption - 1]}";
            }
            else if (newMode == "view")
            {
                mode = newMode;

                dgvDateTime.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnView.Enabled = false;
                btnSelectDate.Enabled = false;
                btnSelectStaff.Enabled = false;
                btnSelectTime.Enabled = false;

                cboxDog.Enabled = false;
                cboxServices.Enabled = false;
                checkDelDog.Enabled = false;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                checkPaid.Enabled = false;
                checkTeeth.Enabled = false;

                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceOption} - {services[serv.ServiceOption - 1]}";
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
                TimeSpan time = dtpDateTime.Value.TimeOfDay;
            }
            else if (type == "date")
            {
                dgvDateTime.ColumnCount = 2;
                string[] rows = new string[dgvDateTime.ColumnCount];
                dgvDateTime.Columns[0].Name = "Date";
                dgvDateTime.Columns[1].Name = "Availabilty";

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
            }
            else if (type == "staff")
            {
                dgvDateTime.ColumnCount = 2;
                string[] rows = new string[dgvDateTime.ColumnCount];
                dgvDateTime.Columns[0].Name = "Staff Member";
                dgvDateTime.Columns[1].Name = "Availabilty";

                string[] day = order.Date.Split('/'); // order date
                string[] st = order.StartTime.Split(':'); // order start time
                string[] et = order.EndTime.Split(':'); // order endtime
                dtpDateTime.Value = new DateTime(Convert.ToInt32(day[2]), Convert.ToInt32(day[1]), Convert.ToInt32(day[0]), Convert.ToInt32(st[0]), Convert.ToInt32(st[1]), 00); // startTime
                string start = $"{dtpDateTime.Value.Hour}:{dtpDateTime.Value.Minute}";
                string date = dtpDateTime.Value.ToShortTimeString();
                dtpDateTime.Value = new DateTime(Convert.ToInt32(day[2]), Convert.ToInt32(day[1]), Convert.ToInt32(day[0]), Convert.ToInt32(et[0]), Convert.ToInt32(et[1]), 00); // endTime 
                string end = $"{dtpDateTime.Value.Hour}:{dtpDateTime.Value.Minute}";

                foreach (Staff staff in staffAccess.getAllStaff().FindAll(e => e.Deleted == 0))
                {
                    rows[0] = $"{staff.Name}";
                    rows[1] = "Available";
                    foreach (Orders order in orders.FindAll(e => e.Cancelled == 0))
                    {
                        if (order.StaffId == staff.Id)
                        {
                            if (order.Date == date)
                            {
                                if (order.StartTime == start && order.EndTime == end)
                                {
                                    rows[1] = $"Unavailable - Booking with {dogAccess.getDogById(order.DogId).Name}";
                                }
                                else rows[1] = "Available";
                            }
                            else rows[1] = "Available";
                        }
                        else rows[1] = "Available";
                    }
                    dgvDateTime.Rows.Add(rows);
                }
                foreach (DataGridViewRow row in dgvDateTime.Rows)
                {
                    string rowStr = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    if (rowStr == "Unavailable")
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
                dgvDateTime.ColumnCount = 11;
                string[] rows = new string[dgvDateTime.ColumnCount];
                dgvDateTime.Columns[0].Name = "Order ID";
                dgvDateTime.Columns[1].Name = "Dog";
                dgvDateTime.Columns[2].Name = "Dog Owner";
                dgvDateTime.Columns[3].Name = "Date";
                dgvDateTime.Columns[4].Name = "Starting Time";
                dgvDateTime.Columns[5].Name = "Staff Assigned";
                dgvDateTime.Columns[6].Name = "Service";
                dgvDateTime.Columns[7].Name = "Extra Ears";
                dgvDateTime.Columns[8].Name = "Extra Nails";
                dgvDateTime.Columns[9].Name = "Extra Teeth";
                dgvDateTime.Columns[10].Name = "Customer has Paid?";

                foreach (Orders order in orders.FindAll(e => e.Cancelled == 0))
                {
                    rows[0] = order.Id.ToString();
                    Dog dog = dogAccess.getDogById(order.DogId);
                    rows[1] = dog.Name;
                    Customer cust = custAccess.getOwnerById(dog.OwnerId);
                    rows[2] = $"{cust.Forename} {cust.Surname}";
                    rows[3] = order.Date;
                    rows[4] = order.StartTime;
                    rows[5] = staffAccess.getStaffById(order.StaffId).Name;
                    Service serv = serviceAccess.getServiceById(servOrderAccess.getObjectByOrderID(order.Id).ServiceID);
                    rows[6] = services[serv.ServiceOption - 1];
                    rows[7] = serv.Ears == 0 ? "No" : "Yes";
                    rows[8] = serv.Nails == 0 ? "No" : "Yes";
                    rows[9] = serv.Teeth == 0 ? "No" : "Yes";
                    rows[10] = order.Paid == 0 ? "No" : "Yes";
                    dgvDateTime.Rows.Add(rows);
                }
            }
        }

        private string getEndTime(bool add = false)
        {
            string[] date = txtDate.Text.Split('/');
            string[] time = txtTime.Text.Split(':');
            dtpDateTime.Value = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]), Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 00);
            int hours = dtpDateTime.Value.AddHours(Globals.defBookingLengthHour).Hour;
            DateTime min = dtpDateTime.Value;
            if (serv.Nails == 1) min = min.AddMinutes(Globals.extraNailsMinute);
            if (serv.Teeth == 1) min = min.AddMinutes(Globals.extraTeethMinute);
            if (serv.Ears == 1) min = min.AddMinutes(Globals.extraEarsMinute);
            if (add) // if we are adding a record
            {
                List<Orders> tempOrders = orderAccess.getAllOrders().FindAll(e => e.DogId == order.DogId);
                if (tempOrders.Count >= 1) min = min.AddMinutes(Globals.firstTimeMinute);
            }
            return min.ToShortTimeString();
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
                order = new Orders();
                order.Id = orderAccess.getAllOrders().Count + 1;
                order.DogId = Convert.ToInt32(cboxDog.Text.Replace(" ", "").Split('-')[0]);
                order.StaffId = Convert.ToInt32(txtStaff.Text.Replace(" ", "").Split('-')[0]);
                order.Cancelled = 0;
                order.Paid = checkPaid.Checked ? 1 : 0;
                order.Date = txtDate.Text;
                order.StartTime = txtTime.Text;

                serv.ServiceID = serviceAccess.getAllServices().Count + 1;
                serv.ServiceOption = Convert.ToInt32(cboxServices.Text.Replace(" ", "").Split('-')[0]);
                serv.Ears = checkEars.Checked ? 1 : 0;
                serv.Nails = checkNails.Checked ? 1 : 0;
                serv.Teeth = checkTeeth.Checked ? 1 : 0;
                order.EndTime = getEndTime(true);

                ServiceOrder so = new ServiceOrder(order.Id, serv.ServiceID);

                DialogResult opt = MessageBox.Show("Are you sure these details are correct?", "Add Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    if (servOrderAccess.insertServiceOrder(so) && orderAccess.insertOrder(order) && serviceAccess.insertService(serv))
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
                order.EndTime = getEndTime();

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

        private void checkDelDog_CheckedChanged(object sender, EventArgs e)
        {
            populateComboBox(true);
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
        }
        #endregion
    }
}
