using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETS.Manager;
using ETS.Entity;
using System.Threading;

namespace ETS.View
{
    public partial class ShowEmployees : Form
    {
        public ShowEmployees()
        {
            InitializeComponent();
        }
        
        private void ShowEmployees_Load(object sender, EventArgs e)
        {
            //first - gain all datas
            EmployeeManager manager = new EmployeeManager();
            List<Employee> list = manager.GetAllEmployees();
            //make a header for listview look better
            lisAll.View = System.Windows.Forms.View.Details;

            string header = "Emp ID".PadRight(10, ' ') +
                "First Name".PadRight(10, ' ') +
                "Last Name".PadRight(10, ' ') +
                "Email".PadRight(25, ' ') +
                "Date of Birth".PadRight(15, ' ') +
                "Phone";
            lisAll.Columns.Add(header,550);
            //put all Employee details in listView
            foreach (Employee item in list)
            {
                lisAll.Items.Add(item.ToString());
            }
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
        private void searchEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Nav.SearchEmp(this);
        }

        private void searchWorkHoursToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Nav.SearchHours(this);
        }
        private void showAllEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav.ShowEmps(this);
        }
        private void showAllWorkRecordsToolStripMenuItem_Click_1(object sender, EventArgs e)
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
