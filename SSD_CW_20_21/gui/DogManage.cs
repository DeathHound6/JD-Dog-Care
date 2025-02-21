﻿using System;
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
            lbSelectDog.SelectedItem = null;
            dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0);
            Text = "JD Dog Care - Manage Dogs";

            populateComboBox();
            populateListBox();
            cboxSearch.SelectedIndex = 0;
            dtpDOB.MaxDate = DateTime.Today.AddDays(7 * -8);
            dtpDOB.MinDate = Convert.ToDateTime("01/01/1990 00:00:00");

            changeMode("view");
        }

        #region Events
        private void txtDogName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsControl(e.KeyChar) && e.KeyChar != (char)8) || char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '`' || e.KeyChar == '|' || e.KeyChar == '<' || e.KeyChar == '>' || e.KeyChar == '£' || e.KeyChar == '$' || e.KeyChar == '=' || e.KeyChar == '+' || e.KeyChar == '^')
            {
                e.Handled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            lbSelectDog.SelectedIndex += 1;

            if (lbSelectDog.SelectedIndex == 0) btnPrevious.Enabled = false;
            else btnPrevious.Enabled = true;
            if (lbSelectDog.SelectedIndex == lbSelectDog.Items.Count - 1) btnNext.Enabled = false;
            else btnNext.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            lbSelectDog.SelectedIndex -= 1;

            if (lbSelectDog.SelectedIndex == 0) btnPrevious.Enabled = false;
            else btnPrevious.Enabled = true;
            if (lbSelectDog.SelectedIndex == lbSelectDog.Items.Count - 1) btnNext.Enabled = false;
            else btnNext.Enabled = true;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            new GroomingMain().Show();
            Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs ev)
        {
            if (mode != "edit")
            {
                changeMode("edit");
            }
            else
            {
                if (cboxDogOwner.Text == "")
                {
                    throwDogException("Select the dog's owner", "Dog Owner");
                    return;
                }
                if (dtpDOB.Value > DateTime.Now.AddDays(7 * -8)) // 7 days per week * -8 weeks (8 weeks subtracted)
                {
                    throwDogException("The dog is too young", "Dog too young");
                    return;
                }
                if (dtpDOB.Value < DateTime.Now.AddDays(7 * -8).AddYears(-20).AddDays(-1)) // dogs usually live 15-20 yrs
                {
                    throwDogException("The dog is too old", "Dog too old");
                    return;
                }

                DialogResult opt = MessageBox.Show("Are you sure you want to update these details? They cannot be reversed", "Update dog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    dog.Name = txtDogName.Text;
                    dog.Breed = cboxDogBreed.Text;
                    dog.HairLength = cboxHair.Text;
                    dog.Aggression = cboxAggression.Text;
                    dog.OwnerId = Convert.ToInt32(cboxDogOwner.Text.Replace(" ", "").Split('-')[1]);
                    dog.DOB = dtpDOB.Value.ToShortDateString();
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
                if (txtDogName.Text == "" && cboxDogOwner.Text == "" && cboxDogBreed.Text == "" && cboxHair.Text == "" && cboxAggression.Text == "")
                {
                    throwDogException("The values of the input boxes must not be empty", "Empty Details");
                    return;
                }
                if (txtDogName.Text == "")
                {
                    throwDogException("Enter the dog's name", "Dog Name");
                    return;
                }
                if (cboxDogOwner.Text == "")
                {
                    throwDogException("Select the dog's owner", "Dog Owner");
                    return;
                }
                if (cboxDogBreed.Text == "")
                {
                    throwDogException("Select the dog's breed", "Dog Breed");
                    return;
                }
                if (dtpDOB.Value > DateTime.Now.AddDays(7 * -8)) // 7 days per week * -8 weeks (8 weeks subtracted)
                {
                    throwDogException("The dog is too young", "Dog too young");
                    return;
                }
                if (dtpDOB.Value <= DateTime.Now.AddDays(7 * -8).AddYears(-20).AddDays(-1)) // dogs usually live 15-20 yrs
                {
                    throwDogException("The dog is too old", "Dog too old");
                    return;
                }

                DialogResult opt = MessageBox.Show("Are you sure these details are correct?", "Add Dog?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opt == DialogResult.Yes)
                {
                    dog.Name = txtDogName.Text.Replace("'", "''");
                    dog.OwnerId = getIdFromString(cboxDogOwner.Text);
                    dog.Breed = cboxDogBreed.Text;
                    dog.Aggression = cboxAggression.Text;
                    dog.Deleted = 0;
                    dog.Id = getIdFromString(lblDogId.Text);
                    dog.DOB = dtpDOB.Value.ToShortDateString();
                    dog.HairLength = cboxHair.Text;
                    if (dogAccess.insertDog(dog))
                    {
                        dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0);
                        populateListBox();
                        changeMode("view");
                        MessageBox.Show("The dog has been added successfully", "Dog Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong when adding the dog's details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mode != "view") changeMode("view");
        }

        private void lbSelectDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSelectDog.SelectedItem != null)
            {
                dog = dogAccess.getDogById(getIdFromString(lbSelectDog.GetItemText(lbSelectDog.SelectedItem)));
                changeMode("view");
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            dog.DOB = dtpDOB.Value.ToShortDateString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs ev)
        {
            if (cboxSearch.Text.ToLower() == "dog")
            {
                dogs = dogAccess.getAllDogs().FindAll(e => e.Deleted == 0 && e.Name.ToLower().Contains(txtSearch.Text.ToLower()));
            }
            else
            {
                dogs = dogAccess.getAllDogs().FindAll(e => {
                    Customer cust = custAccess.getOwnerById(e.OwnerId);
                    return e.Deleted == 0 && $"{cust.Forename} {cust.Surname}".ToLower().Contains(txtSearch.Text.ToLower());
                });
            }
            populateListBox();
        }

        private void cboxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            if (cboxSearch.Text == "") txtSearch.Enabled = false;
            else txtSearch.Enabled = true;
            txtSearch_TextChanged(txtSearch, new EventArgs());
        }
        #endregion

        #region Custom Methods
        private void changeMode(string newMode)
        {
            if (newMode == "view")
            {
                if (dog == null || dog.Name == null)
                {
                    if (dogs.Count > 0) dog = dogs.ToArray()[0];
                    else
                    {
                        dog = new Dog();
                        dog.Id = dogs.Count + 1;
                        dog.OwnerId = 1;
                        dog.Aggression = "";
                        dog.Breed = "";
                        dog.DOB = DateTime.Today.ToShortDateString();
                        dog.HairLength = "";
                        dog.Name = "";
                        dog.Deleted = 0;
                    }
                }

                txtDogName.Enabled = false;
                cboxDogBreed.Enabled = false;
                cboxDogOwner.Enabled = false;
                cboxAggression.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                if (dogs.Count > 0) btnUpdate.Enabled = true;
                else btnUpdate.Enabled = false;
                lbSelectDog.Enabled = true;
                dtpDOB.Enabled = false;
                cboxHair.Enabled = false;
                cboxSearch.Enabled = true;
                txtSearch.Enabled = true;
                if (lbSelectDog.SelectedIndex == 0) btnPrevious.Enabled = false;
                else btnPrevious.Enabled = true;
                if (lbSelectDog.SelectedIndex == lbSelectDog.Items.Count - 1) btnNext.Enabled = false;
                else btnNext.Enabled = true;

                lblDogId.Text = $"#{dog.Id}";
                txtDogName.Text = dog.Name;
                cboxDogBreed.Text = dog.Breed;
                cboxHair.Text = dog.HairLength;
                dtpDOB.Value = Convert.ToDateTime(dog.DOB);

                Customer cust = custAccess.getOwnerById(dog.OwnerId);
                cboxDogOwner.Text = $"{cust.Forename} {cust.Surname} - {cust.Id}";

                cboxAggression.Text = dog.Aggression;
                btnAdd.Text = "Add New Dog";
                btnUpdate.Text = "Edit Current Dog";
                btnDelete.Text = "";
                btnCancel.Text = "";

                mode = newMode;
            }
            else if (newMode == "add")
            {
                txtSearch.Text = "";
                cboxSearch.SelectedIndex = 0;

                dog = new Dog();
                dog.Id = dogAccess.getAllDogs().Count + 1;
                dog.Deleted = 0;

                txtDogName.Enabled = true;
                cboxDogBreed.Enabled = true;
                cboxDogOwner.Enabled = true;
                cboxAggression.Enabled = true;
                cboxHair.Enabled = true;
                dtpDOB.Enabled = true;
                btnCancel.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                lbSelectDog.Enabled = false;
                txtSearch.Enabled = false;
                cboxSearch.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;

                txtDogName.Text = "";
                cboxDogBreed.SelectedIndex = 0;
                cboxDogOwner.SelectedIndex = 0;
                lblDogId.Text = $"#{dog.Id}";
                cboxHair.SelectedIndex = 0;
                cboxAggression.SelectedIndex = 0;
                btnAdd.Text = "Save New Dog";
                btnCancel.Text = "Cancel New Dog";
                btnDelete.Text = "";
                btnUpdate.Text = "";
                dtpDOB.Value = dtpDOB.MaxDate;

                mode = newMode;
            }
            else if (newMode == "edit")
            {
                if (lbSelectDog.SelectedItem == null)
                {
                    MessageBox.Show("Select a dog to edit first", "Select a dog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    changeMode("view");
                    return;
                }
                
                btnAdd.Text = "";
                btnCancel.Text = "Cancel Edit Dog";
                btnDelete.Text = "Delete Dog";
                btnUpdate.Text = "Save Changes";
                dtpDOB.Value = Convert.ToDateTime(dog.DOB);
                txtSearch.Text = "";
                cboxSearch.Text = "";

                cboxSearch.Enabled = false;
                txtSearch.Enabled = false;
                cboxHair.Enabled = true;
                txtDogName.Enabled = true;
                cboxDogBreed.Enabled = true;
                cboxDogOwner.Enabled = true;
                cboxAggression.Enabled = true;
                dtpDOB.Enabled = true;
                btnCancel.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                lbSelectDog.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                
                mode = newMode;
            }
        }

        private void populateListBox()
        {
            DataTable data = new DataTable();
            data.Columns.Add("DogID");
            data.Columns.Add("DogName");

            foreach (Dog dog in dogs)
            {
                Customer owner = custAccess.getOwnerById(dog.OwnerId);
                data.Rows.Add(dog.Id, $"Dog({dog.Name}, {dog.Id}) - Owner({owner.Forename} {owner.Surname})");
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
            cboxHair.Items.Clear();
            cboxSearch.Items.Clear();

            List<Customer> owners = custAccess.getAllCustomers().FindAll(e => e.Deleted == 0);
            foreach (Customer owner in owners)
            {
                cboxDogOwner.Items.Add($"{owner.Forename} {owner.Surname} - {owner.Id}");
            }

            string[] breeds = { "Basset Hound", "Border Collie", "Bulldog", "French Bulldog", "German Shephard", "Great Dane", "Husky", "Labrador", "Rottweiler", "Poodle", "Pug" };
            foreach (string breed in breeds)
            {
                cboxDogBreed.Items.Add(breed);
            }

            string[] aggressions = { "Low", "Medium", "High" };
            foreach (string aggression in aggressions)
            {
                cboxAggression.Items.Add(aggression);
            }

            string[] lengths = { "Short", "Medium", "Long" };
            foreach (string length in lengths)
            {
                cboxHair.Items.Add(length);
            }

            string[] search = { "Owner", "Dog" };
            foreach (string txt in search)
            {
                cboxSearch.Items.Add(txt);
            }
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
