using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using INF2011S_Project.Business;
using System.Data;
using System.Data.SqlClient;

namespace INF2011S_Project.Data
{
    public class GuestDB : DB
    {
        #region Data Members
        private string table1 = "Guest";
        private string sqlLocal1 = "SELECT * FROM Guest";
        private Collection<Guest> guests;
        #endregion

        #region Property Method: Collection
        public Collection<Guest> AllGuests { get { return guests; } }
        #endregion

        #region Constructor
        public GuestDB() : base()
        {
            RetrieveAllGuestsFromDB();
        }
        #endregion

        #region Utility Methods
        public void RetrieveAllGuests()
        {
            dsMain.Tables["Guests"].Clear();
            RetrieveAllGuestsFromDB();
        }

        public void RetrieveAllGuestsFromDB()
        {
            //fill data set
            guests = new Collection<Guest>();

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
            Guest guest;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    guest = new Guest();

                    //Obtain each guest attribute from the specific field in the row in the table
                    guest.GuestID = Convert.ToInt32(myRow["GuestID"]);
                    guest.FirstName = Convert.ToString(myRow["FirstName"]);
                    guest.SecondName = Convert.ToString(myRow["Surname"]);
                    guest.CellPhone = Convert.ToString(myRow["Phone"]);
                    guest.HomeAddress = Convert.ToString(myRow["Address"]);
                    guest.EmailAddress = Convert.ToString(myRow["Email"]);
                    //add booking to bookings collection
                    guests.Add(guest);

                }
            }
        }

        private void FillRow(DataRow aRow, Guest aGuest, DB.DBOperation operation)
        {

            if (operation == DB.DBOperation.Add)
            {
                aRow["GuestID"] = aGuest.GuestID;  //NOTE square brackets to indicate index of collections of fields in row.
            }

            aRow["FirstName"] = aGuest.FirstName;
            aRow["Surname"] = aGuest.SecondName;
            aRow["Phone"] = aGuest.CellPhone;
            aRow["Address"] = aGuest.HomeAddress;
            aRow["Email"] = aGuest.EmailAddress;

        }

        private int FindRow(Guest aGuest, string table)
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
                    ///check if guest id equal to what we are looking for
                    if (aGuest.GuestID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["GuestID"]))
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
        public void DataSetChange(Guest aGuest, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aGuest, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aGuest, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Guest aGuest)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 40, "FirstName");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@SecondName", SqlDbType.NVarChar, 60, "SecondName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 70, "EmailAddress");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CellPhone", SqlDbType.NVarChar, 15, "CellPhone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Address", SqlDbType.NVarChar, 100, "Address");
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Select_Guest_Command(int guestId)
        {
            //---Create Parameters to communicate with SQL Select
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            daMain.SelectCommand.Parameters.Add(param);
        }

        private void Build_UPDATE_Parameters(Guest aGuest)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 40, "FirstName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@SecondName", SqlDbType.NVarChar, 60, "Second");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //create and add update PHONE parameter
            param = new SqlParameter("@CellPhone", SqlDbType.NVarChar, 15, "CellPhone");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //create and add update EMAIL parameter
            param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 70, "EmailAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //create and add update address paramete
            param = new SqlParameter("@HomeAddress", SqlDbType.NVarChar, 100, "HomeAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the booking reference of record that needs to change with the original guestID of the record
            param = new SqlParameter("@GuestID", SqlDbType.Int, 15, "GuestID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Build_DELETE_Parameters()
        {
            //Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@GuestID", SqlDbType.Int, 15, "GuestID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Remove(param);

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 40, "FirstName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@SecondName", SqlDbType.NVarChar, 60, "Second");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            //create and add update PHONE parameter
            param = new SqlParameter("@CellPhone", SqlDbType.NVarChar, 15, "CellPhone");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            //create and add update EMAIL parameter
            param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 70, "EmailAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            //create and add update address paramete
            param = new SqlParameter("@HomeAddress", SqlDbType.NVarChar, 100, "HomeAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

        }

        private void Create_INSERT_Command(Guest aGuest)
        {
            //Command used to insert values into the Bookings table..

            daMain.InsertCommand = new SqlCommand("INSERT into Guest (FirstName, FirstName, HomeAddress, EmailAddress, CellPhonePhone) VALUES (@FirstName, @SecondName, @HomeAddress, @EmailAddress, @CellPhone)", cnMain);
            Build_INSERT_Parameters(aGuest);
        }

        private void Create_UPDATE_Command(Guest aGuest)
        {
            //Command that must be used to insert values into bookings table
            //The GuestID and BookingReference cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE Guest SET FirstName = @FirstName, SecondName = @SecondName, HomeAddress =@HomeAddress, EmailAddress = @EmailAddress, CellPhone =@CellPhone " + "WHERE GuestID = @GuestID", cnMain);
            Build_UPDATE_Parameters(aGuest);
        }

        private string Create_DELETE_Command(Guest aGuest)
        {
            string errorString = null;
            //Command used to delete values from the Guest table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Guest WHERE GuestID = @GuestID", cnMain);

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
        public bool UpdateDataSource(Guest aGuest)
        {
            bool success = true;
            Create_INSERT_Command(aGuest);
            Create_UPDATE_Command(aGuest);
            Create_DELETE_Command(aGuest);

            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool UpdateGuestDataSource(Guest aGuest)
        {
            bool success = true;
            Create_UPDATE_Command(aGuest);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool InsertGuestDataSource(Guest aGuest)
        {
            bool success = true;
            Create_INSERT_Command(aGuest);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        #endregion
    }
}
