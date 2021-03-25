namespace SSD_CW_20_21.gui
{
    partial class DogManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cboxHair = new System.Windows.Forms.ComboBox();
            this.lblCoat = new System.Windows.Forms.Label();
            this.lblDoB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.cboxAggression = new System.Windows.Forms.ComboBox();
            this.lblAggression = new System.Windows.Forms.Label();
            this.cboxDogBreed = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cboxDogOwner = new System.Windows.Forms.ComboBox();
            this.txtDogName = new System.Windows.Forms.TextBox();
            this.lblBreed = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblDogId = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlDogs = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lbSelectDog = new System.Windows.Forms.ListBox();
            this.cboxSearch = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlDetails.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlDogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(7, 41);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(66, 25);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Dogs";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblName.Location = new System.Drawing.Point(8, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 20);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name:";
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlDetails.Controls.Add(this.label11);
            this.pnlDetails.Controls.Add(this.cboxHair);
            this.pnlDetails.Controls.Add(this.lblCoat);
            this.pnlDetails.Controls.Add(this.lblDoB);
            this.pnlDetails.Controls.Add(this.dtpDOB);
            this.pnlDetails.Controls.Add(this.cboxAggression);
            this.pnlDetails.Controls.Add(this.lblAggression);
            this.pnlDetails.Controls.Add(this.cboxDogBreed);
            this.pnlDetails.Controls.Add(this.lblID);
            this.pnlDetails.Controls.Add(this.cboxDogOwner);
            this.pnlDetails.Controls.Add(this.txtDogName);
            this.pnlDetails.Controls.Add(this.lblBreed);
            this.pnlDetails.Controls.Add(this.lblOwner);
            this.pnlDetails.Controls.Add(this.lblDogId);
            this.pnlDetails.Controls.Add(this.lblName);
            this.pnlDetails.Location = new System.Drawing.Point(345, 118);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(613, 323);
            this.pnlDetails.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Brown;
            this.label11.Location = new System.Drawing.Point(368, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(228, 75);
            this.label11.TabIndex = 30;
            this.label11.Text = "Dogs must be at least 8 Weeks old and at most 20 Years old";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboxHair
            // 
            this.cboxHair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxHair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHair.FormattingEnabled = true;
            this.cboxHair.Location = new System.Drawing.Point(131, 278);
            this.cboxHair.Name = "cboxHair";
            this.cboxHair.Size = new System.Drawing.Size(231, 28);
            this.cboxHair.TabIndex = 29;
            // 
            // lblCoat
            // 
            this.lblCoat.AutoSize = true;
            this.lblCoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCoat.Location = new System.Drawing.Point(8, 279);
            this.lblCoat.Name = "lblCoat";
            this.lblCoat.Size = new System.Drawing.Size(113, 20);
            this.lblCoat.TabIndex = 28;
            this.lblCoat.Text = "Coat Length:";
            // 
            // lblDoB
            // 
            this.lblDoB.AutoSize = true;
            this.lblDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDoB.Location = new System.Drawing.Point(8, 135);
            this.lblDoB.Name = "lblDoB";
            this.lblDoB.Size = new System.Drawing.Size(117, 20);
            this.lblDoB.TabIndex = 27;
            this.lblDoB.Text = "Date of Birth:";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Enabled = false;
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Location = new System.Drawing.Point(131, 135);
            this.dtpDOB.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDOB.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(231, 26);
            this.dtpDOB.TabIndex = 26;
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            // 
            // cboxAggression
            // 
            this.cboxAggression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxAggression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAggression.FormattingEnabled = true;
            this.cboxAggression.Location = new System.Drawing.Point(131, 230);
            this.cboxAggression.Name = "cboxAggression";
            this.cboxAggression.Size = new System.Drawing.Size(231, 28);
            this.cboxAggression.TabIndex = 25;
            // 
            // lblAggression
            // 
            this.lblAggression.AutoSize = true;
            this.lblAggression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggression.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAggression.Location = new System.Drawing.Point(8, 231);
            this.lblAggression.Name = "lblAggression";
            this.lblAggression.Size = new System.Drawing.Size(104, 20);
            this.lblAggression.TabIndex = 24;
            this.lblAggression.Text = "Aggression:";
            // 
            // cboxDogBreed
            // 
            this.cboxDogBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDogBreed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDogBreed.FormattingEnabled = true;
            this.cboxDogBreed.Location = new System.Drawing.Point(131, 180);
            this.cboxDogBreed.Name = "cboxDogBreed";
            this.cboxDogBreed.Size = new System.Drawing.Size(231, 28);
            this.cboxDogBreed.TabIndex = 23;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblID.Location = new System.Drawing.Point(7, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(71, 20);
            this.lblID.TabIndex = 22;
            this.lblID.Text = "Dog ID:";
            // 
            // cboxDogOwner
            // 
            this.cboxDogOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDogOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDogOwner.FormattingEnabled = true;
            this.cboxDogOwner.Location = new System.Drawing.Point(131, 88);
            this.cboxDogOwner.Name = "cboxDogOwner";
            this.cboxDogOwner.Size = new System.Drawing.Size(231, 28);
            this.cboxDogOwner.TabIndex = 21;
            // 
            // txtDogName
            // 
            this.txtDogName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDogName.Location = new System.Drawing.Point(131, 49);
            this.txtDogName.Name = "txtDogName";
            this.txtDogName.ShortcutsEnabled = false;
            this.txtDogName.Size = new System.Drawing.Size(231, 26);
            this.txtDogName.TabIndex = 18;
            // 
            // lblBreed
            // 
            this.lblBreed.AutoSize = true;
            this.lblBreed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreed.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBreed.Location = new System.Drawing.Point(8, 181);
            this.lblBreed.Name = "lblBreed";
            this.lblBreed.Size = new System.Drawing.Size(62, 20);
            this.lblBreed.TabIndex = 15;
            this.lblBreed.Text = "Breed:";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwner.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblOwner.Location = new System.Drawing.Point(8, 88);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(65, 20);
            this.lblOwner.TabIndex = 13;
            this.lblOwner.Text = "Owner:";
            // 
            // lblDogId
            // 
            this.lblDogId.AutoSize = true;
            this.lblDogId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDogId.Location = new System.Drawing.Point(127, 12);
            this.lblDogId.Name = "lblDogId";
            this.lblDogId.Size = new System.Drawing.Size(19, 20);
            this.lblDogId.TabIndex = 12;
            this.lblDogId.Text = "#";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(157, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 49);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Edit Dog";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(319, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 49);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete Dog";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(345, 447);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(613, 55);
            this.panel3.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(480, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 49);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel Action";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 49);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add Dog";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlDogs
            // 
            this.pnlDogs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlDogs.Controls.Add(this.btnNext);
            this.pnlDogs.Controls.Add(this.btnPrevious);
            this.pnlDogs.Controls.Add(this.lbSelectDog);
            this.pnlDogs.Location = new System.Drawing.Point(12, 118);
            this.pnlDogs.Name = "pnlDogs";
            this.pnlDogs.Size = new System.Drawing.Size(327, 381);
            this.pnlDogs.TabIndex = 20;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(176, 319);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(148, 49);
            this.btnNext.TabIndex = 22;
            this.btnNext.Text = "Next Dog";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(4, 319);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(148, 49);
            this.btnPrevious.TabIndex = 21;
            this.btnPrevious.Text = "Previous Dog";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lbSelectDog
            // 
            this.lbSelectDog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectDog.FormattingEnabled = true;
            this.lbSelectDog.ItemHeight = 18;
            this.lbSelectDog.Location = new System.Drawing.Point(4, 12);
            this.lbSelectDog.Name = "lbSelectDog";
            this.lbSelectDog.Size = new System.Drawing.Size(320, 292);
            this.lbSelectDog.TabIndex = 0;
            this.lbSelectDog.SelectedIndexChanged += new System.EventHandler(this.lbSelectDog_SelectedIndexChanged);
            // 
            // cboxSearch
            // 
            this.cboxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSearch.FormattingEnabled = true;
            this.cboxSearch.Location = new System.Drawing.Point(98, 95);
            this.cboxSearch.Name = "cboxSearch";
            this.cboxSearch.Size = new System.Drawing.Size(87, 21);
            this.cboxSearch.TabIndex = 21;
            this.cboxSearch.SelectedIndexChanged += new System.EventHandler(this.cboxSearch_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Search By";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(249, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ShortcutsEnabled = false;
            this.txtSearch.Size = new System.Drawing.Size(129, 20);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(191, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Value:";
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMenu.Location = new System.Drawing.Point(686, 505);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(133, 57);
            this.btnMenu.TabIndex = 27;
            this.btnMenu.Text = "Grooming Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // DogManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 615);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboxSearch);
            this.Controls.Add(this.pnlDogs);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel3);
            this.Name = "DogManage";
            this.Text = "DogManage";
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.pnlDetails, 0);
            this.Controls.SetChildIndex(this.pnlDogs, 0);
            this.Controls.SetChildIndex(this.cboxSearch, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.btnMenu, 0);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlDogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblDogId;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtDogName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboxDogOwner;
        private System.Windows.Forms.Panel pnlDogs;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cboxDogBreed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbSelectDog;
        private System.Windows.Forms.ComboBox cboxAggression;
        private System.Windows.Forms.Label lblAggression;
        private System.Windows.Forms.Label lblDoB;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cboxHair;
        private System.Windows.Forms.Label lblCoat;
        private System.Windows.Forms.ComboBox cboxSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label11;
    }
}