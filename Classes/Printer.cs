using DGVPrinterHelper;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace IBMSystem
{
    class Printer
    {
        public void PrintDataGridView(string title, string subTitle, string footer, DataGridView DGV)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = title;
            printer.SubTitle = subTitle;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = footer;
            printer.FooterSpacing = 15;

            printer.PrintDataGridView(DGV);
        }

        public void GenerateInvoice(PrintPageEventArgs e, string[] BillDetails)
        {
            //Image Codes
            Bitmap bmp = Properties.Resources.TopHeader;
            Image Header = bmp;
            e.Graphics.DrawImage(Header, 25, 25, Header.Width, Header.Height);

            Bitmap bmp2 = Properties.Resources.DIV;
            Image HeadingsDivs = bmp2;
            e.Graphics.DrawImage(HeadingsDivs, 25, 606, HeadingsDivs.Width, HeadingsDivs.Height);

            Bitmap bmp3 = Properties.Resources.DataGrid;
            Image DataGrid = bmp3;
            e.Graphics.DrawImage(DataGrid, 25, 686, DataGrid.Width, DataGrid.Height);

            Bitmap bmp4 = Properties.Resources.DataRows;
            Image DataRows = bmp4;
            e.Graphics.DrawImage(DataRows, 25, 725, DataRows.Width, DataRows.Height);

            // Customer Details And Bill Invoice Details At the Same Positions

            // Headings For Both
            e.Graphics.DrawString("CUSTOMER", new Font("Arial", 14, FontStyle.Bold), Brushes.White, new Point(30, 420));
            e.Graphics.DrawString("BILL INVOICE", new Font("Arial", 14, FontStyle.Bold), Brushes.White, new Point(445, 420));

            // Customer
            e.Graphics.DrawString(BillDetails[0], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 456));
            e.Graphics.DrawString(BillDetails[1], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 476));
            e.Graphics.DrawString(BillDetails[2], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(80, 476));
            e.Graphics.DrawString(BillDetails[3], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 496));
            e.Graphics.DrawString(BillDetails[4], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 516));

            e.Graphics.DrawString("Phone No:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(30, 556));
            e.Graphics.DrawString(BillDetails[5], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(110, 556));
            e.Graphics.DrawString("Email:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 576));
            e.Graphics.DrawString(BillDetails[6], new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, new Point(110, 576));

            //Bill Invoice
            e.Graphics.DrawString("BI:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(450, 456));
            e.Graphics.DrawString(BillDetails[7], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 456));

            // Issue Date
            e.Graphics.DrawString("Issue Date:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(450, 496));
            e.Graphics.DrawString(BillDetails[8], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 496));
            e.Graphics.DrawString(DateTime.Now.ToShortTimeString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(650, 496));

            e.Graphics.DrawString("BI Status:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(450, 516));
            e.Graphics.DrawString(BillDetails[9], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 516));


            // Account Details
            e.Graphics.DrawString("Account No:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(450, 556));
            e.Graphics.DrawString(BillDetails[22], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 556));
            e.Graphics.DrawString("Meter No:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(450, 576));
            e.Graphics.DrawString(BillDetails[23], new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, new Point(550, 576));

            // Middle Div Headings
            e.Graphics.DrawString("Due Date", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(30, 614));
            e.Graphics.DrawString("Due Day(S)", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(250, 614));
            e.Graphics.DrawString("Water Consumption", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(400, 614));
            e.Graphics.DrawString("Due Amount", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(600, 614));

            // Middle Div Content
            e.Graphics.DrawString(BillDetails[10], new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 652));
            e.Graphics.DrawString(BillDetails[11] + " Days", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 652));
            e.Graphics.DrawString(BillDetails[18], new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(400, 652));
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[13].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 652));

            // Data Grid Headings
            e.Graphics.DrawString("DESCRIPTION", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(30, 695));
            e.Graphics.DrawString("AMOUNT", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(600, 695));

            // Data Grid Description
            e.Graphics.DrawString("Balance Brought Forward", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 725));
            e.Graphics.DrawString("Meter Reading Charge", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 757));
            e.Graphics.DrawString("Meter Rental Charge", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 788));
            e.Graphics.DrawString("Water Charge Consumption", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 818));
            e.Graphics.DrawString("Water Readings", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 849));
            e.Graphics.DrawString("Monthly Subtotal Liable", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 880));
            e.Graphics.DrawString("Value Added Tax (VAT)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 911));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 942));

            //Data Grid Content
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[14].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 725));
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[15].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 757));
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[16].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 788));
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[17].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 818));
            e.Graphics.DrawString(BillDetails[18], new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 849));
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[19].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 880));
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[20].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 911));
            e.Graphics.DrawString(string.Format("{0} {1}", "MK", Global.extraMethods.MoneyFormat(BillDetails[21].ToString())), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 942));


            //Footer
            e.Graphics.DrawString("Operator: " + "USD001198501, " + " Elvis Namuru ", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(260, 1102));
            e.Graphics.DrawString("******* Blantyre Water Board *******", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(275, 1125));
            e.Graphics.DrawString("Water is life", new Font("Arial", 11, FontStyle.Italic), Brushes.DarkBlue, new Point(360, 1145));
            //================================ENDS HERE ===========================
        }

        public void PrintingTaskDetails(PrintPageEventArgs e, string[] BillDetails)
        {
            string SQL = "SELECT c.Firstname, c.Surname, s.Account_No, a.Meter_Number, s.Amount, c.Contact_Address FROM Account a, Customer c, Schedule s WHERE c.CustomerID=a.CustomerID AND s.Account_No=a.Account_No AND s.Job_ID='" + BillDetails[1] + "';";
            Global.dal.MyExecuteReader(SQL);
            int Increment = 725;

            //Image Codes
            Bitmap bmp = Properties.Resources.bwb;
            Image Header = bmp;
            e.Graphics.DrawImage(Header, 300, 25, Header.Width, Header.Height);

            Bitmap bmp2 = Properties.Resources.DIV;
            Image HeadingsDivs = bmp2;
            e.Graphics.DrawImage(HeadingsDivs, 25, 360, HeadingsDivs.Width, HeadingsDivs.Height);

            // Top Details
            e.Graphics.DrawString("EMPLOYEE WORKING DOCUMENT", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(250, 270));
            e.Graphics.DrawString("Date:  " + BillDetails[0], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 300));
            e.Graphics.DrawString("Job ID:  " + BillDetails[1], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(340, 330));

            // Headings For Both
            e.Graphics.DrawString("JOB DETAILS", new Font("Arial", 14, FontStyle.Bold), Brushes.White, new Point(30, 367));
            e.Graphics.DrawString("EMPLOYEE", new Font("Arial", 14, FontStyle.Bold), Brushes.White, new Point(445, 367));

            // Job Details
            e.Graphics.DrawString("Job Type:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(30, 400));
            e.Graphics.DrawString(BillDetails[2], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 400));
            e.Graphics.DrawString("Start Date:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 430));
            e.Graphics.DrawString(BillDetails[3], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 430));
            e.Graphics.DrawString("End Date:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(30, 460));
            e.Graphics.DrawString(BillDetails[4], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 460));
            e.Graphics.DrawString("Duration:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 490));
            e.Graphics.DrawString(BillDetails[5], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 490));
            e.Graphics.DrawString("Location:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(30, 520));
            e.Graphics.DrawString(BillDetails[6], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 520));
            e.Graphics.DrawString("Status:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 550));
            e.Graphics.DrawString(BillDetails[7], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 550));
            e.Graphics.DrawString("Number of Task:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 580));
            e.Graphics.DrawString(BillDetails[8], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 580));

            // Employee Details
            e.Graphics.DrawString("Employee ID:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(450, 400));
            e.Graphics.DrawString(BillDetails[9], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(610, 400));
            e.Graphics.DrawString("Employee Name:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(450, 430));
            e.Graphics.DrawString(BillDetails[10], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(610, 430));

            // Task Header
            e.Graphics.DrawString("TASK DETAILS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(350, 630));

            Bitmap bmp3 = Properties.Resources.DIV;
            Image DataGrid = bmp3;
            e.Graphics.DrawImage(DataGrid, 25, 686, DataGrid.Width, DataGrid.Height);         

            // Task Div Headings
            e.Graphics.DrawString("Customer", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(30, 694));
            e.Graphics.DrawString("Account", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(200, 694));
            e.Graphics.DrawString("Meter No", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(300, 694));
            e.Graphics.DrawString("Bill (MK)", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(400, 694));
            e.Graphics.DrawString("Address", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(500, 694));
            e.Graphics.DrawString("Status", new Font("Arial", 12, FontStyle.Bold), Brushes.White, new Point(700, 694));
            
            // Grid
            Bitmap bmp4 = Properties.Resources.DataRows;
            Image DataRows = bmp4;
            e.Graphics.DrawImage(DataRows, 25, 725, DataRows.Width, DataRows.Height);

            while (Global.dal.SQLReader.Read())
            {
                e.Graphics.DrawString(Global.dal.SQLReader.GetString("Firstname"), new Font("segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(30, Increment));
                e.Graphics.DrawString(Global.dal.SQLReader.GetString("Surname"), new Font("segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(90, Increment));
                e.Graphics.DrawString(Global.dal.SQLReader.GetString("Account_No"), new Font("segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(200, Increment));
                e.Graphics.DrawString(Global.dal.SQLReader.GetString("Meter_Number"), new Font("segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(300, Increment));
                e.Graphics.DrawString(Global.dal.SQLReader.GetString("Amount"), new Font("segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(400, Increment));
                e.Graphics.DrawString(Global.dal.SQLReader.GetString("Contact_Address"), new Font("segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(500, Increment));

                Increment = Increment + 31;
            }

            //Footer
            e.Graphics.DrawString("******* Blantyre Water Board *******", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(275, 1125));
            e.Graphics.DrawString("Water is life", new Font("Arial", 11, FontStyle.Italic), Brushes.DarkBlue, new Point(360, 1145));
            //================================ENDS HERE ===========================
        }
    }
}
