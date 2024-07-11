using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siticone.Desktop.UI.WinForms;

namespace IBMSystem
{
    class Account
    {
        private string accNo;
        private string customerID_FK;
        private string meterNo;
        private string meterBox;
        private string meterType;
        private string accType;
        private string status;
        private string location;
        private string dateIssued;
        private int acc_Bill;

        public void AddAccount()
        {
            string Query = "INSERT INTO account Values ('" + AccountNo + "', '" + CustomerID_FK + "', '" + MeterNo + "', '" + MeterBox + "', '" + MeterType +
                "', '" + AccountType + "', '" + Status + "', '" + Location + "', '" + DateIssued + "', " + AccBill + ")";
            Global.dal.MyExecute(Query);
        }

        public void UpdateAccount(string AccNo)
        {
            string SQL = ("UPDATE account SET Account_No='"+ AccountNo +"', Meter_Number='" + MeterNo + "', Meter_Box='" + MeterBox 
                + "', Meter_Type='" + MeterType +"', Account_Type='" + AccountType +"', Status='"+ Status +"', Account_Location='"+ Location + "', Date_Issued='" + DateIssued +"' WHERE Account_No='"+ AccNo +"';");
            Global.dal.MyExecute(SQL);
        }
        public string AccountNo
        {
            get { return accNo; }
            set { accNo = value; }
        }

        public string CustomerID_FK
        {
            get { return customerID_FK; }
            set { customerID_FK = value; }
        }
        public string MeterNo
        {
            get { return meterNo; }
            set { meterNo = value; }
        }

        public string MeterBox
        {
            get { return meterBox; }
            set { meterBox = value; }
        }

        public string MeterType
        {
            get { return meterType; }
            set { meterType = value; }
        }

        public string AccountType
        {
            get { return accType; }
            set { accType = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string DateIssued
        {
            get { return dateIssued; }
            set { dateIssued = value; }
        }

        public int AccBill
        {
            get { return acc_Bill; }
            set { acc_Bill = value; }
        }
    }
}
