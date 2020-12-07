namespace SSD_CW_20_21.gui
{
    partial class BookingsManage
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cboxCust = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkDelDog = new System.Windows.Forms.CheckBox();
            this.btnSelectStaff = new System.Windows.Forms.Button();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.btnSelectTime = new System.Windows.Forms.Button();
            this.btnSelectDate = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkPaid = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkEars = new System.Windows.Forms.CheckBox();
            this.checkTeeth = new System.Windows.Forms.CheckBox();
            this.checkNails = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxDog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxServices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvDateTime = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblOrderCancelled = new System.Windows.Forms.Label();
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateTime)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.cboxCust);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.checkDelDog);
            this.panel2.Controls.Add(this.btnSelectStaff);
            this.panel2.Controls.Add(this.txtStaff);
            this.panel2.Controls.Add(this.btnSelectTime);
            this.panel2.Controls.Add(this.btnSelectDate);
            this.panel2.Controls.Add(this.txtTime);
            this.panel2.Controls.Add(this.txtDate);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.checkPaid);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.checkEars);
            this.panel2.Controls.Add(this.checkTeeth);
            this.panel2.Controls.Add(this.checkNails);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboxDog);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboxServices);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(515, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 323);
            this.panel2.TabIndex = 13;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(340, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 48;
            this.checkBox1.Text = "Hide Deleted";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cboxCust
            // 
            this.cboxCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCust.FormattingEnabled = true;
            this.cboxCust.Location = new System.Drawing.Point(124, 8);
            this.cboxCust.Name = "cboxCust";
            this.cboxCust.Size = new System.Drawing.Size(210, 28);
            this.cboxCust.TabIndex = 47;
            this.cboxCust.SelectedIndexChanged += new System.EventHandler(this.cboxCust_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(7, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Owner:";
            // 
            // checkDelDog
            // 
            this.checkDelDog.AutoSize = true;
            this.checkDelDog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDelDog.Location = new System.Drawing.Point(340, 49);
            this.checkDelDog.Name = "checkDelDog";
            this.checkDelDog.Size = new System.Drawing.Size(100, 17);
            this.checkDelDog.TabIndex = 45;
            this.checkDelDog.Text = "Hide Deleted";
            this.checkDelDog.UseVisualStyleBackColor = true;
            this.checkDelDog.CheckedChanged += new System.EventHandler(this.checkDelDog_CheckedChanged);
            // 
            // btnSelectStaff
            // 
            this.btnSelectStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectStaff.Location = new System.Drawing.Point(320, 263);
            this.btnSelectStaff.Name = "btnSelectStaff";
            this.btnSelectStaff.Size = new System.Drawing.Size(75, 23);
            this.btnSelectStaff.TabIndex = 44;
            this.btnSelectStaff.Text = "Select";
            this.btnSelectStaff.UseVisualStyleBackColor = true;
            this.btnSelectStaff.Click += new System.EventHandler(this.btnSelectStaff_Click);
            // 
            // txtStaff
            // 
            this.txtStaff.Enabled = false;
            this.txtStaff.Location = new System.Drawing.Point(124, 265);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(189, 20);
            this.txtStaff.TabIndex = 43;
            // 
            // btnSelectTime
            // 
            this.btnSelectTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectTime.Location = new System.Drawing.Point(320, 208);
            this.btnSelectTime.Name = "btnSelectTime";
            this.btnSelectTime.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTime.TabIndex = 42;
            this.btnSelectTime.Text = "Select";
            this.btnSelectTime.UseVisualStyleBackColor = true;
            this.btnSelectTime.Click += new System.EventHandler(this.btnSelectTime_Click);
            // 
            // btnSelectDate
            // 
            this.btnSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDate.Location = new System.Drawing.Point(320, 164);
            this.btnSelectDate.Name = "btnSelectDate";
            this.btnSelectDate.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDate.TabIndex = 41;
            this.btnSelectDate.Text = "Select";
            this.btnSelectDate.UseVisualStyleBackColor = true;
            this.btnSelectDate.Click += new System.EventHandler(this.btnSelectDate_Click);
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(124, 210);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(189, 20);
            this.txtTime.TabIndex = 40;
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(124, 167);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(189, 20);
            this.txtDate.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(8, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 38;
            this.label9.Text = "Start Time:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(8, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Paid:";
            // 
            // checkPaid
            // 
            this.checkPaid.AutoSize = true;
            this.checkPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPaid.Location = new System.Drawing.Point(124, 292);
            this.checkPaid.Name = "checkPaid";
            this.checkPaid.Size = new System.Drawing.Size(63, 24);
            this.checkPaid.TabIndex = 36;
            this.checkPaid.Text = "Paid";
            this.checkPaid.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(7, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(8, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Staff:";
            // 
            // checkEars
            // 
            this.checkEars.AutoSize = true;
            this.checkEars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEars.Location = new System.Drawing.Point(361, 122);
            this.checkEars.Name = "checkEars";
            this.checkEars.Size = new System.Drawing.Size(65, 24);
            this.checkEars.TabIndex = 31;
            this.checkEars.Text = "Ears";
            this.checkEars.UseVisualStyleBackColor = true;
            // 
            // checkTeeth
            // 
            this.checkTeeth.AutoSize = true;
            this.checkTeeth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTeeth.Location = new System.Drawing.Point(239, 127);
            this.checkTeeth.Name = "checkTeeth";
            this.checkTeeth.Size = new System.Drawing.Size(74, 24);
            this.checkTeeth.TabIndex = 30;
            this.checkTeeth.Text = "Teeth";
            this.checkTeeth.UseVisualStyleBackColor = true;
            // 
            // checkNails
            // 
            this.checkNails.AutoSize = true;
            this.checkNails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNails.Location = new System.Drawing.Point(124, 128);
            this.checkNails.Name = "checkNails";
            this.checkNails.Size = new System.Drawing.Size(67, 24);
            this.checkNails.TabIndex = 29;
            this.checkNails.Text = "Nails";
            this.checkNails.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(8, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Extras:";
            // 
            // cboxDog
            // 
            this.cboxDog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDog.FormattingEnabled = true;
            this.cboxDog.Location = new System.Drawing.Point(124, 42);
            this.cboxDog.Name = "cboxDog";
            this.cboxDog.Size = new System.Drawing.Size(210, 28);
            this.cboxDog.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Dog:";
            // 
            // cboxServices
            // 
            this.cboxServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxServices.FormattingEnabled = true;
            this.cboxServices.Location = new System.Drawing.Point(124, 88);
            this.cboxServices.Name = "cboxServices";
            this.cboxServices.Size = new System.Drawing.Size(278, 28);
            this.cboxServices.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(8, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Service:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.dgvDateTime);
            this.panel4.Location = new System.Drawing.Point(12, 102);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(497, 462);
            this.panel4.TabIndex = 21;
            // 
            // dgvDateTime
            // 
            this.dgvDateTime.AllowUserToAddRows = false;
            this.dgvDateTime.AllowUserToDeleteRows = false;
            this.dgvDateTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDateTime.Location = new System.Drawing.Point(3, 3);
            this.dgvDateTime.Name = "dgvDateTime";
            this.dgvDateTime.ReadOnly = true;
            this.dgvDateTime.Size = new System.Drawing.Size(491, 456);
            this.dgvDateTime.TabIndex = 0;
            this.dgvDateTime.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDateTime_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Bookings";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.btnView);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(515, 431);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 55);
            this.panel3.TabIndex = 23;
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(325, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(115, 49);
            this.btnView.TabIndex = 21;
            this.btnView.Text = "View Orders";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 49);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add Order";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(219, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 49);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Cancel Order";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(112, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 49);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Edit Order";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblOrderCancelled
            // 
            this.lblOrderCancelled.AutoSize = true;
            this.lblOrderCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblOrderCancelled.Location = new System.Drawing.Point(607, 66);
            this.lblOrderCancelled.Name = "lblOrderCancelled";
            this.lblOrderCancelled.Size = new System.Drawing.Size(259, 18);
            this.lblOrderCancelled.TabIndex = 24;
            this.lblOrderCancelled.Text = "ORDER HAS BEEN CANCELLED";
            this.lblOrderCancelled.Visible = false;
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.Location = new System.Drawing.Point(543, 507);
            this.dtpDateTime.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.dtpDateTime.MinDate = new System.DateTime(2020, 11, 13, 0, 0, 0, 0);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpDateTime.TabIndex = 25;
            this.dtpDateTime.Visible = false;
            // 
            // BookingsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 612);
            this.Controls.Add(this.dtpDateTime);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblOrderCancelled);
            this.Name = "BookingsManage";
            this.Text = "BookingsManage";
            this.Controls.SetChildIndex(this.lblOrderCancelled, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.dtpDateTime, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateTime)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cboxServices;
        private System.Windows.Forms.ComboBox cboxDog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkEars;
        private System.Windows.Forms.CheckBox checkTeeth;
        private System.Windows.Forms.CheckBox checkNails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvDateTime;
        private System.Windows.Forms.Button btnSelectTime;
        private System.Windows.Forms.Button btnSelectDate;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblOrderCancelled;
        private System.Windows.Forms.Button btnSelectStaff;
        private System.Windows.Forms.TextBox txtStaff;
        private System.Windows.Forms.CheckBox checkDelDog;
        private System.Windows.Forms.DateTimePicker dtpDateTime;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cboxCust;
        private System.Windows.Forms.Label label6;
    }
}