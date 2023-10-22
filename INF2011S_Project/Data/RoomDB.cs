using INF2011S_Project.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Data
{
    public class RoomDB : DB
    {
        #region Data Members
        private string table3 = "Room";
        private string sqlLocal3 = "SELECT * FROM Room";
        private Collection<Room> rooms;
        #endregion

        #region Property Method: Collection
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }
        #endregion

        #region Constructor
        public RoomDB() : base()
        {
            //instantiate guest collection
            rooms = new Collection<Room>();
            //fill data set
            FillDataSet(sqlLocal3, table3);
            Add2Collection(table3);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        private void Add2Collection(string table)
        {
            DataRow myRow = null;
            Room room;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    room = new Room();

                    //Obtain each Room attribute from the specific field in the row in the table
                    room.RoomNumber = Convert.ToInt32(myRow["RoomNumber"]);
                    //add booking to bookings collection
                    rooms.Add(room);

                }
            }
        }

        private void FillRow(DataRow aRow, Room aRoom, DB.DBOperation operation)
        {

            if (operation == DB.DBOperation.Add)
            {
                aRow["RoomNumber"] = aRoom.RoomNumber;
            }
        }

        private int FindRow(Room aRoom, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //check if roomNumber equal to what we are looking for
                    if (aRoom.RoomNumber == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["RoomNumber"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }

        #endregion

        #region Data Operations CRUD
        public void DataSetChange(Room aRoom, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table3;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aRoom, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aRoom, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aRoom, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aRoom, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion


        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Room aRoom)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@RoomNumber", SqlDbType.Int, 10, "RoomNumber");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

        }

        private void Build_UPDATE_Parameters(Room aRoom)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            //testing the booking reference of record that needs to change with the original guestID of the record
            param = new SqlParameter("@RoomNumber", SqlDbType.Int, 15, "RoomNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Create_UPDATE_Command(Room aRoom)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Room SET RoomNumber = @RoomNumber " + "WHERE RoomNumber = @RoomNumber", cnMain);
            Build_UPDATE_Parameters(aRoom);
        }

        //update data source
        public bool UpdateDataSource(Room aRoom)
        {
            bool success = true;

            Create_UPDATE_Command(aRoom);

            success = UpdateDataSource(sqlLocal3, table3);
            return success;
        }

        #endregion

    }
}
