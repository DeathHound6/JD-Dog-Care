using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SSD_CW_20_21.gui
{
    public partial class BookingsManage : Template
    {
        private OrderDBAccess orderAccess = Globals.orderAccess;
        private DogDBAccess dogAccess = Globals.dogAccess;
        private StaffDBAccess staffAccess = Globals.staffAccess;
        private ServiceDBAccess serviceAccess = Globals.servAccess;
        private List<Orders> orders;
        private Orders order;
        private Service service;
        private string mode = "view";

        private string[] services = { "Wash, shampoo, brush", "Wash, shampoo, brush, trim", "Wash, shampoo, brush, full-trim" };

        public BookingsManage() : base()
        {
            InitializeComponent();
            orders = orderAccess.getAllOrders();
            if (orders.Count > 0) order = orders.ToArray()[0];
            else order = new Orders(1, 1, 1, $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}", $"{DateTime.Now.Hour}:{DateTime.Now.Minute}", 0);

            Text = "JD Dog Care - Bookings";
            
            populateListBox();
            populateComboBox();
            changeMode("view");
        }

        private void populateListBox()
        {
            DataTable data = new DataTable();

            data.Columns.Add("OrderID");
            data.Columns.Add("Dog");
            data.Columns.Add("DateTime");

            foreach(Orders order in orders)
            {
                data.Rows.Add(order.Id, dogAccess.getDogById(order.DogId).Name, $"{order.Date}, {order.Time}");
            }

            lbSelectOrder.DisplayMember = "OrderID";
            lbSelectOrder.ValueMember = "Dog";
            lbSelectOrder.DataSource = data;
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

            List<Staff> staffs = staffAccess.getAllStaff();
            foreach(Staff staff in staffs)
            {
                cboxStaff.Items.Add($"{staff.Id} - {staff.Name}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mode != "view")
            {
                changeMode("view");
            }
        }

        private void changeMode(string newMode)
        {
            if (newMode == "view")
            {
                mode = newMode;

                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                checkTeeth.Enabled = false;

                cboxDog.Enabled = false;
                cboxServices.Enabled = false;
                cboxStaff.Enabled = false;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                checkTeeth.Enabled = false;
                lblOrderCancelled.Visible = order.Cancelled == 0 ? false : true;

                lblOrderId.Text = $"#{order.Id}";
                cboxDog.Text = $"{dogAccess.getDogById(order.DogId).Id} - {dogAccess.getDogById(order.DogId).Name}";
                int servIndex = serviceAccess.getAllServices().FindIndex(e => e.OrderID == order.Id);
                if (servIndex == -1) servIndex = 0;
                cboxServices.Text = $"{servIndex + 1} - {services[servIndex]}";
                cboxStaff.Text = $"{order.StaffId} - {staffAccess.getAllStaff().ToArray()[order.StaffId - 1].Name}";
                dtDateTime.Value = DateTime.Now;

                service = serviceAccess.getAllServices().Find(e => e.OrderID == order.Id);
                if (service == null) service = new Service(order.Id, Convert.ToInt32(cboxServices.Text.Replace(" ", "").Split('-')[0]), 0, 0, 0);
                checkEars.Checked = service.Ears == 0 ? false : true;
                checkNails.Checked = service.Nails == 0 ? false : true;
                checkTeeth.Checked = service.Teeth == 0 ? false : true;
            }
            else if (newMode == "add")
            {
                mode = newMode;

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnAdd.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;

                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                cboxStaff.Enabled = true;
                checkEars.Checked = false;
                checkNails.Checked = false;
                checkTeeth.Checked = false;
                lblOrderCancelled.Visible = false;

                cboxDog.Text = "";
                cboxServices.Text = "";
                cboxStaff.Text = "";
                lblOrderId.Text = $"#{orderAccess.getAllOrders().Count + 1}";
                dtDateTime.Value = DateTime.Now;
            }
            else if(newMode == "edit")
            {
                mode = newMode;

                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                checkTeeth.Enabled = true;
                checkNails.Enabled = true;
                checkEars.Enabled = true;

                cboxDog.Enabled = true;
                cboxServices.Enabled = true;
                cboxStaff.Enabled = true;
                lblOrderCancelled.Visible = order.Cancelled == 0 ? false : true;

                checkEars.Checked = service.Ears == 0 ? false : true;
                checkNails.Checked = service.Nails == 0 ? false : true;
                checkTeeth.Checked = service.Teeth == 0 ? false : true;

                int servIndex = serviceAccess.getAllServices().FindIndex(e => e.OrderID == order.Id);
                if (servIndex == -1) servIndex = 0;
                cboxDog.Text = $"{order.DogId} - {dogAccess.getDogById(order.DogId).Name}";
                cboxServices.Text = $"{servIndex + 1} - {services[servIndex]}";
                cboxStaff.Text = $"{order.StaffId} - {staffAccess.getStaffById(order.StaffId).Name}";
                lblOrderId.Text = $"#{order.Id}";

                string[] dayArr = order.Date.Split('/');
                string[] timeArr = order.Time.Split(':');
                dtDateTime.Value = new DateTime(Convert.ToInt32(dayArr[2]), Convert.ToInt32(dayArr[1]), Convert.ToInt32(dayArr[0]), Convert.ToInt32(timeArr[0]), Convert.ToInt32(timeArr[1]), 00);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mode != "add") changeMode("add");
            else
            {
                Service serv = new Service();
                serv.OrderID = Convert.ToInt32(lblOrderId.Text.Replace("#", ""));
                serv.Teeth = checkTeeth.Checked ? 1 : 0;
                serv.Option = Convert.ToInt32(cboxServices.Text.Replace(" ", "").Split('-')[0]);
                serviceAccess.insertService(serv);

                Orders order = new Orders();
                order.Id = serv.OrderID;
                order.DogId = Convert.ToInt32(cboxDog.Text.Replace(" ", "").Split('-')[0]);
                order.StaffId = Convert.ToInt32(cboxStaff.Text.Replace(" ", "").Split('-')[0]);
                order.Cancelled = 0;
                order.Paid = 0;
                order.Date = $"{dtDateTime.Value.Day}/{dtDateTime.Value.Month}/{dtDateTime.Value.Year}";
                order.Time = $"{dtDateTime.Value.Hour}:{dtDateTime.Value.Minute}";

                DialogResult opt = MessageBox.Show("Are you sure these details are correct?", "Add Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    if (orderAccess.insertOrder(order))
                    {
                        populateListBox();
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

        private void lbSelectOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSelectOrder.SelectedItem != null)
            {
                order = orderAccess.getOrderById(getIdFromString(lbSelectOrder.GetItemText(lbSelectOrder.SelectedItem)));
                changeMode("view");
            }
        }

        private int getIdFromString(string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]", ""));
        }
    }
}
