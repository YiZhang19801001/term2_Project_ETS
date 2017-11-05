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
    
    public partial class LogIn : Form
    {
        
        public LogIn()
        {
            InitializeComponent();
        }
        
        Thread th;
        int empID;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //call the method
            EmployeeManager manager = new EmployeeManager();
            
            LoginInfo res = manager.Login(txtUserName.Text, txtPassword.Text);
            if (res == null)
            {
                MessageBox.Show("User Name or Password Incorrect");
                return;
            }
            if (res.AccountType == "Admin")
            {
                this.Close();
                th = new Thread(OpenNewAdminForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else if (res.AccountType == "Employee")
            {
                empID = int.Parse(res.EmpID);
                this.Close();
                th = new Thread(OpenNewEmployeeForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
               
            }
        }

        private void OpenNewEmployeeForm(object obj)
        {
            Application.Run(new EmployeeSelfSevice(empID));
        }
        private void OpenNewAdminForm(object obj)
        {
            Application.Run(new Admin());
        }
        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
