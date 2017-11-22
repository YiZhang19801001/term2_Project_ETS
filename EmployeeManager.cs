using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//..
using ETS.Entity;
using ETS.DataAccess;
using ETS.CustomizeExceptionLib;
using System.Text.RegularExpressions;

namespace ETS.Manager
{
    public class EmployeeManager
    {
        //method - get all Employees
        public Result<List<Employee>> GetAllEmployees()
        {
            Result<List<Employee>> result = new Result<List<Employee>>();
            try
            {
                EmployeeDao dao = new EmployeeDao();
                result.Data = dao.SelectAllEmployees();
                result.Status = enumResult.Success;
                return result;
            }
            catch (Exception ex)
            {
                result.Status = enumResult.Fail;
                result.Message = ex.Message;
                return result;
            }
        }


        //method - find an Employee By ID or Email
        public Result<Employee> FindEmployeeByID(string ID)
        {
            Result<Employee> result = new Result<Employee>(); 
            if (ID.Trim() == "")
            {
                throw new InputEmptyException();
            }
            ID = ID.ToUpper();

            int id=0;
            
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
            try
            {
                EmployeeDao dao = new EmployeeDao();
                result.Data = dao.SelectEmpByID(id);
                result.Status = enumResult.Success;
            }
            catch (Exception ex)
            {
                result.Status = enumResult.Fail;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<Employee> FindEmployeeByEmail(string Email)
        {
            Result<Employee> result = new Result<Employee>(); 
            Email = Email.Trim();
            if (Email == "")
            {
                throw new InputEmptyException();
            }
            //if (!Email.Contains('@') || !Email.Contains('.') || Email.Contains(' '))
            //{
            //    throw new EmpEmailFormatIncorrectException();
            //}
            //example Regex rgx = new Regex(@"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$");
            Regex reg = new Regex(@"^[a-zA-z]\w*@\w{2,10}\.\w{2,3}");
            if (!reg.IsMatch(Email))
            {
                throw new EmpEmailFormatIncorrectException();
            }
            try
            {
                EmployeeDao dao = new EmployeeDao();
                result.Data = dao.SelectEmpByEmail(Email);
                result.Status = enumResult.Success;
            }
            catch (Exception ex)
            {
                result.Status = enumResult.Fail;
                result.Message = ex.Message;
            }
            return result;

        }


        //add new employee
        public enumResult AddNewEmployee(string FirstName, string LastName, string Email, string dob, string Phone,string PositionType)
        {
            
            //trim all input
            FirstName = FirstName.Trim();
            LastName = LastName.Trim();
            dob = dob.Trim();
            Email = Email.Trim();
            Phone = Phone.Trim();

            //found out input is empty or not
            if (FirstName == "" ||
                LastName == "" ||
                dob == "" ||
                Email == "")
            {
                throw new InputEmptyException();
            }

            //check names are all letters
            if (!FirstName.All(Char.IsLetter))
            {
                throw new EmpFirstNameFormatIncorrectException();
            }
            if (!LastName.All(Char.IsLetter))
            {
                throw new EmpLastNameFormatIncorrectException();
            }

            //check email format is correct or not
            Regex reg = new Regex(@"^[a-zA-z]\w*@\w{2,10}\.\w{2,3}");
            if (!reg.IsMatch(Email))
            {
                throw new EmpEmailFormatIncorrectException();
            }

            //check date of birth format
            DateTime DOB;
            if (!DateTime.TryParse(dob, out DOB))
            {
                throw new EmpDOBFormatIncorrectException();
            }
            //check age -- shoule between 18 and 70
            int age = DateTime.Today.Year - DOB.Year;
            if (age < 18)
            {
                throw new TryToAddEmployeeUnder18Exceptions();
            }
            if (age > 70)
            {
                throw new TryToAddEmployeeOver70Exceptions();
            }


            enumResult res = new enumResult();

            //convert PositionType to PositionID
            int PositionID=0;
            switch (PositionType)
            {
                case "Admin":
                    PositionID = 1;
                    break;
                case "Employee":
                    PositionID = 2;
                    break;
                default:
                    throw new EmpPositionTypeException();
            }
            try
            {
                EmployeeDao dao = new EmployeeDao();
                dao.AddNewEmployee(FirstName, LastName, DOB, Email, Phone, PositionID);
                res = enumResult.Success;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                res = enumResult.Fail;
                
            }
            return res;
       }


        //update new employee
        public enumResult UpdateEmployee(int ID, string FirstName, string LastName, string dob, string Email, string Phone)
        {
            //trim all input
            FirstName = FirstName.Trim();
            LastName = LastName.Trim();
            dob = dob.Trim();
            Email = Email.Trim();
            Phone = Phone.Trim();
            if (FirstName == "" ||
                LastName == "" ||
                dob == "" ||
                Email == "")
            {
                throw new InputEmptyException();
            }
            ////regex for firstname and lastname
            //Regex regName = new Regex(@"^\w\w*\w$");

            if (!FirstName.All(Char.IsLetter))
            {
                throw new EmpFirstNameFormatIncorrectException();
            }
            if (!LastName.All(Char.IsLetter))
            {
                throw new EmpLastNameFormatIncorrectException();
            }
            Regex reg = new Regex(@"^[a-zA-z]\w*@\w{2,10}\.\w{2,3}");
            if (!reg.IsMatch(Email))
            {
                throw new EmpEmailFormatIncorrectException();
            }
            DateTime DOB;
            if (!DateTime.TryParse(dob, out DOB))
            {
                throw new EmpDOBFormatIncorrectException();
            }

            //check age -- shoule between 18 and 70
            int age = DateTime.Today.Year - DOB.Year;
            if (age < 18)
            {
                throw new TryToAddEmployeeUnder18Exceptions();
            }
            if (age > 70)
            {
                throw new TryToAddEmployeeOver70Exceptions();
            }

            enumResult result = new enumResult();
            try
            {
                EmployeeDao dao = new EmployeeDao();
                dao.UpdateEmployee(ID, FirstName, LastName, Email, DOB, Phone);
                result = enumResult.Success;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = enumResult.Fail;
            }
            return result;
        }


        //Delete one employee according to EmpID
        public enumResult DeleteEmployee(string ID)
        {
            //create new enumResult
            enumResult res = new enumResult();

            //validation && throw exceptions to view.
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

            //call dao method
            try
            {
                EmployeeDao dao = new EmployeeDao();
                dao.DeleteEmployee(id);
                res = enumResult.Success;
            }
            catch (Exception)
            {
                res = enumResult.Fail;
            }

            return res;

            
        }
    }
}
