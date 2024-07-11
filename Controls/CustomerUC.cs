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
    public partial class CustomerUC : UserControl
    {
        public CustomerUC()
        {
            InitializeComponent();
        }
        private string accNo;
        private string accCustFirstname;
        private string accCustSurname;


        [Category("Custom Props")]
        public string AccNo
        {
            get { return accNo; }
            set { accNo = value; AccountNo_LBL.Text = value; }
        }

        [Category("Custom Props")]
        public string AccCustFirstname
        {
            get { return accCustFirstname; }
            set { accCustFirstname = value; AccCustFirstname_LBL.Text = value; }
        }

        [Category("Custom Props")]
        public string AccCustSurname
        {
            get { return accCustSurname; }
            set { accCustSurname = value; AccCustSurname_LBL.Text = value; }
        }

        private void CustomerUC_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            AccountNo_LBL.ForeColor = Color.DimGray;
            AccCustFirstname_LBL.ForeColor = Color.FromArgb(64, 73, 84);          
            AccCustSurname_LBL.ForeColor = Color.FromArgb(64, 73, 84);
        }

        private void CustomerUC_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(1, 174, 242);
            AccCustFirstname_LBL.ForeColor = Color.White;
            AccountNo_LBL.ForeColor = Color.White;
            AccCustSurname_LBL.ForeColor = Color.White;
        }

        private void CustomerUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            AccountNo_LBL.ForeColor = Color.DimGray;
            AccCustFirstname_LBL.ForeColor = Color.FromArgb(64, 73, 84);
            AccCustSurname_LBL.ForeColor = Color.FromArgb(64, 73, 84);
        }
    }
}
