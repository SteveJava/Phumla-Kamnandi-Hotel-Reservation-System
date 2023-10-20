using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class Guest
    {
        #region Data Members
        private int guestID;
        private string firstName, secondName, cellPhone, homeAddress, emailAddress;

        #endregion

        #region Properties
        public int GuestID { get { return guestID; } set { guestID = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string SecondName { get { return secondName; } set { secondName = value; } }
        public string CellPhone { get { return cellPhone; } set { cellPhone = value; } }
        public string HomeAddress { get { return homeAddress; } set { homeAddress = value; } }
        public string EmailAddress { get { return emailAddress; } set { emailAddress = value; } }
        #endregion

        #region Contructor
        public Guest()
        {
            guestID = 0;
            firstName = string.Empty;
            secondName = string.Empty;
            cellPhone = string.Empty;
            homeAddress = string.Empty;
            emailAddress = string.Empty;
        }

        public Guest(int gID, string fName, string sName, string cell, string hAdd, string eAdd)
        {
            guestID = gID;
            firstName = fName;
            secondName = sName;
            cellPhone = cell;
            homeAddress = hAdd;
            emailAddress = eAdd;
        }
        #endregion

    }
}
