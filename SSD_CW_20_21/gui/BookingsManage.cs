using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;

namespace SSD_CW_20_21.gui
{
    public partial class BookingsManage : Template
    {
        private OrderDBAccess orderAccess = Globals.orderAccess;
        private DogDBAccess dogAccess = Globals.dogAccess;
        private StaffDBAccess staffAccess = Globals.staffAccess;
        private ServiceDBAccess serviceAccess = Globals.servAccess;
        private Orders order;
        private string mode = "view";

        private string[] services = { "Wash, shampoo, brush", "Wash, shampoo, brush, trim", "Wash, shampoo, brush, full-trim" };

        public BookingsManage() : base()
        {
            InitializeComponent();
            order = orderAccess.getAllOrders().ToArray()[0];

            Text = "JD Dog Care - Bookings";

            dtDateTime.Value = DateTime.Now;
            populateListBox();
            populateComboBox();
        }

        private void populateListBox()
        {
            DataTable data = new DataTable();
            List<Orders> orders = orderAccess.getAllOrders();

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

                cboxDog.Enabled = false;
                cboxServices.Enabled = false;
                cboxStaff.Enabled = false;
                checkEars.Enabled = false;
                checkNails.Enabled = false;
                checkTeeth.Enabled = false;
                if (order.Cancelled == 1) lblOrderCancelled.Visible = true;
                else lblOrderCancelled.Visible = false;

                lblOrderId.Text = $"#{order.Id}";
                cboxDog.Text = $"{dogAccess.getDogById(order.DogId).Id} - {dogAccess.getDogById(order.DogId).Name}";
                int servIndex = serviceAccess.getAllServices().FindIndex(e => e.OrderID == order.Id);
                cboxServices.Text = $"{servIndex + 1} - {services[servIndex]}";
                cboxStaff.Text = $"{order.StaffId} - {staffAccess.getAllStaff().ToArray()[order.StaffId - 1].Name}";
                dtDateTime.Value = DateTime.Now;

                Service serv = serviceAccess.getAllServices().Find(e => e.OrderID == order.Id);
                if (serv.Nails == 1) checkNails.Checked = true;
                else checkNails.Checked = false;
                if (serv.Teeth == 1) checkTeeth.Checked = true;
                else checkTeeth.Checked = false;
                if (serv.Ears == 1) checkEars.Checked = true;
                else checkEars.Checked = false;
            }
            else if (newMode == "add")
            {
                mode = newMode;

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
                orderAccess.insertOrder(order);
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
