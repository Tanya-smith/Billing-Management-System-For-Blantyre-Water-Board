using System;
using DGVPrinterHelper;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMSystem
{
    public partial class ReportsFrm : Form
    {
        public ReportsFrm()
        {
            InitializeComponent();
        }

        public void PrintReport()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Report";
            printer.SubTitle = "Report................." + DateTime.Today.ToLongDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Blantyre Water Board";
            printer.FooterSpacing = 15;

            printer.PrintDataGridView(BillsFullReport_DGV);
        }

        private void FullReportCMD_Click(object sender, EventArgs e)
        {
            ReportTC.SelectedTab =FullReportTP;
        }

        private void LoadOverdue_BTN_Click(object sender, EventArgs e)
        {
            ReportTC.SelectedTab = OverduesTP;
        }

        private void ReportsFrm_Load(object sender, EventArgs e)
        {
            
            Global.bill.GetOverdues(Details_DGV, OverdueCount_lbl, Undisconnected_lbl, AllCount_LBL, GetMonthNumber(Month_CMB));
            Global.bill.GetDisconnected(Disconnected_DGV, Disconnected_LBL, GetMonthNumber(Month_CMB));
            Global.bill.LoadMainGraph(MainOverview_Chart, CMB);
            Global.bill.CalculateStatisticalSummary(AllPG_LBL, OverduePG_LBL, DisconnPG_LBL, UndisconnPG_LBL, GetMonthNumber(Month_CMB), All_Pbar, Overdue_Pbar, Undisconn_Pbar, Disconn_Pbar);
        }

        private void BackOverdue_BTN_Click(object sender, EventArgs e)
        {
            ReportTC.SelectedTab = reportHomeTP;
        }

        private void Disconn_BTN_Click(object sender, EventArgs e)
        {            
            ReportTC.SelectedTab = DisconnectedTP;
        }

        private void UnDisconnected_BTN_Click(object sender, EventArgs e)
        {
            State_lbl.Text = "Un Disconnected";
            ReportTC.SelectedTab = OverduesTP;
        }

        private void BackDisconn_BTN_Click(object sender, EventArgs e)
        {
            ReportTC.SelectedTab = reportHomeTP;
        }

        private void ReportBackCMD_Click(object sender, EventArgs e)
        {
            ReportTC.SelectedTab = reportHomeTP;
        }

        private void LoadFullReport_CMD_Click(object sender, EventArgs e)
        {
            Global.bill.FullReport(BillsFullReport_DGV, FromDTP.Text, TO_DTP.Text);
        }

        private void ReportPDF_CMD_Click(object sender, EventArgs e)
        {
            PrintReport();
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

        private void searchOverdueTXT_TextChanged(object sender, EventArgs e)
        {
            Global.bill.SearchOverdue(Details_DGV, searchOverdueTXT.Text);
        }

        private void SearchDisconnected_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchBoxTxt_TextChanged(object sender, EventArgs e)
        {
            Global.bill.SearchDisconnect(Disconnected_DGV, SearchDisconnected.Text);
        }

        private void CMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.bill.LoadMainGraph(MainOverview_Chart, CMB);
        }

        private void Month_CMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.bill.GetOverdues(Details_DGV, OverdueCount_lbl, Undisconnected_lbl, AllCount_LBL, GetMonthNumber(Month_CMB));
            Global.bill.GetDisconnected(Disconnected_DGV, Disconnected_LBL, GetMonthNumber(Month_CMB));
            Global.bill.CalculateStatisticalSummary(AllPG_LBL, OverduePG_LBL, DisconnPG_LBL, UndisconnPG_LBL, GetMonthNumber(Month_CMB), All_Pbar, Overdue_Pbar, Undisconn_Pbar, Disconn_Pbar);
        }
    }
}
