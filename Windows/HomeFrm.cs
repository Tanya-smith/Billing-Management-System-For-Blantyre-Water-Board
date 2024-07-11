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
    public partial class HomeFrm : Form
    {
        public HomeFrm()
        {
            InitializeComponent();
        }

        private void HomeFrm_Load(object sender, EventArgs e)
        {
            GetCounts();
            LoadConsumptionChart(Year_CMB);
            LoadTaxChart(Year_CMB);
            LoadIncomeChart(Year_CMB);
            Global.bill.CalculateStatisticalSummary(AllPG_LBL, OverduePG_LBL, DisconnPG_LBL, UndisconnPG_LBL, GetMonthNumber(Month_CMB), All_Pbar, Overdue_Pbar, Undisconn_Pbar, Disconn_Pbar);
        }

        private int GetMonthNumber(ComboBox CMB)
        {
            int getValue = 0;
            if (CMB.Text == "January")
            {
                getValue = 1;
                return getValue;
            }
            else if (CMB.Text == "February")
            {
                getValue = 2;
                return getValue;
            }
            else if (CMB.Text == "March")
            {
                getValue = 3;
                return getValue;
            }
            else if (CMB.Text == "April")
            {
                getValue = 4;
                return getValue;
            }
            else if (CMB.Text == "May")
            {
                getValue = 5;
                return getValue;
            }
            else if (CMB.Text == "June")
            {
                getValue = 6;
                return getValue;
            }
            else if (CMB.Text == "July")
            {
                getValue = 7;
                return getValue;
            }
            else if (CMB.Text == "August")
            {
                getValue = 8;
                return getValue;
            }
            else if (CMB.Text == "September")
            {
                getValue = 9;
                return getValue;
            }
            else if (CMB.Text == "October")
            {
                getValue = 10;
                return getValue;
            }
            else if (CMB.Text == "November")
            {
                getValue = 11;
                return getValue;
            }
            else if (CMB.Text == "December")
            {
                getValue = 3;
                return getValue;
            }
            return getValue;
        }

        private void Onclick(object sender, EventArgs e)
        {
            slider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            slider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;
        }

        private void Consumption_CMD_Click(object sender, EventArgs e)
        {
            Onclick(Consumption_CMD, e);
            GraphTC.SelectedTab = ConsumptionTP;
        }

        private void Tax_CMD_Click(object sender, EventArgs e)
        {
            Onclick(Tax_CMD, e);
            GraphTC.SelectedTab = TaxTP;
        }

        private void Income_CMD_Click(object sender, EventArgs e)
        {
            Onclick(Income_CMD, e);
            GraphTC.SelectedTab = IncomeTP;
        }

        private void GetCounts()
        {
            string SQL = "SELECT COUNT(*) FROM account";
            AccCount_LBL.Text = Global.dal.MyExecuteScaler(SQL).ToString();

            SQL = ("SELECT COUNT(*) FROM employee");
            EmpCount_LBL.Text = Global.dal.MyExecuteScaler(SQL).ToString();

            string monthNo = DateTime.Now.ToString("MM");
            SQL = ("SELECT COUNT(*) FROM invoice WHERE MONTH(Issued_Date)='" + monthNo + "';");
            ReportsCount_LBL.Text = Global.dal.MyExecuteScaler(SQL).ToString();

            SQL = ("SELECT COUNT(*) FROM job WHERE Status='Uncomplete';");
            JobsCount_LBL.Text = Global.dal.MyExecuteScaler(SQL).ToString();
        }

        public void LoadConsumptionChart(ComboBox CMB)
        {
            try
            {
                //string monthNo = DateTime.Now.ToString("MM");
                Consumption_Chart.Series["Consumption"].Points.Clear();
        
                //string SQL = ("SELECT MONTH(Issued_Date) as Month, SUM(Water_Chrg_Consum) as Consumption, SUM(Due_Total) as Amount, SUM(VAT) as VAT FROM Invoice WHERE YEAR(Issued_Date)=" + CMB.Text + " GROUP BY MONTH(Issued_Date)");
                //string SQL = ("SELECT Month, SUM(Consumption) as Consumption FROM statement WHERE YEAR(Date)=" + CMB.Text + " AND Status='Reading' GROUP BY MONTH(Date);");
                string SQL = ("SELECT Month, SUM(Consumption) as Consumption FROM statement WHERE YEAR(Date)=" + CMB.Text + " AND Status='Reading' GROUP BY Month;");
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    Consumption_Chart.Series["Consumption"].Points.AddXY(Global.dal.SQLReader.GetString("Month"), Global.dal.SQLReader.GetInt32("Consumption"));
                   
                }

            }
            catch (Exception EX)
            {
                CustomMB_Frm MB = new CustomMB_Frm();
                MB.show(EX.Message, "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        public void LoadTaxChart(ComboBox CMB)
        {
            try
            {
                Tax_Chart.Series["Tax"].Points.Clear();

                string SQL = ("SELECT MONTH(Issued_Date) as Month, SUM(VAT) as Total_VAT FROM invoice WHERE YEAR(Issued_Date)=" + CMB.Text + " GROUP BY Month;");
                //string SQL = ("SELECT Month, SUM(Consumption) as Consumption FROM Statement WHERE YEAR(Date)=2021 GROUP BY MONTH(Date);");
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    Tax_Chart.Series["Tax"].Points.AddXY(Global.dal.SQLReader.GetString("Month"), Global.dal.SQLReader.GetInt32("Total_VAT"));

                }

            }
            catch (Exception EX)
            {
                CustomMB_Frm MB = new CustomMB_Frm();
                MB.show(EX.Message, "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        public void LoadIncomeChart(ComboBox CMB)
        {
            try
            {
                Income_Chart.Series["Income"].Points.Clear();

                string SQL = ("SELECT MONTH(Issued_Date) as Month, SUM(Due_Total) as Income FROM invoice WHERE YEAR(Issued_Date)=" + CMB.Text + " GROUP BY Month;");
                //string SQL = ("SELECT Month, SUM(Consumption) as Consumption FROM Statement WHERE YEAR(Date)=2021 GROUP BY MONTH(Date);");
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    Income_Chart.Series["Income"].Points.AddXY(Global.dal.SQLReader.GetString("Month"), Global.dal.SQLReader.GetInt32("Income"));

                }

            }
            catch (Exception EX)
            {
                CustomMB_Frm MB = new CustomMB_Frm();
                MB.show(EX.Message, "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        private void Year_CMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadConsumptionChart(Year_CMB);
            LoadTaxChart(Year_CMB);
            LoadIncomeChart(Year_CMB);
        }

        private void Month_CMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.bill.CalculateStatisticalSummary(AllPG_LBL, OverduePG_LBL, DisconnPG_LBL, UndisconnPG_LBL, GetMonthNumber(Month_CMB), All_Pbar, Overdue_Pbar, Undisconn_Pbar, Disconn_Pbar);
        }
    }
}
