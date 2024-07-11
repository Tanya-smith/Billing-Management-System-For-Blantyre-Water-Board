using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace IBMSystem.Classes
{
    class DAL
    {
        private MySqlConnection SQLConn;
        public MySqlDataReader SQLReader;
        private string server;
        private string database;
        private string username;
        private string password;
        private string port;
        private string connectionString;

        public DAL()
        {
            // ***** use this for online database connection ********

           // server = "209.145.62.115";
            //database = "cocmwxy4_ibms_database";
            //username = "cocmwxy4_ibms_user";
            //password = "1234ibms_user100%";
            //port = "3306";

            // **** Local database connection.. Use this for local database connection ******

            server = "localhost";
            database = "cocmwxy4_ibms_database";
            username = "root";
            password = "";
            port = "3306";

            // ***** Local ends *************//

            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            SQLConn = new MySqlConnection(connectionString);

        }

        public MySqlConnection Connect
        {
            get { return SQLConn; }
            set { SQLConn = value; }
        }

        public bool OpenSQLConnection()
        {
            try
            {
                SQLConn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }

        public bool CloseSQLConnection()
        {
            try
            {
                SQLConn.ClearAllPoolsAsync();
                SQLConn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }

        public bool MyExecute(string query)
        {
            bool myReturn = false;
            DAL dbc = new DAL();
            try
            {
                if (dbc.OpenSQLConnection() == true)
                {
                    MySqlCommand msc = new MySqlCommand(query, dbc.Connect);
                    msc.ExecuteNonQuery();
                    myReturn = true;
                }
            }
            catch (Exception ex)
            {
                myReturn = false;
                MessageBox.Show("" + ex.Message);
            }
            return myReturn;
        }

        public bool UploadImage(string SQL)
        {
            bool myReturn = false;
            DAL dbc = new DAL();
            try
            {
                if (dbc.OpenSQLConnection() == true)
                {
                    MySqlCommand msc = new MySqlCommand(SQL, dbc.Connect);

                    msc.Parameters.Add("@id", MySqlDbType.VarChar, 45);
                    msc.Parameters.Add("@transID", MySqlDbType.VarChar, 45);
                    msc.Parameters.Add("@accNo", MySqlDbType.VarChar, 30);
                    msc.Parameters.Add("@date", MySqlDbType.Date);
                    msc.Parameters.Add("@amount", MySqlDbType.Int32, 11);
                    msc.Parameters.Add("@method", MySqlDbType.VarChar, 45);
                    msc.Parameters.Add("@payers", MySqlDbType.VarChar, 30);
                    msc.Parameters.Add("@proof", MySqlDbType.Blob);

                    msc.Parameters["@id"].Value = Global.payment.PaymentID;
                    msc.Parameters["@transID"].Value = Global.payment.TransactionNo;
                    msc.Parameters["@accNo"].Value = Global.payment.AccNo;
                    msc.Parameters["@date"].Value = Global.payment.Date;
                    msc.Parameters["@amount"].Value = Global.payment.Amount;
                    msc.Parameters["@method"].Value = Global.payment.PayMethod;
                    msc.Parameters["@payers"].Value = Global.payment.Payment_Status;
                    msc.Parameters["@proof"].Value = Global.payment.Proof;
                    msc.ExecuteNonQuery();
                    myReturn = true;
                }
            }
            catch (Exception ex)
            {
                myReturn = false;
                MessageBox.Show("" + ex.Message);
            }
            return myReturn;
        }


        public void MyExecuteReader(string query)
        {
            DAL dbc = new DAL();
            try
            {
                if (dbc.OpenSQLConnection() == true)
                {
                    MySqlCommand msc = new MySqlCommand(query, dbc.Connect);
                    this.SQLReader = msc.ExecuteReader();
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("" + EX.Message);
            }
            finally
            {
                
            }
        }

        public int MyExecuteScaler(string query)
        {
            DAL dbc = new DAL();
            int count = 0;
            try
            {

                if (dbc.OpenSQLConnection() == true)
                {
                    MySqlCommand msc = new MySqlCommand(query, dbc.Connect);
                    count = Int32.Parse(msc.ExecuteScalar().ToString());
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
            finally
            {
                
            }

            return count;
        }

        public bool ResetPool()
        {
            try
            {
                SQLConn.ClearAllPoolsAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
