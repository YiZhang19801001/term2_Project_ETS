using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//..

namespace ETS.Manager
{
    public enum enumResult { Success,Fail}
    public class Result<T>
    {
        //fields and props
        public T Data{ get; set; }
        public enumResult Status{ get; set; }

        public string Message{ get; set; }

    }
}
