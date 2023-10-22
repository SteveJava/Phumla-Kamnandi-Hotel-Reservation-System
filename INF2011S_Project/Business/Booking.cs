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
        private int refNum, guestID, numOfAdults, numOfChildren, roomNum;
        private string specialRequests;
        private DateTime checkInDate, checkOutDate;
        #endregion

        #region Properties
        public int ReferenceNumber { get { return refNum; } set { refNum = value; } }
        public int GuestID { get { return guestID; } set {  guestID = value; } }
        public int RoomNumber { get { return roomNum; } set { roomNum = value; } }
        public int NumberOfAdults { get {  return numOfAdults; } set {  numOfAdults = value; } }
        public int NumberOfChildren { get {  return numOfChildren; } set { numOfChildren = value; } }
        public string SpecialRequests { get {  return specialRequests; } set {  specialRequests = value; } }
        public DateTime CheckInDate { get {  return checkInDate; } set {  checkInDate = value; } }
        public DateTime CheckOutDate { get { return checkOutDate; } set { checkOutDate = value; } }
        #endregion

        #region Constructor
        public Booking()
        {
            refNum = 0;
            guestID = 0;
            roomNum = 0;
            specialRequests = null;
            numOfAdults = 0;
            numOfChildren = 0;
            checkInDate = DateTime.MinValue;
            checkOutDate = DateTime.MinValue;

        }
        public Booking(int RefNum, int GuestID, int NoAdults, int NoChildren, int RoomNum, string SpecialRequests, DateTime CheckInDate, DateTime CheckOutDate)
        {
            refNum = RefNum;
            guestID = GuestID;
            numOfAdults = NoAdults;
            numOfChildren = NoChildren;
            roomNum = RoomNum;
            specialRequests = SpecialRequests;
            checkInDate = CheckInDate;
            checkOutDate = CheckOutDate;
        }
        #endregion
    }
}
