namespace SSD_CW_20_21.gui
{
    partial class GroomingMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDogs = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lblUpcoming = new System.Windows.Forms.Label();
            this.btnReports = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(113, 25);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Grooming";
            // 
            // btnDogs
            // 
            this.btnDogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDogs.Location = new System.Drawing.Point(12, 119);
            this.btnDogs.Name = "btnDogs";
            this.btnDogs.Size = new System.Drawing.Size(162, 80);
            this.btnDogs.TabIndex = 10;
            this.btnDogs.Text = "Manage Dogs";
            this.btnDogs.UseVisualStyleBackColor = true;
            this.btnDogs.Click += new System.EventHandler(this.btnDogs_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooking.Location = new System.Drawing.Point(12, 218);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(162, 80);
            this.btnBooking.TabIndex = 12;
            this.btnBooking.Text = "Manage Bookings";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.Location = new System.Drawing.Point(207, 164);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrders.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvOrders.Size = new System.Drawing.Size(504, 283);
            this.dgvOrders.TabIndex = 13;
            // 
            // imgLogo
            // 
            this.imgLogo.Image = global::SSD_CW_20_21.Properties.Resources.logo;
            this.imgLogo.Location = new System.Drawing.Point(694, 43);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(263, 217);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 14;
            this.imgLogo.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMenu.Location = new System.Drawing.Point(686, 507);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(133, 57);
            this.btnMenu.TabIndex = 27;
            this.btnMenu.Text = "Main Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblUpcoming
            // 
            this.lblUpcoming.AutoSize = true;
            this.lblUpcoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcoming.Location = new System.Drawing.Point(355, 132);
            this.lblUpcoming.Name = "lblUpcoming";
            this.lblUpcoming.Size = new System.Drawing.Size(183, 20);
            this.lblUpcoming.TabIndex = 28;
            this.lblUpcoming.Text = "Upcoming 5 Bookings";
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(12, 317);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(162, 80);
            this.btnReports.TabIndex = 29;
            this.btnReports.Text = "View Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // GroomingMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 615);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.lblUpcoming);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.btnDogs);
            this.Controls.Add(this.lblTitle);
            this.Name = "GroomingMain";
            this.Text = "GroomingMain";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnDogs, 0);
            this.Controls.SetChildIndex(this.btnBooking, 0);
            this.Controls.SetChildIndex(this.imgLogo, 0);
            this.Controls.SetChildIndex(this.btnMenu, 0);
            this.Controls.SetChildIndex(this.lblUpcoming, 0);
            this.Controls.SetChildIndex(this.btnReports, 0);
            this.Controls.SetChildIndex(this.dgvOrders, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDogs;
        private System.Windows.Forms.Button btnBooking;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblUpcoming;
        private System.Windows.Forms.Button btnReports;
    }
}