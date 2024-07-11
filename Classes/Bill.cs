using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.Desktop.UI.WinForms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IBMSystem
{
    class Bill
    {
        private string billCode;
        private int balBroughtForward;
        private int current_bill;
        private int meterReadingCharge;
        private int meterRentalCharge;
        private int waterChargeConsum;
        private int rdgs;
        private int waterConsumption;
        private int monthlySubtotal;
        private int vat;
        private string issuedDate;
        private string dueDate;
        private int dueDays;
        private string billStatus;
        private int dueTotal;
        private string accNo_FK;

        public bool GetCurrentBill(string AccID)
        {
            bool getBool = false;
            string SQL = ("SELECT * FROM invoice WHERE Account_No='"+ AccID +"' AND Bill_Status='Current';");
            Global.dal.MyExecuteReader(SQL);
            int count = 0;
            //MessageBox.Show(" " + count);
            while (Global.dal.SQLReader.Read())
            {
                
                count = count + 1;
                
            }
            if (count == 1)
            {
                GetDetails();

                getBool = true;
            }
            else if (count == 0)
            {
                SQL = ("SELECT * FROM invoice WHERE Account_No='" + AccID + "' AND Bill_Status='Overdue';");
                Global.dal.MyExecuteReader(SQL);
                count = 0;
                while (Global.dal.SQLReader.Read())
                {
                    count = count + 1;
                    
                }
                if (count == 1)
                {
                    GetDetails();
                    getBool = true;
                }
                else if (count == 0)
                {
                    SQL = ("SELECT * FROM invoice WHERE Account_No='" + AccID + "' AND Bill_Status='Paid';");
                    Global.dal.MyExecuteReader(SQL);
                    count = 0;
                    while (Global.dal.SQLReader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        GetDetails();
                        getBool = true;
                    }
                    else if (count == 0)
                    {
                        getBool = false;
                    }

                }
            }
            return getBool;
        }

        private void GetDetails()
        {
            BillCode = Global.dal.SQLReader["Bill_Code"].ToString();
            BalBroughtForward = Int32.Parse(Global.dal.SQLReader["Bal_Brought_Forward"].ToString());
            MeterReadingCharge = Int32.Parse(Global.dal.SQLReader["Meter_Reading_Chrg"].ToString());
            MeterRentalCharge = Int32.Parse(Global.dal.SQLReader["Meter_Rental_Chrg"].ToString());
            WaterChargeConsum = Int32.Parse(Global.dal.SQLReader["Water_Chrg_Consum"].ToString());
            Rdgs = Int32.Parse(Global.dal.SQLReader["Rdgs"].ToString());
            WaterConsumption = Int32.Parse(Global.dal.SQLReader["Water_Consumption"].ToString());
            MonthlySubTotal = Int32.Parse(Global.dal.SQLReader["Month_Subtotal_liable"].ToString());
            VAT = Int32.Parse(Global.dal.SQLReader["VAT"].ToString());
            IssuedDate = Global.dal.SQLReader["Issued_Date"].ToString().Split(' ')[0];
            DueDate = Global.dal.SQLReader["Due_Date"].ToString().Split(' ')[0];
            DueDays = Int32.Parse(Global.dal.SQLReader["Due_Days"].ToString());
            CurrentBill = Int32.Parse(Global.dal.SQLReader["Current_Bill"].ToString());
            BillStatus = Global.dal.SQLReader["Bill_Status"].ToString();
            DueTotal = Int32.Parse(Global.dal.SQLReader["Due_Total"].ToString());
        }

        public void CountDownDays()
        {
            List<string> bill_Codes = new List<string>();
            string SQL = "SELECT COUNT(*) FROM invoice WHERE Bill_Status='Current'";
            int count = 0;
            count = Global.dal.MyExecuteScaler(SQL);

            SQL = "SELECT * FROM invoice WHERE Bill_Status='Current'";
            Global.dal.MyExecuteReader(SQL);

            while (Global.dal.SQLReader.Read())
            {
                bill_Codes.Add(Global.dal.SQLReader["Bill_Code"].ToString());
            }
            for (int i = 0; i < count; i++)
            {
                SQL = "SELECT * FROM invoice WHERE Bill_Code='" + bill_Codes[i] + "'";
                Global.dal.MyExecuteReader(SQL);
                while (Global.dal.SQLReader.Read())
                {
                    DateTime Today = DateTime.Now;
                    DateTime DueDate = DateTime.Parse(Global.dal.SQLReader["Due_Date"].ToString());

                    TimeSpan ts = DueDate - Today;
                    int days = ts.Days + 1;

                    SQL = "UPDATE invoice SET Due_Days=" + days + " WHERE Bill_Code='" + bill_Codes[i] + "'";
                    Global.dal.MyExecute(SQL);

                    if (days == 3)
                    {
                        SQL = "SELECT * FROM check_if_email_sent WHERE Bill_Code='" + bill_Codes[i] + "'";
                        Global.dal.MyExecuteReader(SQL);
                        int EmailCount = 0;
                        while (Global.dal.SQLReader.Read())
                        {
                            EmailCount = EmailCount + 1;
                        }
                        if (EmailCount == 1)
                        {
                            MessageBox.Show("Email Already Sent Of Order=" + bill_Codes[i]);
                        }
                        else if (EmailCount == 0)
                        {
                            SQL = "SELECT c.Email_Address, c.Contact_No FROM customer c, account a, invoice i WHERE c.CustomerID=a.CustomerID AND a.Account_No=i.Account_No AND i.Bill_Code='" + bill_Codes[i] + "';";
                            Global.dal.MyExecuteReader(SQL);

                            while (Global.dal.SQLReader.Read())
                            {

                                Global.email.To = Global.dal.SQLReader["Email_Address"].ToString();
                                MessageBox.Show("" + Global.email.To);
                                Global.sms.To = Global.dal.SQLReader["Contact_No"].ToString();
                                Global.email.CC = "";
                                Global.email.Subject = "REMAINDER";
                                Global.email.Body = "You Have 3 days left to Due date\nPlease Pay Your bill in time\nTo Avoid inconviniences";
                              

                            }

                           Global.email.SendEmail();
                           Global.sms.SendSMS();

                           

                            SQL = "INSERT INTO check_if_email_sent VALUES('" + bill_Codes[i] + "', 'Already Sent');";
                            Global.dal.MyExecute(SQL);
                            Global.dal.CloseSQLConnection();
                        }
                    }
                    else if (days <= 0 )
                    {
                        SQL = "UPDATE invoice SET Bill_Status='Overdue' WHERE Bill_Code='" + bill_Codes[i] + "'";
                        Global.dal.MyExecuteReader(SQL);
                    }
                }
            }
        }

        public void UpdateOverdue(string billCode)
        {

            string SQL = "SELECT Due_Date FROM invoice WHERE Bill_Code='" + billCode + "';";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                DateTime Today = DateTime.Now;
                DateTime DueDate = DateTime.Parse(Global.dal.SQLReader["Due_Date"].ToString());

                TimeSpan ts = DueDate - Today;
                int days = ts.Days;

                SQL = "UPDATE invoice SET Due_Days=" + days + " WHERE Bill_Code='" + billCode + "';";
                Global.dal.MyExecute(SQL);
            }

        }

        public void GetOverdues(DataGridView DGV, Label LBL, Label LBL2, Label All_lbl, int CMB)
        {    
            int GetCount = 0;
            string SQL = "SELECT COUNT(*) FROM invoice WHERE Bill_Status='Overdue' AND MONTH(Issued_Date)=" + CMB + ";";
            GetCount = Global.dal.MyExecuteScaler(SQL);
            LBL.Text = LBL2.Text = GetCount.ToString();

            SQL = "SELECT COUNT(*) FROM invoice WHERE MONTH(Issued_Date)=" + CMB + ";";
            All_lbl.Text = Global.dal.MyExecuteScaler(SQL).ToString();

            string SQL2 = "SELECT * FROM invoice WHERE Bill_Status='Overdue' AND MONTH(Issued_Date)=" + CMB + ";";
            LoadDetails(DGV, SQL2);
        }

        public void SearchOverdue(DataGridView DGV, string txt)
        {
            string SQL = "SELECT * FROM invoice WHERE CONCAT(Account_No, Bill_Code) like'%" + txt + "%' AND Bill_Status='Overdue'";
            LoadDetails(DGV, SQL);
        }

        public void SearchDisconnect(DataGridView DGV, string txt)
        {
            //string SQL = "SELECT * FROM invoice WHERE CONCAT(Account_No, Bill_Code) like'%" + txt + "%' AND Bill_Status='Overdue'";
            string Query = "SELECT i.*, a.Status FROM invoice i, account a WHERE CONCAT (i.*, a.Status) AND a.Account_No=i.Account_No AND Status='Disconnected'";
            LoadDetails(DGV, Query);
        }

        public void GetDisconnected(DataGridView DGV, Label lbl, int CMB)
        {           
            int GetCount = 0;
            string SQL = "SELECT COUNT(i.Account_No) FROM account a, invoice i WHERE a.Account_No=i.Account_No AND a.Status='Disconnected' AND MONTH(Issued_Date)=" + CMB + ";";
            GetCount = Global.dal.MyExecuteScaler(SQL);
            //MessageBox.Show("" + GetCount);
            lbl.Text = GetCount.ToString();

            string Query = "SELECT i.*, a.Status FROM invoice i, account a WHERE a.Account_No=i.Account_No AND a.Status='Disconnected'";
            LoadDetails(DGV, Query);
        }

        public void FullReport(DataGridView DGV, string From, string To)
        {
            string SQL = ("SELECT * FROM invoice WHERE Issued_Date BETWEEN '" + From + "' AND '" + To + "';");
            LoadDetails(DGV, SQL);
            if (DGV.Rows.Count < 1)
                MessageBox.Show("No Orders Availables For This Period", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private static void LoadDetails(DataGridView DGV, string SQL)
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
                    Global.dal.SQLReader["Account_No"].ToString(),
                    Global.dal.SQLReader["Bill_Code"].ToString(),
                    Global.dal.SQLReader["Issued_Date"].ToString(),
                    string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(Global.dal.SQLReader["Due_Total"].ToString())),
                    Global.dal.SQLReader["Due_Date"].ToString(),
                    Global.dal.SQLReader["Bill_Status"].ToString()
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

        public void LoadMainGraph(Chart chart, ComboBox CMB)
        { 
            try
            {
                chart.Series["Consumption"].Points.Clear();
                chart.Series["Amount"].Points.Clear();
                chart.Series["VAT"].Points.Clear();

                string SQL = ("SELECT MONTH(Issued_Date) as Month, SUM(Water_Chrg_Consum) as Consumption, SUM(Due_Total) as Amount, SUM(VAT) as VAT FROM invoice WHERE YEAR(Issued_Date)=" + CMB.Text + " GROUP BY MONTH(Issued_Date)");
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    chart.Series["Consumption"].Points.AddXY(Global.dal.SQLReader.GetString("Month"), Global.dal.SQLReader.GetInt32("Consumption"));
                    chart.Series["Amount"].Points.AddXY(Global.dal.SQLReader.GetString("Month"), Global.dal.SQLReader.GetInt32("Amount"));
                    chart.Series["VAT"].Points.AddXY(Global.dal.SQLReader.GetString("Month"), Global.dal.SQLReader.GetInt32("VAT"));
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(" " + EX.Message);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        public void CalculateStatisticalSummary(Label All_lbl, Label Overdue_lbl, Label Disconn_lbl, Label Undiscon_lbl, int CMB, SiticoneProgressBar Pbar1, SiticoneProgressBar Pbar2, SiticoneProgressBar Pbar3, SiticoneProgressBar Pbar4)
        {
            try
            {
                int All = 0, Overdue = 0, Disconn = 0, Undisconn = 0;
                int AllPG = 0, OverduePG = 0, DisconnPG = 0, UndisconnPG = 0;
                string SQL = "SELECT COUNT(*) FROM invoice WHERE MONTH(Issued_Date)=" + CMB + ";";
                All = Int32.Parse(Global.dal.MyExecuteScaler(SQL).ToString());

                SQL = "SELECT COUNT(*) FROM invoice WHERE Bill_Status='Overdue' AND MONTH(Issued_Date)=" + CMB + ";";
                Overdue = Undisconn = Int32.Parse(Global.dal.MyExecuteScaler(SQL).ToString());

                SQL = "SELECT COUNT(*) FROM invoice WHERE Bill_Status='Disconnected' AND MONTH(Issued_Date)=" + CMB + ";";
                Disconn = Int32.Parse(Global.dal.MyExecuteScaler(SQL).ToString());

                // All Bills Percentage
                AllPG = 100; All_lbl.Text = AllPG.ToString();
                Pbar1.Value = AllPG;
                All_lbl.Text += "%";

                // Overdue Bills Percentage
                //MessageBox.Show("" + Overdue + " " + All);
                OverduePG = (Overdue * 100) / All; Overdue_lbl.Text = OverduePG.ToString();

                Pbar2.Value = OverduePG;
                Overdue_lbl.Text += "%";

                // Undisconnected Accounts Percentage
                UndisconnPG = Undisconn * 100 / All; Undiscon_lbl.Text = OverduePG.ToString();
                Pbar3.Value = UndisconnPG;
                Undiscon_lbl.Text += "%";

                // Disconnected Accounts Percentage
                DisconnPG = (Disconn / All) * 100; Disconn_lbl.Text = DisconnPG.ToString();
                Pbar4.Value = DisconnPG;
                Disconn_lbl.Text += "%";
            }
            catch
            {
                CustomMB_Frm MB = new CustomMB_Frm();
                MB.show("No Data Available\nFor This Month", "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
            }



            //string str = "abc";
            //str = str.Insert(2, "XYZ");
        }

        public string BillCode
        {
            get { return billCode; }
            set { billCode = value; }
        }

        public int BalBroughtForward
        {
            get { return balBroughtForward; }
            set { balBroughtForward = value; }
        }

        public int CurrentBill
        {
            get { return current_bill; }
            set { current_bill = value; }
        }

        public int MeterReadingCharge
        {
            get { return meterReadingCharge; }
            set { meterReadingCharge = value; }
        }

        public int MeterRentalCharge
        {
            get { return meterRentalCharge; }
            set { meterRentalCharge = value; }
        }

        public int WaterChargeConsum
        {
            get { return waterChargeConsum; }
            set { waterChargeConsum = value; }
        }

        public int Rdgs
        {
            get { return rdgs; }
            set { rdgs = value; }
        }

        public int MonthlySubTotal
        {
            get { return monthlySubtotal; }
            set { monthlySubtotal = value; }
        }

        public int VAT
        {
            get { return vat; }
            set { vat = value; }
        }

        public string IssuedDate
        {
            get { return issuedDate; }
            set { issuedDate = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public int DueDays
        {
            get { return dueDays; }
            set { dueDays = value; }
        }

        public string BillStatus
        {
            get { return billStatus; }
            set { billStatus = value; }
        }

        public int DueTotal
        {
            get { return dueTotal; }
            set { dueTotal = value; }
        }

        public string AccNo_FK
        {
            get { return accNo_FK; }
            set { accNo_FK = value; }
        }

        public int WaterConsumption
        {
            get { return waterConsumption; }
            set { waterConsumption = value; }
        }

    }
}
