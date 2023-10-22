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

namespace INF2011S_Project.Presentation
{
    public partial class DashBoardForm : Form
    {
        EditBookingForm editBookingForm;
        EditGuestForm editGuestForm;
        NewBookingForm newBookingForm;
        GuestHandler guestHandler;
        public DashBoardForm()
        {
            InitializeComponent();
            guestHandler = new GuestHandler();
        }

        private void makeABookingButton_Click(object sender, EventArgs e)
        {
            newBookingForm = new NewBookingForm();
            newBookingForm.Show();
        }

        private void editBookingButton_Click(object sender, EventArgs e)
        {
            editBookingForm = new EditBookingForm();
            editBookingForm.Show();
        }

        private void editGuestButton_Click(object sender, EventArgs e)
        {
            editGuestForm = new EditGuestForm();
            editGuestForm.Show();
        }
    }
}
