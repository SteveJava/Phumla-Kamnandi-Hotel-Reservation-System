namespace INF2011S_Project.Presentation
{
    partial class DashBoardForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.makeABookingButton = new System.Windows.Forms.Button();
            this.editGuestButton = new System.Windows.Forms.Button();
            this.editBookingButton = new System.Windows.Forms.Button();
            this.dashBoardButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.makeABookingButton);
            this.panel1.Controls.Add(this.editGuestButton);
            this.panel1.Controls.Add(this.editBookingButton);
            this.panel1.Controls.Add(this.dashBoardButton);
            this.panel1.Controls.Add(this.welcomeLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 556);
            this.panel1.TabIndex = 25;
            // 
            // makeABookingButton
            // 
            this.makeABookingButton.Location = new System.Drawing.Point(13, 130);
            this.makeABookingButton.Name = "makeABookingButton";
            this.makeABookingButton.Size = new System.Drawing.Size(175, 52);
            this.makeABookingButton.TabIndex = 4;
            this.makeABookingButton.Text = "Make a Booking";
            this.makeABookingButton.UseVisualStyleBackColor = true;
            this.makeABookingButton.Click += new System.EventHandler(this.makeABookingButton_Click);
            // 
            // editGuestButton
            // 
            this.editGuestButton.Location = new System.Drawing.Point(12, 485);
            this.editGuestButton.Name = "editGuestButton";
            this.editGuestButton.Size = new System.Drawing.Size(175, 52);
            this.editGuestButton.TabIndex = 3;
            this.editGuestButton.Text = "Edit Guest";
            this.editGuestButton.UseVisualStyleBackColor = true;
            this.editGuestButton.Click += new System.EventHandler(this.editGuestButton_Click);
            // 
            // editBookingButton
            // 
            this.editBookingButton.Location = new System.Drawing.Point(12, 427);
            this.editBookingButton.Name = "editBookingButton";
            this.editBookingButton.Size = new System.Drawing.Size(175, 52);
            this.editBookingButton.TabIndex = 2;
            this.editBookingButton.Text = "Edit Booking";
            this.editBookingButton.UseVisualStyleBackColor = true;
            this.editBookingButton.Click += new System.EventHandler(this.editBookingButton_Click);
            // 
            // dashBoardButton
            // 
            this.dashBoardButton.Location = new System.Drawing.Point(13, 56);
            this.dashBoardButton.Name = "dashBoardButton";
            this.dashBoardButton.Size = new System.Drawing.Size(175, 52);
            this.dashBoardButton.TabIndex = 1;
            this.dashBoardButton.Text = "Dashboard";
            this.dashBoardButton.UseVisualStyleBackColor = true;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(19, 21);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(65, 16);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(687, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 361);
            this.panel3.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(245, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 361);
            this.panel2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Overview";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Daily Low-Down";
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "DashBoardForm";
            this.Text = "Phumla Kamnandi Hotels";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button makeABookingButton;
        private System.Windows.Forms.Button editGuestButton;
        private System.Windows.Forms.Button editBookingButton;
        private System.Windows.Forms.Button dashBoardButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}