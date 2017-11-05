using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ETS.Manager;
using ETS.Entity;

namespace ETS.View
{
    public partial class EmployeeSelfSevice : Form
    {
        Employee emp;
        public EmployeeSelfSevice(int empID)
        {
            InitializeComponent();
            EmployeeManager manager = new EmployeeManager();
            emp = manager.FindEmployeeByID(empID);
            //show personal details
            txtDOB.Text = emp.DOB.ToShortDateString();
            txtEmail.Text = emp.Email;
            txtFN.Text = emp.FirstName;
            txtLN.Text = emp.LastName;
            txtPhone.Text = emp.Phone;
            txtID.Text = "EMP"+emp.EmpID.ToString().PadLeft(3,'0');
            //read all work records to show
            List<EmpHour> list= manager.FindEmpHoursByID(empID);
            //add columns in listView format
            lvAll.View = System.Windows.Forms.View.Details;
            lvAll.Columns.Add("Record ID",90);
            lvAll.Columns.Add("Date", 90);
            lvAll.Columns.Add("Hours", 60);
            //read and assign values in listView
            foreach (EmpHour item in list)
            {
                string[] arr = new string[3];//store data
                arr[0] = "WH"+item.EmpHoursID.ToString().PadLeft(4,'0');
                arr[1] = item.WorkDate.ToShortDateString();
                arr[2] = item.Hours.ToString();
                //add the arr to listView
                lvAll.Items.Add(new ListViewItem(arr));
            }
        }

        
        Thread th;
        private void EmployeeSelfSevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            th = new Thread(OpenNewLoginForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void OpenNewLoginForm(Object obj)
        {
            Application.Run(new LogIn());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //assign new values
            emp.Email = txtEmail.Text;
            emp.Phone = txtPhone.Text;
            //call method 
            EmployeeManager manager = new EmployeeManager();
            manager.UpdateEmployee(emp);
            MessageBox.Show("Update Success");
        }

        private void EmployeeSelfSevice_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmail.Text = emp.Email;
            txtPhone.Text = emp.Phone;
        }
    }
}
