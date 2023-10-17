using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class Receptionist:Person
    {
        #region Data Members
        private string empID, passWord;
        #endregion

        #region Properties
        public string EmpID { get { return empID; } set { empID = value; } }
        public string PassWord { get { return passWord; } set { passWord = value; } }
        #endregion

        #region Constructor 
        public Receptionist() 
        {
            empID = string.Empty;
            passWord = string.Empty;
        }
        public Receptionist(string empID, string passWord)
        {
            EmpID = empID;
            PassWord = passWord;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return base.ToString() + "\nEmployeeID: " + empID;
        }

    }
}
