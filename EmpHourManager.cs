using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//..
using ETS.Entity;
using ETS.CustomizeExceptionLib;
using ETS.DataAccess;

namespace ETS.Manager
{
    public class EmpHourManager
    {
        //show all work records
        public List<string[]> ShowAllEmpHours()
        {
            EmpHourDao dao = new EmpHourDao();
            return dao.SelectAllWorkRecords();
        }

        //find emphours by id -- multipe record will return(one Employee work many days)
        public Result<List<EmpHour>> FindEmpHoursByID(string ID)
        {
            #region-- throw exception to view
            if (ID.Trim() == "")
            {
                throw new InputEmptyException();
            }
            ID = ID.ToUpper();

            int id = 0;

            if (!int.TryParse(ID, out id))
            {
                if (ID.Length != 7)
                {
                    throw new EmpIDFormatIncorrect();
                }
                else if (ID[0] != 'E' || ID[1] != 'M' || ID[2] != 'P')
                {
                    throw new EmpIDFormatIncorrect();
                }
                else if (!int.TryParse(ID.Substring(3), out id))
                {
                    throw new EmpIDFormatIncorrect();
                }
            }
            if (id < 0)
            {
                throw new NegativeInput();
            }
            if (id == 0)
            {
                throw new InputZeroException();
            }
            #endregion
            //handle exceptions in Dao
            
            Result<List<EmpHour>> result = new Result<List<EmpHour>>() ;
            try
            {
                EmpHourDao dao = new EmpHourDao();
                result.Data = dao.FindEmpHourById(id);
                result.Status = enumResult.Success;
            }
            catch (Exception ex)
            {
                result.Status = enumResult.Fail;
                result.Message = ex.Message;
            }
            return result;
        }
        //select emphours by date
        public Result<List<EmpHour>> FindEmpHoursByDate(string Date)
        {
            #region -- throw exception to view
            if (Date.Trim() == "")
            {
                throw new InputEmptyException();
            }
            DateTime date;
            if (!DateTime.TryParse(Date, out date))
            {
                throw new InvilidWorkDateException();
            }
            if (date > DateTime.Now)
            {
                throw new TryRecordFutureException();
            }
            #endregion
            //handle exceptions, call Dao method
            Result<List<EmpHour>> result = new Result<List<EmpHour>>();
            try
            {
                EmpHourDao dao = new EmpHourDao();
                result.Data = dao.SelectEmpHoursByDate(date);
                result.Status = enumResult.Success;
            }
            catch (Exception ex)
            {

                result.Status = enumResult.Fail;
                result.Message = ex.Message;
            }
            
            return result;
        }
        //add new work record
        public enumResult AddNewEmpHour(int empID, string d, string hrs)
        {
            #region--check input throw exception to view
            d = d.Trim();
            hrs = hrs.Trim();
            if (d == "" || hrs == "")
            {
                throw new InputEmptyException();
            }
            DateTime date;
            if (!DateTime.TryParse(d, out date))
            {
                throw new InvilidWorkDateException();
            }
            if (date > DateTime.Now)
            {
                throw new TryRecordFutureException();
            }
            double hours;
            if (!double.TryParse(hrs, out hours))
            {
                throw new InvilidWorkHoursException();
            }
            if (hours > 16)
            {
                throw new InvilidWorkHoursException();
            }
            if (hours < 0)
            {
                throw new NegativeInput();
            }
            if (hours == 0)
            {
                throw new InputZeroException();
            }
            #endregion
            //call dao method , and handle exceptions
            enumResult result;
            try
            {
                EmpHourDao dao = new EmpHourDao();
                dao.AddNewWorkRecord(empID, date, hours);
                result = enumResult.Success;
            }
            catch (Exception)
            {

                result = enumResult.Fail;
            }
            return result;
        }

        //update work hours by work hourID
        public enumResult UpdateEmpHoursByEmpHourID(string empHourID, string d, string hrs)
        {
            #region--check the input, throw exceptions to view
            empHourID = empHourID.Substring(2);
            int id;
            int.TryParse(empHourID, out id);
            if (d.Trim() == "" || hrs.Trim() == "")
            {
                throw new InputEmptyException();
            }

            DateTime date;
            if (!DateTime.TryParse(d, out date))
            {
                throw new InvilidWorkDateException();
            }
            if (date > DateTime.Now)
            {
                throw new TryRecordFutureException();
            }

            double hours;
            if (!double.TryParse(hrs, out hours))
            {
                throw new WorkHoursNotNumberException();
            }
            if (hours > 16)
            {
                throw new InvilidWorkHoursException();
            }
            if (hours < 0)
            {
                throw new NegativeInput();
            }
            if (hours == 0)
            {
                throw new InputZeroException();
            }
            #endregion
            //call dao method and handle the exceptions
            enumResult result;
            try
            {
                EmpHourDao dao = new EmpHourDao();
                dao.UpdateEmpHoursByWorkHourID(id, date, hours);
                result = enumResult.Success;

            }
            catch (Exception)
            {
                result = enumResult.Fail;
            }
            return result;
        }

        //delete emphour by emphourid
        public enumResult DeleteEmpHourByEmpHourID(string empHourID)
        {
            //create new enumResult
            enumResult res = new enumResult();

            //Convertion, as emphourID was not entering by user, always read and write by program 
            //no validation needs here
            empHourID = empHourID.Substring(2);
            int id;
            int.TryParse(empHourID, out id);

            //call method
            try
            {
                EmpHourDao dao = new EmpHourDao();
                dao.DeleteEmpHourByEmpHourID(id);
                res = enumResult.Success;
            }
            catch (Exception)
            {
                res = enumResult.Fail;
            }

            return res;
        }

        //find emphour by date and empID
        public Result<List<EmpHour>> FindEmpHourByDateAndEmpID(string date, int empID)
        {
            Result<List<EmpHour>> res = new Result<List<EmpHour>>();
            try
            {
                //create objects
                EmpHourDao dao = new EmpHourDao();
                List<EmpHour> list = dao.SelectEmpHoursByDate(DateTime.Parse(date));
                List<EmpHour> listNew = new List<EmpHour>();

                foreach (EmpHour item in list)
                {
                    if (item.EmpID == empID)
                    {
                        listNew.Add(item);
                    }
                }


                res.Data = listNew;
                res.Status = enumResult.Success;
            }
            catch (Exception)
            {
                res.Status = enumResult.Fail;
            }


            return res;
            
        }
    }
}
