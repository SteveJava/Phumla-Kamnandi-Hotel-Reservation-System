using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class Room
    {
        #region Data Members
        private int roomNum;
        private decimal rate;
        #endregion

        #region Properties
        public int RoomNum { get { return roomNum; } set {  roomNum = value; } }
        public decimal Rate { get { return rate; } set { rate = value; } }
        #endregion

        #region Constructor
        public Room()
        {
            roomNum = 0;
            rate = 0;
        }
        public Room(int RoomNum, decimal Rate)
        {
            this.RoomNum = RoomNum;
            this.Rate = Rate;
        }
        #endregion

    }
}
