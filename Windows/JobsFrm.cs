using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    public partial class JobsFrm : Form
    {
        public JobsFrm()
        {
            InitializeComponent();
        }

        private void JobsFrm_Load(object sender, EventArgs e)
        {
            Global.job.Fill_BillCode(BillCode_CMB);
            Global.job.Fill_EmployeeID(EmployeeCMB);
            Global.job.LoadJobs(JobDetails_DGV);
            Global.job.Status = Status_TXT.Text = "Uncomplete";
        }
        private void ClearControls()
        {
            JobID_TXT.Text = ""; Location_TXT.Text = ""; Location_LBL.Text = "####";
            Description_TXT.Text = ""; Duration_LBL.Text = "####"; StartDate_DTP.Text = DateTime.Today.ToString();
            EndDate_DTP.Text = DateTime.Today.ToString(); AccountNo_LBL.Text = "####"; Amount_LBL.Text = "####";
            Employee_LBL.Text = "####"; EmployeeCMB.Text = "Choose Employee"; BillCode_CMB.Text = "Choose Bill";
            Cart_DGV.Rows.Clear();
        }
        public void PrintSchedule()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Working Schedule";
            printer.SubTitle = "Date................." + DateTime.Today.ToShortDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Blantyre Water Board";
            printer.FooterSpacing = 15;

            printer.PrintDataGridView(JobDetails_DGV);
        }
        private void Onclick(object sender, EventArgs e)
        {
            sliderPNL.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            sliderPNL.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;
        }

        private void Schedule_CMD_Click(object sender, EventArgs e)
        {
            Onclick(Schedule_CMD, e);
            JobsTC.SelectedTab = ScheduleTP;
            Global.job.LoadJobs(JobDetails_DGV);
        }

        private void AssigningJobs_CMD_Click(object sender, EventArgs e)
        {
            Onclick(AssigningJobs_CMD, e);
            JobsTC.SelectedTab = AssigningTP;
        }

        private void SchedulePDF_CMD_Click(object sender, EventArgs e)
        {
            PrintSchedule();
        }

        private bool ValidateBill()
        {
            bool returnValue; returnValue = false;
            string SQL = "SELECT * FROM cart WHERE Bill_Code='" + BillCode_CMB.Text + "'";
            Global.dal.MyExecuteReader(SQL);
            int count = 0;

            while(Global.dal.SQLReader.Read())
            {
                count = count + 1;
            }
            if (count == 0)
            {
                returnValue = true;
            }
            else if (count >= 1)
            {
                returnValue = false;
            }
            return returnValue;
        }

        private void AddToJob_CMD_Click(object sender, EventArgs e)
        {
            if (JobID_TXT.Text != "")
            {
                if (ValidateBill() == true)
                {

                    Global.cart.JobID = JobID_TXT.Text;
                    Global.cart.Bill_Code = BillCode_CMB.Text;
                    Global.cart.Amount = Int32.Parse(Amount_LBL.Text);
                    Global.cart.Account_No = AccountNo_LBL.Text;

                    Global.cart.AddToCart();
                    Global.cart.LoadItems(Cart_DGV);
                }
                else
                {
                    MessageBox.Show("@@@");
                }
               
                
            }
            else
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Please Enter Job ID", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);

            }

        }

        private void BillCode_CMB_SelectedValueChanged(object sender, EventArgs e)
        {
                       
            string SQL = "SELECT Account_No, Due_Total FROM invoice WHERE Bill_Code='" + BillCode_CMB.SelectedItem + "'; ";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                AccountNo_LBL.Text = Global.dal.SQLReader["Account_No"].ToString();
                Amount_LBL.Text = Global.dal.SQLReader["Due_Total"].ToString();
            }

            SQL = "SELECT Account_Location FROM account WHERE Account_No='" + AccountNo_LBL.Text + "'; ";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {               
                Location_LBL.Text = Global.dal.SQLReader["Account_Location"].ToString();
            }

        }


        private void EmployeeCMB_SelectedValueChanged(object sender, EventArgs e)
        {
            string SQL = "SELECT Full_Name FROM employee WHERE Employee_ID='" + EmployeeCMB.SelectedItem + "'; ";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                Employee_LBL.Text = Global.dal.SQLReader["Full_Name"].ToString();
            }
        }

        private void RemoveBill_CMD_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in Cart_DGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                string selectedID = row.Cells[0].Value.ToString();
                Global.cart.RemoveFromCart(selectedID);
                Global.cart.LoadItems(Cart_DGV);
            }
        }

        private void EndDate_DTP_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(StartDate_DTP.Text);
            DateTime endDate = DateTime.Parse(EndDate_DTP.Text);

            TimeSpan ts = endDate - startDate;
            int days = ts.Days;

            Duration_LBL.Text = days.ToString();
        }

        private void StartDate_DTP_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(StartDate_DTP.Text);
            DateTime endDate = DateTime.Parse(EndDate_DTP.Text);

            TimeSpan ts = endDate - startDate;
            int days = ts.Days;

            Duration_LBL.Text = days.ToString();
        }

        private void SaveCMD_Click(object sender, EventArgs e)
        {
            
            if (JobID_TXT.Text == "" || Location_TXT.Text == "" || Status_TXT.Text == "" || Description_TXT.Text == "" ||
               Duration_LBL.Text == "####" || Employee_LBL.Text == "####")
            {

                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("One Filled is Empty", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
            }
            else
            {

                Global.job.JobID = JobID_TXT.Text;
                Global.job.Location = Location_TXT.Text;

                Global.job.StartDate = StartDate_DTP.Text;

                Global.job.EndDate = EndDate_DTP.Text;
                Global.job.Duration = Int32.Parse(Duration_LBL.Text);
                
                Global.job.JobType = Description_TXT.Text;

                Global.job.AddJob();
                if (Global.schedule.GetDataFromGrid(Cart_DGV, EmployeeCMB.Text) == true)
                {
                    Global.cart.DeleteCart();
                    CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                    CustomMessageBox.show("Job Created Successfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
                    ClearControls();
                    Global.job.Fill_BillCode(BillCode_CMB);
                    Global.job.Fill_EmployeeID(EmployeeCMB);
                }
               
            }
        }

        private void JobDetails_DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JobsTC.SelectedTab = TaskTP;
            Global.job.ViewJobDetails(JobDetails_DGV, TaskDetailsDGV);

            EmpNameTSK_LBL.Text = Global.job.EmpName;
            JobIDTSK_LBL.Text = Global.job.JobID;
            JobTypeTSK_LBL.Text = Global.job.JobType;
            StartDateTSK_LBL.Text = Global.job.StartDate;
            EndDateTSK_LBL.Text = Global.job.EndDate;
            DurationTSK_LBL.Text = Global.job.Duration.ToString();
            LocationTSK_LBL.Text = Global.job.Location;
            StatusTSK_LBL.Text = Global.job.Status;
            NoTSK_LBL.Text = Global.job.TaskCount.ToString();
        }

        private void GetDocumentPage()
        {
            PrintDialog printdialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printdialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PD_PrintPage);
            DialogResult result = printdialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string[] parameter;
            parameter = new string[24];
            parameter[0] = StartDateTSK_LBL.Text;
            parameter[1] = JobIDTSK_LBL.Text;
            parameter[2] = JobTypeTSK_LBL.Text;
            parameter[3] = StartDateTSK_LBL.Text;
            parameter[4] = EndDateTSK_LBL.Text;
            parameter[5] = DurationTSK_LBL.Text;
            parameter[6] = LocationTSK_LBL.Text;
            parameter[7] = StatusTSK_LBL.Text;
            parameter[8] = NoTSK_LBL.Text;
            parameter[9] = Global.job.JobID;
            parameter[10] = EmpNameTSK_LBL.Text;

            Global.printer.PrintingTaskDetails(e, parameter);
        }

        private void pdfTSK_CMD_Click(object sender, EventArgs e)
        {
            //GetDocumentPage();
            PreviewDocument_PPD.Document = PrintDocument_PD;
            PreviewDocument_PPD.ShowDialog();
        }

        private void TSKD_update_ToolStrip_Click(object sender, EventArgs e)
        {
            Global.job.UpdateTaskDeatails(TaskDetailsDGV, JobIDTSK_LBL.Text);
        }

        private void UpdateTSK_CMD_Click(object sender, EventArgs e)
        {
            if (Global.job.UpdateJob(TaskDetailsDGV) == true)
            {
                string SQL = "UPDATE job SET Status='Complete' WHERE Job_ID='" + JobIDTSK_LBL.Text + "';";
                Global.dal.MyExecute(SQL);
                SQL = "DELETE FROM schedule WHERE Job_ID='" + JobIDTSK_LBL.Text + "';";
                Global.dal.MyExecute(SQL);
            }
            if (Global.job.UpdateJob(TaskDetailsDGV) == false)
            {
                CustomMB_Frm MB = new CustomMB_Frm();
                MB.show("Failed, Some task are\nIncomplete", "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
            }
        }
    }
}
