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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboxDogBreed = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxDogOwner = new System.Windows.Forms.ComboBox();
            this.txtDogName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDogId = new System.Windows.Forms.Label();
            this.lblDogDeleted = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbSelectDog = new System.Windows.Forms.ListBox();
            this.cboxSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dogs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.cboxSize);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboxDogBreed);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboxDogOwner);
            this.panel2.Controls.Add(this.txtDogName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblDogId);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(345, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 323);
            this.panel2.TabIndex = 12;
            // 
            // cboxDogBreed
            // 
            this.cboxDogBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDogBreed.FormattingEnabled = true;
            this.cboxDogBreed.Location = new System.Drawing.Point(116, 202);
            this.cboxDogBreed.Name = "cboxDogBreed";
            this.cboxDogBreed.Size = new System.Drawing.Size(278, 21);
            this.cboxDogBreed.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(7, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Dog ID:";
            // 
            // cboxDogOwner
            // 
            this.cboxDogOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDogOwner.FormattingEnabled = true;
            this.cboxDogOwner.Location = new System.Drawing.Point(116, 107);
            this.cboxDogOwner.Name = "cboxDogOwner";
            this.cboxDogOwner.Size = new System.Drawing.Size(278, 21);
            this.cboxDogOwner.TabIndex = 21;
            // 
            // txtDogName
            // 
            this.txtDogName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDogName.Location = new System.Drawing.Point(116, 49);
            this.txtDogName.Name = "txtDogName";
            this.txtDogName.Size = new System.Drawing.Size(278, 22);
            this.txtDogName.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(8, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Breed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(8, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Owner:";
            // 
            // lblDogId
            // 
            this.lblDogId.AutoSize = true;
            this.lblDogId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDogId.Location = new System.Drawing.Point(112, 12);
            this.lblDogId.Name = "lblDogId";
            this.lblDogId.Size = new System.Drawing.Size(19, 20);
            this.lblDogId.TabIndex = 12;
            this.lblDogId.Text = "#";
            // 
            // lblDogDeleted
            // 
            this.lblDogDeleted.AutoSize = true;
            this.lblDogDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDogDeleted.ForeColor = System.Drawing.Color.Red;
            this.lblDogDeleted.Location = new System.Drawing.Point(524, 65);
            this.lblDogDeleted.Name = "lblDogDeleted";
            this.lblDogDeleted.Size = new System.Drawing.Size(215, 18);
            this.lblDogDeleted.TabIndex = 24;
            this.lblDogDeleted.Text = "DOG HAS BEEN DELETED";
            this.lblDogDeleted.Visible = false;
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
            this.panel3.Location = new System.Drawing.Point(345, 435);
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.lbSelectDog);
            this.panel4.Location = new System.Drawing.Point(12, 106);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 381);
            this.panel4.TabIndex = 20;
            // 
            // lbSelectDog
            // 
            this.lbSelectDog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectDog.FormattingEnabled = true;
            this.lbSelectDog.ItemHeight = 18;
            this.lbSelectDog.Location = new System.Drawing.Point(4, 12);
            this.lbSelectDog.Name = "lbSelectDog";
            this.lbSelectDog.Size = new System.Drawing.Size(304, 346);
            this.lbSelectDog.TabIndex = 0;
            this.lbSelectDog.SelectedIndexChanged += new System.EventHandler(this.lbSelectDog_SelectedIndexChanged);
            // 
            // cboxSize
            // 
            this.cboxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSize.FormattingEnabled = true;
            this.cboxSize.Location = new System.Drawing.Point(116, 151);
            this.cboxSize.Name = "cboxSize";
            this.cboxSize.Size = new System.Drawing.Size(278, 21);
            this.cboxSize.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(8, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Size:";
            // 
            // DogManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 612);
            this.Controls.Add(this.lblDogDeleted);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Name = "DogManage";
            this.Text = "DogManage";
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.lblDogDeleted, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDogId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtDogName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboxDogOwner;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxDogBreed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbSelectDog;
        private System.Windows.Forms.Label lblDogDeleted;
        private System.Windows.Forms.ComboBox cboxSize;
        private System.Windows.Forms.Label label5;
    }
}