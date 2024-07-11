using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMSystem
{
    class Customer
    {
        private string customerID;
        private string firstname;
        private string surname;
        private string contactNo;
        private string emailAddress;
        private string location;
        private string contactAddress;

        public void AddCustomer()
        {

            string Query = "INSERT INTO customer Values ('" + CustomerID + "','" + Firstname + "', '" + Surname + "', '" + ContactNumber + "', '" + EmailAddress + "', '" + Location + "', '" + ContactAddress + "')";
            Global.dal.MyExecute(Query);
            Global.dal.CloseSQLConnection();
        }

        public void UpdateCustomer(string CustID)
        {
            string SQL = ("UPDATE customer SET CustomerID='" + CustomerID + "', Firstname='" + Firstname +
                "', Surname='"+Surname +"', Contact_No='"+ContactNumber+"', Email_Address='" + EmailAddress 
                + "', Area='" + Location + "', Contact_Address='"+ ContactAddress +"' WHERE CustomerID='"+ CustID +"'");
            Global.dal.MyExecute(SQL);
        }

        public void GetCustDetails(string AccNo)
        {
            string getDetails = ("SELECT c.*, a.Account_No FROM customer c, account a WHERE c.CustomerID=a.CustomerID AND a.Account_No='" + AccNo + "';");
            Global.dal.MyExecuteReader(getDetails);
            while (Global.dal.SQLReader.Read())
            {
                CustomerID = Global.dal.SQLReader["CustomerID"].ToString();
                Firstname = Global.dal.SQLReader["Firstname"].ToString();
                Surname = Global.dal.SQLReader["Surname"].ToString();
                ContactNumber = Global.dal.SQLReader["Contact_No"].ToString();
                EmailAddress = Global.dal.SQLReader["Email_Address"].ToString();
                Location = Global.dal.SQLReader["Area"].ToString();
                ContactAddress = Global.dal.SQLReader["Contact_Address"].ToString();
            }
        }

        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string ContactNumber
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string ContactAddress
        {
            get { return contactAddress; }
            set { contactAddress = value; }
        }
    }
}
