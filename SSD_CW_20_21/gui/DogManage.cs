using System;
using SSD_CW_20_21.Objects;
using SSD_CW_20_21.DbAccess;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace SSD_CW_20_21.gui
{
    public partial class DogManage : Template
    {
        private DogDBAccess dogAccess = Globals.dogAccess;
        private CustomerDBAccess custAccess = Globals.custAccess;
        private Dog dog;
        private string mode = "view";
        // view, edit, add

        public DogManage() : base()
        {
            InitializeComponent();
            Text = "JD Dog Care - Dogs";
            
            populateListBox();
            populateComboBox();

            dog = dogAccess.getDogById(1);
            changeMode("view");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult opt = MessageBox.Show("Are you sure you want to delete this dog? This is permanent and cannot be reversed", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opt == DialogResult.Yes)
            {
                dog.Deleted = 1;
                if (dogAccess.updateDog(dog))
                    MessageBox.Show("That dog has been deleted. Any future bookings for this dog will also be deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mode != "add")
            {
                changeMode("add");
            }
            else
            {
                if (txtDogName.Text == string.Empty && cboxDogOwner.Text == string.Empty && cboxDogBreed.Text == string.Empty)
                {
                    MessageBox.Show("The values of the input boxes must not be empty", "Empty Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDogName.Text == string.Empty)
                {
                    MessageBox.Show("Enter the dog's name", "Dog Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                DialogResult opt = MessageBox.Show("Are you sure these details are correct?", "Add Dog?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    if (dogAccess.insertDog(new Dog(Convert.ToInt32(lblDogId.Text.Replace("#", string.Empty)), Convert.ToInt32(cboxDogOwner.Text.Replace(" ", string.Empty).Split('-')[1]), txtDogName.Text, cboxDogBreed.Text)))
                    {
                        populateListBox();
                        changeMode("view");
                        MessageBox.Show("The dog has been recorded successfully", "Dog Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong when recorded the dog's details. Please try again in a few minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void changeMode(string newMode)
        {
            if (newMode == "view")
            {
                mode = newMode;

                txtDogName.Enabled = false;
                cboxDogBreed.Enabled = false;
                cboxDogOwner.Enabled = false;

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
            }
            else if (newMode == "add")
            {
                mode = newMode;

                txtDogName.Enabled = true;
                cboxDogBreed.Enabled = true;
                cboxDogOwner.Enabled = true;

                txtDogName.Text = "";
                cboxDogBreed.Text = "";
                cboxDogOwner.Text = "";
                lblDogId.Text = $"#{dogAccess.getAllDogs().Count + 1}";
                lblDogDeleted.Visible = false;

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

                txtDogName.Enabled = true;
                cboxDogBreed.Enabled = true;
                cboxDogOwner.Enabled = true;

                btnCancel.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                lbSelectDog.Enabled = false;

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

        private void populateListBox()
        {
            DataTable data = new DataTable();
            List<Dog> dogs = dogAccess.getAllDogs();

            data.Columns.Add("DogID");
            data.Columns.Add("DogName");

            foreach(Dog dog in dogs)
            {
                data.Rows.Add(dog.Id, $"{dog.Name} - {dog.Id}");
            }

            lbSelectDog.ValueMember = "DogID";
            lbSelectDog.DisplayMember = "DogName";
            lbSelectDog.DataSource = data;
        }

        private void populateComboBox()
        {
            List<Customer> owners = custAccess.getAllCustomers();
            foreach(Customer owner in owners)
            {
                cboxDogOwner.Items.Add($"{owner.Forename} {owner.Surname} - {owner.Id}");
            }

            string[] breeds = { "Pug", "German Shephard", "Husky" };
            foreach(string breed in breeds)
            {
                cboxDogBreed.Items.Add(breed);
            }
        }

        private int getIdFromString(string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]", ""));
        }
    }
}
