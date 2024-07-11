using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    public partial class EmployeesFrm : Form
    {
        bool AddEmp = false;
        public EmployeesFrm()
        {
            InitializeComponent();
        }

        private void EmployeesFrm_Load(object sender, EventArgs e)
        {
            PopulateEmpUC();
            CheckUpdateBTN();
        }

        private void CheckUpdateBTN()
        {
            if (EmpID_LBL.Text == "####")
                UpdateEmployee_CMD.Enabled = false;
            else
                UpdateEmployee_CMD.Enabled = true;
        }
        
        private void GetEmpDetails(string EmpNo)
        {
            Global.Emp.GetEmpDetails(EmpNo);
            EmpID_LBL.Text = EmpID_lbl_2.Text = Global.Emp.EmployeeID;
            FullNameEmp_LBL.Text = FullName_LBL_2.Text = Global.Emp.FullName;
            AddressEmp_LBL.Text = Address_Emp_lbl_2.Text = Global.Emp.ContactAddress;
            EmailEmp_LBL.Text = EmailEmp_lbl_2.Text = Global.Emp.EmailAddress;
            NumberEmp_LBL.Text = NumberEmp_lbl_2.Text = Global.Emp.ContactNumber;
            LocationEmp_LBL.Text = LocationEmp_lbl_2.Text = Global.Emp.EmpLocation;
        }

        private void PopulateEmpUC()
        {

            int count = 0;
            string getCount = "SELECT COUNT(*) FROM employee";
            count = Global.dal.MyExecuteScaler(getCount);

            string getCustDetails = ("SELECT * FROM employee;");
            EmpControlsPanel_FLP.Controls.Clear();
            Global.dal.MyExecuteReader(getCustDetails);

            EmpCount_LBL.Text = count.ToString();

            try
            {

                while (Global.dal.SQLReader.Read())
                {
                    EmpUC empUC = new EmpUC();

                    empUC.EmpID = Global.dal.SQLReader["Employee_ID"].ToString();
                    empUC.EmpName = Global.dal.SQLReader["Full_Name"].ToString();

                    empUC.Click += (sender, args) =>
                    {
                        GetEmpDetails(empUC.EmpID);
                        Global.Emp.LoadEmpJobs(EmpJobs_DGV, empUC.EmpID);
                        CheckUpdateBTN();
                    };

                    if (EmpControlsPanel_FLP.Controls.Count < 0)
                        EmpControlsPanel_FLP.Controls.Clear();
                    else
                        EmpControlsPanel_FLP.Controls.Add(empUC);
                }
            }
            catch
            {

            }
        }

        private void SearchBoxTxt_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            string getCount = "SELECT COUNT(*) FROM employee";
            count = Global.dal.MyExecuteScaler(getCount);

            string getCustDetails = ("SELECT * FROM employee WHERE CONCAT(Employee_ID, Full_Name) like'%" + SearchBoxTxt.Text + "%';");
            EmpControlsPanel_FLP.Controls.Clear();
            Global.dal.MyExecuteReader(getCustDetails);

            EmpCount_LBL.Text = count.ToString();

            try
            {

                while (Global.dal.SQLReader.Read())
                {
                    EmpUC empUC = new EmpUC();

                    empUC.EmpID = Global.dal.SQLReader["Employee_ID"].ToString();
                    empUC.EmpName = Global.dal.SQLReader["Full_Name"].ToString();

                    empUC.Click += (sender_1, args) =>
                    {
                        GetEmpDetails(empUC.EmpID);
                        Global.Emp.LoadEmpJobs(EmpJobs_DGV, empUC.EmpID);
                        CheckUpdateBTN();
                    };

                    if (EmpControlsPanel_FLP.Controls.Count < 0)
                        EmpControlsPanel_FLP.Controls.Clear();
                    else
                        EmpControlsPanel_FLP.Controls.Add(empUC);
                }
            }
            catch
            {

            }
        }

        private void BackEmpForm_CMD_Click(object sender, EventArgs e)
        {
            EmployeesTC.SelectedTab = EmpHomeTP;
        }

        private void AddEmp_BTN_Click(object sender, EventArgs e)
        {
            AddEmp = true;
            ClearControls();
            EmployeesTC.SelectedTab = EmpDetailsTP;
        }

        private void AddEmpSave_CMD_Click(object sender, EventArgs e)
        {
            if (AddEmp == true)
            {
                Global.Emp.EmployeeID = EmpID_TXT.Text;
                Global.Emp.FullName = EmpFullName_TXT.Text;
                Global.Emp.EmailAddress = EmpEmail_TXT.Text;
                Global.Emp.ContactAddress = EmpAddress_TXT.Text;
                Global.Emp.ContactNumber = EmpNumber_TXT.Text;
                Global.Emp.EmpLocation = EmpLocation_TXT.Text;

                Global.Emp.AddEmployee();
                GetEmpDetails(EmpID_lbl_2.Text);
                Global.Emp.LoadEmpJobs(EmpJobs_DGV, EmpID_lbl_2.Text);
            }
            else if (AddEmp == false)
            {
                Global.Emp.EmployeeID = EmpID_TXT.Text;
                Global.Emp.FullName = EmpFullName_TXT.Text;
                Global.Emp.EmailAddress = EmpEmail_TXT.Text;
                Global.Emp.ContactAddress = EmpAddress_TXT.Text;
                Global.Emp.ContactNumber = EmpNumber_TXT.Text;
                Global.Emp.EmpLocation = EmpLocation_TXT.Text;

                Global.Emp.UpdateEmployee();
                GetEmpDetails(EmpID_lbl_2.Text);
                Global.Emp.LoadEmpJobs(EmpJobs_DGV, EmpID_lbl_2.Text);
            }
        }

        private void NewEmployee_CMD_Click(object sender, EventArgs e)
        {
            AddEmp = true;
            ClearControls();
            EmpID_lbl_2.Text = "####";
            NumberEmp_lbl_2.Text = "####";
            LocationEmp_lbl_2.Text = "####";
            EmailEmp_lbl_2.Text = "####";
            Address_Emp_lbl_2.Text = "####";
            FullName_LBL_2.Text = "####";

            EmployeesTC.SelectedTab = EmpDetailsTP;
        }

        private void ClearControls()
        {
            EmpID_TXT.Text = ""; 
            EmpNumber_TXT.Text = ""; 
            EmpFullName_TXT.Text = "";
            EmpAddress_TXT.Text = "";
            EmpEmail_TXT.Text = "";
            EmpLocation_TXT.Text = "";
        }

        private void UpdateEmployee_CMD_Click(object sender, EventArgs e)
        {
            AddEmp = false;
            if (EmpID_LBL.Text == "####")
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Please Select Employee", "Error", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Error);
            }
            else
            {
                //GetEmpDetails(EmpID_LBL.Text);
                EmpID_TXT.Text = EmpID_LBL.Text;
                EmpNumber_TXT.Text = NumberEmp_LBL.Text;
                EmpFullName_TXT.Text = FullNameEmp_LBL.Text;
                EmpAddress_TXT.Text = AddressEmp_LBL.Text;
                EmpEmail_TXT.Text = EmailEmp_LBL.Text;
                EmpLocation_TXT.Text = LocationEmp_LBL.Text;

                EmpID_TXT.Enabled = false;

                EmployeesTC.SelectedTab = EmpDetailsTP;
            }
            
        }
    }
}
