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
    public partial class EmpUC : UserControl
    {
        public EmpUC()
        {
            InitializeComponent();
        }

        private string empID;
        private string empName;


        [Category("Custom Props")]
        public string EmpID
        {
            get { return empID; }
            set { empID = value; EmpID_lbl.Text = value; }
        }

        [Category("Custom Props")]
        public string EmpName
        {
            get { return empName; }
            set { empName = value; EmpName_lbl.Text = value; }
        }

        private void EmpUC_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            EmpID_lbl.ForeColor = Color.DimGray;
            EmpName_lbl.ForeColor = Color.DimGray;
        }

        private void EmpUC_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(127, 127, 127);
            EmpID_lbl.ForeColor = Color.WhiteSmoke;
            EmpName_lbl.ForeColor = Color.WhiteSmoke;
        }

        private void EmpUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            EmpID_lbl.ForeColor = Color.DimGray;
            EmpName_lbl.ForeColor = Color.DimGray;
        }
    }
}
