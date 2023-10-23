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
using System.Collections.ObjectModel;

namespace INF2011S_Project.Presentation
{
    public partial class DashBoardForm : Form
    {
        EditBookingForm editBookingForm;
        EditGuestForm editGuestForm;
        NewBookingForm newBookingForm;
        GuestHandler guestHandler;
        Booking booking;

        public Booking PopulateBookingObject(Booking booking)
        {
            booking.CheckInDate = dateTimePicker1.Value;
            return booking;
        }

        public DashBoardForm()
        {
            InitializeComponent();
            guestHandler = new GuestHandler();
        }

        private void makeABookingButton_Click(object sender, EventArgs e)
        {
            newBookingForm = new NewBookingForm();
            newBookingForm.StartPosition = FormStartPosition.CenterScreen;
            newBookingForm.Show();
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            BookingHandler bookingHandler = new BookingHandler();
            DateTime checkIn = dateTimePicker1.Value;

            Collection<Room> availableRooms = bookingHandler.FindAvailableRooms(checkIn, checkIn);

            if (availableRooms.Count > 0)
            {
                // Display available room numbers or other information to the user.
                foreach (Room room in availableRooms)
                {
                    MessageBox.Show($"Available Room Number: {room.RoomNumber}", "Arrivals", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Inform the user that no rooms are available for the selected dates.
                MessageBox.Show("No rooms available for the selected dates.", "Occupany Level", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void DashBoardForm_Load(object sender, EventArgs e)
        {
            BookingDB bookingDB = new BookingDB();
            bookingDB.RetrieveAllBookingsFromDB();
            dataGridView1.DataSource = bookingDB.GetDataSet();
            dataGridView1.DataMember = "Booking";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookingHandler bookingHandler = new BookingHandler();
            DateTime checkIn = dateTimePicker2.Value;
            DateTime checkOut = dateTimePicker3.Value;

            Collection<Room> availableRooms = bookingHandler.FindAvailableRooms(checkIn, checkOut);

            if (availableRooms.Count > 0)
            {
                // Display available room numbers or other information to the user.
             
                    MessageBox.Show($"Occupancy level from the {checkIn} to the {checkOut}: {5 - availableRooms.Count} rooms are taken", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                // Inform the user that no rooms are available for the selected dates.
                MessageBox.Show("No rooms available for the selected dates.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
