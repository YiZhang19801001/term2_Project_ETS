using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETS.Entity;
using ETS.Manager;
using System.Threading;

namespace ETS.View
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }
        int ID = 0;


        private void update_Load(object sender, EventArgs e)
        {
            ShowAll();
        }
        private void ShowAll()
        {
            //create objects
            EmployeeManager manager = new EmployeeManager();
            List<Employee> list = new List<Employee>();
            //call methods
            list = manager.GetAllEmployees();
            //show out
            lisAll.DataSource = list;

        }

        private void lisAll_MouseClick(object sender, MouseEventArgs e)
        {
            Employee emp = new Employee();
            emp = (Employee)lisAll.SelectedItem;
            Assign(emp);
        }
        private void Assign(Employee emp)
        {
            txtFN.Text = emp.FirstName;
            txtLN.Text = emp.LastName;
            txtEmail.Text = emp.Email;
            txtDOB.Text = emp.DOB.ToShortDateString();
            txtPhone.Text = emp.Phone;
            ID = emp.EmpID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeManager manager = new EmployeeManager();
            Employee emp = new Employee();
            emp.FirstName = txtFN.Text;
            emp.LastName = txtLN.Text;
            emp.Phone = txtPhone.Text;
            emp.DOB = DateTime.Parse(txtDOB.Text);
            emp.Email = txtEmail.Text;
            emp.EmpID = ID;
            manager.UpdateEmployee(emp);
            ShowAll();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp = (Employee)lisAll.SelectedItem;
            Assign(emp);
        }
        #region -- navigator bar
        private void addNewEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Nav.AddEmployee(this);
        }
        private void newWorkHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.AddWorkHours(this);
        }
        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.UpdateEmp(this);
        }
        private void updateWorkHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.UpdateHours(this);
        }
        private void searchEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.SearchEmp(this);
        }

        private void searchWorkHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.SearchHours(this);
        }
        private void showAllEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.ShowEmps(this);
        }
        private void showAllWorkRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.ShowHours(this);
        }
        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Nav.Exit(this);
        }
        #endregion

    }
}
