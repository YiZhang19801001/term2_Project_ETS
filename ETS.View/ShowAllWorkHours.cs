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
    public partial class ShowAllWorkHours : Form
    {
        public ShowAllWorkHours()
        {
            InitializeComponent();
        }


        private void ShowAllWorkHours_Load(object sender, EventArgs e)
        {

            EmployeeManager manager = new EmployeeManager();
            List<WorkRecord> list = manager.ShowAllWorkRecords();

            lisAll.View = System.Windows.Forms.View.Details;

            string header = "ID".PadRight(11, ' ') +
                "First Name".PadRight(11, ' ') +
                "Last Name".PadRight(11, ' ') +
                "Work Date".PadRight(16, ' ') +
                "Working Hours";

            lisAll.Columns.Add(header, 400);
            foreach (WorkRecord item in list)
            {
                lisAll.Items.Add(item.ToString());
            }

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
        private void searchEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
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
