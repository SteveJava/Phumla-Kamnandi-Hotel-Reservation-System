namespace INF2011S_Project
{
    partial class LogInForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.logInButton = new System.Windows.Forms.Button();
            this.passWordTextBox = new System.Windows.Forms.TextBox();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.passWordLabel = new System.Windows.Forms.Label();
            this.employeeIDLabel = new System.Windows.Forms.Label();
            this.signInLabel = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.logInButton);
            this.panel4.Controls.Add(this.passWordTextBox);
            this.panel4.Controls.Add(this.employeeIDTextBox);
            this.panel4.Controls.Add(this.passWordLabel);
            this.panel4.Controls.Add(this.employeeIDLabel);
            this.panel4.Controls.Add(this.signInLabel);
            this.panel4.Location = new System.Drawing.Point(87, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(377, 385);
            this.panel4.TabIndex = 21;
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(263, 340);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(85, 29);
            this.logInButton.TabIndex = 5;
            this.logInButton.Text = "LogIn";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // passWordTextBox
            // 
            this.passWordTextBox.Location = new System.Drawing.Point(29, 257);
            this.passWordTextBox.Name = "passWordTextBox";
            this.passWordTextBox.PasswordChar = '*';
            this.passWordTextBox.Size = new System.Drawing.Size(316, 22);
            this.passWordTextBox.TabIndex = 4;
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.Location = new System.Drawing.Point(32, 127);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(316, 22);
            this.employeeIDTextBox.TabIndex = 3;
            // 
            // passWordLabel
            // 
            this.passWordLabel.AutoSize = true;
            this.passWordLabel.Location = new System.Drawing.Point(29, 229);
            this.passWordLabel.Name = "passWordLabel";
            this.passWordLabel.Size = new System.Drawing.Size(67, 16);
            this.passWordLabel.TabIndex = 2;
            this.passWordLabel.Text = "Password";
            // 
            // employeeIDLabel
            // 
            this.employeeIDLabel.AutoSize = true;
            this.employeeIDLabel.Location = new System.Drawing.Point(29, 98);
            this.employeeIDLabel.Name = "employeeIDLabel";
            this.employeeIDLabel.Size = new System.Drawing.Size(85, 16);
            this.employeeIDLabel.TabIndex = 1;
            this.employeeIDLabel.Text = "Employee ID";
            // 
            // signInLabel
            // 
            this.signInLabel.AutoSize = true;
            this.signInLabel.Location = new System.Drawing.Point(26, 22);
            this.signInLabel.Name = "signInLabel";
            this.signInLabel.Size = new System.Drawing.Size(47, 16);
            this.signInLabel.TabIndex = 0;
            this.signInLabel.Text = "Sign In";
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 525);
            this.Controls.Add(this.panel4);
            this.Name = "LogInForm";
            this.Text = "Phumla Kamnandi Hotels";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.TextBox passWordTextBox;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.Label passWordLabel;
        private System.Windows.Forms.Label employeeIDLabel;
        private System.Windows.Forms.Label signInLabel;
    }
}