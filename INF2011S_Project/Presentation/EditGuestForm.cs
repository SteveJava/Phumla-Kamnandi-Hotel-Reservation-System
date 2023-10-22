using INF2011S_Project.Business;
using INF2011S_Project.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Project.Presentation
{
    public partial class EditGuestForm : Form
    {
        #region Data Members
        private GuestDB guestDB;
        private Guest guest;
        private Collection<Guest> guests;
        private GuestHandler guestHandler;

        private DB.DBOperation operation;
        enum FormState { View = 0, Update = 1, Delete = 2 }
        private FormState state;

        #endregion

        #region Constructor
        public EditGuestForm()
        {
            InitializeComponent();
            state = FormState.View;
        }
        #endregion

        #region Utility Methods
        private void PopulateGuestDetails(Guest guest)
        {
            if (guest != null)
            {
                if (guest.GuestID == Convert.ToInt32(guestIDTextBox.Text))
                {
                    firstNameTextBox.Text = guest.FirstName.ToString();
                    surNameTextBox.Text = guest.SecondName.ToString();
                    cellPhoneTextBox.Text = guest.CellPhone.ToString();
                    emailTextBox.Text = guest.EmailAddress.ToString();
                    addressTextBox.Text = guest.HomeAddress.ToString();
                }
            }
            else { Console.WriteLine("Guest not found, re-enter GuestID"); }
        }

        public void PopulateObject(Guest guest)
        {
            guest.FirstName = firstNameTextBox.Text;
            guest.SecondName = surNameTextBox.Text;
            guest.CellPhone = cellPhoneTextBox.Text;
            guest.EmailAddress = emailTextBox.Text;
            guest.HomeAddress = addressTextBox.Text;
        }
        #endregion

        private void showAllButton_Click(object sender, EventArgs e)
        {
            guestDB = new GuestDB();
            guestDB.RetrieveAllGuestsFromDB();
            dataGridView1.DataSource = guestDB.GetDataSet();
            dataGridView1.DataMember = "Guest";
        }

        private void updateGuestButton_Click_1(object sender, EventArgs e)
        {
            state = FormState.Update;
            guestHandler = new GuestHandler();
            guest = guestHandler.Find(Convert.ToInt32(guestIDTextBox.Text));
            Console.WriteLine("If you click confirm, the information in the TextBoxes will be used");
            PopulateGuestDetails(guest);            
        }

        private void deleteGuestButton_Click_1(object sender, EventArgs e)
        {
            state = FormState.Delete;
            guestHandler = new GuestHandler();
            guest = guestHandler.Find(Convert.ToInt32(guestIDTextBox.Text));
            PopulateGuestDetails(guest);
        }

        private void confirmChangesButton_Click_1(object sender, EventArgs e)
        {

            if (state == FormState.Update)
            {
                PopulateObject(guest);
                guestHandler.DataMaintenance(guest, DB.DBOperation.Update);
            }
            else
            {
                guestHandler.DataMaintenance(guest, DB.DBOperation.Delete);
            }
            guestHandler.FinalizeChanges(guest);
            state = FormState.View;
        }
    }
}
