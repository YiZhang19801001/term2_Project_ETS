using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Entity
{
    public class Employee
    {
        //fields & props
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public DateTime DOB { get; set; }
        public string Phone{ get; set; }

        //method -- override toString to show info of object
        public override string ToString()
        {
            return "EMP"+EmpID.ToString().PadLeft(3,'0').PadRight(7,' ')+
                FirstName.PadRight(10,' ')+
                LastName.PadRight(10,' ')+
                Email.PadRight(25,' ')+
                DOB.ToShortDateString().PadRight(15,' ')+
                Phone;
        }
        public string ToString(int a)
        {
            return "EMP"+EmpID.ToString().PadLeft(3,'0').PadRight(5,' ')+
                FirstName.PadRight(10,' ')+
                LastName.PadRight(10,' ')+
                Phone;
        }
    }
}
