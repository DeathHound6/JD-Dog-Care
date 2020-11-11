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
            this.label7 = new System.Windows.Forms.Label();
            this.dtDateTime = new System.Windows.Forms.DateTimePicker();
            this.cboxStaff = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkEars = new System.Windows.Forms.CheckBox();
            this.checkTeeth = new System.Windows.Forms.CheckBox();
            this.checkNails = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxDog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxServices = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrderCancelled = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbSelectOrder = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dtDateTime);
            this.panel2.Controls.Add(this.cboxStaff);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.checkEars);
            this.panel2.Controls.Add(this.checkTeeth);
            this.panel2.Controls.Add(this.checkNails);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboxDog);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboxServices);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblOrderId);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(345, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 323);
            this.panel2.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(7, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Date + Time:";
            // 
            // dtDateTime
            // 
            this.dtDateTime.Location = new System.Drawing.Point(124, 218);
            this.dtDateTime.MinDate = new System.DateTime(2020, 11, 6, 0, 0, 0, 0);
            this.dtDateTime.Name = "dtDateTime";
            this.dtDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtDateTime.TabIndex = 34;
            this.dtDateTime.Value = new System.DateTime(2020, 11, 6, 11, 52, 29, 0);
            // 
            // cboxStaff
            // 
            this.cboxStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxStaff.FormattingEnabled = true;
            this.cboxStaff.Location = new System.Drawing.Point(124, 89);
            this.cboxStaff.Name = "cboxStaff";
            this.cboxStaff.Size = new System.Drawing.Size(278, 28);
            this.cboxStaff.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(7, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Staff:";
            // 
            // checkEars
            // 
            this.checkEars.AutoSize = true;
            this.checkEars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEars.Location = new System.Drawing.Point(361, 170);
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
            this.checkTeeth.Location = new System.Drawing.Point(239, 170);
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
            this.checkNails.Location = new System.Drawing.Point(124, 171);
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
            this.label4.Location = new System.Drawing.Point(7, 171);
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
            this.cboxDog.Location = new System.Drawing.Point(124, 45);
            this.cboxDog.Name = "cboxDog";
            this.cboxDog.Size = new System.Drawing.Size(278, 28);
            this.cboxDog.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(7, 48);
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
            this.cboxServices.Location = new System.Drawing.Point(124, 128);
            this.cboxServices.Name = "cboxServices";
            this.cboxServices.Size = new System.Drawing.Size(278, 28);
            this.cboxServices.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(7, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Order ID:";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderId.Location = new System.Drawing.Point(120, 12);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(19, 20);
            this.lblOrderId.TabIndex = 12;
            this.lblOrderId.Text = "#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(7, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Service:";
            // 
            // lblOrderCancelled
            // 
            this.lblOrderCancelled.AutoSize = true;
            this.lblOrderCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblOrderCancelled.Location = new System.Drawing.Point(512, 66);
            this.lblOrderCancelled.Name = "lblOrderCancelled";
            this.lblOrderCancelled.Size = new System.Drawing.Size(259, 18);
            this.lblOrderCancelled.TabIndex = 24;
            this.lblOrderCancelled.Text = "ORDER HAS BEEN CANCELLED";
            this.lblOrderCancelled.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.lbSelectOrder);
            this.panel4.Location = new System.Drawing.Point(12, 102);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 381);
            this.panel4.TabIndex = 21;
            // 
            // lbSelectOrder
            // 
            this.lbSelectOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectOrder.FormattingEnabled = true;
            this.lbSelectOrder.ItemHeight = 18;
            this.lbSelectOrder.Location = new System.Drawing.Point(4, 12);
            this.lbSelectOrder.Name = "lbSelectOrder";
            this.lbSelectOrder.Size = new System.Drawing.Size(304, 346);
            this.lbSelectOrder.TabIndex = 0;
            this.lbSelectOrder.SelectedIndexChanged += new System.EventHandler(this.lbSelectOrder_SelectedIndexChanged);
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
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(345, 431);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(613, 55);
            this.panel3.TabIndex = 23;
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
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOrderCancelled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox lbSelectOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
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
        private System.Windows.Forms.ComboBox cboxStaff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDateTime;
    }
}