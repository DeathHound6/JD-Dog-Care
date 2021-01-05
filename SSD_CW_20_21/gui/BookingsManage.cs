using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;
using System;
using System.Collections.Generic;
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

            dtpRoomView.MinDate = DateTime.Today;
            dtpRoomView.Value = DateTime.Now;
            dtpDateTime.Value = DateTime.Now;

            Text = "JD Dog Care - Add Bookings";

            changeMode("view");
            populateComboBox();
            type = "orders";
            populateDataGrid();
            txtStaff.Enabled = false;
            txtTime.Enabled = false;
            txtDate.Enabled = false;
        }

        #region Custom Methods
        private void populateComboBox()
        {
            populateServCbox();
            populateCustCbox(checkDelCust.Checked);
            populateDogCbox(checkDelDog.Checked);
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

                dgvSelect.Enabled = true;
                dgvSelect.Visible = true;
                dgvRoomOne.Visible = false;
                dgvRoomTwo.Visible = false;
                dgvRoomThree.Visible = false;

                dgvRoomOne.Columns.Clear();
                dgvRoomOne.Rows.Clear();
                dgvRoomTwo.Columns.Clear();
                dgvRoomTwo.Rows.Clear();
                dgvRoomThree.Columns.Clear();
                dgvRoomThree.Rows.Clear();
                dgvSelect.Columns.Clear();
                dgvSelect.Rows.Clear();

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
                txtPaid.Enabled = true;

                cboxCust.Enabled = true;
                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                checkEars.Checked = false;
                checkNails.Checked = false;
                checkTeeth.Checked = false;
                lblOrderCancelled.Visible = false;

                lblDate.Visible = false;
                dtpRoomView.Visible = false;
                lblMessageOne.Visible = false;
                lblMessageTwo.Visible = false;
                lblRoomOne.Visible = false;
                lblRoomTwo.Visible = false;
                lblRoomThree.Visible = false;

                cboxCust.Text = "";
                cboxDog.Text = "";
                cboxServices.Text = "";
            }
            else if (newMode == "edit")
            {
                mode = newMode;

                dgvSelect.Visible = false;
                dgvRoomOne.Visible = true;
                dgvRoomTwo.Visible = true;
                dgvRoomThree.Visible = true;

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
                txtPaid.Enabled = true;

                cboxCust.Enabled = true;
                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                lblOrderCancelled.Visible = order.Cancelled == 0 ? false : true;

                checkEars.Checked = order.Ears == 0 ? false : true;
                checkNails.Checked = order.Nails == 0 ? false : true;
                checkTeeth.Checked = order.Teeth == 0 ? false : true;

                lblDate.Visible = false;
                dtpRoomView.Visible = false;
                lblMessageOne.Visible = false;
                lblMessageTwo.Visible = false;
                lblRoomOne.Visible = false;
                lblRoomTwo.Visible = false;
                lblRoomThree.Visible = false;

                cboxCust.Text = $"{dogAccess.getDogById(order.DogId).OwnerId} - {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Forename} {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Surname}";
                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceID} - {serv.Description}";
            }
            else if (newMode == "view")
            {
                if (orders.Count > 0) order = orders.ToArray()[0];
                else order = new Orders(1, 1, 1, dtpDateTime.Value.ToShortDateString(), dtpDateTime.Value.ToShortTimeString(), dtpDateTime.Value.AddMinutes(serv.Time).ToShortTimeString(), 0, 0, 0, 1, 0);
                mode = newMode;

                dgvSelect.Visible = false;
                dgvRoomOne.Visible = true;
                dgvRoomTwo.Visible = true;
                dgvRoomThree.Visible = true;

                dgvSelect.Enabled = false;
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
                txtPaid.Enabled = false;
                checkTeeth.Enabled = false;

                cboxCust.Text = $"{dogAccess.getDogById(order.DogId).OwnerId} - {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Forename} {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Surname}";
                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceID} - {serv.Description}";
                checkDelDog.Checked = false;
                checkEars.Checked = false;
                checkNails.Checked = false;
                checkTeeth.Checked = false;

                lblDate.Visible = true;
                dtpRoomView.Visible = true;
                lblMessageOne.Visible = true;
                lblMessageTwo.Visible = true;
                lblRoomOne.Visible = true;
                lblRoomTwo.Visible = true;
                lblRoomThree.Visible = true;

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
            dgvSelect.Columns.Clear();
            dgvSelect.Rows.Clear();

            if (type == "time")
            {
                dgvSelect.ColumnCount = 2;
                string[] rows = new string[dgvSelect.ColumnCount];
                dgvSelect.Columns[0].Name = "Time";
                dgvSelect.Columns[1].Name = "Availabilty";

                dtpDateTime.Value = DateTime.Now;
                DateTime startTimedateTime = Convert.ToDateTime("09:00:00");

                while (startTimedateTime < Convert.ToDateTime("17:00:00"))
                {
                    rows[0] = startTimedateTime.ToShortTimeString();
                    rows[1] = "Yes";
                    foreach (Orders odr in orders)
                    {
                        if (odr.Date == order.Date)
                        {
                            if (Convert.ToDateTime(odr.StartTime) >= startTimedateTime && Convert.ToDateTime(odr.EndTime) < startTimedateTime) rows[1] = "No (Another booking is taking place)";
                            else continue;
                        }
                        else continue;
                    }
                    dgvSelect.Rows.Add(rows);
                    startTimedateTime = startTimedateTime.AddMinutes(15);
                }
                foreach (DataGridViewRow row in dgvSelect.Rows)
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
                dgvSelect.ColumnCount = 2;
                string[] rows = new string[dgvSelect.ColumnCount];
                dgvSelect.Columns[0].Name = "Date";
                dgvSelect.Columns[1].Name = "Availabilty";

                dtpDateTime.Value = DateTime.Now;
                DateTime min = dtpDateTime.Value;
                DateTime max = min.AddYears(1);

                while (min < max)
                {
                    if (dtpDateTime.Value.AddDays(3) >= min)
                    {
                        min = min.AddDays(1);
                        continue;
                    }
                    rows[0] = min.ToShortDateString();
                    if (!orders.Any()) rows[1] = "Yes";
                    if (DateSystem.IsPublicHoliday(min, CountryCode.GB)) rows[1] = "No - Public Holiday";
                    else if (DateSystem.IsWeekend(min, CountryCode.GB)) rows[1] = "No - Weekend";
                    else
                    {
                        foreach (Orders order in orders)
                        {
                            if (min.ToShortDateString() == order.Date && getIdFromString(cboxDog.Text) == order.DogId)
                            {
                                rows[1] = $"No - {dogAccess.getDogById(order.DogId).Name} is already booked in for this day";
                                break;
                            }
                            else rows[1] = "Yes";
                        }
                    }
                    rows[0] += $"({min.DayOfWeek})";
                    dgvSelect.Rows.Add(rows);
                    min = min.AddDays(1);
                }
                foreach (DataGridViewRow row in dgvSelect.Rows)
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
                dgvSelect.ColumnCount = 2;
                string[] rows = new string[dgvSelect.ColumnCount];
                dgvSelect.Columns[0].Name = "Staff Member";
                dgvSelect.Columns[1].Name = "Availabilty";

                DateTime date = Convert.ToDateTime(order.Date);
                DateTime start = Convert.ToDateTime(order.StartTime);
                DateTime end = getEndTime(start);

                foreach (Staff staff in staffAccess.getAllStaff().FindAll(e => e.Deleted == 0))
                {
                    rows[0] = $"{staff.Name}";
                    rows[1] = "Yes";
                    bool staffAvailableOnOrderDay = false;
                    foreach (string day in staff.WorkingDays.Split(','))
                    {
                        if (date.DayOfWeek.ToString().Contains(day))
                        {
                            staffAvailableOnOrderDay = true;
                            break;
                        }
                    }
                    if (staffAvailableOnOrderDay)
                    {
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
                    }
                    else rows[1] = "No - Not working on this day";
                    dgvSelect.Rows.Add(rows);
                }
                foreach (DataGridViewRow row in dgvSelect.Rows)
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
                displayBookingSlots();
            }
        }

        private void displayBookingSlots()
        {
            object[] arr = { dgvRoomOne, dgvRoomTwo, dgvRoomThree };
            int roomID = 0;
            foreach (DataGridView dgv in arr)
            {
                dgv.Rows.Clear();
                dgv.Columns.Clear();
                roomID++;
                List<Orders> orders = orderAccess.getAllOrders().FindAll(e => {
                    return e.Cancelled == 0 && e.RoomID == roomID && Convert.ToDateTime(e.Date) == Convert.ToDateTime(dtpRoomView.Value.ToShortDateString());
                });
                DateTime start = Convert.ToDateTime("09:00:00");
                while (start < Convert.ToDateTime("17:00:00"))
                {
                    // create each column
                    dgv.Columns.Add("", "");
                    start = start.AddMinutes(15);
                }
                dgv.Rows.Add();
                dgv.RowTemplate.Height = dgv.Height;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    // style each column
                    col.Width = dgv.Size.Width / dgv.Columns.Count;
                    col.DividerWidth = 1;
                    col.Tag = -1;

                    if (orders.Count > 0)
                    {
                        foreach (Orders order in orders)
                        {
                            dgv.Rows[0].Cells[col.Index].Style.BackColor = Color.Green;
                            start = Convert.ToDateTime("09:00:00");
                            for (int j = 1; j <= 32 / col.Index; j++)
                            {
                                start = start.AddMinutes(15);
                                if (Convert.ToDateTime(order.StartTime) >= start && Convert.ToDateTime(order.EndTime) < start)
                                {
                                    col.Tag = order.Id;
                                    dgv.Rows[0].Cells[col.Index].Style.BackColor = Color.Red;
                                }
                            }
                        }
                    }
                    else dgv.Rows[0].Cells[col.Index].Style.BackColor = Color.Green;
                }
            }
        }

        private DateTime getEndTime(DateTime start = new DateTime(), bool add = false)
        {
            dtpDateTime.Value = start;
            int hours = dtpDateTime.Value.AddMinutes(serv.Time).Hour;
            DateTime min = dtpDateTime.Value;
            if (order.Nails == 1) min = min.AddMinutes(Globals.extraNailsMinute);
            if (order.Teeth == 1) min = min.AddMinutes(Globals.extraTeethMinute);
            if (order.Ears == 1) min = min.AddMinutes(Globals.extraEarsMinute);
            if (add) // if we are adding a record
            {
                List<Orders> tempOrders = orderAccess.getAllOrders().FindAll(e => e.DogId == order.DogId);
                if (tempOrders.Count == 0) min = min.AddMinutes(Globals.firstTimeMinute);
            }
            return min;
        }

        private double calcCost(Orders order)
        {
            double cost = serv.Cost;
            if (order.Ears == 1) cost += Globals.extraEarsPrice;
            if (order.Nails == 1) cost += Globals.extraNailsPrice;
            if (order.Teeth == 1) cost += Globals.extraTeethPrice;
            if (orderAccess.getAllOrders().FindAll(e => e.DogId == order.DogId).Count == 0 || orderAccess.getAllOrders().Find(e => e.DogId == order.DogId) == order) cost += 5.00; // first time cost
            return cost;
        }

        private void roomDGVCellClick(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            int orderID = Convert.ToInt32(dgv.Columns[e.ColumnIndex].Tag.ToString());
            Orders odr = orderID != -1 ? orderAccess.getOrderById(orderID) : null;

            if (odr == null)
            {
                MessageBox.Show("During this timeslot, there is no order appointment taking place", "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string text = $"Dog: {dogAccess.getDogById(odr.DogId).Name}";
                text += $"\nDate: {odr.Date}";
                text += $"\nTime: {odr.StartTime} - {odr.EndTime}";
                text += $"\nRoom: #{odr.RoomID}";
                text += $"\nStaff: {staffAccess.getStaffById(odr.StaffId).Name}";
                text += $"\nPaid Amount: {odr.Paid} / {calcCost(odr)}";
                MessageBox.Show(text, $"Order #{odr.Id}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkValidEndTime(CheckBox obj)
        {
            if (obj.Checked && order.StartTime != null)
            {
                DateTime end = getEndTime(Convert.ToDateTime(order.StartTime), true);
                if (end.Hour >= 17)
                {
                    MessageBox.Show($"You cannot add the Extra {obj.Text} as it finishes after closing time", "Cannot add extra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    obj.Checked = false;
                    if (obj == checkNails) order.Nails = 0;
                    else if (obj == checkTeeth) order.Teeth = 0;
                    else if (obj == checkEars) order.Ears = 0;
                }
                else
                {
                    order.EndTime = end.ToShortTimeString();
                    txtEndtime.Text = order.EndTime;
                    if (obj == checkNails) order.Nails = 1;
                    else if (obj == checkTeeth) order.Teeth = 1;
                    else if (obj == checkEars) order.Ears = 1;
                }
            }
        }

        private bool checkValidEndTime(ComboBox obj)
        {
            if (obj.Text != "" && order.StartTime != null)
            {
                DateTime end = getEndTime(Convert.ToDateTime(order.StartTime), true);
                if (end.Hour >= 17)
                {
                    MessageBox.Show($"You cannot pick this service as as it finishes after closing time", "Cannot add extra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboxServices.Text = serv.Description;
                    return false;
                }
                else
                {
                    serv = serviceAccess.getServiceByDesc(cboxServices.Text);
                    order.EndTime = end.ToShortTimeString();
                    txtEndtime.Text = order.EndTime;
                    return true;
                }
            }
            return true;
        }

        private void dgvCellMouseClick(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            int orderID = Convert.ToInt32(dgv.Columns[e.ColumnIndex].Tag.ToString());
            Orders odr = orderID != -1 ? orderAccess.getOrderById(orderID) : null;

            if (odr == null)
            {
                MessageBox.Show("During this timeslot, there is no order appointment taking place", "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                order = orderAccess.getOrderById(Convert.ToInt32(dgv.Columns[e.ColumnIndex].Tag.ToString()));
                changeMode("view");
            }
        }

        private bool checkValidPaidAmount(double amount)
        {
            // if text doesn't start with '£', append it to the start
            if (!txtPaid.Text.StartsWith("£"))
            {
                string text = txtPaid.Text;
                txtPaid.Text = $"£{text}";
            }

            // if text doesn't end with '.', append it
            if (!txtPaid.Text.EndsWith(".")) txtPaid.Text += ".";

            // if text isn't in money format (ending in '.dd' - where d is a digit) append it with the correct amount of 0s
            if (txtPaid.Text.Split('.')[1].Length < 2)
            {
                int zeroCount = 2 - txtPaid.Text.Split('.')[1].Length;
                string toAdd = "";
                for (int i = 0; i < zeroCount; i++)
                {
                    toAdd += "0";
                }
                txtPaid.Text += toAdd;
            }

            // if amount paid is negative, inform user
            if (Convert.ToDouble(txtPaid.Text.Replace("£", "")) < 0)
            {
                MessageBox.Show("The paid amount input cannot be lower than the £0.00", "Paid Amount too small", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // if amount paid input is greater than the actual cost of the order, inform user
            if (Convert.ToDouble(txtPaid.Text.Replace("£", "")) > calcCost(order))
            {
                MessageBox.Show("The paid amount input cannot be greater than the cost of the order", "Paid Amount too big", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mode != "view") changeMode("view");
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
                order.Paid = Convert.ToDouble(txtPaid.Text.Replace("£", ""));
                if (!checkValidPaidAmount(order.Paid)) return;
                order.Date = txtDate.Text;
                order.StartTime = txtTime.Text;

                order.Ears = checkEars.Checked ? 1 : 0;
                order.Nails = checkNails.Checked ? 1 : 0;
                order.Teeth = checkTeeth.Checked ? 1 : 0;
                order.EndTime = getEndTime(Convert.ToDateTime(txtTime.Text), true).ToShortTimeString();

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

        private void checkNails_CheckedChanged(object sender, EventArgs e)
        {
            checkValidEndTime(checkNails);
            txtCost.Text = $"£{calcCost(order)}";
        }

        private void checkTeeth_CheckedChanged(object sender, EventArgs e)
        {
            checkValidEndTime(checkTeeth);
            txtCost.Text = $"£{calcCost(order)}";
        }

        private void checkEars_CheckedChanged(object sender, EventArgs e)
        {
            checkValidEndTime(checkEars);
            txtCost.Text = $"£{calcCost(order)}";
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
                order.EndTime = getEndTime(Convert.ToDateTime(order.Date)).ToShortTimeString();
                order.Paid = Convert.ToDouble(txtPaid.Text.Replace("£", ""));
                if (!checkValidPaidAmount(order.Paid)) return;

                ServiceOrder so = servOrderAccess.getObjectByOrderID(order.Id);
                so.ServiceID = serviceAccess.getServiceByDesc(cboxServices.Text).ServiceID;

                DialogResult res = MessageBox.Show("Are you sure you want to update this order's details?", "Update Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (orderAccess.updateOrder(order) && servOrderAccess.updateServOrder(so))
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
            populateDogCbox(checkDelDog.Checked);
        }

        private void checkDelCust_CheckedChanged(object sender, EventArgs e)
        {
            populateCustCbox(checkDelCust.Checked);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            changeMode("view");
        }

        private void dgvSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvSelect.Rows[e.RowIndex].Cells[0].Value == null) return;
            if (type == "date")
            {
                if (dgvSelect.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                {
                    MessageBox.Show("This date is not available to select a booking for. Please select another date", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string date = Convert.ToString(dgvSelect.Rows[e.RowIndex].Cells[0].Value).Split('(')[0];
                order.Date = date;
                txtDate.Text = date;
                type = "";
                populateDataGrid();
                btnSelectTime.Enabled = true;
            }
            else if (type == "time")
            {
                if (dgvSelect.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                {
                    MessageBox.Show("This time is not available to select a booking for. Please select another time", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string time = Convert.ToString(dgvSelect.Rows[e.RowIndex].Cells[0].Value);
                txtTime.Text = time;
                order.StartTime = time;
                order.EndTime = getEndTime(Convert.ToDateTime(time)).ToShortTimeString();
                txtEndtime.Text = order.EndTime;
                type = "";
                populateDataGrid();
                btnSelectStaff.Enabled = true;
            }
            else if (type == "staff")
            {
                if (dgvSelect.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                {
                    MessageBox.Show("This staff member is not available at this time", "Invalid Staff Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = Convert.ToString(dgvSelect.Rows[e.RowIndex].Cells[0].Value);
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

        private void dgvRoomOne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            roomDGVCellClick(dgvRoomOne, e);
        }

        private void dgvRoomTwo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            roomDGVCellClick(dgvRoomTwo, e);
        }

        private void dgvRoomThree_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            roomDGVCellClick(dgvRoomThree, e);
        }

        private void dtpRoomView_ValueChanged(object sender, EventArgs e)
        {
            displayBookingSlots();
        }

        private void cboxServices_Click(object sender, EventArgs e)
        {
            if (checkValidEndTime(cboxServices)) serv = serviceAccess.getServiceByDesc(cboxServices.Text);
            txtCost.Text = $"£{calcCost(order)}";
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtPaid_Enter(object sender, EventArgs e)
        {
            if (!checkValidPaidAmount(Convert.ToDouble(txtPaid.Text.Replace("£", "")))) return;
        }

        private void dgvRoomOne_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvCellMouseClick(dgvRoomOne, e);
            }
        }

        private void dgvRoomTwo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvCellMouseClick(dgvRoomTwo, e);
            }
        }

        private void dgvRoomThree_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvCellMouseClick(dgvRoomThree, e);
            }
        }
        #endregion
    }
}
