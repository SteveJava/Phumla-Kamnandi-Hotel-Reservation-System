using INF2011S_Project.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Project.Data
{
    public class BookingDB : DB
    {
        #region Data Members
        private string table1 = "Booking";
        private string sqlLocal1 = "SELECT * FROM Booking";

        private Collection<Booking> bookings;
        #endregion

        #region Property Method: Collection
        public Collection<Booking> AllBookings { get { return bookings; } }

        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            RetrieveAllBookingsFromDB();
        }
        #endregion

        #region Utility Methods
        public void RetrieveAllBookings()
        {
            dsMain.Tables["Booking"].Clear();
            RetrieveAllBookingsFromDB();
        }

        public void RetrieveAllBookingsFromDB()
        {
            //fill data set
            bookings = new Collection<Booking>();

            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
        }
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        private void Add2Collection(string table)
        {
            DataRow myRow = null;
            Booking booking;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    booking = new Booking();
                    //Obtain each booking attribute from the specific field in the row in the table
                    booking.GuestID = Convert.ToInt32(myRow["GuestID"]);
                    booking.ReferenceNumber = Convert.ToInt32(myRow["ReferenceNumber"]);
                    booking.CheckInDate = Convert.ToDateTime(myRow["CheckInDate"]);
                    booking.CheckOutDate = Convert.ToDateTime(myRow["CheckOutDate"]);
                    booking.RoomNumber = Convert.ToInt32(myRow["RoomNumber"]);
                    booking.NumberOfAdults = Convert.ToInt32(myRow["NumberOfAdults"]);
                    object value = (myRow["NumberOfChildren"]);
                    if (value != DBNull.Value)
                    {
                        booking.NumberOfChildren = Convert.ToInt32(value);

                    }
                    booking.SpecialRequests = Convert.ToString(myRow["SpecialRequests"]);
                    //add booking to bookings collection
                    bookings.Add(booking);

                }
            }
        }



        private void FillRow(DataRow aRow, Booking aBooking, DB.DBOperation operation)
        {
            //Booking booking;

            if (operation == DB.DBOperation.Add)
            {
                aRow["ReferenceNumber"] = aBooking.ReferenceNumber;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["GuestID"] = aBooking.GuestID;
                aRow["NumberOfAdults"] = aBooking.NumberOfAdults;
                aRow["NumberOfChildren"] = aBooking.NumberOfChildren;
                aRow["SpecialRequests"] = aBooking.SpecialRequests;
                aRow["CheckInDate"] = aBooking.CheckInDate;
                aRow["CheckOutDate"] = aBooking.CheckOutDate;
                aRow["RoomNumber"] = aBooking.RoomNumber;
            }   
        }

        private int FindRow(Booking aBooking, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //check if booking id equal to what we are looking for
                    if (aBooking.ReferenceNumber == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["ReferenceNumber"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }

        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Booking aBooking, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aBooking, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aBooking, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aBooking, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aBooking, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Booking aBooking)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ReferenceNumber", SqlDbType.Int, 10, "ReferenceNumber");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomNumber", SqlDbType.Int, 10, "RoomNumber");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 10, "CheckInDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 10, "CheckOutDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@NumberOfAdults", SqlDbType.Int, 10, "NumberOfAdults");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@NumberOfChildren", SqlDbType.Int, 10, "NumberOfChildren");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@SpecialRequests", SqlDbType.NVarChar, 200, "SpecialRequests");
            daMain.InsertCommand.Parameters.Add(param);
        }


        private void Build_UPDATE_Parameters(Booking aBooking)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ReferenceNumber", SqlDbType.Int, 10, "ReferenceNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomNumber", SqlDbType.Int, 10, "RoomNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 10, "CheckInDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 10, "CheckOutDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@NumberOfAdults", SqlDbType.Int, 10, "NumberOfAdults");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@NumberOfChildren", SqlDbType.Int, 10, "NumberOfChildren");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@SpecialRequests", SqlDbType.NVarChar, 200, "SpecialRequests");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Parameters()
        {
            //Create Parameters to communicate with SQL DELETE
            SqlParameter param;

            param = new SqlParameter("@ReferenceNumber", SqlDbType.Int, 10, "ReferenceNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomNumber", SqlDbType.Int, 10, "RoomNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 10, "CheckInDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 10, "CheckOutDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@NumberOfAdults", SqlDbType.Int, 10, "NumberOfAdults");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@NumberOfChildren", SqlDbType.Int, 10, "NumberOfChildren");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@SpecialRequests", SqlDbType.NVarChar, 200, "SpecialRequests");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

        }

        private void Create_INSERT_Command(Booking aBooking)
        {
            //Command used to insert values into the Bookings table..

            daMain.InsertCommand = new SqlCommand("INSERT into Booking (ReferenceNumber, GuestID, RoomNumber, CheckInDate, CheckOutDate, NumberOfAdults, NumberOfChildren, SpecialRequests)" +
                " VALUES (@ReferenceNumber, @GuestID, @RoomNumber, @CheckInDate, @CheckOutDate, @NumberOfAdults, @NumberOfChildren, @SpecialRequests)", cnMain);
            Build_INSERT_Parameters(aBooking);
        }

        private void Create_UPDATE_Command(Booking aBooking)
        {
            //Command that must be used to insert values into bookings table
            //The GuestID and BookingReference cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE Booking SET ReferenceNumber =@ReferenceNumber, GuestID =@GuestID, RoomNumber =@RoomNumber, CheckInDate =@CheckInDate, " +
                "CheckOutDate =@CheckOutDate, NumberOfAdults =@NumberOfAdults, NumberOfChildren =@NumberOfChildren, SpecialRequests =@SpecialRequests " + "WHERE ReferenceNumber = @ReferenceNumber", cnMain);
            Build_UPDATE_Parameters(aBooking);
        }

        private string Create_DELETE_Command(Booking aBooking)
        {
            string errorString = null;
            //Command used to delete values from the Bookings table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Booking WHERE ReferenceNumber = @ReferenceNumber", cnMain);

            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }

        //update data source
        public bool UpdateDataSource(Booking aBooking)
        {
            bool success = true;
            Create_INSERT_Command(aBooking);
            Create_UPDATE_Command(aBooking);
            Create_DELETE_Command(aBooking);

            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool UpdateBookingDataSource(Booking booking)
        {
            bool success = true;
            Create_UPDATE_Command(booking);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool InsertBookingDataSource(Booking booking)
        {
            bool success = true;
            Create_INSERT_Command(booking);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool DeleteBookingDataSource(Booking booking)
        {
            bool success = true;
            Create_DELETE_Command(booking);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        #endregion
    }
}
