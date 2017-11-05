using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Entity
{
    public class WorkRecord
    {
        //fields & props
        public int EmpID { get; set; }
        public int EmpHoursID { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public DateTime WorkDate{ get; set; }
        public double Hours{ get; set; }
        //methods
        public override string ToString()
        {
            return "EMP" + EmpID.ToString().PadLeft(3, '0').PadRight(7,' ') +
                " " + FirstName.PadRight(10, ' ') +
                " " + LastName.PadRight(10, ' ') +
                " " + WorkDate.ToShortDateString().PadRight(15, ' ')+
                " "+Hours.ToString().PadRight(10,' ');

        }
    }
}
