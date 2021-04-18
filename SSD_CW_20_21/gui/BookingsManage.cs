using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using Nager.Date;

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

            dtpRoomView.MaxDate = DateTime.Today.AddYears(1).AddDays(-1);
            dtpRoomView.MinDate = DateTime.Today.AddYears(-1);
            dtpRoomView.Value = DateTime.Today;

            dtpDateTime.MaxDate = DateTime.Today.AddYears(1);
            dtpDateTime.MinDate = DateTime.Today.AddYears(-1);
            dtpDateTime.Value = DateTime.Today;

            Text = "JD Dog Care - Manage Bookings";

            changeMode("view");
            populateComboBox();
            type = "orders";
            populateDataGrid();
            txtStaff.Enabled = false;
            txtTime.Enabled = false;
            txtDate.Enabled = false;
            txtCost.Text = "";
        }

        #region Custom Methods
        private string CleanTime(string time)
        {
            return time.Replace(" AM", "").Replace(" PM", "");
        }

        private void populateComboBox()
        {
            populateServCbox();
            populateCustCbox();
            populateDogCbox();
        }

        private static int SortOrders(Orders o1, Orders o2)
        {
            DateTime time2 = Convert.ToDateTime(o1.Date);
            DateTime time1 = Convert.ToDateTime(o2.Date);
            return time2.CompareTo(time1);
        }

        private Orders getFirstOrder(Orders order)
        {
            List<Orders> orders = orderAccess.getAllOrders().FindAll(e => e.Cancelled == 0 && order.DogId == e.DogId);
            orders.Sort(SortOrders);
            if (orders.Count > 0) return orders[0];
            return null;
        }

        private void populateCustCbox()
        {
            cboxCust.Items.Clear();
            custs = custAccess.getAllCustomers().FindAll(e => e.Deleted == 0);
            foreach (Customer cust in custs)
            {
                cboxCust.Items.Add($"{cust.Id} - {cust.Forename} {cust.Surname}");
            }
            cboxCust.Text = "";
        }

        private void populateDogCbox()
        {
            cboxDog.Items.Clear();
            dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0 && e.OwnerId == (cboxCust.Text != "" ? getIdFromString(cboxCust.Text) : custs[0].Id));
            if (dogs.Count > 0)
            {
                foreach (Dog dog in dogs)
                {
                    cboxDog.Items.Add($"{dog.Id} - {dog.Name}");
                }
            }
            else cboxDog.Items.Add("None Available");
        }

        private void populateServCbox()
        {
            List<Service> services = serviceAccess.getAllServices();
            cboxServices.Items.Clear();
            foreach (Service srv in services)
            {
                cboxServices.Items.Add($"{srv.ServiceID} - {srv.Description}");
            }
            serv = cboxServices.Text != "" ? serviceAccess.getServiceById(getIdFromString(cboxServices.Text)) : services.ToArray()[0];
            Orders firstOrder = getFirstOrder(order);
            txtCost.Text = $"£{Globals.calcCost(order, serviceAccess.getServiceById(order.ServiceID), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToString()}";
        }

        private void changeMode(string newMode)
        {
            if (newMode == "add")
            {
                order = new Orders();
                order.Id = orderAccess.getAllOrders().Count + 1;
                order.DogId = 1;
                serv = serviceAccess.getAllServices()[0];
                mode = newMode;

                dgvSelect.Enabled = true;
                dgvSelect.Visible = true;
                dgvRoomOne.Visible = false;
                dgvRoomTwo.Visible = false;
                dgvRoomThree.Visible = false;
                lblOrderCancelled.Visible = false;
                lblDate.Visible = false;
                dtpRoomView.Visible = false;
                lblRoomOne.Visible = false;
                lblRoomTwo.Visible = false;
                lblRoomThree.Visible = false;

                dgvRoomOne.Columns.Clear();
                dgvRoomOne.Rows.Clear();
                dgvRoomTwo.Columns.Clear();
                dgvRoomTwo.Rows.Clear();
                dgvRoomThree.Columns.Clear();
                dgvRoomThree.Rows.Clear();
                dgvSelect.Columns.Clear();
                dgvSelect.Rows.Clear();

                btnUpdate.Enabled = false;
                btnUpdate.Text = "";
                btnDelete.Enabled = false;
                btnDelete.Text = "";
                btnAdd.Enabled = true;
                btnAdd.Text = "Add Booking";
                btnView.Enabled = true;
                btnView.Text = "View Booking";

                btnSelectStaff.Enabled = false;
                btnSelectTime.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;
                cboxPaid.Enabled = true;
                cboxCust.Enabled = true;
                cboxDog.Enabled = true;
                cboxServices.Enabled = true;

                checkEars.Checked = false;
                checkNails.Checked = false;
                checkTeeth.Checked = false;
                cboxCust.SelectedIndex = 0;
                cboxDog.SelectedIndex = 0;
                cboxServices.SelectedIndex = 0;
                txtDate.Text = dtpRoomView.Value.ToShortDateString();
                cboxPaid.Checked = false;
                txtTime.Text = "";
                txtEndtime.Text = "";
                txtStaff.Text = "";
            }
            else if (newMode == "edit")
            {
                mode = newMode;

                dgvSelect.Visible = true;
                dgvRoomOne.Visible = false;
                dgvRoomTwo.Visible = false;
                dgvRoomThree.Visible = false;

                dgvSelect.Enabled = true;

                btnAdd.Enabled = false;
                btnAdd.Text = "";
                btnDelete.Enabled = true;
                btnDelete.Text = "Cancel Booking";
                btnUpdate.Enabled = true;
                btnUpdate.Text = "Edit Booking";
                btnView.Enabled = true;
                btnView.Text = "View Booking";
                btnSelectStaff.Enabled = true;
                btnSelectTime.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;
                cboxPaid.Enabled = true;

                cboxCust.Enabled = true;
                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                lblOrderCancelled.Visible = order.Cancelled == 0 ? false : true;

                checkEars.Checked = order.Ears == 0 ? false : true;
                checkNails.Checked = order.Nails == 0 ? false : true;
                checkTeeth.Checked = order.Teeth == 0 ? false : true;

                lblDate.Visible = false;
                dtpRoomView.Visible = false;
                lblRoomOne.Visible = false;
                lblRoomTwo.Visible = false;
                lblRoomThree.Visible = false;

                cboxCust.Text = $"{dogAccess.getDogById(order.DogId).OwnerId} - {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Forename} {custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId).Surname}";
                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceID} - {serv.Description}";
                cboxPaid.Checked = order.Paid == 1 ? true : false;
            }
            else if (newMode == "view")
            {
                if (order == null || order.Cancelled == 1 || serv == null)
                {
                    if (orders.Count > 0) order = orderAccess.getAllOrders().ToArray()[0];
                    else order = new Orders(1, 1, 1, 1, dtpDateTime.Value.ToShortDateString(), dtpDateTime.Value.ToShortTimeString(), 0, 0, 0, 1, 0);
                    serv = serviceAccess.getServiceById(order.ServiceID);
                }
                mode = newMode;

                dgvSelect.Visible = false;
                dgvRoomOne.Visible = true;
                dgvRoomTwo.Visible = true;
                dgvRoomThree.Visible = true;

                dgvSelect.Enabled = false;
                btnAdd.Enabled = true;
                btnAdd.Text = "Add Booking";
                btnDelete.Enabled = false;
                btnDelete.Text = "";
                btnUpdate.Enabled = false;
                btnUpdate.Text = "";
                btnView.Enabled = false;
                btnView.Text = "";
                btnSelectStaff.Enabled = false;
                btnSelectTime.Enabled = false;

                cboxCust.Enabled = false;
                cboxDog.Enabled = false;
                cboxServices.Enabled = false;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                cboxPaid.Enabled = false;
                checkTeeth.Enabled = false;
                
                Orders firstOrder = getFirstOrder(order);
                cboxCust.Text = "";
                cboxDog.Text = "";
                txtCost.Text = "£";
                txtDate.Text = "";
                txtEndtime.Text = "";
                txtStaff.Text = "";
                txtTime.Text = "";
                cboxServices.Text = "";
                checkEars.Checked = order.Ears == 1;
                checkNails.Checked = order.Nails == 1;
                checkTeeth.Checked = order.Teeth == 1;

                lblDate.Visible = true;
                dtpRoomView.Visible = true;
                lblRoomOne.Visible = true;
                lblRoomTwo.Visible = true;
                lblRoomThree.Visible = true;

                type = "orders";
                displayBookingSlots();

                cboxPaid.Checked = order.Paid == 1;
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

            dgvSelect.ScrollBars = ScrollBars.None;
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
                    Orders firstOrder = getFirstOrder(order);
                    rows[0] = CleanTime(startTimedateTime.ToShortTimeString());
                    rows[1] = "Yes";
                    foreach (Orders odr in orders)
                    {
                        if (odr.Date == order.Date)
                        {
                            if (Convert.ToDateTime(odr.StartTime) >= startTimedateTime && getEndTime(odr, serviceAccess.getServiceById(odr.ServiceID), Convert.ToDateTime(odr.StartTime), odr == firstOrder || firstOrder == null) < startTimedateTime) rows[1] = "No (Another booking is taking place)";
                            else continue;
                        }
                        else continue;
                    }
                    if (getEndTime(order, serv, startTimedateTime, (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)) > Convert.ToDateTime("17:00:00")) rows[1] = "No (Ends after closing time)";
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
                dgvSelect.ScrollBars = ScrollBars.Vertical;
            }
            else if (type == "staff")
            {
                dgvSelect.ColumnCount = 2;
                string[] rows = new string[dgvSelect.ColumnCount];
                dgvSelect.Columns[0].Name = "Staff Member";
                dgvSelect.Columns[1].Name = "Availabilty";

                DateTime date = Convert.ToDateTime(order.Date);
                DateTime start = Convert.ToDateTime(order.StartTime);
                Orders firstOrder = getFirstOrder(order);
                DateTime end = getEndTime(order, serv, start, (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null));

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
                        // part-time staff not available after 12pm
                        if (staff.Partial == 1 && (Convert.ToDateTime(order.StartTime) > Convert.ToDateTime("12:00:00") || getEndTime(order, serviceAccess.getServiceById(serv.ServiceID), Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)) > Convert.ToDateTime("12:00:00")))
                            rows[1] = "No - Not working at this time";
                        // staff lunches - unavailable
                        else if (Convert.ToDateTime(order.StartTime) >= Convert.ToDateTime(staff.StartLunch) && getEndTime(order, serviceAccess.getServiceById(order.ServiceID), Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)) <= Convert.ToDateTime(staff.EndLunch))
                            rows[1] = "No - On Lunch";
                        else
                        {
                            foreach (Orders order in orders.FindAll(e => e.Cancelled == 0))
                            {
                                if (order.StaffId == staff.Id)
                                {
                                    if (Convert.ToDateTime(order.Date) == date)
                                    {
                                        if (Convert.ToDateTime(order.StartTime) >= start && getEndTime(order, serviceAccess.getServiceById(order.ServiceID), Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)) <= end)
                                            rows[1] = $"No - Booking with {dogAccess.getDogById(order.DogId).Name}";
                                    }
                                }
                                rows[1] = "Yes";
                            }
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

            foreach (DataGridViewColumn col in dgvSelect.Columns)
            {
                col.Width = dgvSelect.Size.Width / dgvSelect.Columns.Count;
            }
            foreach (DataGridViewRow row in dgvSelect.Rows)
            {
                row.Height = dgvSelect.Size.Height / 5;
            }
            dgvSelect.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void displayBookingSlots()
        {
            DataGridView[] arr = { dgvRoomOne, dgvRoomTwo, dgvRoomThree };
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

                start = Convert.ToDateTime("09:00:00");
                while (start < Convert.ToDateTime("17:00:00"))
                {
                    foreach (DataGridViewCell cell in dgv.Rows[0].Cells)
                    {
                        cell.Value = start.ToShortTimeString();
                        start = start.AddMinutes(15);
                    }
                }

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    // style each column
                    col.Width = dgv.Size.Width / dgv.Columns.Count;
                    col.DividerWidth = 1;
                    col.Tag = -1;
                    dgv.Rows[0].Cells[col.Index].Style.SelectionBackColor = Color.Green;
                    dgv.Rows[0].Cells[col.Index].Style.BackColor = Color.Green;

                    foreach (Orders order in orders)
                    {
                        string[] date = order.Date.Split('/');
                        DateTime counter = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]), 09, 00, 00);

                        // actual end time
                        Orders firstOrder = getFirstOrder(order);
                        string[] endTime = CleanTime(getEndTime(order, serviceAccess.getServiceById(order.ServiceID), Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToShortTimeString()).Split(':');
                        DateTime end = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]), Convert.ToInt32(endTime[0]), Convert.ToInt32(CleanTime(endTime[1])), 00);

                        // actual start time
                        string[] startTime = order.StartTime.Split(':');
                        DateTime Start = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]), Convert.ToInt32(startTime[0]), Convert.ToInt32(CleanTime(startTime[1])), 00);

                        for (int i = 0; i < dgv.ColumnCount; i++)
                        {
                            dgv.Rows[0].Cells[i].Tag = $"{counter.ToShortTimeString()} - {order.Date}";
                            dgv.Rows[0].Cells[i].Style.BackColor = Color.Green;
                            dgv.Rows[0].Cells[i].Style.SelectionBackColor = Color.Green;

                            if (Start <= counter && counter <= end)
                            {
                                dgv.Columns[i].Tag = order.Id;
                                dgv.Rows[0].Cells[i].Style.BackColor = Color.Red;
                                dgv.Rows[0].Cells[i].Style.SelectionBackColor = Color.Red;
                            }
                            counter = counter.AddMinutes(15);
                        }
                    }
                }
            }
        }

        private DateTime getEndTime(DateTime start = new DateTime(), bool add = false)
        {
            dtpDateTime.Value = start;
            DateTime min = dtpDateTime.Value;
            min = min.AddMinutes(serv.Time);
            if (order.Nails == 1) min = min.AddMinutes(Globals.extraNailsMinute);
            if (order.Teeth == 1) min = min.AddMinutes(Globals.extraTeethMinute);
            if (order.Ears == 1) min = min.AddMinutes(Globals.extraEarsMinute);
            Orders firstOrder = getFirstOrder(order);
            if ((mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && add && firstOrder == null)) min = min.AddMinutes(Globals.firstTimeMinute);
            return min;
        }

        private DateTime getEndTime(Orders odr, Service srv, DateTime start, bool add)
        {
            dtpDateTime.Value = start;
            DateTime min = dtpDateTime.Value;
            min = min.AddMinutes(srv.Time);
            if (odr.Nails == 1) min = min.AddMinutes(Globals.extraNailsMinute);
            if (odr.Teeth == 1) min = min.AddMinutes(Globals.extraTeethMinute);
            if (odr.Ears == 1) min = min.AddMinutes(Globals.extraEarsMinute);
            Orders firstOrder = getFirstOrder(odr);
            if ((mode != "add" && odr.Id == firstOrder.Id) || (mode == "add" && add && firstOrder == null)) min = min.AddMinutes(Globals.firstTimeMinute);
            return min;
        }

        private void checkValidEndTime(CheckBox obj)
        {
            if (obj.Checked && order.StartTime != null)
            {
                Orders firstOrder = getFirstOrder(order);
                DateTime end = getEndTime(order, serviceAccess.getServiceById(order.ServiceID), Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null));
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
                    txtEndtime.Text = CleanTime(end.ToShortTimeString());
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
                Orders firstOrder = getFirstOrder(order);
                DateTime end = getEndTime(order, serviceAccess.getServiceById(order.ServiceID), Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null));
                if (end.Hour >= 17)
                {
                    MessageBox.Show($"You cannot pick this service as as it finishes after closing time", "Cannot add extra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboxServices.Text = serv.Description;
                    return false;
                }
                else
                {
                    serv = serviceAccess.getServiceByDesc(cboxServices.Text);
                    txtEndtime.Text = CleanTime(end.ToShortTimeString());
                    return true;
                }
            }
            return true;
        }
        
        private bool dgvCellMouseClick(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            int orderID = Convert.ToInt32(dgv.Columns[e.ColumnIndex].Tag.ToString());
            order = orderID != -1 ? orderAccess.getOrderById(orderID) : null;

            if (order == null)
            {
                MessageBox.Show("During this timeslot, there is no order appointment taking place", "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
                btnUpdate.Text = "";
                return false;
            }
            else
            {
                Orders firstOrder = getFirstOrder(order);
                txtEndtime.Text = CleanTime(getEndTime(order, serviceAccess.getServiceById(order.ServiceID), Convert.ToDateTime($"{order.Date} {order.StartTime}"), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToShortTimeString());
                txtStaff.Text = staffAccess.getStaffById(order.StaffId).Name;
                checkEars.Checked = order.Ears == 1 ? true : false;
                checkTeeth.Checked = order.Teeth == 1 ? true : false;
                checkNails.Checked = order.Nails == 1 ? true : false;
                txtDate.Text = order.Date;
                txtTime.Text = CleanTime(order.StartTime);
                txtCost.Text = $"£{Globals.calcCost(order, serviceAccess.getServiceById(order.ServiceID), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToString()}";
                cboxPaid.Checked = order.Paid == 1 ? true : false;
                Customer owner = custAccess.getOwnerById(dogAccess.getDogById(order.DogId).OwnerId);
                cboxCust.Text = $"{owner.Id} - {owner.Forename} {owner.Surname}";
                Service serv = serviceAccess.getServiceById(order.ServiceID);
                cboxServices.Text = $"{serv.ServiceID} - {serv.Description}";
                Dog dog = dogAccess.getDogById(order.DogId);
                cboxDog.Text = $"{dog.Id} - {dog.Name}";

                btnUpdate.Enabled = true;
                btnUpdate.Text = "Edit Booking";
                return true;
            }
        }

        private bool checkRoomValid(int roomNo)
        {
            Orders firstOrder = getFirstOrder(order);
            List<Orders> tempOrders = orderAccess.getAllOrders().FindAll(e => {
                return e.RoomID == roomNo && Convert.ToDateTime(e.StartTime) >= Convert.ToDateTime(txtTime.Text) && Convert.ToDateTime(getEndTime(e, serviceAccess.getServiceById(e.ServiceID), Convert.ToDateTime(e.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null))) <= Convert.ToDateTime(txtEndtime.Text) && e.Date == txtDate.Text;
            });
            if (tempOrders.Count > 0) return false;
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
            if (mode != "add")
            {
                if (dtpRoomView.Value <= DateTime.Today)
                {
                    MessageBox.Show("You cannot add a booking for any day today or prior", "Cannot add booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dtpRoomView.Value.DayOfWeek == DayOfWeek.Saturday || dtpRoomView.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("You are not able to make a booking for the weekend, as we are not open", "Not Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (DateSystem.IsPublicHoliday(dtpRoomView.Value, CountryCode.GB))
                {
                    MessageBox.Show("You cannot make a booking for a public holiday as we are not open", "Not Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DateTime end = DateTime.Today.AddDays(7 * 3);
                int ordersBeforeEnd = orders.FindAll(odr => Convert.ToDateTime(odr.Date) <= end).Count;
                // allow for override "3 weeks in advance" if there are less than 21 bookings within next 3 weeks (allows for 1 booking per day for 3 weeks)
                if (dtpRoomView.Value < end && ordersBeforeEnd >= 21)
                {
                    MessageBox.Show("You can only create a booking 3 weeks in advance", "Cannot make booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                changeMode("add");
            }
            else
            {
                if (orderAccess.getAllOrders().Find(o => o.DogId == order.DogId && o.Date == txtDate.Text) != null)
                {
                    MessageBox.Show("This dog is already booked in for that day", "Cannot add booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtTime.Text == string.Empty)
                {
                    MessageBox.Show("Select the start time for the booking", "Select Start Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtStaff.Text == string.Empty)
                {
                    MessageBox.Show("Select the staff for the booking", "Select Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int RoomID = 0;
                for (int i = 1; i <= 3; i++)
                {
                    if (checkRoomValid(i))
                    {
                        RoomID = i;
                        break;
                    }
                }
                if (RoomID == 0)
                {
                    MessageBox.Show("No rooms are available to book an order at this time on this day", "No Rooms Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Dog dog = dogAccess.getDogById(Convert.ToInt32(cboxDog.Text.Replace(" ", "").Split('-')[0]));
                Staff staff = staffAccess.getStaffById(staffAccess.getStaffByName(txtStaff.Text.Replace(" ", "").Split('-')[0]).Id);
                string ears = checkEars.Checked ? "Yes" : "No";
                string nails = checkNails.Checked ? "Yes" : "No";
                string teeth = checkTeeth.Checked ? "Yes" : "No";

                DialogResult opt = MessageBox.Show($"Are you sure these details are correct?\nDog: {dog.Name}\nDate: {txtDate.Text}\nStartTime: {txtTime.Text}\nStaff: {staff.Name}\nService: {serv.Description}\nEars: {ears}\nNails: {nails}\nTeeth: {teeth}", "Add Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    order.Id = orderAccess.getAllOrders().Count + 1;
                    order.DogId = dog.Id;
                    order.StaffId = staff.Id;
                    order.Cancelled = 0;
                    order.Paid = cboxPaid.Checked ? 1 : 0;
                    order.Date = txtDate.Text;
                    order.StartTime = txtTime.Text;
                    order.Ears = checkEars.Checked ? 1 : 0;
                    order.Nails = checkNails.Checked ? 1 : 0;
                    order.Teeth = checkTeeth.Checked ? 1 : 0;
                    order.RoomID = RoomID;
                    order.ServiceID = serv.ServiceID;

                    if (orderAccess.insertOrder(order))
                    {
                        changeMode("view");
                        MessageBox.Show("The order has been recorded successfully", "Order Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        try
                        {
                            orderAccess.deleteOrder(order);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Order could not be removed");
                        }
                        MessageBox.Show("Something went wrong when recording the order. Please try again in a few minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void checkNails_CheckedChanged(object sender, EventArgs e)
        {
            checkValidEndTime(checkNails);
            order.Nails = checkNails.Checked ? 1 : 0;
            Orders firstOrder = getFirstOrder(order);
            txtEndtime.Text = order.StartTime != null ? CleanTime(getEndTime(order, serv, Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToShortTimeString()) : "";
            txtCost.Text = $"£{Globals.calcCost(order, serv, (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToString()}";
        }

        private void checkTeeth_CheckedChanged(object sender, EventArgs e)
        {
            checkValidEndTime(checkTeeth);
            order.Teeth = checkTeeth.Checked ? 1 : 0;
            Orders firstOrder = getFirstOrder(order);
            txtEndtime.Text = order.StartTime != null ? CleanTime(getEndTime(order, serv, Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToShortTimeString()) : "";
            txtCost.Text = $"£{Globals.calcCost(order, serv, (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToString()}";
        }

        private void checkEars_CheckedChanged(object sender, EventArgs e)
        {
            checkValidEndTime(checkEars);
            order.Ears = checkEars.Checked ? 1 : 0;
            Orders firstOrder = getFirstOrder(order);
            txtEndtime.Text = order.StartTime != null ? CleanTime(getEndTime(order, serv, Convert.ToDateTime(order.StartTime), (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToShortTimeString()) : "";
            txtCost.Text = $"£{Globals.calcCost(order, serv, (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToString()}";
        }

        private void btnUpdate_Click(object sender, EventArgs ev)
        {
            if (mode != "edit")
            {
                if (dtpRoomView.Value <= DateTime.Now)
                {
                    MessageBox.Show("You cannot edit a booking prior to or taking place today", "Cannot Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                changeMode("edit");
            }
            else
            {
                if (cboxCust.Text == string.Empty)
                {
                    MessageBox.Show("Select the dog's owner for the booking", "Select Dog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                if (txtTime.Text == string.Empty)
                {
                    MessageBox.Show("Select the start time for the booking", "Select Start Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtStaff.Text == string.Empty)
                {
                    MessageBox.Show("Select the staff for the booking", "Select Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult res = MessageBox.Show("Are you sure you want to update this booking's details?", "Update Booking?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    order.Date = txtDate.Text;
                    order.StartTime = txtTime.Text;
                    order.Paid = cboxPaid.Checked ? 1 : 0;
                    order.ServiceID = serv.ServiceID;

                    if (orderAccess.updateOrder(order))
                    {
                        changeMode("view");
                        MessageBox.Show("Successfully updated the booking details", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong while saving the booking details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult opt = MessageBox.Show("Are you sure you want to cancel this booking? This is permanent and cannot be reversed", "Cancel Booking?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opt == DialogResult.Yes)
            {
                order.Cancelled = 1;
                if (orderAccess.updateOrder(order))
                {
                    changeMode("view");
                    MessageBox.Show("This booking has been cancelled. It will now be refunded the amount that has already been paid for", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void btnView_Click(object sender, EventArgs e)
        {
            changeMode("view");
        }

        private void dgvSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvSelect.Rows[e.RowIndex].Cells[0].Value == null) return;
            if (type == "staff")
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
            else if (type == "time")
            {
                if (dgvSelect.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                {
                    MessageBox.Show("This time is not available for a booking", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string content = CleanTime(Convert.ToString(dgvSelect.Rows[e.RowIndex].Cells[0].Value));
                string[] times = content.Split(':');
                string[] dates = dtpRoomView.Value.ToShortDateString().Split('/');
                Orders firstOrder = getFirstOrder(order);
                DateTime start = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                DateTime end = getEndTime(order, serv, start, (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null));
                txtTime.Text = CleanTime(start.ToShortTimeString());
                txtEndtime.Text = CleanTime(end.ToShortTimeString());

                order.StartTime = txtTime.Text;
                type = "";
                populateDataGrid();
                btnSelectStaff.Enabled = true;
            }
        }

        private void cboxCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDogCbox();
            cboxDog.SelectedIndex = 0;
        }

        private void dtpRoomView_ValueChanged(object sender, EventArgs e)
        {
            displayBookingSlots();
        }

        private void dgvRoomOne_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewCell cell in dgvRoomOne.SelectedCells)
            {
                cell.Style.SelectionBackColor = dgvRoomOne.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (dgvCellMouseClick(dgvRoomOne, e)) dgvCellMouseClick(dgvRoomOne, e);
            }
        }

        private void dgvRoomTwo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewCell cell in dgvRoomTwo.SelectedCells)
            {
                cell.Style.SelectionBackColor = dgvRoomTwo.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (dgvCellMouseClick(dgvRoomTwo, e)) dgvCellMouseClick(dgvRoomTwo, e);
            }
        }

        private void dgvRoomThree_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewCell cell in dgvRoomThree.SelectedCells)
            {
                cell.Style.SelectionBackColor = dgvRoomThree.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (dgvCellMouseClick(dgvRoomThree, e)) dgvCellMouseClick(dgvRoomThree, e);
            }
        }

        private void cboxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkValidEndTime(cboxServices)) serv = serviceAccess.getServiceById(getIdFromString(cboxServices.Text));
            Orders firstOrder = getFirstOrder(order);
            txtCost.Text = $"£{Globals.calcCost(order, serv, (mode != "add" && order.Id == firstOrder.Id) || (mode == "add" && firstOrder == null)).ToString()}";
            order.ServiceID = serv.ServiceID;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            new GroomingMain().Show();
            Hide();
        }

        private void cboxDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dogID = getIdFromString(cboxDog.Text);
            order.DogId = dogID;
            if (orderAccess.getAllOrders().Find(o => o.DogId == dogID && o.Date == txtDate.Text) != null && mode == "add")
            {
                MessageBox.Show("This dog is already booked in for that day", "Cannot add booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void dgvRoomOne_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewCell cell = dgvRoomOne.Rows[0].Cells[e.ColumnIndex];
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(cell.Value.ToString(), e.CellStyle.Font, Brushes.Black, 30, 1);
                e.Graphics.ResetTransform();
                e.Handled = true;
            }
        }

        private void dgvRoomTwo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewCell cell = dgvRoomTwo.Rows[0].Cells[e.ColumnIndex];
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(cell.Value.ToString(), e.CellStyle.Font, Brushes.Black, 30, 1);
                e.Graphics.ResetTransform();
                e.Handled = true;
            }
        }

        private void dgvRoomThree_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewCell cell = dgvRoomThree.Rows[0].Cells[e.ColumnIndex];
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(cell.Value.ToString(), e.CellStyle.Font, Brushes.Black, 30, 1);
                e.Graphics.ResetTransform();
                e.Handled = true;
            }
        }
        #endregion
    }
}
