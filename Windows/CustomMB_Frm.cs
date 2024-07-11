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
    public partial class CustomMB_Frm : Form
    {
        public CustomMB_Frm()
        {
            InitializeComponent();
            this.Show();
        }

        public enum MessageBoxButtons
        {
            OK=0, YesNo=1, YesNoCancel=2
        };

        public enum MessageBoxIcons
        {
            Informative=0, Warning=1, Error=2
        };

        public void show(string msg)
        {
            Title_lbl.Text = "";
            Message_lbl.Text = msg;

            Yes_BTN.Visible = false;
            No_BTN.Visible = false;
            Cancel_BTN.Visible = false;
        }

        public void show(string msg, string title)
        {
            Title_lbl.Text = title;
            Message_lbl.Text = msg;

            Yes_BTN.Visible = false;
            No_BTN.Visible = false;
            Cancel_BTN.Visible = false;
        }

        public void show(string msg, string title, MessageBoxButtons MBB)
        {
            Title_lbl.Text = title;
            Message_lbl.Text = msg;

            if (MessageBoxButtons.OK == MBB)
            {
                Yes_BTN.Visible = false;
                No_BTN.Visible = false;
                Cancel_BTN.Visible = false;
            }
            else if(MessageBoxButtons.YesNo == MBB)
            {
                Yes_BTN.Visible = true;
                No_BTN.Visible = true;

                Yes_BTN.Location = new Point(196, 196);
                No_BTN.Location = new Point(266, 196);

                Cancel_BTN.Visible = false;
                OK_BTN.Visible = false;
            }
            else if (MessageBoxButtons.YesNoCancel == MBB)
            {
                Yes_BTN.Visible = true;
                No_BTN.Visible = true;
                Cancel_BTN.Visible = true;
                OK_BTN.Visible = false;
            }
        }

        public void show(string msg, string title, MessageBoxButtons MBB, MessageBoxIcons MBI)
        {
            Title_lbl.Text = title;
            Message_lbl.Text = msg;

            if (MessageBoxButtons.OK == MBB)
            {
                Yes_BTN.Visible = false;
                No_BTN.Visible = false;
                Cancel_BTN.Visible = false;
            }
            else if (MessageBoxButtons.YesNo == MBB)
            {
                Yes_BTN.Visible = true;
                No_BTN.Visible = true;

                Yes_BTN.Location = new Point(196, 196);
                No_BTN.Location = new Point(266, 196);

                Cancel_BTN.Visible = false;
                OK_BTN.Visible = false;
            }
            else if (MessageBoxButtons.YesNoCancel == MBB)
            {
                Yes_BTN.Visible = true;
                No_BTN.Visible = true;
                Cancel_BTN.Visible = true;
                OK_BTN.Visible = false;
            }
            if (MessageBoxIcons.Error == MBI)
            {
                //Icon_PB.Image = Image.FromFile(@"");
                Icon_PB.Image = Properties.Resources.Error_Red;
            }
            else if (MessageBoxIcons.Informative == MBI)
            {
                //Icon_PB.Image = Image.FromFile(@"");
                Icon_PB.Image = Properties.Resources.Info;
            }
            else if (MessageBoxIcons.Warning == MBI)
            {
                //Icon_PB.Image = Image.FromFile(@"");
                Icon_PB.Image = Properties.Resources.Warning;
            }
        }

        private void Cancel_BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void No_BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Yes_BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_CMD_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
