namespace SSD_CW_20_21.gui
{
    partial class Main
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
            this.btnGrooming = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWalking = new System.Windows.Forms.Button();
            this.btnTraining = new System.Windows.Forms.Button();
            this.btnDaycare = new System.Windows.Forms.Button();
            this.btnMobile = new System.Windows.Forms.Button();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrooming
            // 
            this.btnGrooming.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrooming.Location = new System.Drawing.Point(12, 132);
            this.btnGrooming.Name = "btnGrooming";
            this.btnGrooming.Size = new System.Drawing.Size(162, 80);
            this.btnGrooming.TabIndex = 6;
            this.btnGrooming.Text = "Grooming";
            this.btnGrooming.UseVisualStyleBackColor = true;
            this.btnGrooming.Click += new System.EventHandler(this.btnGrooming_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "JD Dog Care";
            // 
            // btnWalking
            // 
            this.btnWalking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWalking.Location = new System.Drawing.Point(12, 218);
            this.btnWalking.Name = "btnWalking";
            this.btnWalking.Size = new System.Drawing.Size(162, 80);
            this.btnWalking.TabIndex = 8;
            this.btnWalking.Text = "Dog Walking";
            this.btnWalking.UseVisualStyleBackColor = true;
            this.btnWalking.Click += new System.EventHandler(this.btnWalking_Click);
            // 
            // btnTraining
            // 
            this.btnTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraining.Location = new System.Drawing.Point(12, 304);
            this.btnTraining.Name = "btnTraining";
            this.btnTraining.Size = new System.Drawing.Size(162, 80);
            this.btnTraining.TabIndex = 9;
            this.btnTraining.Text = "Dog Training";
            this.btnTraining.UseVisualStyleBackColor = true;
            this.btnTraining.Click += new System.EventHandler(this.btnTraining_Click);
            // 
            // btnDaycare
            // 
            this.btnDaycare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaycare.Location = new System.Drawing.Point(12, 390);
            this.btnDaycare.Name = "btnDaycare";
            this.btnDaycare.Size = new System.Drawing.Size(162, 80);
            this.btnDaycare.TabIndex = 10;
            this.btnDaycare.Text = "Day Care";
            this.btnDaycare.UseVisualStyleBackColor = true;
            this.btnDaycare.Click += new System.EventHandler(this.btnDaycare_Click);
            // 
            // btnMobile
            // 
            this.btnMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMobile.Location = new System.Drawing.Point(12, 476);
            this.btnMobile.Name = "btnMobile";
            this.btnMobile.Size = new System.Drawing.Size(162, 80);
            this.btnMobile.TabIndex = 11;
            this.btnMobile.Text = "Collection, Delivery and Mobile Grooming";
            this.btnMobile.UseVisualStyleBackColor = true;
            this.btnMobile.Click += new System.EventHandler(this.btnMobile_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.Image = global::SSD_CW_20_21.Properties.Resources.logo;
            this.imgLogo.Location = new System.Drawing.Point(701, 67);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(248, 235);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 12;
            this.imgLogo.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 615);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.btnMobile);
            this.Controls.Add(this.btnDaycare);
            this.Controls.Add(this.btnTraining);
            this.Controls.Add(this.btnWalking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGrooming);
            this.Name = "Main";
            this.Text = "Menu";
            this.Controls.SetChildIndex(this.btnGrooming, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnWalking, 0);
            this.Controls.SetChildIndex(this.btnTraining, 0);
            this.Controls.SetChildIndex(this.btnDaycare, 0);
            this.Controls.SetChildIndex(this.btnMobile, 0);
            this.Controls.SetChildIndex(this.imgLogo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrooming;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWalking;
        private System.Windows.Forms.Button btnTraining;
        private System.Windows.Forms.Button btnDaycare;
        private System.Windows.Forms.Button btnMobile;
        private System.Windows.Forms.PictureBox imgLogo;
    }
}