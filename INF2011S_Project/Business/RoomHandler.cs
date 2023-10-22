using INF2011S_Project.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class RoomHandler
    {
        #region Data Members
        private RoomDB roomDB;
        private Collection<Room> rooms;
        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }
        #endregion

        #region Constructor
        public RoomHandler()
        {
            roomDB = new RoomDB();
            rooms = roomDB.AllRooms;
        }

        #endregion

        #region Database Communication.
        public void DataMaintenance(Room aRoom, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            roomDB.DataSetChange(aRoom, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    rooms.Add(aRoom);
                    break;
                case DB.DBOperation.Update:
                    index = FindIndex(aRoom);
                    rooms[index] = aRoom;  // replace room at this index with the updated room
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aRoom);  // find the index of the specific room in collection
                    rooms.RemoveAt(index);  // remove that room from the collection
                    break;

            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Room aRoom)
        {
            //***call the roomDB method that will commit the changes to the database
            return roomDB.UpdateDataSource(aRoom);
        }
        #endregion

        #region Searching through a collection

        //This method receives a room number as a parameter; finds the booking object in the collection of guests and then returns this object
        public Room Find(int roomNum)
        {
            int index = 0;
            //check if it is the first guest
            bool found = (rooms[index].RoomNumber == roomNum);
            int count = rooms.Count;
            while (!(found) && (index < rooms.Count - 1))
            {
                index = index + 1;
                found = (rooms[index].RoomNumber == roomNum);   // this will be TRUE if found
            }
            return rooms[index];
        }

        public int FindIndex(Room aRoom)
        {
            int counter = 0;
            bool found = false;
            found = (aRoom.RoomNumber == rooms[counter].RoomNumber);   //using a Boolean Expression to initialise found
            while (!(found) & counter < rooms.Count - 1)
            {
                counter += 1;
                found = (aRoom.RoomNumber == rooms[counter].RoomNumber);
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
