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
            dashBoardForm = new DashBoardForm();
            dashBoardForm.Show();
        }
    }
}
