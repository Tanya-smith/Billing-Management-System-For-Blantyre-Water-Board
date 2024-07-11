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
    public partial class LoginFrm : Form
    {
        string username; string password;
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void Close_CMD_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Username_TXT_Click(object sender, EventArgs e)
        {
            Username_TXT.BackColor = Color.White;
            UserContain_PNL.BackColor = Color.White;
            PassContainer_PNL.BackColor = SystemColors.Control;
            Password_TXT.BackColor = SystemColors.Control;
        }

        private void Password_TXT_Click(object sender, EventArgs e)
        { 
            PassContainer_PNL.BackColor = Color.White;
            Password_TXT.BackColor = Color.White;
            Username_TXT.BackColor = SystemColors.Control;
            UserContain_PNL.BackColor = SystemColors.Control;
        }

        private void Lock_PB_MouseDown(object sender, MouseEventArgs e)
        {
            Password_TXT.UseSystemPasswordChar = false;
        }

        private void Lock_PB_MouseUp(object sender, MouseEventArgs e)
        {
            Password_TXT.UseSystemPasswordChar = true;
        }

        private void Login_CMD_Click(object sender, EventArgs e)
        {
            Global.user.Username = Username_TXT.Text;
            Global.user.Password = Password_TXT.Text;
            Global.user.Login(this);

            Password_TXT.Text = "";
            Username_TXT.Text = "";
        }

        private void ForgetPassword_CMD_Click(object sender, EventArgs e)
        {
            CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
            CustomMessageBox.show("Opps We Got An Error", "Error", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
            
        }

        private void Password_TXT_MouseEnter(object sender, EventArgs e)
        {
            password = Password_TXT.Text;
            Password_TXT.Text = "";
        }
        private void Password_TXT_MouseLeave(object sender, EventArgs e)
        {
            if (Password_TXT.Text == "")
                Password_TXT.Text = password;
            else if (Password_TXT.Text != "")
                Password_TXT.Text = Password_TXT.Text;
        }

        private void Username_TXT_MouseEnter(object sender, EventArgs e)
        {
            username = Username_TXT.Text;
            Username_TXT.Text = "";
        }

        private void Username_TXT_MouseLeave(object sender, EventArgs e)
        {
            if (Username_TXT.Text == "")
                Username_TXT.Text = username;
            else if (Username_TXT.Text != "")
                    Username_TXT.Text = Username_TXT.Text;
        }
    }
}
