using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    public partial class ViewImageFrm : Form
    {
        int WaterConsumption; double dueTotal;
        public ViewImageFrm()
        {
            InitializeComponent();
        }

        private void ViewImageFrm_Load(object sender, EventArgs e)
        {
            TransactionCode_TXT.Text = Global.payment.TransactionNo;
            
            MemoryStream ms = new MemoryStream(Global.payment.Proof);
            ImageBox_PB.Image = Image.FromStream(ms);
        }

        private void ConfirmPayment_BTN_Click(object sender, EventArgs e)
        {
            if (Verify() == true)
            {
                if (Global.payment.Payment_Status == "Pending")
                {
                    Global.payment.UpdateBillAfterPayment(Global.Acc.AccountNo, Global.payment.Amount);
                    
                    AddPaymentStatement(Convert.ToInt32(Global.payment.Amount), Global.payment.CurrentBill, Global.payment.PaymentID);
                    UpdatePaymentStatus(Global.payment.PaymentID);

                    CustomMB_Frm MB = new CustomMB_Frm();
                    MB.show("Payment Confirmed", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
                }
                else if (Global.payment.Payment_Status == "Confirmed")
                {
                    CustomMB_Frm MB = new CustomMB_Frm();
                    MB.show("The Payment is Confirmed\nAlready, Try Another", "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
                }
            }
            else if (Verify() == false)
            {
                Global.email.To = "gbada2002@yahoo.co.uk";
                Global.email.CC = "";
                Global.email.Subject = "PROOF OF PAYMENT FAILED";
                Global.email.Body = "Your proof of payment you uploaded was Invalid";

                Global.email.SendEmail();

                CustomMB_Frm MB = new CustomMB_Frm();
                MB.show("Invalid Transaction \nNumner", "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
                
            }
            
        }

        private void AddPaymentStatement(int PayAmount, double balance, string PayID)
        {
            GetBill();
            Global.statement.StatementNo = Global.statement.GenerateStateNo();
            Global.statement.Consumption = Convert.ToInt32(WaterConsumption);
            Global.statement.DueTotal = Convert.ToInt32(dueTotal);
            Global.statement.TotalPayments = PayAmount;
            Global.statement.Balance = balance;
            DateTime date = DateTime.Now;
            Global.statement.Date = date.ToString("yyyy-MM-dd");
            Global.statement.Month = DateTime.Now.ToMonthName();
            Global.statement.Status = "Payment";

            Global.statement.AddStatement(Global.Acc.AccountNo, Global.bill.BillCode);
        }

        public void UpdatePaymentStatus(string payID)
        {
            string SQL = "UPDATE payment SET Payment_Status='Confirmed' WHERE Payment_ID='"+ payID +"';";
            Global.dal.MyExecute(SQL);
        }

        public void GetBill()
        {
            string SQL = "SELECT * FROM invoice WHERE Bill_Code='" + Global.bill.BillCode + "';";
            Global.dal.MyExecuteReader(SQL);

            while (Global.dal.SQLReader.Read())
            {
                WaterConsumption = Convert.ToInt32(Global.dal.SQLReader["Water_Consumption"].ToString());
                dueTotal = Convert.ToInt32(Global.dal.SQLReader["Due_Total"].ToString());
            }
        }

        public bool Verify()
        {
            bool val = false;
            string SQL = "SELECT * FROM payment_db WHERE Transaction_No='" + TransactionCode_TXT.Text + "';";
            Global.dal.MyExecuteReader(SQL);

            int count = 0;

            while (Global.dal.SQLReader.Read())
            {
                count = count + 1;
            }

            if (count == 1)
            {
                val = true;
            }
            else if (count == 0)
                val = false;
            return val;
        }
    }
}
