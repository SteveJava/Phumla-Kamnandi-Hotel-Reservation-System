using INF2011S_Project.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Data
{
    public class ReceptionistDB : DB
    {
        #region Data Members
        private string table1 = "Receptionist";
        private string sqlLocal1 = "SELECT * FROM Receptionist";
        private Collection<Receptionist> receptionists;
        #endregion

        #region Property Method: Collection
        public Collection<Receptionist> AllReceptionists { get { return receptionists; } }
        #endregion

        #region Constructor
        public ReceptionistDB() : base()
        {
            RetrieveAllReceptionistsFromDB();
        }
        #endregion

        #region Utility Methods
        public void RetrieveAllReceptionists()
        {
            dsMain.Tables["Receptionist"].Clear();
            RetrieveAllReceptionistsFromDB();
        }

        public void RetrieveAllReceptionistsFromDB()
        {
            //fill data set
            receptionists = new Collection<Receptionist>();

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
            Receptionist receptionist;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    receptionist = new Receptionist();

                    //Obtain each guest attribute from the specific field in the row in the table
                    receptionist.EmpID = Convert.ToInt32(myRow["EmpID"]);
                    receptionist.Password = Convert.ToString(myRow["Password"]);
                    //add booking to bookings collection
                    receptionists.Add(receptionist);

                }
            }
        }

        private void FillRow(DataRow aRow, Receptionist aReceptionist, DB.DBOperation operation)
        {

            if (operation == DB.DBOperation.Add)
            {
                aRow["EmpID"] = aReceptionist.EmpID;  //NOTE square brackets to indicate index of collections of fields in row.
            }
            aRow["Password"] = aReceptionist.Password;
        }

        private int FindRow(Receptionist aReceptionist, string table)
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
                    ///check if receptionist id equal to what we are looking for
                    if (aReceptionist.EmpID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["EmpID"]))
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
        public void DataSetChange(Receptionist aReceptionist, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aReceptionist, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aReceptionist, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aReceptionist, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aReceptionist, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Receptionist aReceptionist)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@EmpID", SqlDbType.Int, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Password", SqlDbType.NVarChar, 40, "Password");
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Select_Receptionist_Command(int receptionistId)
        {
            //---Create Parameters to communicate with SQL Select
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@EmpID", SqlDbType.Int, 10, "EmpID");
            daMain.SelectCommand.Parameters.Add(param);
        }

        private void Build_UPDATE_Parameters(Receptionist aReceptionist)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@Password", SqlDbType.NVarChar, 40, "Password");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the booking reference of record that needs to change with the original guestID of the record
            param = new SqlParameter("@EmpID", SqlDbType.Int, 15, "EmpID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Build_DELETE_Parameters()
        {
            //Create Parameters to communicate with SQL DELETE
            SqlParameter param;

            param = new SqlParameter("@EmpID", SqlDbType.Int, 15, "EmpID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@Password", SqlDbType.NVarChar, 50, "Password");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

        }

        private void Create_INSERT_Command(Receptionist aReceptionist)
        {
            //Command used to insert values into the Receptionist table..

            daMain.InsertCommand = new SqlCommand("INSERT into Receptionist (EmpID, Password) VALUES (@EmpID, @Password)", cnMain);
            Build_INSERT_Parameters(aReceptionist);
        }

        private void Create_UPDATE_Command(Receptionist aReceptionist)
        {
            //Command that must be used to insert values into receptionist table

            daMain.UpdateCommand = new SqlCommand("UPDATE Receptionist SET EmpID = @EmpID, Password = @Password " + "WHERE EmpID = @EmpID", cnMain);
            Build_UPDATE_Parameters(aReceptionist);
        }

        private string Create_DELETE_Command(Receptionist aReceptionist)
        {
            string errorString = null;
            //Command used to delete values from the Receptionist table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Receptionist WHERE EmpID = @EmpID", cnMain);

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
        public bool UpdateDataSource(Receptionist aReceptionist)
        {
            bool success = true;
            Create_INSERT_Command(aReceptionist);
            Create_UPDATE_Command(aReceptionist);
            Create_DELETE_Command(aReceptionist);

            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool UpdateReceptionistDataSource(Receptionist aReceptionist)
        {
            bool success = true;
            Create_UPDATE_Command(aReceptionist);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool InsertReceptionistDataSource(Receptionist aReceptionist)
        {
            bool success = true;
            Create_INSERT_Command(aReceptionist);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool DeleteReceptionistDataSource(Receptionist receptionist)
        {
            bool success = true;
            Create_DELETE_Command(receptionist);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        #endregion
    }
}
