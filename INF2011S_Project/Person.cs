using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Project
{
    public class Person
    {
        #region Data Members
        private string personID, firstName, secondName, emailAddress, cellPhone, homeAddress;
        #endregion

        #region Properties
        public string PersonID { get { return personID; } set { personID = value; } }
        public string FirstName { get {  return firstName; } set { firstName = value; } }
        public string SecondName { get { return secondName; } set {  secondName = value; } }
        public string EmailAddress { get { return emailAddress; } set {  emailAddress = value; } }
        public string CellPhone { get {  return cellPhone; } set {  cellPhone = value; } }
        public string HomeAddress { get { return homeAddress; } set {  homeAddress = value; } }
        #endregion

        #region Constructor
        public Person() 
        {
            personID = string.Empty;
            firstName = string.Empty;
            secondName = string.Empty;
            emailAddress = string.Empty;
            cellPhone = string.Empty;
            homeAddress = string.Empty;
        }
        public Person(string pID, string pFirstName, string pSecondName, string pEmailAddress, string pCellPhone, string pHomeAddress)
        {
            personID = pID;
            firstName = pFirstName;
            secondName = pSecondName;
            emailAddress = pEmailAddress;
            cellPhone = pCellPhone;
            homeAddress = pHomeAddress;
        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            return "PersonID: " + personID + "\nName: " +  firstName + " " + secondName + "\nCell Number" + cellPhone;
        }
        #endregion

    }
}
