using System;
using System.Windows.Forms;
using Siticone.Desktop.UI.WinForms;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace IBMSystem
{
    class Statement
    {
        private string statementNo;
        private string billCode;
        private string accNo;
        private int consumption;
        private double dueTotal;
        private int totalPayments;
        private double balance;
        private string date;
        private string month;
        private string bbl;
        private string status;

        public string GenerateStateNo()
        {
            StatementNo = "";
          
            int count = 0;
            string SQL = "SELECT COUNT(Statement_No) FROM statement";
            count = Global.dal.MyExecuteScaler(SQL);
            count = count + 1;

            StatementNo = "SN/" + count.ToString();
            return StatementNo;
        }

        public void AddStatement(string AccountNo, string BCode)
        {
            string SQL = ("INSERT INTO statement VALUES ('" + StatementNo + "','" + AccountNo + "', '" + BCode + "', " + Consumption + ", " + DueTotal + ", " + TotalPayments + ", " + Balance + ", '" + Date + "', '" + Month + "', '" + Status + "')");
            Global.dal.MyExecute(SQL);
        }
        public void LoadShortStatement(SiticoneDataGridView DGV, string AccountNO)
        {
            try
            {
                string SQL = ("SELECT * FROM statement WHERE Account_No='"+ AccountNO +"';");
                DGV.Rows.Clear();
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    DGV.Rows.Add(
                    new object[]
                    {
                        Global.dal.SQLReader["Statement_No"].ToString(),
                        Global.dal.SQLReader["Bill_Code"].ToString(),
                        Global.dal.SQLReader["Due_Total"].ToString(),
                        Global.dal.SQLReader["Date"].ToString().Split(' ')[0]
                    });
                }
                if (DGV.Rows.Count < 1)
                {
                    MessageBox.Show("Details unavailable", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("" + EX.Message);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        public void LoadChart(Chart chart, string AccNo)
        {
            string SQL = ("SELECT SUM(Consumption) AS Consumption, Month FROM statement WHERE Account_No='" + AccNo + "' AND Status='Reading' GROUP BY Month;");
            chart.Series["Consumption"].Points.Clear();
            Global.dal.MyExecuteReader(SQL);

            while (Global.dal.SQLReader.Read())
            {
                chart.Series["Consumption"].Points.AddXY(Global.dal.SQLReader["Month"].ToString(), Global.dal.SQLReader["Consumption"].ToString());
            }
        }

        public void GetStateCode(SiticoneDataGridView DGVStatement)
        {
            DataGridViewCell DGV_Cell = null;
            foreach (DataGridViewCell Selected_DGV_Cell in DGVStatement.SelectedCells)
            {
                DGV_Cell = Selected_DGV_Cell;
                break;
            }
            if (DGV_Cell != null)
            {
                DataGridViewRow DGV_Row = DGV_Cell.OwningRow;
                StatementNo = DGV_Row.Cells[0].Value.ToString();             
            }
        }

        public void FullStatement(DataGridView DGV, string AccNo)
        {
            string SQL = ("SELECT * FROM statement WHERE Account_No='" + AccNo + "' ORDER BY Date;");
            LoadDetails(DGV, SQL);
            if (DGV.Rows.Count < 1)
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("No any Statement \n Has Been Made", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);

            }
        }

        
        public void ViewStatement(SiticoneDataGridView DGV, string No)
        {
            string SQL = ("SELECT * FROM statement WHERE Statement_No='" + No + "';");
            LoadDetails(DGV, SQL);
            if (DGV.Rows.Count < 1)
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("No any Statement \n Has Been Made", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);

            }
        }

        private void LoadDetails(DataGridView DGV, string SQL)
        {
            try
            {
                DGV.Rows.Clear();
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    DGV.Rows.Add(
                    new object[]
                    {
                        Global.dal.SQLReader["Statement_No"].ToString(),
                        Global.dal.SQLReader["Date"].ToString().Split(' ')[0],
                        Global.dal.SQLReader["Bill_Code"].ToString(),
                        Global.dal.SQLReader["Consumption"].ToString(),
                        Global.dal.SQLReader["Due_Total"].ToString(),
                        Global.dal.SQLReader["Total_Payments"].ToString(),
                        Global.dal.SQLReader["Balance"].ToString(),

                    });

                    BBL = Global.dal.SQLReader["Balance"].ToString();
                }
                if (DGV.Rows.Count < 1)
                {
                    MessageBox.Show("Details unavailable", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("" + EX.Message);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        public string StatementNo
        {
            get { return statementNo; }
            set { statementNo = value; }
        }

        public string BillCode
        {
            get { return billCode; }
            set {billCode = value; }
        }

        public string AccNo
        {
            get { return accNo; }
            set { accNo = value; }
        }

        public int Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }

        public double DueTotal
        {
            get { return dueTotal; }
            set { dueTotal = value; }
        }

        public int TotalPayments
        {
            get { return totalPayments; }
            set { totalPayments = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public string BBL
        {
            get { return bbl; }
            set { bbl = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
