using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class Guest:Person
    {
        #region Data Members
        private string guestID;
        #endregion

        #region Properties
        public string GuestId { get { return guestID; } set { guestID = value; } }
        #endregion

        #region Contructor
        public Guest()
        {
            guestID = string.Empty;
        }

        public Guest(string gID)
        {
            guestID = gID;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return base.ToString() + "\nGuestID: " + guestID;
        }
        #endregion

    }
}
