using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ETS.Manager;
using ETS.Entity;

namespace ETS.View
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }


        private void CleanUp() {
            txtFN.Text = "";
            txtLN.Text = "";
            txtEmail.Text = "";
            txtDOB.Text = "";
            txtPhone.Text = "";
        }
        private void Assign(Employee emp)
        {
            txtFN.Text = emp.FirstName;
            txtLN.Text = emp.LastName;
            txtEmail.Text = emp.Email;
            txtDOB.Text = emp.DOB.ToShortDateString();
            txtPhone.Text = emp.Phone;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //read input
            //create object
            Employee emp = new Employee();
            //assign values
            
            emp.FirstName = txtFN.Text;
            emp.LastName = txtLN.Text;
            emp.DOB = DateTime.Parse(txtDOB.Text);
            emp.Email = txtEmail.Text;
            emp.Phone = txtPhone.Text;
            //call method
            EmployeeManager manager = new EmployeeManager();
            manager.AddNewEmployee(emp);
            ClearUp();
            //message to show user
            MessageBox.Show("New Employee Added");
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearUp();
        }
        private void ClearUp() {
            txtDOB.Clear();
            txtEmail.Clear();
            txtFN.Clear();
            txtLN.Clear();
            txtPhone.Clear();
        }
        #region -- navigator bar
        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nav.Exit(this);
        }
        #endregion

        private void txtFN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
