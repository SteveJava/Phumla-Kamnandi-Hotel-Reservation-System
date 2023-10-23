using INF2011S_Project.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class BookingHandler
    {
        // This is where the check availability will be. And other crud functions
        #region Data Members
        private BookingDB bookingDB;
        private Collection<Booking> bookings;
        public static int currentReferenceNumber;
        enum Seasonality { Low = 550, Mid = 750, High = 995 }
        private Seasonality season;
        #endregion
                
        #region Properties
        public Collection<Booking> AllBookings { get { return bookings; } }
        #endregion

        #region Constructor
        public BookingHandler()
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
        }
        #endregion

        #region Methods 
        public Collection<Room> FindAvailableRooms(DateTime CheckIn, DateTime CheckOut)
        {
            RoomHandler roomHandler = new RoomHandler();

            Collection<Room> roomlist = new Collection<Room>();
            foreach (Booking book in this.bookings)
            {
                bool isAvailable = (CheckIn <= book.CheckInDate && CheckOut >= book.CheckOutDate) || // Booking completely within the specific range
                                    (CheckIn >= book.CheckInDate && CheckOut <= book.CheckOutDate) || // Booking completely covers the specific range
                                    (CheckIn >= book.CheckInDate && CheckIn < book.CheckOutDate ||      // Partial overlap at the beggining
                                    (CheckOut > book.CheckInDate && CheckOut <= book.CheckOutDate)); // Partial overlap at the end
                if (isAvailable)
                {
                    int roomID = book.RoomNumber;
                    Room room = roomHandler.Find(roomID);
                    if (!roomlist.Contains(room))
                    {
                        roomlist.Add(room);
                    }
                }
            }

            Collection<Room> availablelist = roomHandler.AllRooms;
            foreach (Room room in roomlist)
            {
                if (availablelist.Contains(room))
                {
                    availablelist.Remove(room);
                }
                
            }
            return availablelist;
        }

        public Collection<Room> FindArrival(DateTime CheckIn)
        {
            RoomHandler roomHandler = new RoomHandler();

            Collection<Room> roomlist = new Collection<Room>();
            foreach (Booking book in this.bookings)
            {
                bool isAvailable = (book.CheckInDate == CheckIn);
                if (isAvailable)
                {
                    int roomID = book.RoomNumber;
                    Room room = roomHandler.Find(roomID);
                    if (!roomlist.Contains(room))
                    {
                        roomlist.Add(room);
                    }
                }
            }

            Collection<Room> availablelist = roomHandler.AllRooms;
            foreach (Room room in roomlist)
            {
                if (availablelist.Contains(room))
                {
                    availablelist.Remove(room);
                }

            }
            return availablelist;
        }

        public void CalculateSeasonality(DateTime CheckIn, DateTime CheckOut)
        {
            // Define the start and end dates for each season.
            DateTime lowSeasonStart = new DateTime(CheckIn.Year, 12, 1);
            DateTime lowSeasonEnd = new DateTime(CheckIn.Year, 12, 7);
            DateTime midSeasonStart = new DateTime(CheckIn.Year, 12, 8);
            DateTime midSeasonEnd = new DateTime(CheckIn.Year, 12, 16);
            DateTime highSeasonStart = new DateTime(CheckIn.Year, 12, 17);
            DateTime highSeasonEnd = new DateTime(CheckIn.Year, 12, 31);

            // Check if the stay falls within the specified date ranges.
            if (CheckIn >= lowSeasonStart && CheckOut <= lowSeasonEnd)
            {
                season = Seasonality.Low;
            }
            else if (CheckIn >= midSeasonStart && CheckOut <= midSeasonEnd)
            {
                season = Seasonality.Mid;
            }
            else if (CheckIn >= highSeasonStart && CheckOut <= highSeasonEnd)
            {
                season = Seasonality.High;
            }
            else { season = Seasonality.Low; }
         }

        public int CalculateCost(DateTime CheckIn, DateTime CheckOut)
        {
            TimeSpan duration = CheckOut - CheckIn;
            int daysOfStay = duration.Days;
            decimal cost = 0;
            CalculateSeasonality(CheckIn, CheckOut);
            switch (season)
            {
                case Seasonality.Low:
                    cost = daysOfStay * (int)season;
                    break;
                case Seasonality.Mid:
                    cost = daysOfStay * (int)season;
                    break;
                case Seasonality.High:
                    cost = daysOfStay * (int)season;
                    break;
                default:
                    cost = daysOfStay * 100; // Set a default cost when season is not specified.
                    break;
            }

            return (int)cost; // Assuming cost is an integer value.
        }


        public int generateReferenceNumber()
        {
            BookingDB bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
            return bookings.Count() + 1;
        }

        #endregion

        #region Database Communication.
        public Booking RecordBooking(Booking booking)
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;

            if (booking.ReferenceNumber == 0)
            {
                bookingDB.DataSetChange(booking, DB.DBOperation.Add);
                bookingDB.InsertBookingDataSource(booking);
            }
            else
            {
                bookingDB.DataSetChange(booking, DB.DBOperation.Update);
                bookingDB.UpdateBookingDataSource(booking);
            }
            bookingDB.RetrieveAllBookings();
            bookings = bookingDB.AllBookings;
            booking = bookings.First(x => x.ReferenceNumber == booking.ReferenceNumber);
            currentReferenceNumber = booking.ReferenceNumber;
            return booking;
        }

        public void DeleteBooking(Booking booking)
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;

            if (!(booking.ReferenceNumber == 0))
            {
                bookingDB.DataSetChange(booking, DB.DBOperation.Delete);
                bookingDB.DeleteBookingDataSource(booking);
            }

        }


        public void DataMaintenance(Booking aBooking, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            bookingDB.DataSetChange(aBooking, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    bookings.Add(aBooking);
                    break;
                case DB.DBOperation.Update:
                    index = FindIndex(aBooking);
                    bookings[index] = aBooking;  // replace booking at this index with the updated booking
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aBooking);  // find the index of the specific booking in collection
                    bookings.RemoveAt(index);  // remove that booking from the collection
                    break;

            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Booking booking)
        {
            //***call the BookingDB method that will commit the changes to the database
            return bookingDB.UpdateDataSource(booking);
        }
        #endregion

        #region Searching through a collection

        //This method receives a booking ref as a parameter; finds the booking object in the collection of bookings and then returns this object
        public Booking Find(int bookRef)
        {
            int index = 0;
            bool found = (bookings[index].ReferenceNumber == bookRef);

            while (!(found) && (index < bookings.Count - 1))
            {
                index = index + 1;
                found = (bookings[index].ReferenceNumber == bookRef);
            }
            return bookings[index];

         }

        public int FindIndex(Booking aBooking)
        {
            int counter = 0;
            bool found = false;
            found = (aBooking.ReferenceNumber == bookings[counter].ReferenceNumber);   //using a Boolean Expression to initialise found
            while (!(found) & counter < bookings.Count - 1)
            {
                counter += 1;
                found = (aBooking.ReferenceNumber == bookings[counter].ReferenceNumber);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}
