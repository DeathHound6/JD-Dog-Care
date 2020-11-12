namespace SSD_CW_20_21.gui
{
    partial class Template
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolstripMenuMain = new System.Windows.Forms.ToolStripTextBox();
            this.toolstripMenuSubsystems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripTxtGrooming = new System.Windows.Forms.ToolStripTextBox();
            this.toolstripTxtWalking = new System.Windows.Forms.ToolStripTextBox();
            this.toolstripTxtTraining = new System.Windows.Forms.ToolStripTextBox();
            this.toolstripTxtDaycare = new System.Windows.Forms.ToolStripTextBox();
            this.toolstripTxtMobile = new System.Windows.Forms.ToolStripTextBox();
            this.lblDbConn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Cyan;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripMenuMain,
            this.toolstripMenuSubsystems});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(970, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolstripMenuMain
            // 
            this.toolstripMenuMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripMenuMain.Name = "toolstripMenuMain";
            this.toolstripMenuMain.Size = new System.Drawing.Size(73, 23);
            this.toolstripMenuMain.Text = "Main Menu";
            this.toolstripMenuMain.Click += new System.EventHandler(this.toolstripMenuMain_Click);
            // 
            // toolstripMenuSubsystems
            // 
            this.toolstripMenuSubsystems.BackColor = System.Drawing.SystemColors.Control;
            this.toolstripMenuSubsystems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripTxtGrooming,
            this.toolstripTxtWalking,
            this.toolstripTxtTraining,
            this.toolstripTxtDaycare,
            this.toolstripTxtMobile});
            this.toolstripMenuSubsystems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripMenuSubsystems.Name = "toolstripMenuSubsystems";
            this.toolstripMenuSubsystems.Size = new System.Drawing.Size(89, 23);
            this.toolstripMenuSubsystems.Text = "Sub Systems";
            // 
            // toolstripTxtGrooming
            // 
            this.toolstripTxtGrooming.Name = "toolstripTxtGrooming";
            this.toolstripTxtGrooming.Size = new System.Drawing.Size(100, 23);
            this.toolstripTxtGrooming.Text = "Grooming";
            this.toolstripTxtGrooming.Click += new System.EventHandler(this.toolstripTxtGrooming_Click);
            // 
            // toolstripTxtWalking
            // 
            this.toolstripTxtWalking.Name = "toolstripTxtWalking";
            this.toolstripTxtWalking.Size = new System.Drawing.Size(100, 23);
            this.toolstripTxtWalking.Text = "Dog Walking";
            this.toolstripTxtWalking.Click += new System.EventHandler(this.toolstripTxtWalking_Click);
            // 
            // toolstripTxtTraining
            // 
            this.toolstripTxtTraining.Name = "toolstripTxtTraining";
            this.toolstripTxtTraining.Size = new System.Drawing.Size(160, 23);
            this.toolstripTxtTraining.Text = "Dog Training";
            this.toolstripTxtTraining.Click += new System.EventHandler(this.toolstripTxtTraining_Click);
            // 
            // toolstripTxtDaycare
            // 
            this.toolstripTxtDaycare.Name = "toolstripTxtDaycare";
            this.toolstripTxtDaycare.Size = new System.Drawing.Size(100, 23);
            this.toolstripTxtDaycare.Text = "Day Care";
            this.toolstripTxtDaycare.Click += new System.EventHandler(this.toolstripTxtDaycare_Click);
            // 
            // toolstripTxtMobile
            // 
            this.toolstripTxtMobile.Name = "toolstripTxtMobile";
            this.toolstripTxtMobile.Size = new System.Drawing.Size(305, 23);
            this.toolstripTxtMobile.Text = "Collection, Delivery and Mobile Grooming";
            this.toolstripTxtMobile.Click += new System.EventHandler(this.toolstripTxtMobile_Click);
            // 
            // lblDbConn
            // 
            this.lblDbConn.AutoSize = true;
            this.lblDbConn.BackColor = System.Drawing.Color.Transparent;
            this.lblDbConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbConn.ForeColor = System.Drawing.Color.Green;
            this.lblDbConn.Location = new System.Drawing.Point(9, 17);
            this.lblDbConn.Name = "lblDbConn";
            this.lblDbConn.Size = new System.Drawing.Size(175, 16);
            this.lblDbConn.TabIndex = 3;
            this.lblDbConn.Text = "Database Disconnected";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.lblDbConn);
            this.panel1.Location = new System.Drawing.Point(0, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 42);
            this.panel1.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(825, 507);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 57);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 612);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Template";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Template_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Template_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox toolstripMenuMain;
        private System.Windows.Forms.ToolStripMenuItem toolstripMenuSubsystems;
        private System.Windows.Forms.ToolStripTextBox toolstripTxtGrooming;
        private System.Windows.Forms.ToolStripTextBox toolstripTxtWalking;
        private System.Windows.Forms.Label lblDbConn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripTextBox toolstripTxtTraining;
        private System.Windows.Forms.ToolStripTextBox toolstripTxtDaycare;
        private System.Windows.Forms.ToolStripTextBox toolstripTxtMobile;
        private System.Windows.Forms.Button btnExit;
    }
}