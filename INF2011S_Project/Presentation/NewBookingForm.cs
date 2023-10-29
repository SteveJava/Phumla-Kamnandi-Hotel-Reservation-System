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
using System.Diagnostics.Eventing.Reader;

namespace INF2011S_Project.Presentation
{
    public partial class NewBookingForm : Form
    {
        #region Data Members
        public bool existing = false;
        private EditBookingForm editBookingForm;
        private EditGuestForm editGuestForm;
        private DashBoardForm dashBoardForm;

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

        public Booking PopulateBookingObject()
        {
            Booking booking = new Booking
            {
                ReferenceNumber = bookingHandler.generateReferenceNumber()
            };
            MessageBox.Show($"ReferenceNumber: {booking.ReferenceNumber}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            booking.GuestID = guest.GuestID;
            booking.NumberOfAdults = Convert.ToInt32(numberOfAdultsTextBox.Text);
            booking.NumberOfAdults = Convert.ToInt32(numberOfChildrenTextBox.Text);
            booking.SpecialRequests = specialRequestsTextBox.Text;
            booking.CheckInDate = checkInDateTimePicker.Value;
            booking.CheckOutDate = checkOutDateTimePicker.Value;
            booking.RoomNumber = availableRoom;
            return booking;
        }

        public Account PopulateAccountObject()
        {
                DateTime checkIn = checkInDateTimePicker.Value;
                DateTime checkOut = checkOutDateTimePicker.Value;
                account = new Account();
                accountHandler = new AccountHandler();
                account.AccountID = accountHandler.generateAccountID();
                account.GuestID = guest.GuestID;
                account.CCDate = expiryDateTextBox.Text;
                account.CCNo = CCNoTextBox.Text;
                account.Balance = bookingHandler.CalculateCost(checkIn, checkOut);
                return account;

        }
        #endregion

        private void newConfirmButton_Click(object sender, EventArgs e)
        {
            existing = true;
            guestHandler = new GuestHandler();
            PopulateGuestObject();
            guestHandler.DataMaintenance(guest, operation);
            guestHandler.FinalizeChanges(guest);
        }

        private void oldConfirmButton_Click(object sender, EventArgs e)
        {
            existing = true;
            guestHandler = new GuestHandler();
            this.guest = guestHandler.FindName(existingGuestFirstNameTextBox.Text, existingGuestSecondNameTextBox.Text);
            guest.GuestID = guestHandler.generateID();
            guestHandler.DataMaintenance(guest, operation);
            guestHandler.FinalizeChanges(guest);
            AccountHandler accountHandler = new AccountHandler();
            
          
        }

        private void confirmBookingButton_Click(object sender, EventArgs e)
        {
            AccountHandler accountHandler = new AccountHandler();
            if (existing == false)
            {
                account = PopulateAccountObject();
                accountHandler.DataMaintenance(account, operation);
                accountHandler.FinalizeChanges(account);
                booking = PopulateBookingObject();
                bookingHandler.DataMaintenance(booking, operation);
                bookingHandler.FinalizeChanges(booking);
                MessageBox.Show($"AccountID number: {account.AccountID} \nAccount CCNo: {account.CCNo} \nAccount CCDate: {account.CCDate} \nBalance: {account.Balance}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
               
                account = accountHandler.Find(1);
                account.Balance = bookingHandler.CalculateCost(checkInDateTimePicker.Value, checkOutDateTimePicker.Value);
                booking = PopulateBookingObject();
                bookingHandler.DataMaintenance(booking, operation);
                bookingHandler.FinalizeChanges(booking);
                MessageBox.Show($"AccountID number: {account.AccountID} \nAccount CCNo: {account.CCNo} \nAccount CCDate: {account.CCDate} \nBalance: {account.Balance}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void checkAvailabilityButton_Click(object sender, EventArgs e)
        {
            if (existing == false) { MessageBox.Show($"Please click confirm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
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

        private void button1_Click(object sender, EventArgs e)
        {
            existing = false;
            panel3.Visible = false;
            panel2.Visible = true;
            label14.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            existing = true;
            panel2.Visible = false;
            panel3.Visible = true;
            label14.Visible = false;
        }

        private void editBookingButton_Click(object sender, EventArgs e)
        {
            editBookingForm = new EditBookingForm();
            editBookingForm.StartPosition = FormStartPosition.CenterScreen;
            editBookingForm.Show();
            this.Close();
        }

        private void editGuestButton_Click(object sender, EventArgs e)
        {
            editGuestForm = new EditGuestForm();
            editGuestForm.StartPosition = FormStartPosition.CenterScreen;
            editGuestForm.Show();
            this.Close();
        }

        private void dashBoardButton_Click(object sender, EventArgs e)
        {
            dashBoardForm = new DashBoardForm();
            dashBoardForm.StartPosition = FormStartPosition.CenterScreen;
            dashBoardForm.Show();
            this.Close();
        }

        private void NewBookingForm_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            label14.Visible = true;
        }
    }
}
