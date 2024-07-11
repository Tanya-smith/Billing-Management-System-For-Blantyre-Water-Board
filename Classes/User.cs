using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMSystem
{
    class User
    {
        private string userID;
        private string username;
        private string password;
        private string userType;

        public void Login(LoginFrm Frm)
        {
            try
            {
                if (Global.dal.OpenSQLConnection() == true)
                {
                    string SQL = "SELECT * FROM user WHERE Username='" + this.Username + "' AND Password='" + this.Password + "'";
                    Global.dal.MyExecuteReader(SQL);
                    int count = 0;
                    while (Global.dal.SQLReader.Read())
                    {
                        count = count + 1;

                    }
                    if (count == 1)
                    {
                        this.UserID = Global.dal.SQLReader["User_ID"].ToString();
                        this.Username = Global.dal.SQLReader["Username"].ToString();
                        this.UserType = Global.dal.SQLReader["User_Type"].ToString();

                        Frm.Hide();
                        MainFrm MF = new MainFrm();
                        MF.Show();
                    }
                    if (count > 1)
                    {
                        MessageBox.Show("Duplicate accounts");
                        Frm.Show();
                    }
                    else if (count == 0)
                    { 
                        CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                        CustomMessageBox.show("Account does not exist!\nPlease contact administrator", "Login Failed", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Warning);
                        Frm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to Connect");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Global.dal.CloseSQLConnection();
            }
        }

        private string GetQuery(string Q)
        {
            if (Q == "Q1")
                Q = "INSERT INTO user Values ('" + UserID + "','" + Username + "', '" + Password + "', '" + UserType + "')";
            return Q;
        }
        public void Save_users()
        {
            string Query = "Q1";
            if (Global.dal.MyExecute(GetQuery(Query)) == true)
            {
                CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                CustomMessageBox.show("User Added Successfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
            }            
                Global.dal.CloseSQLConnection();
        }
        public void LoadUserData(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Clear();
                string SQL = ("SELECT * FROM user");
                Global.dal.MyExecuteReader(SQL);

                while (Global.dal.SQLReader.Read())
                {
                    dgv.Rows.Add(
                    new object[]
                    {
                        Global.dal.SQLReader["User_ID"].ToString(),
                        Global.dal.SQLReader["Username"].ToString(),
                        Global.dal.SQLReader["Password"].ToString(),
                        Global.dal.SQLReader["User_Type"].ToString()
                    });
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

        public void GetUserDetails(string userID)
        {
            string SQL = ("SELECT * FROM user WHERE User_ID='" + userID + "';");
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                UserID = Global.dal.SQLReader["User_ID"].ToString();
                Username = Global.dal.SQLReader["Username"].ToString();
                Password = Global.dal.SQLReader["Password"].ToString();
                UserType = Global.dal.SQLReader["User_Type"].ToString();
            }
        }

        public bool LoginCheck(string uCheck)
        {
            bool Restrict = false;
            if (uCheck == "Staff")
            {
                MessageBox.Show("You Are Restricted To this Functionality");
                Restrict = false;
            }
            else Restrict = true;
            return Restrict;
        }

        public void Update_user(string ID)
        {
            string query = "UPDATE user SET User_ID='" + UserID + "', Username='" + Username + "', Password='" + Password + "', User_Type='" + UserType + "' WHERE User_ID='" + ID + "';";
            Global.dal.MyExecute(query);
            CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
            CustomMessageBox.show("Details updated Successfully.", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
        }

        public void DeleteUser(string UserID)
        {
            string query = "DELETE FROM user " +
                         "WHERE User_ID= '" + UserID + "';";
            Global.dal.MyExecute(query);
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }
    }
}
