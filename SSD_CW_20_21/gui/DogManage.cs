using System;
using SSD_CW_20_21.Objects;
using SSD_CW_20_21.DbAccess;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using SSD_CW_20_21.Custom.Exceptions;

namespace SSD_CW_20_21.gui
{
    public partial class DogManage : Template
    {
        #region Local Variables
        private DogDBAccess dogAccess = Globals.dogAccess;
        private CustomerDBAccess custAccess = Globals.custAccess;
        private OrderDBAccess orderAccess = Globals.orderAccess;
        private List<Dog> dogs;
        private Dog dog;
        private string mode = "view";
        // view, edit, add
        #endregion

        public DogManage() : base()
        {
            InitializeComponent();
            dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0);
            Text = "JD Dog Care - Dogs";
            
            populateListBox();
            populateComboBox();
            
            changeMode("view");
        }

        #region Events
        private void btnUpdate_Click(object sender, EventArgs ev)
        {
            if (mode != "edit")
            {
                changeMode("edit");
            }
            else
            {
                dog.Name = txtDogName.Text;
                dog.Breed = cboxDogBreed.Text;
                dog.OwnerId = Convert.ToInt32(cboxDogOwner.Text.Replace(" ", string.Empty).Split('-')[1]);

                DialogResult opt = MessageBox.Show("Are you sure you want to update these details? They cannot be reversed", "Update dog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    if (dogAccess.updateDog(dog))
                    {
                        MessageBox.Show("Successfully updated the dog", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changeMode("view");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the dog", "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs ev)
        {
            DialogResult opt = MessageBox.Show("Are you sure you want to delete this dog? This is permanent and cannot be reversed. Any future bookings for this dog will also be deleted", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opt == DialogResult.Yes)
            {
                dog.Deleted = 1;
                if (dogAccess.updateDog(dog))
                {
                    dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0);
                    changeMode("view");
                    foreach (Orders order in orderAccess.getAllOrders().FindAll(e => e.DogId == dog.Id))
                    {
                        order.Cancelled = 1;
                        orderAccess.updateOrder(order);
                    }
                    populateListBox();
                    MessageBox.Show("That dog has been deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs ev)
        {
            if (mode != "add")
            {
                changeMode("add");
            }
            else
            {
                if (txtDogName.Text == string.Empty && cboxDogOwner.Text == string.Empty && cboxDogBreed.Text == string.Empty)
                {
                    throwDogException("The values of the input boxes must not be empty", "Empty Details");
                    return;
                }
                if (txtDogName.Text == string.Empty)
                {
                    throwDogException("Enter the dog's name", "Dog Name");
                    return;
                }
                if (cboxDogOwner.Text == string.Empty)
                {
                    MessageBox.Show("Select the dog's owner", "Dog Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboxDogBreed.Text == string.Empty)
                {
                    MessageBox.Show("Select the dog's breed", "Dog Breed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dog.Name = txtDogName.Text;
                dog.OwnerId = getIdFromString(cboxDogOwner.Text);
                dog.Breed = cboxDogBreed.Text;
                dog.Aggression = cboxAggression.Text;
                dog.Deleted = 0;
                dog.Id = getIdFromString(lblDogId.Text);

                DialogResult opt = MessageBox.Show("Are you sure these details are correct?", "Add Dog?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    if (dogAccess.insertDog(dog))
                    {
                        dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0);
                        populateListBox();
                        changeMode("view");
                        MessageBox.Show("The dog has been recorded successfully", "Dog Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong when recording the dog's details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mode != "view")
            {
                changeMode("view");
            }
        }

        private void lbSelectDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSelectDog.SelectedItem != null)
            {
                dog = dogAccess.getDogById(getIdFromString(lbSelectDog.GetItemText(lbSelectDog.SelectedItem)));
                changeMode("view");
            }
        }

        private void txtDogName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            dog.DOB = dtpDOB.Value.ToShortDateString();
        }
        #endregion

        #region Custom Methods
        private void changeMode(string newMode)
        {
            if (newMode == "view")
            {
                mode = newMode;

                txtDogName.Enabled = false;
                cboxDogBreed.Enabled = false;
                cboxDogOwner.Enabled = false;
                cboxAggression.Enabled = false;

                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                lbSelectDog.Enabled = true;

                lblDogId.Text = $"#{dog.Id}";
                txtDogName.Text = dog.Name;
                cboxDogBreed.Text = dog.Breed;
                Customer cust = custAccess.getOwnerById(dog.OwnerId);
                cboxDogOwner.Text = $"{cust.Forename} {cust.Surname} - {cust.Id}";
                if (cust.Deleted == 1) cboxDogOwner.Text += " [Deleted]";
                if (dog.Deleted == 1) lblDogDeleted.Visible = true;
                else lblDogDeleted.Visible = false;
                cboxAggression.Text = dog.Aggression;
                btnAdd.Text = "Add New Dog";
                btnUpdate.Text = "Edit Current Dog";
                btnDelete.Text = "";
                btnCancel.Text = "";
            }
            else if (newMode == "add")
            {
                dog = new Dog();
                dog.Id = dogAccess.getAllDogs().Count + 1;
                dog.Deleted = 0;
                mode = newMode;

                txtDogName.Enabled = true;
                cboxDogBreed.Enabled = true;
                cboxDogOwner.Enabled = true;
                cboxAggression.Enabled = true;

                txtDogName.Text = "";
                cboxDogBreed.Text = "";
                cboxDogOwner.Text = "";
                lblDogId.Text = $"#{dog.Id}";
                lblDogDeleted.Visible = false;
                cboxAggression.Text = "";
                btnAdd.Text = "Save New Dog";
                btnCancel.Text = "Cancel New Dog";
                btnDelete.Text = "";
                btnUpdate.Text = "";

                btnCancel.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                lbSelectDog.Enabled = false;
            }
            else if (newMode == "edit")
            {
                if (lbSelectDog.SelectedItem == null)
                {
                    MessageBox.Show("Select a dog to edit first", "Select a dog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    changeMode("view");
                    return;
                }

                if (dog.Deleted == 1)
                {
                    lblDogDeleted.Visible = true;
                    changeMode("view");
                    return;
                }
                else
                {
                    lblDogDeleted.Visible = false;
                }
                mode = newMode;

                lblDogId.Text = $"#{dog.Id}";
                txtDogName.Text = dog.Name;
                cboxDogBreed.Text = dog.Breed;
                Customer cust = custAccess.getOwnerById(dog.OwnerId);
                cboxDogOwner.Text = $"{cust.Forename} {cust.Surname} - {cust.Id}";
                cboxAggression.Text = dog.Aggression;
                btnAdd.Text = "";
                btnCancel.Text = "Cancel Edit Dog";
                btnDelete.Text = "Delete Dog";
                btnUpdate.Text = "Save Changes";

                txtDogName.Enabled = true;
                cboxDogBreed.Enabled = true;
                cboxDogOwner.Enabled = true;
                cboxAggression.Enabled = true;

                btnCancel.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                lbSelectDog.Enabled = false;
            }
        }

        private void populateListBox()
        {
            DataTable data = new DataTable();
            data.Columns.Add("DogID");
            data.Columns.Add("DogName");

            foreach (Dog dog in dogs)
            {
                data.Rows.Add(dog.Id, $"{dog.Name} - {dog.Id}");
            }
            lbSelectDog.ValueMember = "DogID";
            lbSelectDog.DisplayMember = "DogName";
            lbSelectDog.DataSource = data;
        }

        private void populateComboBox()
        {
            cboxDogBreed.Items.Clear();
            cboxDogOwner.Items.Clear();
            cboxAggression.Items.Clear();

            List<Customer> owners = custAccess.getAllCustomers().FindAll(e => e.Deleted == 0);
            foreach (Customer owner in owners)
            {
                cboxDogOwner.Items.Add($"{owner.Forename} {owner.Surname} - {owner.Id}");
            }

            string[] breeds = { "Pug", "German Shephard", "Husky" };
            foreach (string breed in breeds)
            {
                cboxDogBreed.Items.Add(breed);
            }

            string[] arr = { "Low", "Medium", "High" };
            foreach (string a in arr)
            {
                cboxAggression.Items.Add(a);
            }
            cboxAggression.Text = "";
        }

        private int getIdFromString(string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]", ""));
        }

        private void throwDogException(string message, string title)
        {
            try
            {
                throw new DogException(message);
            }
            catch (DogException)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        
    }
}
