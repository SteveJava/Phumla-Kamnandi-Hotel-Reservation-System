using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF2011S_Project.Presentation;
using INF2011S_Project.Business;
using INF2011S_Project.Data;


namespace INF2011S_Project
{
    public partial class LogInForm : Form
    {
        DashBoardForm dashBoardForm;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            Receptionist receptionist = new Receptionist();
            ReceptionistHandler receptionistHandler = new ReceptionistHandler();
            if ((receptionistHandler.Find(Convert.ToInt32(employeeIDTextBox.Text)) != null) && (receptionistHandler.FindPassWord((passWordTextBox.Text)) != null))
            {
                dashBoardForm = new DashBoardForm();
                dashBoardForm.StartPosition = FormStartPosition.CenterScreen;
                dashBoardForm.Show();
            }
            else
            {
                MessageBox.Show($"Incorrect login details, please try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
