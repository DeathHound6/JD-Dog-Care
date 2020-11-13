﻿namespace SSD_CW_20_21.gui
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnSelectDate = new System.Windows.Forms.Button();
            this.btnSelectTime = new System.Windows.Forms.Button();
            this.lblOrderCancelled = new System.Windows.Forms.Label();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.btnSelectStaff = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateTime)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(8, 239);
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
            this.label8.Location = new System.Drawing.Point(8, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Paid:";
            // 
            // checkPaid
            // 
            this.checkPaid.AutoSize = true;
            this.checkPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPaid.Location = new System.Drawing.Point(124, 280);
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
            this.label7.Location = new System.Drawing.Point(7, 197);
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
            this.label5.Location = new System.Drawing.Point(7, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Staff:";
            // 
            // checkEars
            // 
            this.checkEars.AutoSize = true;
            this.checkEars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEars.Location = new System.Drawing.Point(361, 156);
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
            this.checkTeeth.Location = new System.Drawing.Point(239, 156);
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
            this.checkNails.Location = new System.Drawing.Point(124, 157);
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
            this.label4.Location = new System.Drawing.Point(8, 156);
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
            this.cboxDog.Location = new System.Drawing.Point(124, 12);
            this.cboxDog.Name = "cboxDog";
            this.cboxDog.Size = new System.Drawing.Size(278, 28);
            this.cboxDog.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(7, 12);
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
            this.cboxServices.Location = new System.Drawing.Point(124, 117);
            this.cboxServices.Name = "cboxServices";
            this.cboxServices.Size = new System.Drawing.Size(278, 28);
            this.cboxServices.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(8, 117);
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
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(515, 431);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 55);
            this.panel3.TabIndex = 23;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 49);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add Order";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(319, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 49);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Cancel Order";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(157, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 49);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Edit Order";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(124, 196);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(189, 20);
            this.txtDate.TabIndex = 39;
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(124, 239);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(189, 20);
            this.txtTime.TabIndex = 40;
            // 
            // btnSelectDate
            // 
            this.btnSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDate.Location = new System.Drawing.Point(320, 193);
            this.btnSelectDate.Name = "btnSelectDate";
            this.btnSelectDate.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDate.TabIndex = 41;
            this.btnSelectDate.Text = "Select";
            this.btnSelectDate.UseVisualStyleBackColor = true;
            // 
            // btnSelectTime
            // 
            this.btnSelectTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectTime.Location = new System.Drawing.Point(320, 237);
            this.btnSelectTime.Name = "btnSelectTime";
            this.btnSelectTime.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTime.TabIndex = 42;
            this.btnSelectTime.Text = "Select";
            this.btnSelectTime.UseVisualStyleBackColor = true;
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
            // txtStaff
            // 
            this.txtStaff.Enabled = false;
            this.txtStaff.Location = new System.Drawing.Point(124, 69);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(189, 20);
            this.txtStaff.TabIndex = 43;
            // 
            // btnSelectStaff
            // 
            this.btnSelectStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectStaff.Location = new System.Drawing.Point(320, 67);
            this.btnSelectStaff.Name = "btnSelectStaff";
            this.btnSelectStaff.Size = new System.Drawing.Size(75, 23);
            this.btnSelectStaff.TabIndex = 44;
            this.btnSelectStaff.Text = "Select";
            this.btnSelectStaff.UseVisualStyleBackColor = true;
            // 
            // BookingsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 612);
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
    }
}