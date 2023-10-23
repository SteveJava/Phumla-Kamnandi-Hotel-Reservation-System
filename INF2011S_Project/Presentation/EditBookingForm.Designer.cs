namespace INF2011S_Project.Presentation
{
    partial class EditBookingForm
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
            this.bookingsLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numberOfAdultsLabel = new System.Windows.Forms.Label();
            this.numberOfChildrenLabel = new System.Windows.Forms.Label();
            this.specialRequestsLabel = new System.Windows.Forms.Label();
            this.numberOfAdultsTextBox = new System.Windows.Forms.TextBox();
            this.numberOfChildrenTextBox = new System.Windows.Forms.TextBox();
            this.specialRequestsTextBox = new System.Windows.Forms.TextBox();
            this.deleteBookingButton = new System.Windows.Forms.Button();
            this.confirmChangesButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.makeABookingButton = new System.Windows.Forms.Button();
            this.editGuestButton = new System.Windows.Forms.Button();
            this.editBookingButton = new System.Windows.Forms.Button();
            this.dashBoardButton = new System.Windows.Forms.Button();
            this.showAllBookingsButton = new System.Windows.Forms.Button();
            this.guestNameLabel = new System.Windows.Forms.Label();
            this.referenceNumberTextBox = new System.Windows.Forms.TextBox();
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookingsLabel
            // 
            this.bookingsLabel.AutoSize = true;
            this.bookingsLabel.Location = new System.Drawing.Point(239, 21);
            this.bookingsLabel.Name = "bookingsLabel";
            this.bookingsLabel.Size = new System.Drawing.Size(64, 16);
            this.bookingsLabel.TabIndex = 2;
            this.bookingsLabel.Text = "Bookings";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(242, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 213);
            this.dataGridView1.TabIndex = 3;
            // 
            // numberOfAdultsLabel
            // 
            this.numberOfAdultsLabel.AutoSize = true;
            this.numberOfAdultsLabel.Location = new System.Drawing.Point(241, 371);
            this.numberOfAdultsLabel.Name = "numberOfAdultsLabel";
            this.numberOfAdultsLabel.Size = new System.Drawing.Size(112, 16);
            this.numberOfAdultsLabel.TabIndex = 8;
            this.numberOfAdultsLabel.Text = "Number of Adults:";
            // 
            // numberOfChildrenLabel
            // 
            this.numberOfChildrenLabel.AutoSize = true;
            this.numberOfChildrenLabel.Location = new System.Drawing.Point(241, 409);
            this.numberOfChildrenLabel.Name = "numberOfChildrenLabel";
            this.numberOfChildrenLabel.Size = new System.Drawing.Size(124, 16);
            this.numberOfChildrenLabel.TabIndex = 9;
            this.numberOfChildrenLabel.Text = "Number of Children:";
            // 
            // specialRequestsLabel
            // 
            this.specialRequestsLabel.AutoSize = true;
            this.specialRequestsLabel.Location = new System.Drawing.Point(241, 445);
            this.specialRequestsLabel.Name = "specialRequestsLabel";
            this.specialRequestsLabel.Size = new System.Drawing.Size(117, 16);
            this.specialRequestsLabel.TabIndex = 10;
            this.specialRequestsLabel.Text = "Special Requests:";
            // 
            // numberOfAdultsTextBox
            // 
            this.numberOfAdultsTextBox.Location = new System.Drawing.Point(375, 368);
            this.numberOfAdultsTextBox.Name = "numberOfAdultsTextBox";
            this.numberOfAdultsTextBox.Size = new System.Drawing.Size(100, 22);
            this.numberOfAdultsTextBox.TabIndex = 13;
            // 
            // numberOfChildrenTextBox
            // 
            this.numberOfChildrenTextBox.Location = new System.Drawing.Point(375, 406);
            this.numberOfChildrenTextBox.Name = "numberOfChildrenTextBox";
            this.numberOfChildrenTextBox.Size = new System.Drawing.Size(100, 22);
            this.numberOfChildrenTextBox.TabIndex = 14;
            // 
            // specialRequestsTextBox
            // 
            this.specialRequestsTextBox.Location = new System.Drawing.Point(375, 445);
            this.specialRequestsTextBox.Multiline = true;
            this.specialRequestsTextBox.Name = "specialRequestsTextBox";
            this.specialRequestsTextBox.Size = new System.Drawing.Size(333, 92);
            this.specialRequestsTextBox.TabIndex = 15;
            // 
            // deleteBookingButton
            // 
            this.deleteBookingButton.Location = new System.Drawing.Point(916, 445);
            this.deleteBookingButton.Name = "deleteBookingButton";
            this.deleteBookingButton.Size = new System.Drawing.Size(126, 23);
            this.deleteBookingButton.TabIndex = 16;
            this.deleteBookingButton.Text = "Delete Booking";
            this.deleteBookingButton.UseVisualStyleBackColor = true;
            this.deleteBookingButton.Click += new System.EventHandler(this.deleteBookingButton_Click);
            // 
            // confirmChangesButton
            // 
            this.confirmChangesButton.Location = new System.Drawing.Point(916, 514);
            this.confirmChangesButton.Name = "confirmChangesButton";
            this.confirmChangesButton.Size = new System.Drawing.Size(126, 23);
            this.confirmChangesButton.TabIndex = 17;
            this.confirmChangesButton.Text = "Çonfirm Changes";
            this.confirmChangesButton.UseVisualStyleBackColor = true;
            this.confirmChangesButton.Click += new System.EventHandler(this.confirmChangesButton_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.makeABookingButton);
            this.panel1.Controls.Add(this.editGuestButton);
            this.panel1.Controls.Add(this.editBookingButton);
            this.panel1.Controls.Add(this.dashBoardButton);
            this.panel1.Controls.Add(this.welcomeLabel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 556);
            this.panel1.TabIndex = 19;
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
            // 
            // dashBoardButton
            // 
            this.dashBoardButton.Location = new System.Drawing.Point(13, 56);
            this.dashBoardButton.Name = "dashBoardButton";
            this.dashBoardButton.Size = new System.Drawing.Size(175, 52);
            this.dashBoardButton.TabIndex = 1;
            this.dashBoardButton.Text = "Dashboard";
            this.dashBoardButton.UseVisualStyleBackColor = true;
            this.dashBoardButton.Click += new System.EventHandler(this.dashBoardButton_Click);
            // 
            // showAllBookingsButton
            // 
            this.showAllBookingsButton.Location = new System.Drawing.Point(916, 292);
            this.showAllBookingsButton.Name = "showAllBookingsButton";
            this.showAllBookingsButton.Size = new System.Drawing.Size(126, 23);
            this.showAllBookingsButton.TabIndex = 20;
            this.showAllBookingsButton.Text = "Show All Bookings";
            this.showAllBookingsButton.UseVisualStyleBackColor = true;
            this.showAllBookingsButton.Click += new System.EventHandler(this.showAllBookingsButton_Click);
            // 
            // guestNameLabel
            // 
            this.guestNameLabel.AutoSize = true;
            this.guestNameLabel.Location = new System.Drawing.Point(241, 299);
            this.guestNameLabel.Name = "guestNameLabel";
            this.guestNameLabel.Size = new System.Drawing.Size(169, 16);
            this.guestNameLabel.TabIndex = 4;
            this.guestNameLabel.Text = "Enter a Reference Number:";
            // 
            // referenceNumberTextBox
            // 
            this.referenceNumberTextBox.Location = new System.Drawing.Point(416, 296);
            this.referenceNumberTextBox.Name = "referenceNumberTextBox";
            this.referenceNumberTextBox.Size = new System.Drawing.Size(64, 22);
            this.referenceNumberTextBox.TabIndex = 11;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(916, 371);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(126, 23);
            this.editButton.TabIndex = 21;
            this.editButton.Text = "Edit Booking";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // EditBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.showAllBookingsButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirmChangesButton);
            this.Controls.Add(this.deleteBookingButton);
            this.Controls.Add(this.specialRequestsTextBox);
            this.Controls.Add(this.numberOfChildrenTextBox);
            this.Controls.Add(this.numberOfAdultsTextBox);
            this.Controls.Add(this.referenceNumberTextBox);
            this.Controls.Add(this.specialRequestsLabel);
            this.Controls.Add(this.numberOfChildrenLabel);
            this.Controls.Add(this.numberOfAdultsLabel);
            this.Controls.Add(this.guestNameLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bookingsLabel);
            this.Name = "EditBookingForm";
            this.Text = "Phumla Kamnandi Hotels";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label bookingsLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label numberOfAdultsLabel;
        private System.Windows.Forms.Label numberOfChildrenLabel;
        private System.Windows.Forms.Label specialRequestsLabel;
        private System.Windows.Forms.TextBox numberOfAdultsTextBox;
        private System.Windows.Forms.TextBox numberOfChildrenTextBox;
        private System.Windows.Forms.TextBox specialRequestsTextBox;
        private System.Windows.Forms.Button deleteBookingButton;
        private System.Windows.Forms.Button confirmChangesButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button makeABookingButton;
        private System.Windows.Forms.Button editGuestButton;
        private System.Windows.Forms.Button editBookingButton;
        private System.Windows.Forms.Button dashBoardButton;
        private System.Windows.Forms.Button showAllBookingsButton;
        private System.Windows.Forms.Label guestNameLabel;
        private System.Windows.Forms.TextBox referenceNumberTextBox;
        private System.Windows.Forms.Button editButton;
    }
}