using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETS.Entity;
using ETS.DataAccess;

namespace ETS.Manager
{
    public class EmployeeManager
    {
        //method - get all categories
        public List<Employee> GetAllEmployees()
        {
            EmployeeDao dao = new EmployeeDao();
            return dao.SelectAllEmployees();
        }
        //method - find a record
        public Employee FindEmployeeByID(int ID)
        {
            EmployeeDao dao = new EmployeeDao();

            return dao.SelectEmpByID(ID);

        }
        public Employee FindEmployeeByEmail(string Email)
        {
            EmployeeDao dao = new EmployeeDao();

            return dao.SelectEmpByEmail(Email);

        }
        //add new employee
        public void AddNewEmployee(Employee emp)
        {
            EmployeeDao dao = new EmployeeDao();
            dao.AddNewEmployee(emp);
        }

        //update new employee
        public void UpdateEmployee(Employee emp)
        {
            EmployeeDao dao = new EmployeeDao();
            dao.UpdateEmployee(emp);
        }
        //show all work records
        public List<WorkRecord> ShowAllWorkRecords()
        {
            EmployeeDao dao = new EmployeeDao();
            return dao.SelectAllWorkRecords();
        }
        //login
        public LoginInfo Login(string userName,string passWord) {
            EmployeeDao dao = new EmployeeDao();
            return dao.Login(userName,passWord);
        }
        //add new work record
        public void AddNewWorkRecord(int empID, DateTime date, double hours)
        {
            EmployeeDao dao = new EmployeeDao();
            dao.AddNewWorkRecord(empID, date, hours);
        }
        //find emphours by id
        public List<EmpHour> FindEmpHoursByID(int id)
        {
            EmployeeDao dao = new EmployeeDao();
            return dao.FindEmpHourById(id);
        }
        //update work hours by id
        public void UpdateEmpHoursByID(int id, DateTime date, double hours)
        {
            EmployeeDao dao = new EmployeeDao();
            dao.UpdateEmpHoursByID(id, date, hours);
        }
        //select emphours by date
        public List<EmpHour> FindEmpHoursByDate(DateTime date)
        {
            EmployeeDao dao = new EmployeeDao();
            return dao.SelectEmpHoursByDate(date);
        }
    }
}
