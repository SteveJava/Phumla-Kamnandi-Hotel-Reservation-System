using INF2011S_Project.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        // NEED TO COMPELTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Room FindAvailableRoom(DateTime CheckIn, DateTime CheckOut)
        {
            return null;
        }

        public int CalculateCost(DateTime CheckIn, DateTime CheckOut)
        {
            return 0;
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

            BookingDB bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
            Booking foundBooking = null;
            if (bookings.Any(x => x.ReferenceNumber == bookRef))
            {
                foundBooking = bookings.First(x => x.ReferenceNumber == bookRef);
                currentReferenceNumber = foundBooking.ReferenceNumber;
            }
            return foundBooking;
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
