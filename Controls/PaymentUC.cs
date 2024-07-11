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
    public partial class PaymentUC : UserControl
    {
        public PaymentUC()
        {
            InitializeComponent();
        }

        private string payID;
        private string payDate;


        [Category("Custom Props")]
        public string PayID
        {
            get { return payID; }
            set { payID = value; ID_Pay_lbl.Text = value; }
        }

        [Category("Custom Props")]
        public string PayDate
        {
            get { return payDate; }
            set { payDate = value; PayDate_DTP.Text = value; }
        }

        private void PaymentUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(127, 127, 127);
            ID_Pay_lbl.ForeColor = Color.WhiteSmoke;
            PayDate_DTP.ForeColor = Color.WhiteSmoke;
        }

        private void PaymentUC_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            ID_Pay_lbl.ForeColor = Color.DimGray;
            PayDate_DTP.ForeColor = Color.DimGray;
        }

        private void PaymentUC_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(127, 127, 127);
            ID_Pay_lbl.ForeColor = Color.WhiteSmoke;
            PayDate_DTP.ForeColor = Color.WhiteSmoke;
        }
    }
}
