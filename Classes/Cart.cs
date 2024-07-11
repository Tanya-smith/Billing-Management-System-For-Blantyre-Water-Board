using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    class Cart
    {
        private string no;
        private string jobID;
        private string bill_Code;
        private string account_No;
        private int amount;


        public void AddToCart()
        {
            string SQL = "INSERT INTO cart (Job_ID, Bill_Code, Account_No, Amount) Values ('" + JobID + "', '" + Bill_Code + "', '" + Account_No + "', '" + Amount + "')";
            Global.dal.MyExecute(SQL);
        }

        public void RemoveFromCart(string code)
        {
            string query = "DELETE FROM cart " +
                         "WHERE No= '" + code + "';";
            Global.dal.MyExecute(query);
            Global.dal.CloseSQLConnection();
        }

        public void DeleteCart()
        {
            string Query = "DELETE FROM cart";
            Global.dal.MyExecute(Query);
            Global.dal.CloseSQLConnection();
        }

        public void LoadItems(DataGridView dgv)
        {
            string query = ("SELECT * FROM cart");
            LoadData(dgv, query);
        }

        private static void LoadData(DataGridView dgv, string query)
        {
            try
            {
                dgv.Rows.Clear();
                Global.dal.MyExecuteReader(query);

                while (Global.dal.SQLReader.Read())
                {
                    dgv.Rows.Add(
                    new object[]
                    {
                        Global.dal.SQLReader["No"].ToString(),
                        Global.dal.SQLReader["Job_ID"].ToString(),
                        Global.dal.SQLReader["Bill_Code"].ToString(),
                        Global.dal.SQLReader["Account_No"].ToString(),
                        Global.dal.SQLReader["Amount"].ToString(),
                    }

                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }


        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string JobID
        {
            get { return jobID; }
            set { jobID = value; }        
        }

        public string Bill_Code
        {
            get { return bill_Code; }
            set { bill_Code = value; }
        }

        public string Account_No
        {
            get { return account_No; }
            set { account_No = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
