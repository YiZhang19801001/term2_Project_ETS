﻿using System;
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
    public partial class AddNewWorkHours : Form
    {
        public AddNewWorkHours()
        {
            InitializeComponent();
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
        List<EmpHour> list;
        int id;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            listDisplay.Clear();
            //read employee details and show it in label next to the button
            //read input
            id = int.Parse(txtID.Text);
            //call find employee by id method
            EmployeeManager manager = new EmployeeManager();
            list = manager.FindEmpHoursByID(id);
            Employee emp= manager.FindEmployeeByID(id);
            //show details in listView
            listDisplay.View = System.Windows.Forms.View.Details;
            listDisplay.Columns.Add("ID", 70);
            listDisplay.Columns.Add("WorkDate", 90);
            listDisplay.Columns.Add("Hours", 50);

            for (int i = 0; i < list.Count; i++)
            {
                string[] arr = new string[3];
                arr[0] = "WH" + list[i].EmpHoursID.ToString().PadLeft(4, '0');
                arr[1] = list[i].WorkDate.ToShortDateString();
                arr[2] = list[i].Hours.ToString();
                listDisplay.Items.Add(new ListViewItem(arr));
            }
            if (emp != null)
            {
                lblName.Text = emp.FirstName + " " + emp.LastName;
            }
            else
            {
                lblName.Text = "No one found";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHours.Clear();
            txtDate.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //insert new record 
            //read input
            DateTime date = DateTime.Parse(txtDate.Text);
            double hours = double.Parse(txtHours.Text);
            //call method
            EmployeeManager manager = new EmployeeManager();
            manager.AddNewWorkRecord(id, date, hours);
            MessageBox.Show("Record Added");
        }
    }
}
