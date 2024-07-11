using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    class BillGenerator
    {
        private double vat;
        private double currentBill;
        private int readingChrg;
        private int rentalChrg;
        private int chargePerKilo;
        private int previousReading;
        private int newReading;
        private int waterConsumption;
        private double waterConsumpCharge;
        private int balBroughtForward;
        private double subTotalLiable;
        private string billStatus;
        private string issuedDate;
        private string dueDate;
        private double dueTotal;
        private int dueDays;

        public int GetWaterConsumption(string AccNo)
        {

            string SQL = "SELECT * FROM readings WHERE Account_No='"+ AccNo +"';";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
               PrevReading = Int32.Parse(Global.dal.SQLReader["Previous_Reading"].ToString());
            }

            WaterConsumption = NewReading - PrevReading;
            return WaterConsumption;
        }

        public double GetWaterConsumpCharge(string AccNo)
        {
            string SQL = "SELECT * FROM bill_settings";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                ChargePerKillo = Int32.Parse(Global.dal.SQLReader["Charge_Per_Kilo"].ToString());
            }

            // Generating water charge
            waterConsumpCharge = GetWaterConsumption(AccNo) * ChargePerKillo;
            return WaterConsumpCharge;
        }

        private int CalculateBBForward(string AccNo)
        {
            int bbF = 0;
            string SQL = "SELECT Acc_Bill FROM account WHERE Account_No='" + AccNo + "'";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                bbF = Int32.Parse(Global.dal.SQLReader["Acc_Bill"].ToString());
            }

            return bbF;
        }

        public void UPdateInvoiceStatus(string AccNo)
        {
            string SQL = "UPDATE invoice SET Bill_Status='Incurrent' WHERE Account_No='" + AccNo + "' AND Bill_Status='Current';";
            Global.dal.MyExecute(SQL);

            SQL = "UPDATE invoice SET Bill_Status='Incurrent' WHERE Account_No='" + AccNo + "' AND Bill_Status='Paid';";
            Global.dal.MyExecute(SQL);

            SQL = "UPDATE invoice SET Bill_Status='Incurrent' WHERE Account_No='" + AccNo + "' AND Bill_Status='Overdue';";
            Global.dal.MyExecute(SQL);
        }

        public void GenerateBill(string AccNo, string BillCode)
        {
            double VATPercentage = 0;
            string SQL = "SELECT * FROM bill_settings";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                ReadingChrg = Int32.Parse(Global.dal.SQLReader["Reading_Charge"].ToString());
                RentalChrg = Int32.Parse(Global.dal.SQLReader["Rental_Charge"].ToString());
                VATPercentage = Int32.Parse(Global.dal.SQLReader["VAT"].ToString());
            }

            

            BalBroughtForward = CalculateBBForward(AccNo);
            SubTotalLiable = RentalChrg + ReadingChrg + GetWaterConsumpCharge(AccNo);
            VAT = VATPercentage * SubTotalLiable / 100;
            DueTotal = VAT + SubTotalLiable + BalBroughtForward;
            CurrentBill = DueTotal;
            BillStatus = "Current";

            

            SQL = "INSERT INTO invoice VALUES ('" + BillCode + "', '" + AccNo + "', " + BalBroughtForward + ", " + ReadingChrg
                + ", " + RentalChrg + ", " + WaterConsumpCharge + ", " + NewReading + ", " + WaterConsumption + ", " + SubTotalLiable + ", " + VAT + ", '" + IssuedDate + "', '" +
                DueDate + "', " + DueDays + ", " + CurrentBill + ", '" + BillStatus + "', " + DueTotal + ")";
            Global.dal.MyExecute(SQL);

            SQL = "UPDATE account SET Acc_Bill='" + CurrentBill + "' WHERE Account_No='" + AccNo + "';";
            Global.dal.MyExecute(SQL);

            Global.reading.AccNo = AccNo; Global.reading.PrevReading = NewReading;
            Global.reading.SaveReading();
            CustomMB_Frm MB = new CustomMB_Frm();
            MB.show("Bill Generated", "Infor", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
        }

        public double VAT
        {
            get { return vat; }
            set { vat = value; }
        }

        public double CurrentBill
        {
            get{ return currentBill; }
            set { currentBill = value; }
        }

        public int ReadingChrg
        {
            get { return readingChrg; }
            set { readingChrg = value; }
        }

        public int RentalChrg
        {
            get { return rentalChrg; }
            set { rentalChrg = value; }
        }

        public int ChargePerKillo
        {
            get { return chargePerKilo; }
            set { chargePerKilo = value; }
        }

        public int PrevReading
        {
            get { return previousReading; }
            set { previousReading = value; }
        }

        public int NewReading
        {
            get { return newReading; }
            set { newReading = value; }
        }

        public int WaterConsumption
        {
            get { return waterConsumption; }
            set { waterConsumption = value; }
        }

        public double WaterConsumpCharge
        {
            get { return waterConsumpCharge; }
            set { waterConsumpCharge = value; }
        }

        public int BalBroughtForward
        {
            get { return balBroughtForward; }
            set { balBroughtForward = value; }
        }

        public string BillStatus
        {
            get { return billStatus; }
            set { billStatus = value; }
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

        public double DueTotal
        {
            get { return dueTotal; }
            set { dueTotal = value; }
        }

        public double SubTotalLiable
        {
            get { return subTotalLiable; }
            set { subTotalLiable = value; }
        }
    }
}
