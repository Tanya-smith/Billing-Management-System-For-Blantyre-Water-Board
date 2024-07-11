using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    class Payment
    {
        private string paymentID;
        private string transactionNo;
        private string date;
        private double amount;
        private string payMethod;
        private string payment_status;
        private string accNo;
        private byte[] proof;
        private double current_Bill;


        public void LoadPayments(string payID)
        {
            string SQL = "SELECT * FROM payment WHERE Payment_ID='"+ payID +"'";
            Global.dal.MyExecuteReader(SQL);
            while(Global.dal.SQLReader.Read())
            {
                PaymentID = Global.dal.SQLReader["Payment_ID"].ToString();
                TransactionNo = Global.dal.SQLReader["Transaction_Number"].ToString();
                AccNo = Global.dal.SQLReader["Account_No"].ToString();
                Date = Global.dal.SQLReader["Date"].ToString();
                Amount = Convert.ToInt32(Global.dal.SQLReader["Amount"].ToString());
                PayMethod = Global.dal.SQLReader["Payment_Method"].ToString();
                Payment_Status = Global.dal.SQLReader["Payment_Status"].ToString();
                Proof = (byte[]) Global.dal.SQLReader["Proof"];
            }
        }

        public void UpdateBillAfterPayment(string AccNo, double payAmount)
        {
            string SQL = "SELECT Bill_Code, Current_Bill, Due_Total FROM invoice WHERE Bill_Status='Current' AND Account_No='" + AccNo + "';";
            Global.dal.MyExecuteReader(SQL);
            int count = 0;
            CurrentBill = 0; double dueTotal = 0; string bill_Code = "";
            while (Global.dal.SQLReader.Read())
            {
                count = count + 1;
                MessageBox.Show("" + count);
                
            }
            if (count == 1)
            {
                bill_Code = Global.dal.SQLReader["Bill_Code"].ToString();
                CurrentBill = Convert.ToInt32(Global.dal.SQLReader["Current_Bill"].ToString());
                dueTotal = Convert.ToInt32(Global.dal.SQLReader["Due_Total"].ToString());

                CurrentBill = CurrentBill - payAmount;

                if (current_Bill > 0)
                {
                    SQL = "UPDATE invoice SET Current_Bill=" + CurrentBill + ", Bill_Status='Current' WHERE Bill_Code='" + bill_Code + "';";
                    Global.dal.MyExecute(SQL);

                    SQL = "UPDATE Account SET Acc_Bill=" + CurrentBill + " WHERE Account_No='" + AccNo + "';";
                    Global.dal.MyExecute(SQL);
                }
                if (current_Bill <= 0)
                {
                    SQL = "UPDATE invoice SET Current_Bill=" + CurrentBill + ", Bill_Status='Paid' WHERE Bill_Code='" + bill_Code + "';";
                    Global.dal.MyExecute(SQL);

                    SQL = "UPDATE Account SET Acc_Bill=" + CurrentBill + " WHERE Account_No='" + AccNo + "';";
                    Global.dal.MyExecute(SQL);
                }
            }
            else if (count == 0)
            {
                SQL = "SELECT Bill_Code, Current_Bill, Due_Total FROM invoice WHERE Bill_Status='Overdue' AND Account_No='" + AccNo + "';";
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    bill_Code = Global.dal.SQLReader["Bill_Code"].ToString();
                    CurrentBill = Convert.ToInt32(Global.dal.SQLReader["Current_Bill"].ToString());
                    dueTotal = Convert.ToInt32(Global.dal.SQLReader["Due_Total"].ToString());
                }

                CurrentBill = CurrentBill - payAmount;

                if (current_Bill > 0)
                {
                    SQL = "UPDATE invoice SET Current_Bill=" + CurrentBill + ", Bill_Status='Overdue' WHERE Bill_Code='" + bill_Code + "';";
                    Global.dal.MyExecute(SQL);

                    SQL = "UPDATE Account SET Acc_Bill=" + CurrentBill + " WHERE Account_No='" + AccNo + "';";
                    Global.dal.MyExecute(SQL);
                }
                if (current_Bill <= 0)
                {
                    SQL = "UPDATE invoice SET Current_Bill=" + CurrentBill + ", Bill_Status='Paid' WHERE Bill_Code='" + bill_Code + "';";
                    Global.dal.MyExecute(SQL);

                    SQL = "UPDATE Account SET Acc_Bill=" + CurrentBill + " WHERE Account_No='" + AccNo + "';";
                    Global.dal.MyExecute(SQL);
                }

            }
        }


        public string PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public double CurrentBill
        {
            get { return current_Bill; }
            set { current_Bill = value; }
        }

        public string TransactionNo
        {
            get { return transactionNo; }
            set { transactionNo = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string PayMethod
        {
            get { return payMethod; }
            set { payMethod = value; }
        }

        public string Payment_Status
        {
            get { return payment_status; }
            set { payment_status = value; }
        }

        public string AccNo
        {
            get { return accNo; }
            set { accNo = value; }
        }

        public byte[] Proof
        {
            get { return proof; }
            set { proof = value; }
        }
    }
}
