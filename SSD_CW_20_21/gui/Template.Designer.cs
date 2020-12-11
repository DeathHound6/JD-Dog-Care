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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template));
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
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.Cyan;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripMenuMain,
            this.toolstripMenuSubsystems});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolstripMenuMain
            // 
            resources.ApplyResources(this.toolstripMenuMain, "toolstripMenuMain");
            this.toolstripMenuMain.Name = "toolstripMenuMain";
            this.toolstripMenuMain.ReadOnly = true;
            this.toolstripMenuMain.Click += new System.EventHandler(this.toolstripMenuMain_Click);
            // 
            // toolstripMenuSubsystems
            // 
            resources.ApplyResources(this.toolstripMenuSubsystems, "toolstripMenuSubsystems");
            this.toolstripMenuSubsystems.BackColor = System.Drawing.SystemColors.Control;
            this.toolstripMenuSubsystems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripTxtGrooming,
            this.toolstripTxtWalking,
            this.toolstripTxtTraining,
            this.toolstripTxtDaycare,
            this.toolstripTxtMobile});
            this.toolstripMenuSubsystems.Name = "toolstripMenuSubsystems";
            // 
            // toolstripTxtGrooming
            // 
            resources.ApplyResources(this.toolstripTxtGrooming, "toolstripTxtGrooming");
            this.toolstripTxtGrooming.Name = "toolstripTxtGrooming";
            this.toolstripTxtGrooming.ReadOnly = true;
            this.toolstripTxtGrooming.Click += new System.EventHandler(this.toolstripTxtGrooming_Click);
            // 
            // toolstripTxtWalking
            // 
            resources.ApplyResources(this.toolstripTxtWalking, "toolstripTxtWalking");
            this.toolstripTxtWalking.Name = "toolstripTxtWalking";
            this.toolstripTxtWalking.ReadOnly = true;
            this.toolstripTxtWalking.Click += new System.EventHandler(this.toolstripTxtWalking_Click);
            // 
            // toolstripTxtTraining
            // 
            resources.ApplyResources(this.toolstripTxtTraining, "toolstripTxtTraining");
            this.toolstripTxtTraining.Name = "toolstripTxtTraining";
            this.toolstripTxtTraining.ReadOnly = true;
            this.toolstripTxtTraining.Click += new System.EventHandler(this.toolstripTxtTraining_Click);
            // 
            // toolstripTxtDaycare
            // 
            resources.ApplyResources(this.toolstripTxtDaycare, "toolstripTxtDaycare");
            this.toolstripTxtDaycare.Name = "toolstripTxtDaycare";
            this.toolstripTxtDaycare.ReadOnly = true;
            this.toolstripTxtDaycare.Click += new System.EventHandler(this.toolstripTxtDaycare_Click);
            // 
            // toolstripTxtMobile
            // 
            resources.ApplyResources(this.toolstripTxtMobile, "toolstripTxtMobile");
            this.toolstripTxtMobile.Name = "toolstripTxtMobile";
            this.toolstripTxtMobile.ReadOnly = true;
            this.toolstripTxtMobile.Click += new System.EventHandler(this.toolstripTxtMobile_Click);
            // 
            // lblDbConn
            // 
            resources.ApplyResources(this.lblDbConn, "lblDbConn");
            this.lblDbConn.BackColor = System.Drawing.Color.Transparent;
            this.lblDbConn.ForeColor = System.Drawing.Color.Green;
            this.lblDbConn.Name = "lblDbConn";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.lblDbConn);
            this.panel1.Name = "panel1";
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Template
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Template";
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