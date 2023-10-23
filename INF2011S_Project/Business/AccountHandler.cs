using INF2011S_Project.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class AccountHandler
    {
        #region Data Members
        private AccountDB accountDB;
        private Collection<Account> accounts;
        #endregion

        #region Properties
        public Collection<Account> AllAccounts
        {
            get
            {
                return accounts;
            }
        }
        #endregion

        #region Constructor
        public AccountHandler()
        {
              accountDB = new AccountDB();
              accounts = accountDB.AllAccounts;
        }

        #endregion

        #region Methods
        public int generateAccountID()
        {
            AccountDB accountDB = new AccountDB();
            accounts = accountDB.AllAccounts;
            return accounts.Count() + 1;
        }
        #endregion

        #region Database Communication.

        public Account RecordAccount(Account account)
        {
            accountDB = new AccountDB();
            accounts = accountDB.AllAccounts;

            if (account.AccountID == 0)
            {
                accountDB.DataSetChange(account, DB.DBOperation.Add);
                accountDB.InsertAccountDataSource(account);
            }
            else
            {
                accountDB.DataSetChange(account, DB.DBOperation.Update);
                accountDB.UpdateAccountDataSource(account);
            }
            accountDB.RetrieveAllAccounts();
            accounts = accountDB.AllAccounts;
            account = accounts.First(x => x.AccountID == account.AccountID);
            return account;
        }

        public void DeleteAccount(Account account)
        {
            accountDB = new AccountDB();
            accounts = accountDB.AllAccounts;

            if (!(account.AccountID == 0))
            {
                accountDB.DataSetChange(account, DB.DBOperation.Delete);
                accountDB.DeleteAccountDataSource(account);
            }

        }

        public void DataMaintenance(Account aAccount, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            accountDB.DataSetChange(aAccount, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    accounts.Add(aAccount);
                    break;
                case DB.DBOperation.Update:
                    index = FindIndex(aAccount);
                    accounts[index] = aAccount;  // replace account at this index with the updated account
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aAccount);  // find the index of the specific account in collection
                    accounts.RemoveAt(index);  // remove that account from the collection
                    break;

            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Account account)
        {
            //***call the BookingDB method that will commit the changes to the database
            return accountDB.UpdateDataSource(account);
        }
        #endregion

        #region Searching through a collection

        //This method receives a Account ID as a parameter; finds the booking object in the collection of accounts and then returns this object
        public Account Find(int aID)
        {
            AccountDB accountDB = new AccountDB();
            accounts = accountDB.AllAccounts;
            Account foundAccount = null;
            if (accounts.Any(x => x.AccountID == aID))
            {
                foundAccount = accounts.First(x => x.AccountID == aID);
            }
            return foundAccount;
        }

        public int FindIndex(Account aAccount)
        {
            int counter = 0;
            bool found = false;
            found = (aAccount.AccountID == accounts[counter].AccountID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < accounts.Count - 1)
            {
                counter += 1;
                found = (aAccount.AccountID == accounts[counter].AccountID);
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
