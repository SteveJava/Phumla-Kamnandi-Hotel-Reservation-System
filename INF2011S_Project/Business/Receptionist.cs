using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project.Business
{
    public class Receptionist
    {
        #region Data Members
        private string passWord;
        private int empID;
        #endregion

        #region Properties
        public int EmpID { get { return empID; } set { empID = value; } }
        public string Password { get { return passWord; } set { passWord = value; } }
        #endregion

        #region Constructor 
        public Receptionist() 
        {
            empID = 0;
            passWord = string.Empty;
        }
        public Receptionist(int EmpID, string PassWord)
        {
            empID = EmpID;
            passWord = PassWord;
        }
        #endregion

    }
}
