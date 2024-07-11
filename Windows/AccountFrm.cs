using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;

namespace IBMSystem
{
    public partial class AccountFrm : Form
    {
        bool AccFormAdd = true; 
        public byte[] Img { get; set; }
        public AccountFrm()
        {
            InitializeComponent();
        }

        private void AccountFrm_Load(object sender, EventArgs e)
        {
            Global.bill.CountDownDays();

            string getCustDetails = ("SELECT c.Firstname, c.Surname, a.Account_No FROM customer c, account a WHERE c.CustomerID=a.CustomerID;");
            PopulateAccUC(getCustDetails);
            BillTC.SelectedTab = TempBillTP;
            accSTPNL2.Visible = false;
            accSTPNL2.SendToBack();
        }

        private void Onclick(object sender, EventArgs e)
        {
            slider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            slider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;
        }
        private void AccountDetails_CMD_Click_1(object sender, EventArgs e)
        {
            GetAccDetails(AccNo_LBL.Text);
            Onclick(AccountDetails_CMD, e);
            AccInfoTC.SelectedTab = AccDescriptionTP;
        }

        private void Cust_Details_CMD_Click_1(object sender, EventArgs e)
        {
            Onclick(Cust_Details_CMD, e);
            AccInfoTC.SelectedTab = AccCustomerTP;
            GetCustDetails();
        }

        private void Acc_Statements_CMD_Click_1(object sender, EventArgs e)
        {
            Onclick(Acc_Statements_CMD, e);
            AccInfoTC.SelectedTab = accStatementTP;
            Global.statement.LoadShortStatement(ShortStatement_DGV, AccNo_LBL.Text);
            Global.statement.LoadChart(WaterCons_Chart, AccNo_LBL.Text);
            Global.statement.LoadChart(StatementChart2, AccNo_LBL.Text);
        }

        private void Acc_Payments_CMD_Click(object sender, EventArgs e)
        {
            Onclick(Acc_Payments_CMD, e);
            AccInfoTC.SelectedTab = Acc_PaymentTP;
           // PopulatePaymentUC();
        }
        /// <summary>
        ///  Commands
        /// </summary>


        private void AccountCMD_Click(object sender, EventArgs e)
        {
            AccInfoTC.SelectedTab = AccDescriptionTP;
            AccountTC.SelectedTab = HomeTP;
            BillTC.SelectedTab = TempBillTP;
            Onclick(AccountDetails_CMD, e);
        }

        private void FullStatementCMD_Click(object sender, EventArgs e)
        {
            Global.statement.FullStatement(FullStatementDGV, AccNo_LBL.Text);
            BBL_Full_LBL.Text = Global.statement.BBL;
            accSTPNL2.Visible = true;
            accSTPNL2.BringToFront();
        }

        private void ShortST_BackCMD_Click(object sender, EventArgs e)
        {
            accSTPNL2.Visible = false;
            accSTPNL2.SendToBack();
        }

        private void BackAccForm_CMD_Click(object sender, EventArgs e)
        {
            GetAccDetails(AccNo_LBL.Text);
            AccountTC.SelectedTab = AccDetailsTP;
        }

        private void NewAccount_CMD_Click(object sender, EventArgs e)
        {
            AccountTC.SelectedTab = AddAccountTP;
            AccFormAdd = true;
            AccNo_TXT.Enabled = true; CustID_TXT.Enabled = true; AccDateIssued_DTP.Enabled = true;
        }

        private void AddAccount_BTN_Click(object sender, EventArgs e)
        {
            AccountTC.SelectedTab = AddAccountTP;
            AccFormAdd = true;
            AccNo_TXT.Enabled = true; CustID_TXT.Enabled = true; AccDateIssued_DTP.Enabled = true;
        }

        private void UpdateAcc_CMD_Click(object sender, EventArgs e)
        {
            // gettting Customer Details to Form
            CustID_TXT.Text = CustID_LBL.Text;
            CustFirstname_TXT.Text = CustFirstname_LBL.Text;
            CustLastname_TXT.Text = CustSurname_LBL.Text;
            CustContactNo_TXT.Text = CustContactNo_LBL.Text;
            CustEmailAddress_TXT.Text = CustEmail_LBL.Text;
            CustLocation_TXT.Text = CustLocation_LBL.Text;
            CustContactAddress_TXT.Text = CustAddress_LBL.Text;

            // getting Account Details
            AccNo_TXT.Text = AccNo_LBL.Text;
            MeterNo_TXT.Text = AccMeterNo_LBL.Text;
            MeterBox_TXT.Text = MeterBook_LBL.Text;
            MeterType_TXT.Text = MeterType_LBL.Text;
            AccType_TXT.Text = AccType_LBL.Text;
            AccStatus_TXT.Text = AccStatus_LBL.Text;
            AccLocation_TXT.Text = AccLocation_LBL.Text;
            AccDateIssued_DTP.Text = AccDateIssued_DTP.Text;

            AccountTC.SelectedTab = AddAccountTP;
            AccFormAdd = false;
            AccNo_TXT.Enabled = false; CustID_TXT.Enabled = false; AccDateIssued_DTP.Enabled = false;
        }

        private void SetupBill_BTN_Click(object sender, EventArgs e)
        {
            IssuedDate_DTP.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime IssuedDate = DateTime.Now;
            DateTime DueDate = IssuedDate.EndOfMonth();
            TimeSpan ts = DueDate - IssuedDate;
            int days = ts.Days;

            Global.billGenerator.IssuedDate = IssuedDate.ToString("yyyy-MM-dd");
            Global.billGenerator.DueDate = DueDate.ToString("yyyy-MM-dd");
            Global.billGenerator.DueDays = days;
            BillTC.SelectedTab = SetupTP;
            BillDueDate_DTP.Text = DueDate.ToString("yyyy-MM-dd");
            DueDaysSetup_TXT.Text = days.ToString();
        }

        private void SetBill_BTN_Click(object sender, EventArgs e)
        {
            BillTC.SelectedTab = SetupTP;
        }

        private void UpdateCust_BTN_Click(object sender, EventArgs e)
        {
            updateCustForm_PNL.Visible = true;
            CustID_TXT_F2.Text = CustID_LBL.Text;
            CustFirstname_TXT_F2.Text = CustFirstname_LBL.Text;
            CustSurname_TXT_F2.Text = CustSurname_LBL.Text;
            CustNo_TXT_F2.Text = CustContactNo_LBL.Text;
            CustEmail_TXT_F2.Text = CustEmail_LBL.Text;
            CustLocation_TXT_F2.Text = CustLocation_LBL.Text;
            CustAddress_TXT_F2.Text = CustAddress_LBL.Text;
        }


        /// <summary>
        /// Accounts Code Start Here
        /// </summary>

        private void AddAccSave_CMD_Click(object sender, EventArgs e)
        {
            if (AccFormAdd == true)
            {
                AddCustomer();
                AddAccount();
                Global.reading.AccNo = Global.Acc.AccountNo;
                Global.reading.DefaultReading();

                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Account Created\nSuccessfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
                ClearControls();
            }
            else if (AccFormAdd == false)
            {
                UpdateAccount();
                ClearControls();
            }
            

        }
        public void PopulateAccUC(string SQL)
        {
            int count = 0;
            string getCount = "SELECT COUNT(*) FROM account";
            count = Global.dal.MyExecuteScaler(getCount);

            
            ucContainerFPL.Controls.Clear();
            Global.dal.MyExecuteReader(SQL);

            AccCount_LBL.Text = count.ToString();

            try
            {

                while (Global.dal.SQLReader.Read())
                {
                    CustomerUC CustUC = new CustomerUC();

                    CustUC.AccNo = Global.dal.SQLReader["Account_No"].ToString();
                    CustUC.AccCustFirstname = Global.dal.SQLReader["Firstname"].ToString();
                    CustUC.AccCustSurname = Global.dal.SQLReader["Surname"].ToString();

                    CustUC.Click += (sender, args) =>
                    {
                        GetAccDetails(CustUC.AccNo);
                        AccountTC.SelectedTab = AccDetailsTP;
                        BillTC.SelectedTab = CurrentTP;
                        Global.statement.LoadChart(WaterCons_Chart, AccNo_LBL.Text);
                        Global.statement.LoadChart(StatementChart2, AccNo_LBL.Text);
                        Global.bill.UpdateOverdue(Bill_Code_LBL.Text);
                        PopulatePaymentUC();
                    };

                    if (ucContainerFPL.Controls.Count < 0)
                        ucContainerFPL.Controls.Clear();
                    else
                        ucContainerFPL.Controls.Add(CustUC);
                }
            }
            catch
            {

            }
        }

        private void SearchBoxTxt_TextChanged(object sender, EventArgs e)
        {
            //"SELECT c.Firstname, c.Surname, a.Account_No FROM customer c, account a WHERE c.CustomerID=a.CustomerID;");
            string SQL = "SELECT c.Firstname, c.Surname, a.Account_No FROM customer c, account a WHERE CONCAT(c.Firstname, c.Surname, a.Account_No) like'%" + SearchBoxTxt.Text + "%' AND c.CustomerID=a.CustomerID;";
            PopulateAccUC(SQL);
        }

        private void GetAccDetails(string AccNo)
        {
            string getDetails = ("SELECT * FROM account WHERE Account_No='" + AccNo + "';");
            Global.dal.MyExecuteReader(getDetails);
            while (Global.dal.SQLReader.Read())
            {
                AccNo_LBL.Text = Global.dal.SQLReader["Account_No"].ToString();
                AccMeterNo_LBL.Text = Global.dal.SQLReader["Meter_Number"].ToString();
                MeterBook_LBL.Text = Global.dal.SQLReader["Meter_Box"].ToString();
                MeterType_LBL.Text = Global.dal.SQLReader["Meter_Type"].ToString();
                AccType_LBL.Text = Global.dal.SQLReader["Account_Type"].ToString();
                AccStatus_LBL.Text = Global.dal.SQLReader["Status"].ToString();
                AccLocation_LBL.Text = Global.dal.SQLReader["Account_Location"].ToString();
                AccIssuedDate_LBL.Text = Global.dal.SQLReader["Date_Issued"].ToString().Split(' ')[0];
            }
        }

        private void GetCustDetails()
        {
            Global.Cust.GetCustDetails(AccNo_LBL.Text);
            CustID_LBL.Text = Global.Cust.CustomerID;
            CustFirstname_LBL.Text = Global.Cust.Firstname;
            CustSurname_LBL.Text = Global.Cust.Surname;
            CustContactNo_LBL.Text = Global.Cust.ContactNumber;
            CustEmail_LBL.Text = Global.Cust.EmailAddress;
            CustLocation_LBL.Text = Global.Cust.Location;
            CustAddress_LBL.Text = Global.Cust.ContactAddress;
        }

        private void AddAccount()
        {
            if (AccNo_TXT.Text == "" || MeterNo_TXT.Text == "" || MeterBox_TXT.Text == "" || MeterType_TXT.Text == "" ||
                AccType_TXT.Text == "" || AccStatus_TXT.Text == "" || AccLocation_TXT.Text == "" || AccDateIssued_DTP.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Global.Acc.AccountNo = AccNo_TXT.Text;
                Global.Acc.CustomerID_FK = CustID_TXT.Text;
                Global.Acc.MeterNo = MeterNo_TXT.Text;
                Global.Acc.MeterBox = MeterBox_TXT.Text;
                Global.Acc.MeterType = MeterType_TXT.Text;
                Global.Acc.AccountType = AccType_TXT.Text;
                Global.Acc.Status = AccStatus_TXT.Text;
                Global.Acc.Location = AccLocation_TXT.Text;
                Global.Acc.DateIssued = AccDateIssued_DTP.Text;

                Global.Acc.AddAccount();
            }
        }

        private void UpdateAccount()
        {
            if (CustID_TXT.Text == "" || CustFirstname_TXT.Text == "" || CustLastname_TXT.Text == "" || CustContactNo_TXT.Text == "" ||
                CustEmailAddress_TXT.Text == "" || CustLocation_TXT.Text == "" || CustContactAddress_TXT.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (AccNo_TXT.Text == "" || MeterNo_TXT.Text == "" || MeterBox_TXT.Text == "" || MeterType_TXT.Text == "" ||
                AccType_TXT.Text == "" || AccStatus_TXT.Text == "" || AccLocation_TXT.Text == "" || AccDateIssued_DTP.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Global.Cust.CustomerID = CustID_TXT.Text;
                Global.Cust.Firstname = CustFirstname_TXT.Text;
                Global.Cust.Surname = CustLastname_TXT.Text;
                Global.Cust.ContactNumber = CustContactNo_TXT.Text;
                Global.Cust.EmailAddress = CustEmailAddress_TXT.Text;
                Global.Cust.Location = CustLocation_TXT.Text;
                Global.Cust.ContactAddress = CustContactAddress_TXT.Text;
                Global.Cust.UpdateCustomer(CustID_TXT.Text);

                // Account Details

                Global.Acc.AccountNo = AccNo_TXT.Text;
                Global.Acc.MeterNo = MeterNo_TXT.Text;
                Global.Acc.MeterBox = MeterBox_TXT.Text;
                Global.Acc.MeterType = MeterType_TXT.Text;
                Global.Acc.AccountType = AccType_TXT.Text;
                Global.Acc.Status = AccStatus_TXT.Text;
                Global.Acc.Location = AccLocation_TXT.Text;
                Global.Acc.DateIssued = AccDateIssued_DTP.Text;
                Global.Acc.UpdateAccount(AccNo_LBL.Text);

                MessageBox.Show("Details Updated");
            }
        }

        private void AddCustomer()
        {
            if (CustID_TXT.Text == "" || CustFirstname_TXT.Text == "" || CustLastname_TXT.Text == "" || CustContactNo_TXT.Text == "" ||
                CustEmailAddress_TXT.Text == "" || CustLocation_TXT.Text == "" || CustContactAddress_TXT.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Global.Cust.CustomerID = CustID_TXT.Text;
                Global.Cust.Firstname = CustFirstname_TXT.Text;
                Global.Cust.Surname = CustLastname_TXT.Text;
                Global.Cust.ContactNumber = CustContactNo_TXT.Text;
                Global.Cust.EmailAddress = CustEmailAddress_TXT.Text;
                Global.Cust.Location = CustLocation_TXT.Text;
                Global.Cust.ContactAddress = CustContactAddress_TXT.Text;

                Global.Cust.AddCustomer();
            }
        }

        private void CustSave_CMD_F2_Click(object sender, EventArgs e)
        {
            if (CustID_TXT_F2.Text == "" || CustFirstname_TXT_F2.Text == "" || CustSurname_TXT_F2.Text == "" || CustNo_TXT_F2.Text == "" ||
                CustEmail_TXT_F2.Text == "" || CustLocation_TXT_F2.Text == "" || CustAddress_TXT_F2.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Global.Cust.CustomerID = CustID_TXT_F2.Text;
                Global.Cust.Firstname = CustFirstname_TXT_F2.Text;
                Global.Cust.Surname = CustSurname_TXT_F2.Text;
                Global.Cust.ContactNumber = CustNo_TXT_F2.Text;
                Global.Cust.EmailAddress = CustEmail_TXT_F2.Text;
                Global.Cust.Location = CustLocation_TXT_F2.Text;
                Global.Cust.ContactAddress = CustAddress_TXT_F2.Text;

                Global.Cust.UpdateCustomer(CustID_TXT_F2.Text);
                GetCustDetails();
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("Customer Details\nUpdated Successfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
                updateCustForm_PNL.Visible = false;
            }
        }

        private void ClearControls()
        {
            CustID_TXT.Text = "";               AccNo_TXT.Text = "";
            CustFirstname_TXT.Text = "";        MeterNo_TXT.Text = "";
            CustLastname_TXT.Text = "";         MeterBox_TXT.Text = "";
            CustContactNo_TXT.Text = "";        MeterType_TXT.Text = "";
            CustEmailAddress_TXT.Text = "";     AccType_TXT.Text = "";
            CustLocation_TXT.Text = "";         AccStatus_TXT.Text = "";
            CustContactAddress_TXT.Text = "";   AccLocation_TXT.Text = "";
        }

        private void GetBill_CMD_Click(object sender, EventArgs e)
        {
            GetCurrentBill();
            BillTC.SelectedTab = CurrentTP;
        }
        private void BillTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCurrentBill();
        }

        private void GetCurrentBill()
        {
            if (Global.bill.GetCurrentBill(AccNo_LBL.Text) == true)
            {
                BBF_Bill_LBL.Text = Global.bill.BalBroughtForward.ToString();
                MeterRdgC_Bill_LBL.Text = Global.bill.MeterReadingCharge.ToString();
                MeterRentalC_Bill_LBL.Text = Global.bill.MeterRentalCharge.ToString();
                WCC_Bill_LBL.Text = Global.bill.WaterChargeConsum.ToString();
                MeterRdgC_Bill_LBL.Text = Global.bill.MeterReadingCharge.ToString();
                MSL_Bill_LBL.Text = Global.bill.MonthlySubTotal.ToString();
                VAT_Bill_LBL.Text = Global.bill.VAT.ToString();
                Rdg_Bill_LBL.Text = Global.bill.Rdgs.ToString();
                Bill_Code_LBL.Text = Global.bill.BillCode.ToString();
                StatusBill_LBL.Text = Global.bill.BillStatus.ToString();
                DueDaysBill_LBL.Text = Global.bill.DueDays.ToString();
                Issued_Bill_LBL.Text = Global.bill.IssuedDate.ToString();
                Due_DateBill_LBL.Text = Global.bill.DueDate.ToString();
                DueTotal_Bill_LBL.Text = Global.bill.DueTotal.ToString();
                AccCurrent_Bill_LBL.Text = Global.bill.CurrentBill.ToString();
                
            }
            else if (Global.bill.GetCurrentBill(AccNo_LBL.Text) == false)
            {
                BBF_Bill_LBL.Text = "#####";
                MeterRdgC_Bill_LBL.Text = "#####";
                MeterRentalC_Bill_LBL.Text = "#####";
                WCC_Bill_LBL.Text = "#####";
                MeterRdgC_Bill_LBL.Text = "#####";
                MSL_Bill_LBL.Text = "#####";
                VAT_Bill_LBL.Text = "#####";
                Rdg_Bill_LBL.Text = "#####";
                Bill_Code_LBL.Text = "#####";
                StatusBill_LBL.Text = "#####";
                DueDaysBill_LBL.Text = "##";
                Issued_Bill_LBL.Text = "#####";
                Due_DateBill_LBL.Text = "#####";
                DueTotal_Bill_LBL.Text = "#####";
                
            }
        }

        private void ShortStatement_DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.statement.GetStateCode(ShortStatement_DGV);
            Global.statement.ViewStatement(FullStatementDGV, Global.statement.StatementNo);
            BBL_Full_LBL.Text = Global.statement.BBL;
            accSTPNL2.Visible = true;
            accSTPNL2.BringToFront();
        }

        private void BillPrinter_PD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string[] billDetails;
            billDetails = new string[24];

            // Customer Details
            billDetails[0] = CustID_LBL.Text;
            billDetails[1] = CustFirstname_LBL.Text;
            billDetails[2] = CustSurname_LBL.Text;
            billDetails[3] = CustAddress_LBL.Text;
            billDetails[4] = CustLocation_LBL.Text;
            billDetails[5] = CustContactNo_LBL.Text;
            billDetails[6] = CustEmail_LBL.Text;

            // Account Details
            billDetails[22] = AccNo_LBL.Text;
            billDetails[23] = AccMeterNo_LBL.Text;

            // Billing Details
            billDetails[7] = Bill_Code_LBL.Text;
            billDetails[8] = Issued_Bill_LBL.Text; ;
            billDetails[9] = AccStatus_LBL.Text;
            billDetails[10] = Due_DateBill_LBL.Text;
            billDetails[11] = DueDaysBill_LBL.Text;
            billDetails[13] = DueTotal_Bill_LBL.Text;

            //
            billDetails[14] = BBF_Bill_LBL.Text;
            billDetails[15] = MeterRdgC_Bill_LBL.Text;
            billDetails[16] = MeterRentalC_Bill_LBL.Text;
            billDetails[17] = WCC_Bill_LBL.Text;
            billDetails[18] = Global.bill.WaterConsumption.ToString();
            billDetails[19] = MSL_Bill_LBL.Text;
            billDetails[20] = VAT_Bill_LBL.Text;
            billDetails[21] = DueTotal_Bill_LBL.Text;

            Printer printer = new Printer();
            printer.GenerateInvoice(e, billDetails);
        }

        private void GenerateBillPDF_CMD_Click(object sender, EventArgs e)
        {
            PrintDialog printdialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printdialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(BillPrinter_PD_PrintPage);
            DialogResult result = printdialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void Bill_Preview_CMD_Click(object sender, EventArgs e)
        {
            BillPreview_PPC.Document = BillPrinter_PD;
            BillPreview_PPC.ShowDialog();
        }

        private void SetupBill_CMD_Click(object sender, EventArgs e)
        {
            if (MeterReading_TXT.Text == "" && BillCode_TXT.Text == "" && IssuedDate_DTP.Text == BillDueDate_DTP.Text)
            {
                CustomMB_Frm MB = new CustomMB_Frm();
                MB.show("One Field is Empty or\nDue date is Incorrent", "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
            }
            else
            {
                if (ValidateReading(Convert.ToInt32(MeterReading_TXT.Text)) == true)
                {
                    string billCode = ""; billCode += "BC" + MeterReading_TXT.Text + AccNo_LBL.Text;
                    Global.billGenerator.NewReading = Int32.Parse(MeterReading_TXT.Text);
                    Global.billGenerator.UPdateInvoiceStatus(AccNo_LBL.Text);
                    Global.billGenerator.GenerateBill(AccNo_LBL.Text, billCode);
                    GetCurrentBill(); BillTC.SelectedTab = CurrentTP;
                    MeterReading_TXT.Text = ""; BillCode_TXT.Text = "";
                    AddStatement();
                }
                else if (ValidateReading(Convert.ToInt32(MeterReading_TXT.Text)) == false)
                {
                    CustomMB_Frm MB = new CustomMB_Frm();
                    MB.show("Leading Value has To be\nGreater than previous", "Warning", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
                }

            }
            
        }

        private bool ValidateReading(int reading)
        {
            bool val = false;
            string SQL = "SELECT Previous_Reading FROM readings WHERE Account_No='" + AccNo_LBL.Text + "';";
            Global.dal.MyExecuteReader(SQL);
            int prevReading = 0;

            while (Global.dal.SQLReader.Read())
            {
                prevReading = Convert.ToInt32(Global.dal.SQLReader["Previous_Reading"].ToString());
            }

            if (reading >= prevReading)
            {
                val = true;
            }
            else if (reading < prevReading)
            {
                val = false;
            }
            return val;
        }

        private void BillDueDate_DTP_ValueChanged(object sender, EventArgs e)
        {
                     
        }

        private void CloseCustForm_CMD_Click(object sender, EventArgs e)
        {
            updateCustForm_PNL.Visible = false;
        }

        private void AddStatement()
        {
            Global.statement.StatementNo = Global.statement.GenerateStateNo();
            Global.statement.Consumption = Global.billGenerator.WaterConsumption;
            Global.statement.DueTotal = Global.billGenerator.DueTotal;
            Global.statement.TotalPayments = 0;
            Global.statement.Balance = Global.billGenerator.CurrentBill;
            Global.statement.Date = Global.billGenerator.IssuedDate;
            Global.statement.Month = DateTime.Now.ToMonthName();
            Global.statement.Status = "Reading";

            Global.statement.AddStatement(AccNo_LBL.Text, Bill_Code_LBL.Text);
        }

        private void PDF_FullStatement_CMD_Click(object sender, EventArgs e)
        {
            string title = "Account Statement";
            string subTitle = "Issued Date" + DateTime.Today.ToLongDateString();
            string footer = "Blantyre Water Board";
            Global.printer.PrintDataGridView(title, subTitle, footer, FullStatementDGV);
        }


        /// <summary>
        /// **************************** Payment Codes ************************************
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void AddPaymentStatement(int PayAmount, double balance, string PayID, string date)
        {
            Global.statement.StatementNo = Global.statement.GenerateStateNo();
            Global.statement.Consumption = Convert.ToInt32(Rdg_Bill_LBL.Text);
            Global.statement.DueTotal = Convert.ToInt32(DueTotal_Bill_LBL.Text);
            Global.statement.TotalPayments = PayAmount;
            Global.statement.Balance = balance;
            Global.statement.Date = date;
            Global.statement.Month = DateTime.Now.ToMonthName();
            Global.statement.Status = "Payment";

            Global.statement.AddStatement(AccNo_LBL.Text, Bill_Code_LBL.Text);
        }
        private void UploadImage_CMD_Click(object sender, EventArgs e)
        {
            int count = 0;
            string SQL = "SELECT COUNT(Payment_ID) FROM payment";
            count = Global.dal.MyExecuteScaler(SQL);
            count = count + 1;

            Global.payment.PaymentID = "PID/" + count.ToString();
            Global.payment.TransactionNo = Trans_Pay_TXT.Text;
            Global.payment.AccNo = AccNo_LBL.Text;
            Global.payment.Date = Date_Pay_TXT.Text;
            Global.payment.Amount = Int32.Parse(Amount_Pay_TXT.Text);
            Global.payment.PayMethod = Method_Pay_TXT.Text;
            Global.payment.Payment_Status = Name_Pay_TXT.Text;

            MemoryStream ms = new MemoryStream();
            Proof_Pay_PB.Image.Save(ms, Proof_Pay_PB.Image.RawFormat);
            byte[] Img = ms.ToArray();

            Global.payment.Proof = Img;

            SQL = "INSERT INTO payment (Payment_ID, Transaction_Number, Account_No, Date, Amount, Payment_Method, Payers_Name, Proof) VALUES (@id, @transID, @accNo, @date, @amount, @method, @payers, @proof)";
            Global.dal.UploadImage(SQL);
            //Global.payment.UpdateBillAfterPayment(AccNo_LBL.Text, Global.payment.Amount);
            //AddPaymentStatement(Convert.ToInt32(Global.payment.Amount), Global.payment.CurrentBill, Global.payment.PaymentID, Global.payment.Date);
        }

        private void LoadPayment(string PayID)
        {
            Global.payment.LoadPayments(PayID);
            PaymentID_lbl.Text = Global.payment.PaymentID;
            PayTransNo_lbl.Text = Global.payment.TransactionNo;
            PayDate_lbl.Text = Global.payment.Date;
            PayAmount_lbl.Text = Global.payment.Amount.ToString();
            PaymentMethod_lbl.Text = Global.payment.PayMethod;
            PayersName_lbl.Text = Global.payment.Payment_Status;
            MemoryStream ms = new MemoryStream(Global.payment.Proof);
            PayProof_PB.Image = Image.FromStream(ms);               
        }

        public void PopulatePaymentUC()
        {
            string SQL = ("SELECT * FROM payment WHERE Account_No='"+ AccNo_LBL.Text + "';");
            PayControlsPanel_FLP.Controls.Clear();
            Global.dal.MyExecuteReader(SQL);
            try
            {
                while (Global.dal.SQLReader.Read())
                {
                    PaymentUC PayUC = new PaymentUC();

                    PayUC.PayID = Global.dal.SQLReader["Payment_ID"].ToString();
                    PayUC.PayDate = Global.dal.SQLReader["Date"].ToString();

                    PayUC.Click += (sender, args) =>
                    {
                        LoadPayment(PayUC.PayID);
                    };

                    if (PayControlsPanel_FLP.Controls.Count < 0)
                        PayControlsPanel_FLP.Controls.Clear();
                    else
                        PayControlsPanel_FLP.Controls.Add(PayUC);
                }
            }
            catch
            {

            }
        }

        private void AddPayment_BTN_Click(object sender, EventArgs e)
        {
            AccInfoTC.SelectedTab = Add_PaymentTP;
        }
        private void PayProof_PB_Click(object sender, EventArgs e)
        {
            Global.Acc.AccountNo = AccNo_LBL.Text;
            Global.bill.BillCode = Bill_Code_LBL.Text;
            LoadPayment(PaymentID_lbl.Text);

            MemoryStream ms = new MemoryStream();
            Proof_Pay_PB.Image.Save(ms, Proof_Pay_PB.Image.RawFormat);
            Global.payment.Proof = ms.ToArray();

            ViewImageFrm VIFrm = new ViewImageFrm();
            Popup(VIFrm);
        }

        private void Popup(Form Frm)
        {
            // Take A screen shoot
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(this.PointToScreen(new Point(0, 0)), new Point(0, 0), this.ClientRectangle.Size);
                double percent = 0.60;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brush = new SolidBrush(darken))
                {
                    G.FillRectangle(brush, this.ClientRectangle);
                }
            }
            // The  screen shoo put it on the panel
            using (Panel pan = new Panel())
            {
                pan.Location = new Point(0, 0);
                pan.Size = this.ClientRectangle.Size;
                pan.BackgroundImage = bmp;
                this.Controls.Add(pan);
                pan.BringToFront();

                Frm.StartPosition = FormStartPosition.CenterParent;
                Frm.ShowDialog(this);
            }
        }


        /// <summary>
        /// ******************** Image Convertion codes *******************************************
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ConvertText_CMD_Click(object sender, EventArgs e)
        {
            Bitmap bmp = ((Bitmap)PayProof_PB.Image);
            var ocr = new AutoOcr();
            ConvertedText_TXT.Text = ocr.Read(bmp).ToString();

            test(ConvertedText_TXT.Text);
        }

        private void test(string txt)
        {
            // A list that will hold the words ending with '//jj'
            List<string> results = new List<string>();

            // The text you provided
            //string input = @"ffafa adada//bb adad ssss//jj aad adad CO220427.0854.I12403. aaada dsdsd//jj dsdsd sfsfhf//vv dfdfdf";

            // Split the string on the space character to get each word
            string[] words = txt.Split(' ');

            // Loop through each word
            foreach (string word in words)
            {
                // Does it end with '//jj'?
                if (word.EndsWith(@"."))
                {
                    // Yes, add to the list
                    results.Add(word);
                }
            }

            // Show the results
            foreach (string result in results)
            {
                MessageBox.Show(result);
            }
        }

        
    }
}
