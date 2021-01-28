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
            this.tsMenu = new System.Windows.Forms.ToolStripTextBox();
            this.tsDogs = new System.Windows.Forms.ToolStripTextBox();
            this.tsBookings = new System.Windows.Forms.ToolStripTextBox();
            this.dayCareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dogWalkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dogTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.lblDbConn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.viewReportsToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripMenuMain,
            this.toolstripMenuSubsystems,
            this.dayCareToolStripMenuItem,
            this.dogWalkingToolStripMenuItem,
            this.dogTrainingToolStripMenuItem,
            this.collectionToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolstripMenuMain
            // 
            resources.ApplyResources(this.toolstripMenuMain, "toolstripMenuMain");
            this.toolstripMenuMain.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.toolstripMenuMain.Name = "toolstripMenuMain";
            this.toolstripMenuMain.ReadOnly = true;
            this.toolstripMenuMain.Click += new System.EventHandler(this.toolstripMenuMain_Click);
            // 
            // toolstripMenuSubsystems
            // 
            resources.ApplyResources(this.toolstripMenuSubsystems, "toolstripMenuSubsystems");
            this.toolstripMenuSubsystems.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.toolstripMenuSubsystems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenu,
            this.tsDogs,
            this.tsBookings,
            this.viewReportsToolStripMenuItem});
            this.toolstripMenuSubsystems.Name = "toolstripMenuSubsystems";
            // 
            // tsMenu
            // 
            resources.ApplyResources(this.tsMenu, "tsMenu");
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Click += new System.EventHandler(this.tsMenu_Click);
            // 
            // tsDogs
            // 
            resources.ApplyResources(this.tsDogs, "tsDogs");
            this.tsDogs.Name = "tsDogs";
            this.tsDogs.Click += new System.EventHandler(this.tsDogs_Click);
            // 
            // tsBookings
            // 
            resources.ApplyResources(this.tsBookings, "tsBookings");
            this.tsBookings.Name = "tsBookings";
            this.tsBookings.Click += new System.EventHandler(this.tsBookings_Click);
            // 
            // dayCareToolStripMenuItem
            // 
            resources.ApplyResources(this.dayCareToolStripMenuItem, "dayCareToolStripMenuItem");
            this.dayCareToolStripMenuItem.Name = "dayCareToolStripMenuItem";
            this.dayCareToolStripMenuItem.Click += new System.EventHandler(this.dayCareToolStripMenuItem_Click);
            // 
            // dogWalkingToolStripMenuItem
            // 
            resources.ApplyResources(this.dogWalkingToolStripMenuItem, "dogWalkingToolStripMenuItem");
            this.dogWalkingToolStripMenuItem.Name = "dogWalkingToolStripMenuItem";
            this.dogWalkingToolStripMenuItem.Click += new System.EventHandler(this.dogWalkingToolStripMenuItem_Click);
            // 
            // dogTrainingToolStripMenuItem
            // 
            resources.ApplyResources(this.dogTrainingToolStripMenuItem, "dogTrainingToolStripMenuItem");
            this.dogTrainingToolStripMenuItem.Name = "dogTrainingToolStripMenuItem";
            this.dogTrainingToolStripMenuItem.Click += new System.EventHandler(this.dogTrainingToolStripMenuItem_Click);
            // 
            // collectionToolStripMenuItem
            // 
            resources.ApplyResources(this.collectionToolStripMenuItem, "collectionToolStripMenuItem");
            this.collectionToolStripMenuItem.Name = "collectionToolStripMenuItem";
            this.collectionToolStripMenuItem.Click += new System.EventHandler(this.collectionToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
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
            // viewReportsToolStripMenuItem
            // 
            resources.ApplyResources(this.viewReportsToolStripMenuItem, "viewReportsToolStripMenuItem");
            this.viewReportsToolStripMenuItem.Name = "viewReportsToolStripMenuItem";
            this.viewReportsToolStripMenuItem.Click += new System.EventHandler(this.viewReportsToolStripMenuItem_Click);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripTextBox tsMenu;
        private System.Windows.Forms.ToolStripTextBox tsDogs;
        private System.Windows.Forms.ToolStripTextBox tsBookings;
        protected System.Windows.Forms.ToolStripMenuItem toolstripMenuSubsystems;
        protected System.Windows.Forms.Label lblDbConn;
        protected System.Windows.Forms.ToolStripMenuItem dayCareToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem dogWalkingToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem dogTrainingToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem collectionToolStripMenuItem;
        protected System.Windows.Forms.ToolStripTextBox exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox viewReportsToolStripMenuItem;
    }
}