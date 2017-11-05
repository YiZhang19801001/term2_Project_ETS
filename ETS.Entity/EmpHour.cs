using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Entity
{
    public class EmpHour
    {
        //fields & props
        public int EmpHoursID{ get; set; }
        public int EmpID { get; set; }
        public DateTime WorkDate{ get; set; }
        public double Hours{ get; set; }

        //method -- override toString to show info
        public override string ToString()
        {
            return "Record ID: "+EmpHoursID+
                "\nEmployee ID: "+EmpID+
                "\nWork Date: "+WorkDate+
                "\nHours: "+Hours;
        }
    }
}
