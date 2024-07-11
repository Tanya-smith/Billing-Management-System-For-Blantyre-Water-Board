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
    public partial class UserUC : UserControl
    {
        public UserUC()
        {
            InitializeComponent();
        }

        private string userID;
        private string username;


        [Category("Custom Props")]
        public string UserID
        {
            get { return userID; }
            set { userID = value; UserID_lbl.Text = value; }
        }

        [Category("Custom Props")]
        public string Username
        {
            get { return username; }
            set { username = value; Username_lbl.Text = value; }
        }

        private void UserUC_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            UserID_lbl.ForeColor = Color.DimGray;
            Username_lbl.ForeColor = Color.DimGray;
        }

        private void UserUC_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(127, 127, 127);
            UserID_lbl.ForeColor = Color.WhiteSmoke;
            Username_lbl.ForeColor = Color.WhiteSmoke;
        }

        private void UserUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            UserID_lbl.ForeColor = Color.DimGray;
            Username_lbl.ForeColor = Color.DimGray;
        }
    }
}
