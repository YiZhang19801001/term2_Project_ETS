using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETS.Entity;
using System.Data.SqlClient;
using System.Data;

namespace ETS.DataAccess
{
    public class EmployeeDao
    {
        //method - select all employees
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_Employees_SelectAll", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //#3 - run command
                SqlDataReader reader = command.ExecuteReader();

                //#4 - handle results
                while (reader.Read())
                {
                    //map record to object
                    Employee emp = new Employee();
                    emp.EmpID = Convert.ToInt32(reader["EmpID"]);
                    emp.FirstName = Convert.ToString(reader["FirstName"]);
                    emp.LastName = Convert.ToString(reader["LastName"]);
                    emp.Email = Convert.ToString(reader["Email"]);
                    emp.DOB = Convert.ToDateTime(reader["DOB"]);
                    emp.Phone = Convert.ToString(reader["Phone"]);
                    //add to list
                    list.Add(emp);
                }
                return list;
            }
        }
        //method - select employee by ID;
        public Employee SelectEmpByID(int ID)
        {
            Employee emp = new Employee();
            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_Employees_SelectByID", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //add parameters
                command.Parameters.Add("@EmpID", SqlDbType.Int);
                command.Parameters["@EmpID"].Value = ID;
                //#3 - run command
                SqlDataReader reader = command.ExecuteReader();

                //#4 - handle results
                while (reader.Read())
                {
                    //map record to object

                    emp.EmpID = Convert.ToInt32(reader["EmpID"]);
                    emp.FirstName = Convert.ToString(reader["FirstName"]);
                    emp.LastName = Convert.ToString(reader["LastName"]);
                    emp.Email = Convert.ToString(reader["Email"]);
                    emp.DOB = Convert.ToDateTime(reader["DOB"]);
                    emp.Phone = Convert.ToString(reader["Phone"]);
                    return emp;
                }
                return null;

            }
        }
        //method - select employee by email;
        public Employee SelectEmpByEmail(string Email)
        {
            Employee emp = new Employee();
            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_Employees_SelectByEmail", conn);
                command.CommandType = CommandType.StoredProcedure;
                //add parameters
                command.Parameters.Add("@Email", SqlDbType.VarChar);
                command.Parameters["@Email"].Value = Email;
                //#3 - run command
                SqlDataReader reader = command.ExecuteReader();

                //#4 - handle results
                while (reader.Read())
                {
                    //map record to object

                    emp.EmpID = Convert.ToInt32(reader["EmpID"]);
                    emp.FirstName = Convert.ToString(reader["FirstName"]);
                    emp.LastName = Convert.ToString(reader["LastName"]);
                    emp.Email = Convert.ToString(reader["Email"]);
                    emp.DOB = Convert.ToDateTime(reader["DOB"]);
                    emp.Phone = Convert.ToString(reader["Phone"]);
                    return emp;
                }
                return null;

            }
        }
        //method - insert employee
        public void AddNewEmployee(Employee emp)
        {

            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_Employees_InsertNewEmployee", conn);
                command.CommandType = CommandType.StoredProcedure;
                //add parameters

                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);
                command.Parameters.Add("@Email", SqlDbType.VarChar);
                command.Parameters.Add("@DOB", SqlDbType.Date);
                command.Parameters.Add("@Phone", SqlDbType.VarChar);
                //assign values

                command.Parameters["@Email"].Value = emp.Email;
                command.Parameters["@FirstName"].Value = emp.FirstName;
                command.Parameters["@LastName"].Value = emp.LastName;
                command.Parameters["@DOB"].Value = emp.DOB;
                command.Parameters["@Phone"].Value = emp.Phone;

                //#3 - run command
                command.ExecuteNonQuery();

            }
        }
        //method - update employee information according ID
        public void UpdateEmployee(Employee emp)
        {

            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_Employees_UpdateEmployeeInfo", conn);
                command.CommandType = CommandType.StoredProcedure;
                //add parameters
                command.Parameters.Add("@EmpID", SqlDbType.Int);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);
                command.Parameters.Add("@Email", SqlDbType.VarChar);
                command.Parameters.Add("@DOB", SqlDbType.Date);
                command.Parameters.Add("@Phone", SqlDbType.VarChar);
                //assign values
                command.Parameters["@EmpID"].Value = emp.EmpID;
                command.Parameters["@Email"].Value = emp.Email;
                command.Parameters["@FirstName"].Value = emp.FirstName;
                command.Parameters["@LastName"].Value = emp.LastName;
                command.Parameters["@DOB"].Value = emp.DOB;
                command.Parameters["@Phone"].Value = emp.Phone;
                //#3 - run command
                command.ExecuteNonQuery();
            }
        }

        //method - select Work Records
        public List<WorkRecord> SelectAllWorkRecords()
        {
            List<WorkRecord> list = new List<WorkRecord>();

            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_EmployeesAndEmpHours_SelectAll", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //#3 - run command
                SqlDataReader reader = command.ExecuteReader();

                //#4 - handle results
                while (reader.Read())
                {
                    //map record to object
                    WorkRecord record = new WorkRecord();
                    record.EmpID = Convert.ToInt32(reader["EmpID"]);
                    record.EmpHoursID = Convert.ToInt32(reader["EmpHoursID"]);
                    record.FirstName = Convert.ToString(reader["FirstName"]);
                    record.LastName = Convert.ToString(reader["LastName"]);
                    record.WorkDate = Convert.ToDateTime(reader["WorkDate"]);
                    record.Hours = Convert.ToDouble(reader["Hours"]);
                    //add to list
                    list.Add(record);
                }
                return list;
            }
        }

        //method - log in
        public LoginInfo Login(string userName, string password)
        {

            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_LoginInfo_Compare", conn);
                command.CommandType = CommandType.StoredProcedure;
                //add parameters
                command.Parameters.Add("@UserName", SqlDbType.VarChar);
                command.Parameters.Add("@PassWord", SqlDbType.VarChar);
                command.Parameters["@UserName"].Value = userName;
                command.Parameters["@PassWord"].Value = password;
                //#3 - run command
                SqlDataReader reader = command.ExecuteReader();

                //#4 - handle results
                if (reader.Read())
                {
                    LoginInfo loginInfo = new LoginInfo();
                    loginInfo.AccountType = Convert.ToString(reader["AccountType"]);
                    loginInfo.UserName = Convert.ToString(reader["UserName"]);
                    loginInfo.PassWord = Convert.ToString(reader["PassWord"]);
                    loginInfo.EmpID = Convert.ToString(reader["EmpID"]);
                    return loginInfo;
                }
                else
                {
                    return null;
                }


            }


        }
        //method - insert work record
        public void AddNewWorkRecord(int empID, DateTime date, double hours)
        {
            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_EmpHours_InsertNewRecord", conn);
                command.CommandType = CommandType.StoredProcedure;
                //add parameters

                command.Parameters.Add("@EmpID", SqlDbType.Int);
                command.Parameters.Add("@WorkDate", SqlDbType.Date);
                command.Parameters.Add("@Hours", SqlDbType.Float);

                //assign values

                command.Parameters["@EmpID"].Value = empID;
                command.Parameters["@WorkDate"].Value = date;
                command.Parameters["@Hours"].Value = hours;


                //#3 - run command
                command.ExecuteNonQuery();

            }
        }
        //method - select date and hours by id
        public List<EmpHour> FindEmpHourById(int id)
        {
            List<EmpHour> list = new List<EmpHour>();
            //create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_EmpHours_SelectWorkDateAndHoursByID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("EmpID",SqlDbType.Int);
                command.Parameters["EmpID"].Value = id;

                //#3 - run command
                SqlDataReader reader = command.ExecuteReader();

                //#4 - handle results
                while (reader.Read())
                {
                    //map record to object
                    EmpHour emp = new EmpHour();

                    emp.EmpHoursID = Convert.ToInt32(reader["EmpHoursID"]);
                    emp.WorkDate = Convert.ToDateTime(reader["WorkDate"]);
                    emp.Hours = Convert.ToDouble(reader["Hours"]);

                    //add to list
                    list.Add(emp);
                }
                return list;
            }


        }
        //method - update employee information according ID
        public void UpdateEmpHoursByID(int id, DateTime date, double hours)
        {

            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_EmpHours_UpdateByID", conn);
                command.CommandType = CommandType.StoredProcedure;
                //add parameters
                command.Parameters.Add("@EmpHoursID", SqlDbType.Int);
                command.Parameters.Add("@WorkDate", SqlDbType.Date);
                command.Parameters.Add("@Hours", SqlDbType.Float);

                //assign values
                command.Parameters["@EmpHoursID"].Value = id;
                command.Parameters["@WorkDate"].Value = date;
                command.Parameters["@Hours"].Value = hours;

                //#3 - run command
                command.ExecuteNonQuery();
            }
        }
        //method - select work hour by date;
        public List<EmpHour> SelectEmpHoursByDate(DateTime date)
        {
            List<EmpHour> list = new List<EmpHour>();
            
            //#1 - create connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=Yi_PD2_ETSDatabase;Integrated Security=True";
            conn.Open();
            using (conn)
            {
                //#2 - create command
                SqlCommand command = new SqlCommand("sp_EmpHours_SelectByDate", conn);
                command.CommandType = CommandType.StoredProcedure;
                //add parameters
                command.Parameters.Add("@WorkDate", SqlDbType.Date);
                command.Parameters["@WorkDate"].Value = date;
                //#3 - run command
                SqlDataReader reader = command.ExecuteReader();

                //#4 - handle results
                while (reader.Read())
                {
                    //map record to object
                    EmpHour eHour = new EmpHour();
                    eHour.EmpHoursID = Convert.ToInt32(reader["EmpHoursID"]);
                    eHour.EmpID = Convert.ToInt32(reader["EmpID"]);
                    eHour.WorkDate = Convert.ToDateTime(reader["WorkDate"]);
                    eHour.Hours = Convert.ToDouble(reader["Hours"]);

                    list.Add(eHour);
                    
                }
                return list;

            }
        }

    }
}
