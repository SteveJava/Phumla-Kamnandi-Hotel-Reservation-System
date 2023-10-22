using INF2011S_Project.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class ReceptionistHandler
    {
        #region Data Members
        private ReceptionistDB receptionistDB;
        private Collection<Receptionist> receptionists;
        #endregion

        #region Properties
        public Collection<Receptionist> AllReceptionists
        {
            get
            {
                return receptionists;
            }
        }
        #endregion

        #region Constructor
        public ReceptionistHandler()
        {
            //  receptionistDB = new ReceptionistDB();
            //  receptionists = receptionistDB.AllReceptionists;
        }

        #endregion

        #region Methods
        // NEED TO HAVE A GENERATE ID!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public int generateID()
        {
            return 0;
        }
        #endregion

        #region Database Communication.

        public Receptionist RecordReceptionist(Receptionist receptionist)
        {
            receptionistDB = new ReceptionistDB();
            receptionists = receptionistDB.AllReceptionists;

            if (receptionist.EmpID == 0)
            {
                receptionistDB.DataSetChange(receptionist, DB.DBOperation.Add);
                receptionistDB.InsertReceptionistDataSource(receptionist);
            }
            else
            {
                receptionistDB.DataSetChange(receptionist, DB.DBOperation.Update);
                receptionistDB.UpdateReceptionistDataSource(receptionist);
            }
            receptionistDB.RetrieveAllReceptionists();
            receptionists = receptionistDB.AllReceptionists;
            receptionist = receptionists.First(x => x.EmpID == receptionist.EmpID);
            return receptionist;
        }

        public void DeleteReceptionist(Receptionist receptionist)
        {
            receptionistDB = new ReceptionistDB();
            receptionists = receptionistDB.AllReceptionists;

            if (!(receptionist.EmpID == 0))
            {
                receptionistDB.DataSetChange(receptionist, DB.DBOperation.Delete);
                receptionistDB.DeleteReceptionistDataSource(receptionist);
            }

        }

        public void DataMaintenance(Receptionist aReceptionist, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            receptionistDB.DataSetChange(aReceptionist, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    receptionists.Add(aReceptionist);
                    break;
                case DB.DBOperation.Update:
                    index = FindIndex(aReceptionist);
                    receptionists[index] = aReceptionist;  // replace receptionist at this index with the updated receptionist
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aReceptionist);  // find the index of the specific receptionist in collection
                    receptionists.RemoveAt(index);  // remove that receptionist from the collection
                    break;

            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Receptionist receptionist)
        {
            //***call the BookingDB method that will commit the changes to the database
            return receptionistDB.UpdateDataSource(receptionist);
        }
        #endregion

        #region Searching through a collection

        //This method receives a Receptionist ID as a parameter; finds the booking object in the collection of receptionists and then returns this object
        public Receptionist Find(int aID)
        {
            ReceptionistDB receptionistDB = new ReceptionistDB();
            receptionists = receptionistDB.AllReceptionists;
            Receptionist foundAccount = null;
            if (receptionists.Any(x => x.EmpID == aID))
            {
                foundAccount = receptionists.First(x => x.EmpID == aID);
            }
            return foundAccount;
        }
        public Receptionist FindPassWord(string password)
        {
            ReceptionistDB receptionistDB = new ReceptionistDB();
            receptionists = receptionistDB.AllReceptionists;
            Receptionist foundAccount = null;
            if (receptionists.Any(x => x.Password.Equals(password)))
            {
                foundAccount = receptionists.First(x => x.Password.Equals(password));
            }
            return foundAccount;
        }

        public int FindIndex(Receptionist aReceptionist)
        {
            int counter = 0;
            bool found = false;
            found = (aReceptionist.EmpID == receptionists[counter].EmpID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < receptionists.Count - 1)
            {
                counter += 1;
                found = (aReceptionist.EmpID == receptionists[counter].EmpID);
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
