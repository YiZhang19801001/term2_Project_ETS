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
    public partial class SearchEmployee : Form
    {
        public SearchEmployee()
        {
            InitializeComponent();
        }


        private void CleanUp()
        {
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


        private void btnFind_Click_1(object sender, EventArgs e)
        {
            //clean up
            CleanUp();
            //read input
            int ID = int.Parse(txtID.Text);
            EmployeeManager manager = new EmployeeManager();
            Employee emp = manager.FindEmployeeByID(ID);
            //show
            if (emp != null)
            {
                Assign(emp);
            }
            else
            {
                MessageBox.Show("Employee not Found");
            }

        }

        private void btnFindByEmail_Click_1(object sender, EventArgs e)
        {
            CleanUp();
            //read input
            string email = txtEmail2.Text;
            //call method
            EmployeeManager manager = new EmployeeManager();
            Employee emp = manager.FindEmployeeByEmail(email);
            //show result
            if (emp != null)
            {
                Assign(emp);
            }
            else
            {
                MessageBox.Show("Employee not Found");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanUp();
            txtEmail2.Clear();
            txtID.Clear();
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
        private void updateEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
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
