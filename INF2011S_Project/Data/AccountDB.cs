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
    public class AccountDB : DB
    {
        #region Data Members
        private string table1 = "Account";
        private string sqlLocal1 = "SELECT * FROM Account";
        private Collection<Account> accounts;
        #endregion

        #region Property Method: Collection
        public Collection<Account> AllAccounts { get { return accounts; } }
        #endregion

        #region Constructor
        public AccountDB() : base()
        {
            RetrieveAllAccountsFromDB();
        }
        #endregion

        #region Utility Methods
        public void RetrieveAllAccounts()
        {
            dsMain.Tables["Account"].Clear();
            RetrieveAllAccountsFromDB();
        }

        public void RetrieveAllAccountsFromDB()
        {
            //fill data set
            accounts = new Collection<Account>();

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
            Account account;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    account = new Account();

                    //Obtain each guest attribute from the specific field in the row in the table
                    account.AccountID = Convert.ToInt32(myRow["AccountID"]);
                    account.GuestID = Convert.ToInt32(myRow["GuestID"]);
                    account.CCNo = Convert.ToString(myRow["CCNo"]);
                    account.CCDate = Convert.ToString(myRow["CCDate"]);
                    account.Balance = Convert.ToDouble(myRow["Balance"]);
                    //add booking to bookings collection
                    accounts.Add(account);

                }
            }
        }

        private void FillRow(DataRow aRow, Account aAccount, DB.DBOperation operation)
        {

            if (operation == DB.DBOperation.Add)
            {
                aRow["AccountID"] = aAccount.AccountID;  //NOTE square brackets to indicate index of collections of fields in row.
            }

            aRow["GuestID"] = aAccount.GuestID;
            aRow["CCNo"] = aAccount.CCNo;
            aRow["CCDate"] = aAccount.CCDate;
            aRow["Balance"] = aAccount.Balance;
        }

        private int FindRow(Account aAccount, string table)
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
                    ///check if account id equal to what we are looking for
                    if (aAccount.AccountID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["AccountID"]))
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
        public void DataSetChange(Account aAccount, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aAccount, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aAccount, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aAccount, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aAccount, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Account aAccount)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@AccountID", SqlDbType.Int, 10, "AccountID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CCNo", SqlDbType.NVarChar, 16, "CCNO");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CCDate", SqlDbType.NVarChar, 50, "CCDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Balance", SqlDbType.BigInt, 20, "Balance");
            daMain.InsertCommand.Parameters.Add(param);
        }

        private void Select_Account_Command(int accountId)
        {
            //---Create Parameters to communicate with SQL Select
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@AccountID", SqlDbType.Int, 10, "AccountID");
            daMain.SelectCommand.Parameters.Add(param);
        }

        private void Build_UPDATE_Parameters(Account aAccount)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CCNo", SqlDbType.NVarChar, 16, "CCNo");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CCDate", SqlDbType.NVarChar, 50, "CCDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Balance", SqlDbType.BigInt, 20, "Balance");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the booking reference of record that needs to change with the original guestID of the record
            param = new SqlParameter("@AccountID", SqlDbType.Int, 15, "AccountID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Build_DELETE_Parameters()
        {
            //Create Parameters to communicate with SQL DELETE
            SqlParameter param;

            param = new SqlParameter("@AccountID", SqlDbType.Int, 15, "AccountID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@CCNo", SqlDbType.NVarChar, 16, "CCNo");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@CCDate", SqlDbType.NVarChar, 50, "CCDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@Balance", SqlDbType.BigInt, 20, "Balance");
            param.SourceVersion = DataRowVersion.Current;
            daMain.DeleteCommand.Parameters.Add(param);

        }

        private void Create_INSERT_Command(Account aAccount)
        {
            //Command used to insert values into the Account table..

            daMain.InsertCommand = new SqlCommand("INSERT into Account (AccountID, GuestID, CCNo, CCDate, Balance) VALUES (@AccountID, @GuestID, @CCNo, @CCDate, @Balance)", cnMain);
            Build_INSERT_Parameters(aAccount);
        }

        private void Create_UPDATE_Command(Account aAccount)
        {
            //Command that must be used to insert values into account table

            daMain.UpdateCommand = new SqlCommand("UPDATE Account SET AccountID = @AccountID, GuestID = @GuestID, CCNo = @CCNo, CCDate = @CCDate, Balance = @Balance " + "WHERE AccountID = @AccountID", cnMain);
            Build_UPDATE_Parameters(aAccount);
        }

        private string Create_DELETE_Command(Account aAccount)
        {
            string errorString = null;
            //Command used to delete values from the Account table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Account WHERE AccountID = @AccountID", cnMain);

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
        public bool UpdateDataSource(Account aAccount)
        {
            bool success = true;
            Create_INSERT_Command(aAccount);
            Create_UPDATE_Command(aAccount);
            Create_DELETE_Command(aAccount);

            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool UpdateAccountDataSource(Account aAccount)
        {
            bool success = true;
            Create_UPDATE_Command(aAccount);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool InsertAccountDataSource(Account aAccount)
        {
            bool success = true;
            Create_INSERT_Command(aAccount);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool DeleteAccountDataSource(Account account)
        {
            bool success = true;
            Create_DELETE_Command(account);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        #endregion
    }
}
