using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Project.Business
{
    public class Booking
    {
        #region Data Members
        private string refNum, bookingID;
        private int numOfAdults, numOfChildren;
        private string specialRequests;
        private DateTime checkInDate, checkOutDate;
        private Boolean checkedIn, checkedOut;
        #endregion

        #region Properties
        public string getRefNum { get { return refNum; } set { refNum = value; } }
        public string getBookingID { get { return bookingID; } set {  bookingID = value; } }
        public int getNumOfAdults { get {  return numOfAdults; } set {  numOfAdults = value; } }
        public int getNumOfChildren { get {  return numOfChildren; } set { numOfChildren = value; } }
        public string getSpecialRequests { get {  return specialRequests; } set {  specialRequests = value; } }
        public DateTime getCheckInDate { get {  return checkInDate; } set {  checkInDate = value; } }
        public DateTime getCheckOutDate { get { return checkOutDate; } set { checkOutDate = value; } }
        public Boolean getCheckedIn { get {  return checkedIn; } set {  checkedIn = value; } }
        public Boolean getCheckedOut { get {  return checkedOut; } set { checkedOut = value; } }
        #endregion

        #region Constructor
        public Booking()
        {
            this.refNum = string.Empty;
            this.bookingID = string.Empty;
            this.numOfAdults = 0;
            this.numOfChildren = 0;
            this.checkedOut = false;
            this.checkedIn = false;
        }
        public Booking(string RefNum, string SpecialRequests, DateTime CheckInDate, DateTime CheckOutDate, Boolean CheckedIn, Boolean CheckedOut)
        {
            refNum = RefNum;
            bookingID = GenerateID();
            specialRequests = SpecialRequests;
            checkInDate = CheckInDate;
            checkOutDate = CheckOutDate;
            checkedIn = CheckedIn;
            checkedOut = CheckedOut;
        }
        #endregion

        #region Methods 
        public string GenerateID()
// NEEDS CHANGING !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            int length = 7;
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
    }
}
