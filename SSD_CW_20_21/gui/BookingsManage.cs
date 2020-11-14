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
        private string mode = "view";

        private string type = "";

        private DataTable datasource = new DataTable();

        private string[] services = { "Wash, shampoo, brush", "Wash, shampoo, brush, trim", "Wash, shampoo, brush, full-trim" };
        #endregion

        public BookingsManage() : base()
        {
            InitializeComponent();
            orders = orderAccess.getAllOrders();

            Text = "JD Dog Care - Add Bookings";
            
            populateComboBox();
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

        private void populateComboBox()
        {
            int optionNo = 1;
            foreach(string option in services)
            {
                cboxServices.Items.Add($"{optionNo} - {option}");
                optionNo++;
            }

            List<Dog> dogs = dogAccess.getAllDogs();
            foreach(Dog dog in dogs)
            {
                cboxDog.Items.Add($"{dog.Id} - {dog.Name}");
            }
        }

        private void changeMode(string newMode)
        {
            if (newMode == "view")
            {
                mode = newMode;

                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                checkTeeth.Enabled = false;

                cboxDog.Enabled = false;
                dgvDateTime.Enabled = false;
                cboxServices.Enabled = false;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                checkTeeth.Enabled = false;

                type = "orders";
                populateDataGrid();
            }
            else if (newMode == "add")
            {
                mode = newMode;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;

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

                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;

                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                lblOrderCancelled.Visible = order.Cancelled == 0 ? false : true;

                checkEars.Checked = serv.Ears == 0 ? false : true;
                checkNails.Checked = serv.Nails == 0 ? false : true;
                checkTeeth.Checked = serv.Teeth == 0 ? false : true;

                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{serv.ServiceOption} - {services[serv.ServiceOption - 1]}";
            }
        }

        private int getIdFromString(string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]", ""));
        }

        private void populateDataGrid()
        {
            if (type == "time")
            {
                dgvDateTime.ColumnCount = 2;
                dgvDateTime.Columns[0].Name = "Time";
                dgvDateTime.Columns[1].Name = "Availabilty";

                dtpDateTime.Value = DateTime.Now;
                TimeSpan time = dtpDateTime.Value.TimeOfDay;
            }
            else if (type == "date")
            {
                dgvDateTime.ColumnCount = 2;
                dgvDateTime.Columns[0].Name = "Date";
                dgvDateTime.Columns[1].Name = "Availabilty";

                DateTime date = dtpDateTime.Value.Date;
                DateTime min = dtpDateTime.MinDate;
                DateTime max = dtpDateTime.MaxDate;
                string[] rows = new string[2];

                while (min < max)
                {
                    rows[0] = date.ToString("dd/MM/yyyy");
                    if (!orders.Any()) rows[1] = "Yes";
                    if (DateSystem.IsPublicHoliday(date, CountryCode.GB)) rows[1] = "No - Public Holiday";
                    if (DateSystem.IsWeekend(date, CountryCode.GB)) rows[1] = "No - Weekend";
                    else
                    {
                        foreach (Orders order in orders)
                        {
                            if (date.ToString("dd/MM/yyyy") == order.Date && getIdFromString(cboxDog.Text) == order.DogId)
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
                dgvDateTime.Columns[0].Name = "Staff Member";
                dgvDateTime.Columns[1].Name = "Availabilty";

                string[] rows = new string[2];
                foreach (Staff staff in staffAccess.getAllStaff().FindAll(e=>e.Deleted == 0))
                {
                    rows[0] = $"{staff.Name}";
                    rows[1] = "Available";
                    if (order.StaffId == staff.Id)
                    {
                        
                    }
                    else rows[1] = "Available";
                }
            }
            else if (type == "orders")
            {
                string[] rows = new string[10];
                dgvDateTime.ColumnCount = 10;
                dgvDateTime.Columns[0].Name = "Dog";
                dgvDateTime.Columns[1].Name = "Dog Owner";
                dgvDateTime.Columns[2].Name = "Date";
                dgvDateTime.Columns[3].Name = "Starting Time";
                dgvDateTime.Columns[4].Name = "Staff Assigned";
                dgvDateTime.Columns[5].Name = "Service";
                dgvDateTime.Columns[6].Name = "Extra Ears";
                dgvDateTime.Columns[7].Name = "Extra Nails";
                dgvDateTime.Columns[8].Name = "Extra Teeth";
                dgvDateTime.Columns[9].Name = "Customer has Paid?";
                
                foreach(Orders order in orders.FindAll(e => e.Cancelled == 0))
                {
                    Dog dog = dogAccess.getDogById(order.DogId);
                    rows[0] = dog.Name;
                    Customer cust = custAccess.getOwnerById(dog.OwnerId);
                    rows[1] = $"{cust.Forename} {cust.Surname}";
                    rows[2] = order.Date;
                    rows[3] = order.StartTime;
                    rows[4] = staffAccess.getStaffById(order.StaffId).Name;
                    Service serv = serviceAccess.getServiceById(servOrderAccess.getObjectByOrderID(order.Id).ServiceID);
                    rows[5] = services[serv.ServiceOption - 1];
                    rows[6] = serv.Ears == 0 ? "No" : "Yes";
                    rows[7] = serv.Nails == 0 ? "No" : "Yes";
                    rows[8] = serv.Teeth == 0 ? "No" : "Yes";
                    rows[9] = order.Paid == 0 ? "No" : "Yes";
                    dgvDateTime.Rows.Add(rows);
                }
            }
            else
            {
                dgvDateTime.DataSource = null;
                dgvDateTime.Rows.Clear();
                dgvDateTime.Columns.Clear();
            }
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
                Orders order = new Orders();
                order.DogId = Convert.ToInt32(cboxDog.Text.Replace(" ", "").Split('-')[0]);
                order.Cancelled = 0;
                serv.ServiceOption = Convert.ToInt32(cboxServices.Text.Replace(" ", "").Split('-')[0]);
                order.Paid = checkPaid.Checked ? 1 : 0;

                DialogResult opt = MessageBox.Show("Are you sure these details are correct?", "Add Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    if (orderAccess.insertOrder(order))
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
                /*order.Date = $"{dtDateTime.Value.Day}/{dtDateTime.Value.Month}/{dtDateTime.Value.Year}";
                order.StartTime = $"{dtDateTime.Value.Hour}:{dtDateTime.Value.Minute}";
                int hours = dtDateTime.Value.AddHours(Globals.defBookingLengthHour).Hour;
                DateTime min = dtDateTime.Value;
                if (order.Nails == 1) min = min.AddMinutes(Globals.extraNailsMinute);
                if (order.Teeth == 1) min = min.AddMinutes(Globals.extraTeethMinute);
                if (order.Ears == 1) min = min.AddMinutes(Globals.extraEarsMinute);

                List<Orders> tempOrders = orderAccess.getAllOrders().FindAll(e => e.DogId == order.DogId);
                if (tempOrders.Count >= 1) min = min.AddMinutes(Globals.firstTimeMinute);
                int minutes = min.Minute;
                order.EndTime = $"{hours}:{minutes}";*/
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
        #endregion
    }
}
