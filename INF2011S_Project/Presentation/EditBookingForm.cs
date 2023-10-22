using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using INF2011S_Project.Properties;
using INF2011S_Project.Data;
using INF2011S_Project.Business;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;

namespace INF2011S_Project.Presentation
{
    public partial class EditBookingForm : Form
    {
        #region Data Members
        private BookingDB bookingDB;
        private Booking booking;
        private Collection<Booking> bookings;
        private BookingHandler bookingHandler;

        private DB.DBOperation operation;
        enum FormState { View = 0, Update = 1, Delete = 2}
        private FormState state;

        #endregion

        #region Constructor
        public EditBookingForm()
        {
            InitializeComponent();
            state = FormState.View;
        }
        #endregion

        #region Utility Methods
        private void PopulateBookingDetails(Booking booking)
        {
            if (booking != null)
            {
                if (booking.ReferenceNumber == Convert.ToInt32(referenceNumberTextBox.Text))
                {
                    numberOfAdultsTextBox.Text = booking.NumberOfAdults.ToString();
                    numberOfChildrenTextBox.Text = booking.NumberOfChildren.ToString();
                    specialRequestsTextBox.Text = booking.SpecialRequests.ToString();
                }
            }
            else { Console.WriteLine("Booking not found, re-enter ReferenceNumber"); }
        }

        public void PopulateObject(Booking booking)
        {
            booking.NumberOfAdults = Convert.ToInt32(numberOfAdultsTextBox.Text);
            booking.NumberOfChildren = Convert.ToInt32(numberOfChildrenTextBox.Text);
            booking.SpecialRequests = specialRequestsTextBox.Text;
        }
        #endregion
        private void showAllBookingsButton_Click(object sender, EventArgs e)
        {
            bookingDB = new BookingDB();
            bookingDB.RetrieveAllBookingsFromDB();
            dataGridView1.DataSource = bookingDB.GetDataSet();
            dataGridView1.DataMember = "Booking";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            state = FormState.Update;
            bookingHandler = new BookingHandler();
            booking = bookingHandler.Find(Convert.ToInt32(referenceNumberTextBox.Text));
            PopulateBookingDetails (booking);
            
            Console.WriteLine("If you click confirm, the information in the TextBoxes will be used");
        }

        private void deleteBookingButton_Click(object sender, EventArgs e)
        {
            state = FormState.Delete;
            bookingHandler = new BookingHandler();
            booking = bookingHandler.Find(Convert.ToInt32(referenceNumberTextBox.Text));
            PopulateBookingDetails(booking);
        }

        private void confirmChangesButton_Click(object sender, EventArgs e)
        {
            

            if (state == FormState.Update)
            {
                PopulateObject(booking);
                bookingHandler.DataMaintenance(booking, DB.DBOperation.Update);
            }
            else
            {
                bookingHandler.DataMaintenance(booking, DB.DBOperation.Delete);
            }
            bookingHandler.FinalizeChanges(booking);
            state = FormState.View;
        }
    }
}
