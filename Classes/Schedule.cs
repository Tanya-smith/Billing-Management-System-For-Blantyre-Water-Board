using System;
using System.Windows.Forms;

namespace IBMSystem
{
    class Schedule
    {
        private int schedule_No;
        private string jobID;
        private string bill_Code;
        private string account_No;
        private int amount;
        private string employee_ID;
        private string task_status;

        public void AddSchedule()
        {
            try
            {
                string SQL = "INSERT INTO schedule (Job_ID, Bill_Code, Account_No, Amount, Employee_ID, Task_Status) VALUES ('" + JobID + "', '" + Bill_Code + "', '" + Account_No + "', " + Amount + ", '" + Employee_ID + "', '" + TaskStatus + "')";
                Global.dal.MyExecute(SQL);
            }
            catch(Exception Ex)
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Error" + Ex.Message, "Error", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Error);

            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        public bool GetDataFromGrid(DataGridView dgv, string EMP_ID)
        {
            bool getValue; getValue = false;

            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                JobID = dgv.Rows[i].Cells[1].Value.ToString();
                Bill_Code = dgv.Rows[i].Cells[2].Value.ToString();
                Account_No = dgv.Rows[i].Cells[3].Value.ToString();
                Amount = Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString());
                Employee_ID = EMP_ID;
                TaskStatus = "Uncomplete";

                AddSchedule();
                getValue = true;
            }

            return getValue;
        }

        public int Schedule_No
        {
            get { return schedule_No; }
            set { schedule_No = value; }
        }

        public string JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }

        public string Bill_Code
        {
            get { return bill_Code; }
            set { bill_Code = value; }
        }

        public string Account_No
        {
            get { return account_No; }
            set { account_No = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Employee_ID
        {
            get { return employee_ID; }
            set { employee_ID = value; }
        }

        public string TaskStatus
        {
            get { return task_status; }
            set { task_status = value; }
        }
    }
}
