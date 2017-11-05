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

namespace ETS.View
{
    public partial class SearchHours : Form
    {
        public SearchHours()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lisAll.Clear();
            //read input
            DateTime date = DateTime.Parse(txtDate.Text);
            double sum = 0;
            //need EmpID, FN, LN, Hours and total
            //step 1 call method gain data from table EmpHours
            EmployeeManager manager = new EmployeeManager();
            List<EmpHour> listHours = manager.FindEmpHoursByDate(date);
            //found out those employees who involved in this date

            //step 2 call method gain data from Employee table by EmployID
            //cause no class object to store the data we assign values we need to listView in one step.
            //make header for listView
            lisAll.View = System.Windows.Forms.View.Details;
            lisAll.Columns.Add("ID", 50);
            lisAll.Columns.Add("First Name", 90);
            lisAll.Columns.Add("Last Name", 90);
            lisAll.Columns.Add("Hours", 60);
            foreach (EmpHour item in listHours)
            {
                string[] arr = new string[4];
                arr[0] = "EMP"+item.EmpID.ToString().PadLeft(3,'0');
                arr[1] = manager.FindEmployeeByID(item.EmpID).FirstName;
                arr[2] = manager.FindEmployeeByID(item.EmpID).LastName;
                arr[3] = item.Hours.ToString();
                lisAll.Items.Add(new ListViewItem(arr));
                sum += item.Hours;
            }
            lblTotal.Text ="Total: "+ sum;

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
        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Nav.Exit(this);
        }
        #endregion
    }
}
