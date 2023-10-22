using INF2011S_Project.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF2011S_Project.Business;
using INF2011S_Project.Data;
using INF2011S_Project.Presentation;
using System.Collections.ObjectModel;

namespace INF2011S_Project.Presentation
{
    public partial class NewBookingForm : Form
    {
        #region Data Members
        private Guest guest;
        private Collection<Guest> guests;
        private GuestHandler guestHandler;

        private Booking booking;
        private Collection<Booking> bookings;
        private BookingHandler bookingHandler;

        private Account account;
        private AccountHandler accountHandler;
        private Collection<Account> accounts;

        private DB.DBOperation operation;
        enum FormState { Add = 0, Update = 1 }
        private FormState state;
        private bool available = false;

        public DateTime checkIn = new DateTime();
        public DateTime checkOut = new DateTime();
        public int availableRoom;

        #endregion

        #region Constructor
        public NewBookingForm()
        {
            InitializeComponent();
          
        }
        #endregion

        #region Utility Methods
        public void PopulateGuestObject()
        {
            guest = new Guest();
            guest.GuestID = guestHandler.generateID();
            guest.FirstName = firstNameTextBox.Text;
            guest.SecondName = surNameTextBox.Text;
            guest.CellPhone = cellPhoneTextBox.Text;
            guest.EmailAddress = emailTextBox.Text;
            guest.HomeAddress = addressTextBox.Text;
           
        }

        public void PopulateBookingObject()
        {
            Booking booking = new Booking();
            booking.ReferenceNumber = bookingHandler.generateReferenceNumber();
            MessageBox.Show($"ReferenceNumber: {booking.ReferenceNumber}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            booking.GuestID = guest.GuestID;
            booking.NumberOfAdults = Convert.ToInt32(numberOfAdultsTextBox.Text);
            booking.NumberOfAdults = Convert.ToInt32(numberOfChildrenTextBox.Text);
            booking.SpecialRequests = specialRequestsTextBox.Text;
            booking.CheckInDate = checkInDateTimePicker.Value;
            booking.CheckOutDate = checkOutDateTimePicker.Value;
            booking.RoomNumber = availableRoom;

        }

        public void PopulateAccountObject()
        {
            account = new Account();
            account.AccountID = accountHandler.generateID();
            account.GuestID = guest.GuestID;
            account.CCDate = CCNoTextBox.Text;
            account.CCNo = CCNoTextBox.Text;
            account.Balance = bookingHandler.CalculateCost(checkIn, checkOut);
        }
        #endregion

        private void newConfirmButton_Click(object sender, EventArgs e)
        {
            guestHandler = new GuestHandler();
            PopulateGuestObject();
            guestHandler.DataMaintenance(guest, operation);
            guestHandler.FinalizeChanges(guest);
        }

        private void oldConfirmButton_Click(object sender, EventArgs e)
        {
            guestHandler = new GuestHandler();
            guest = guestHandler.FindName(existingGuestFirstNameTextBox.Text, existingGuestSecondNameTextBox.Text);
            guest.GuestID = guestHandler.generateID();
            guestHandler.DataMaintenance(guest, operation);
            guestHandler.FinalizeChanges(guest);
        }

        private void confirmBookingButton_Click(object sender, EventArgs e)
        {
            AccountHandler accountHandler = new AccountHandler();  
            PopulateAccountObject();
            accountHandler.DataMaintenance(account, operation);
            accountHandler.FinalizeChanges(account);

            bookingHandler = new BookingHandler();
            PopulateBookingObject();
            bookingHandler.DataMaintenance(booking, operation);
            bookingHandler.FinalizeChanges(booking);
        }

        private void checkAvailabilityButton_Click(object sender, EventArgs e)
        {
            bookingHandler = new BookingHandler();
            checkIn = checkInDateTimePicker.Value;
            checkOut = checkOutDateTimePicker.Value;

            Collection<Room> availableRooms = bookingHandler.FindAvailableRooms(checkIn, checkOut);
            availableRoom = availableRooms.FirstOrDefault().RoomNumber;

            if (availableRooms.Count > 0)
            {
                // Display available room numbers or other information to the user.
                foreach (Room room in availableRooms)
                {
                    MessageBox.Show($"Available Room Number: {room.RoomNumber}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Enable controls for the user to make a booking.
                numberOfAdultsTextBox.Enabled = true;
                numberOfChildrenTextBox.Enabled = true;
                confirmBookingButton.Enabled = true;
            }
            else
            {
                // Inform the user that no rooms are available for the selected dates.
                MessageBox.Show("No rooms available for the selected dates.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numberOfAdultsTextBox.Enabled = false;
                numberOfChildrenTextBox.Enabled = false;
                confirmBookingButton.Enabled = false;
            }
        }
    }
}
