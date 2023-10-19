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
        private string CCNo, CCDate;
        private double balance = 0;
        #endregion

        #region Properties
        public string CCNo_ { get { return CCNo; } set {  CCNo = value; } }
        public string CCDate_ { get { return CCDate; } set { CCDate = value; } }
        public double Balance { get { return balance; } set {  balance = value; } }
        #endregion

        #region Constructors
        public Account()
        {
            CCNo = string.Empty;
            CCDate = string.Empty;
            balance = 0;
        }
        public Account(string _CCNo, string _CCDate, double _balance)
        {
            CCNo = _CCNo;
            CCDate = _CCDate; 
            balance = _balance;
        }
        #endregion

        #region Utility Methods
        public void incBalance(double amount) { balance += amount; }
        public void decBalance(double amount) {  balance -= amount; }
        #endregion
    }
}
