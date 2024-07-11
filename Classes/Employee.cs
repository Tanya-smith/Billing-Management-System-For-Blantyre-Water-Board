using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    class Employee
    {
        private string employeeID;
        private string fullName;
        private string contactAddress;
        private string emailAddress;
        private string empLocation;
        private string contactNumber;

        public void AddEmployee()
        {
            string SQL = ("INSERT INTO employee VALUES ('" + EmployeeID + "','" + FullName + "', '" + ContactAddress + "', '" + EmailAddress + "', '" + EmpLocation + "', '" + ContactNumber + "');");
            if (Global.dal.MyExecute(SQL) == true)
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Employee Added Successfully.", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
            }

        }

        public void UpdateEmployee()
        {
            string query = "UPDATE employee SET Employee_ID='" + EmployeeID + "', Full_Name='" + FullName + "', Contact_Address='" + ContactAddress + "', Email_Address='" +
                EmailAddress + "', Emp_Location='" + EmpLocation + "', Contact_Number='" + ContactNumber + "' WHERE Employee_ID='" + EmployeeID + "';";
            if (Global.dal.MyExecute(query) == true)
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Details updated Successfully.", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
            }
        }

        public void GetEmpDetails(string EmpID)
        {
            string SQL = ("SELECT * FROM employee WHERE Employee_ID='" + EmpID + "';");
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                EmployeeID = Global.dal.SQLReader["Employee_ID"].ToString();
                FullName = Global.dal.SQLReader["Full_Name"].ToString();
                ContactAddress = Global.dal.SQLReader["Contact_Address"].ToString();
                EmailAddress = Global.dal.SQLReader["Email_Address"].ToString();
                EmpLocation = Global.dal.SQLReader["Emp_Location"].ToString();
                ContactNumber = Global.dal.SQLReader["Contact_Number"].ToString();
            }
        }

        public void LoadEmpJobs(DataGridView DGV, string EmpNo)
        {
            string SQL = "SELECT j.*, s.Employee_ID FROM job j, schedule s WHERE j.Job_ID=s.Job_ID AND s.Employee_ID='" + EmpNo + "' GROUP BY j.Job_ID;";
            try
            {
                DGV.Rows.Clear();
                Global.dal.MyExecuteReader(SQL);
                while (Global.dal.SQLReader.Read())
                {
                    DGV.Rows.Add(
                    new object[]
                    {
                        Global.dal.SQLReader["Job_ID"].ToString(),
                        Global.dal.SQLReader["Location"].ToString(),
                        Global.dal.SQLReader["Start_Date"].ToString(),
                        Global.dal.SQLReader["End_Date"].ToString(),
                        Global.dal.SQLReader["Status"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string ContactAddress
        {
            get { return contactAddress; }
            set { contactAddress = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string EmpLocation
        {
            get { return empLocation; }
            set { empLocation = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
    }
}
