using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    class Job
    {
        private string jobID;
        private string jobType;
        private string startDate;
        private string endDate;
        private int duration;
        private string location;
        private string status;
        private string empName;
        private int taskCount;

        public void AddJob()
        {
            string SQL = "INSERT INTO job VALUES ('" + JobID + "', '" + JobType + "', '" + StartDate + "', '" + EndDate + "', " + Duration + ", '" + Location + "', '" + Status + "')";
            if (Global.dal.MyExecute(SQL) == true)
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Job Created Successfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);

            }
        }

        public bool UpdateJob(DataGridView dgv)
        {
            bool getValue; getValue = false;

            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                if (dgv.Rows[i].Cells[6].Value.ToString() != "Completed")
                {
                    getValue = false;
                    break;
                }
                if (dgv.Rows[i].Cells[6].Value.ToString() == "Completed")
                {
                    getValue = true;
                }                                
            }

            return getValue;
        }

        public void Fill_BillCode(ComboBox CMB)
        {
            List<string> bill_Codes = new List<string>();
            string Query = "SELECT COUNT(Bill_Code) FROM invoice WHERE Bill_Status='Overdue'";
            int count = 0;
            count = Global.dal.MyExecuteScaler(Query);

            string SQL = "SELECT Bill_Code FROM invoice WHERE Bill_Status='Overdue'";
            CMB.Items.Clear();
            Global.dal.MyExecuteReader(SQL);

            while (Global.dal.SQLReader.Read())
            {
                bill_Codes.Add(Global.dal.SQLReader["Bill_Code"].ToString());
                
            }
            for (int i = 0; i < count; i++)
            {
                SQL = "SELECT * FROM schedule WHERE Bill_Code='" + bill_Codes[i] + "'";
                Global.dal.MyExecuteReader(SQL);
                int getCount = 0;
                while (Global.dal.SQLReader.Read())
                {
                    getCount = getCount + 1;

                }
                if (getCount == 0)
                {
                       
                    CMB.Items.Add(bill_Codes[i].ToString());                                      
                }
            }
        }

        public void Fill_EmployeeID(ComboBox CMB)
        {
     
            List<string> empIDs = new List<string>();
            string SQL = "SELECT COUNT(Employee_ID) FROM employee";
            int count = 0;
            count = Global.dal.MyExecuteScaler(SQL);

            SQL = "SELECT Employee_ID FROM employee";
            CMB.Items.Clear();
            Global.dal.MyExecuteReader(SQL);

            while (Global.dal.SQLReader.Read())
            {
                empIDs.Add(Global.dal.SQLReader.GetString("Employee_ID"));
            }

            for (int i = 0; i < count; i++)
            {
                SQL = "SELECT * FROM schedule WHERE Employee_ID='" + empIDs[i] + "'";
                Global.dal.MyExecuteReader(SQL);
                int getCount = 0;
                while (Global.dal.SQLReader.Read())
                {
                    getCount = getCount + 1;

                }
                if (getCount == 0)
                {

                    CMB.Items.Add(empIDs[i].ToString());
                }
            }
        }
        public void UpdateTaskDeatails(DataGridView DGV, string jID)
        {
            string No, accNo;
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in DGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                No = row.Cells[0].Value.ToString();
                accNo = row.Cells[2].Value.ToString();
                string SQL = "UPDATE schedule SET Task_Status='Completed' WHERE Schedule_No='" + No + "';";
                Global.dal.MyExecute(SQL);

                SQL = "UPDATE account SET Status='Disconnected' WHERE Account_No='" + accNo + "';";
                Global.dal.MyExecute(SQL);
                LoadTask(DGV, jID);
            }
        }
        public void LoadTask(DataGridView dgvTask, string job_ID)
        {
            string SQL = "SELECT c.CustomerID, s.Schedule_No, s.Account_No, a.Meter_Number, s.Amount, s.Task_Status, c.Contact_Address FROM account a, customer c, schedule s WHERE c.CustomerID=a.CustomerID AND s.Account_No=a.Account_No AND s.Job_ID='" + job_ID + "';";
            try
            {
                dgvTask.Rows.Clear();
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    dgvTask.Rows.Add(
                    new object[]
                    {
                            Global.dal.SQLReader["Schedule_No"].ToString(),
                            Global.dal.SQLReader["CustomerID"].ToString(),
                            Global.dal.SQLReader["Account_No"].ToString(),
                            Global.dal.SQLReader["Meter_Number"].ToString(),
                            Global.dal.SQLReader["Amount"].ToString(),
                            Global.dal.SQLReader["Contact_Address"].ToString(),
                            Global.dal.SQLReader["Task_Status"].ToString(),
                    }

                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }
        public void ViewJobDetails(DataGridView dgv, DataGridView dgvTask)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dgv.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                
                this.JobID = row.Cells[0].Value.ToString();

                string SQL = "SELECT COUNT(Account_No) FROM schedule WHERE Job_ID='" + JobID + "';";
                TaskCount = Global.dal.MyExecuteScaler(SQL);

                this.EmpName = row.Cells[1].Value.ToString();
                this.StartDate = row.Cells[2].Value.ToString();
                this.EndDate = row.Cells[3].Value.ToString();
                this.Duration = Convert.ToInt32(row.Cells[4].Value.ToString());
                this.JobType = row.Cells[5].Value.ToString();
                this.Location = row.Cells[6].Value.ToString();
                this.Status = row.Cells[7].Value.ToString();

                SQL = "SELECT c.CustomerID, s.Schedule_No, s.Account_No, a.Meter_Number, s.Amount, s.Task_Status, c.Contact_Address FROM account a, customer c, schedule s WHERE c.CustomerID=a.CustomerID AND s.Account_No=a.Account_No AND s.Job_ID='" + JobID + "';";
                try
                {
                    dgvTask.Rows.Clear();
                    Global.dal.MyExecuteReader(SQL);

                    while (Global.dal.SQLReader.Read())
                    {
                        dgvTask.Rows.Add(
                        new object[]
                        {
                            Global.dal.SQLReader["Schedule_No"].ToString(),
                            Global.dal.SQLReader["CustomerID"].ToString(),
                            Global.dal.SQLReader["Account_No"].ToString(),
                            Global.dal.SQLReader["Meter_Number"].ToString(),
                            Global.dal.SQLReader["Amount"].ToString(),
                            Global.dal.SQLReader["Contact_Address"].ToString(),
                            Global.dal.SQLReader["Task_Status"].ToString(),
                        }

                        );
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
        }

        public void LoadJobs(DataGridView dgv)
        {
            string query = "SELECT j.Job_ID, j.Job_Type, j.Start_Date, j.End_Date, j.Duration, j.Location, j.Status, e.Full_Name FROM job j, employee e, schedule s WHERE j.Job_ID=s.Job_ID AND e.Employee_ID=s.Employee_ID GROUP BY j.Job_ID, e.Full_Name";
            try
            {
                dgv.Rows.Clear();
                Global.dal.MyExecuteReader(query);

                while (Global.dal.SQLReader.Read())
                {
                    dgv.Rows.Add(
                    new object[]
                    {
                        Global.dal.SQLReader["Job_ID"].ToString(),
                        Global.dal.SQLReader["Full_Name"].ToString(),
                        Global.dal.SQLReader["Start_Date"].ToString(),
                        Global.dal.SQLReader["End_Date"].ToString(),
                        Global.dal.SQLReader["Duration"].ToString(),
                        Global.dal.SQLReader["Job_Type"].ToString(),
                        Global.dal.SQLReader["Location"].ToString(),
                        Global.dal.SQLReader["Status"].ToString(),
                    }

                    );
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
        public string JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }

        public string JobType
        {
            get { return jobType; }
            set { jobType = value; }
        }

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        public int TaskCount
        {
            get { return taskCount; }
            set { taskCount = value; }
        }
    }
}
