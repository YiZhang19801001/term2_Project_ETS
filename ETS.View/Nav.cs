using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ETS.View
{
    public static class Nav
    {
        //click exit
        public static void Exit(Form frm)
        {
            
            frm.Close();
            Thread th = new Thread(OpenNewLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewLogin()
        {
            Application.Run(new LogIn()) ;
        }
        //click Add -->New Employee
        public static void AddEmployee(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewAddEmployee);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewAddEmployee()
        {
            Application.Run(new Admin());
        }
        //click Add -->New Work hours
        public static void AddWorkHours(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewAddWorkHours);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewAddWorkHours()
        {
            Application.Run(new AddNewWorkHours());
        }
        //click update -->updateEmploy
        public static void UpdateEmp(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewUpdateEmp);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewUpdateEmp()
        {
            Application.Run(new update());
        }
        //click update -->update Work hours
        public static void UpdateHours(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewUpdateHours);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewUpdateHours()
        {
            Application.Run(new UpdateHours());
        }
        //click search -->Employee
        public static void SearchEmp(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewSearchEmp);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewSearchEmp()
        {
            Application.Run(new SearchEmployee());
        }
        //click search -->work hour
        public static void SearchHours(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewSearchHours);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewSearchHours()
        {
            Application.Run(new SearchHours());
        }
        //click show --> employee
        public static void ShowEmps(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewShowEmps);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewShowEmps()
        {
            Application.Run(new ShowEmployees());
        }
        //click show --> work hours
        public static void ShowHours(Form frm)
        {

            frm.Close();
            Thread th = new Thread(OpenNewShowHours);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private static void OpenNewShowHours()
        {
            Application.Run(new ShowAllWorkHours());
        }
    }
}
