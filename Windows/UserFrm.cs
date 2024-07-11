using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMSystem
{
    public partial class UserFrm : Form
    {
        bool addUser = false;
        public UserFrm()
        {
            InitializeComponent();
        }

        private void UserFrm_Load(object sender, EventArgs e)
        {
            PopulateUserUC();
        }

        private void GetUserDetails(string UserID)
        {
            Global.user.GetUserDetails(UserID);
            UserID_LBL.Text =  Global.user.UserID;
            Username_LBL.Text =  Global.user.Username;
            Password_lbl.Text =  Global.user.Password;
            UserType_lbl.Text =  Global.user.UserType;
        }

        private void PopulateUserUC()
        {

            int count = 0;
            string getCount = "SELECT COUNT(*) FROM user";
            count = Global.dal.MyExecuteScaler(getCount);

            string getCustDetails = ("SELECT * FROM user;");
            userControlsPanel_FLP.Controls.Clear();
            Global.dal.MyExecuteReader(getCustDetails);

            UserCount_LBL.Text = count.ToString();

            try
            {

                while (Global.dal.SQLReader.Read())
                {
                    UserUC userUC = new UserUC();

                    userUC.UserID = Global.dal.SQLReader["User_ID"].ToString();
                    userUC.Username = Global.dal.SQLReader["Username"].ToString();

                    userUC.Click += (sender, args) =>
                    {
                        GetUserDetails(userUC.UserID);
                        UpdateUser_BTN.Enabled = true;
                    };

                    if (userControlsPanel_FLP.Controls.Count < 0)
                        userControlsPanel_FLP.Controls.Clear();
                    else
                        userControlsPanel_FLP.Controls.Add(userUC);
                }
            }
            catch
            {

            }
        }

        private void SearchBoxTxt_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            string getCount = "SELECT COUNT(*) FROM user";
            count = Global.dal.MyExecuteScaler(getCount);

            string getCustDetails = ("SELECT * FROM user WHERE CONCAT(User_ID, Username, User_Type) like'%" + SearchBoxTxt.Text + "%';");
            userControlsPanel_FLP.Controls.Clear();
            Global.dal.MyExecuteReader(getCustDetails);

            UserCount_LBL.Text = count.ToString();

            try
            {

                while (Global.dal.SQLReader.Read())
                {
                    UserUC userUC = new UserUC();

                    userUC.UserID = Global.dal.SQLReader["User_ID"].ToString();
                    userUC.Username = Global.dal.SQLReader["Username"].ToString();

                    userUC.Click += (sender_1, args) =>
                    {
                        GetUserDetails(userUC.UserID);
                        UpdateUser_BTN.Enabled = true;
                    };

                    if (userControlsPanel_FLP.Controls.Count < 0)
                        userControlsPanel_FLP.Controls.Clear();
                    else
                        userControlsPanel_FLP.Controls.Add(userUC);
                }
            }
            catch
            {

            }
        }
        private void UpdateUser_BTN_Click(object sender, EventArgs e)
        {
            UserID_TXT.Text = UserID_LBL.Text;
            Password_TXT.Text = Password_lbl.Text;
            Username_TXT.Text = Username_LBL.Text;
            UserType_CMB.Text = UserType_lbl.Text;

            UserID_TXT.Enabled = false;
            addUser = false;
            AddUserForm_PNL.Visible = true;
        }

        private void AddUser_BTN_Click(object sender, EventArgs e)
        {
            ClearControl();
            addUser = true;
            AddUserForm_PNL.Visible = true;
        }

        private void ClearControl()
        {
            UserID_TXT.Text = "";
            Password_TXT.Text = "";
            Username_TXT.Text = "";
            UserType_CMB.Text = "";
        }

        private void UserSave_CMD_Click(object sender, EventArgs e)
        {
           if (addUser == true)
           {
                if (UserID_TXT.Text == "" || Password_TXT.Text == "" || Username_TXT.Text == "" || UserType_CMB.Text == "")
                {
                    //MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                    CustomMessageBox.show("One of the box is empty. Data is required.", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
                }
                else
                {
                    Global.user.UserID = UserID_TXT.Text;
                    Global.user.Username = Username_TXT.Text;
                    Global.user.Password = Password_TXT.Text;
                    Global.user.UserType = UserType_CMB.Text;
                    Global.user.Save_users();
                    PopulateUserUC();
                    ClearControl();
                    AddUserForm_PNL.Visible = false;
                }
           }
           else if (addUser == false)
           {
                if (UserID_TXT.Text == "" || Password_TXT.Text == "" || Username_TXT.Text == "" || UserType_CMB.Text == "")
                {
                    CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
                    CustomMessageBox.show("One of the box is empty. Data is required.", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
                }
                else
                {
                    Global.user.UserID = UserID_TXT.Text;
                    Global.user.Username = Username_TXT.Text;
                    Global.user.Password = Password_TXT.Text;
                    Global.user.UserType = UserType_CMB.Text;
                    Global.user.Update_user(UserID_TXT.Text);
                    GetUserDetails(UserID_TXT.Text);
                    ClearControl();
                    AddUserForm_PNL.Visible = false;
                }
            }
        }

        private void Close_CMD_Click(object sender, EventArgs e)
        {
            AddUserForm_PNL.Visible = false;
        }
    }
}
