using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class Account
    {
        #region Data Members
        private int accountID, guestID;
        private string ccNo, ccDate;
        private double balance = 0;
        #endregion

        #region Properties
        public int AccountID { get { return accountID; } set { accountID = value; } }
        public int GuestID { get { return guestID; } set { guestID = value; } }
        public string CCNo { get { return ccNo; } set {  ccNo = value; } }
        public string CCDate { get { return ccDate; } set { ccDate = value; } }
        public double Balance { get { return balance; } set {  balance = value; } }
        #endregion

        #region Constructors
        public Account()
        {
            accountID = 0;
            guestID = 0;
            ccNo = string.Empty;
            ccDate = string.Empty;
            balance = 0;
        }
        public Account(int aID, int gID, string _CCNo, string _CCDate, double _balance)
        {
            accountID = aID;
            guestID = gID;
            ccNo = _CCNo;
            ccDate = _CCDate; 
            balance = _balance;
        }
        #endregion

        #region Utility Methods
        public void incBalance(double amount) { balance += amount; }
        public void decBalance(double amount) {  balance -= amount; }
        #endregion
    }
}
