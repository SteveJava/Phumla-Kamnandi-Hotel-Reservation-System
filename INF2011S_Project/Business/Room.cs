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
        #endregion

        #region Properties
        public int RoomNumber { get { return roomNum; } set {  roomNum = value; } }
        #endregion

        #region Constructor
        public Room()
        {
            roomNum = 0;
        }
        public Room(int RoomNum)
        {
            this.roomNum = RoomNum;
        }
        #endregion

    }
}
