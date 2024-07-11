using Siticone.Desktop.UI.WinForms;
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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            //new SiticoneShadowForm(this);
            new SiticoneDragControl(LogoContainerPnl);
            new SiticoneDragControl(DragHeaderPnl);
            new SiticoneDragControl(ControlHeaderPnl);

            
        }
        private void Timer_TM_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToShortTimeString();
        }

        private Form TabForm = null;
        private void OpenChildForm(Form ChildFrm)
        {
            try
            {
                //closing active form and onening new form
                if (TabForm != null) TabForm.Close();
                TabForm = ChildFrm;

                //changing childForm properties to make it behave like a user control
                ChildFrm.TopLevel = false;
                ChildFrm.FormBorderStyle = FormBorderStyle.None; // removing borders
                ChildFrm.Dock = DockStyle.Fill; //make it take a size of a container panel


                PanelSliderPnl.Controls.Add(ChildFrm); // adding the child form to the container panel
                PanelSliderPnl.Tag = ChildFrm; // associating the child form with the container panel
                ChildFrm.BringToFront(); // bringing child form on top of the container panel
                ChildFrm.Size = PanelSliderPnl.Size;
                ChildFrm.Show(); //calling the child form
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new HomeFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void OverviewCmd_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new HomeFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void AccountsCmd_Click(object sender, EventArgs e)
        {
            //SelectUI("DashUC2", true);
            try
            {
                OpenChildForm(new AccountFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void ReportsCMD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new ReportsFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void EmployeesCMD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new EmployeesFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void Users_CMD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new UserFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void SettingsCMD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new SettingsFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void JobCMD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new JobsFrm());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Opps! \n" + Ex.Message);
            }
        }

        private void RedTrackTb_Scroll(object sender, ScrollEventArgs e)
        {
            SideNavContainerPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            //LogoContainerPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            DragHeaderPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            ControlHeaderPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
        }

        private void GreenTrackTb_Scroll(object sender, ScrollEventArgs e)
        {
            SideNavContainerPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            //LogoContainerPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            DragHeaderPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            ControlHeaderPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
        }

        private void BlueTrackTb_Scroll(object sender, ScrollEventArgs e)
        {
            SideNavContainerPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            //LogoContainerPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            DragHeaderPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
            ControlHeaderPnl.FillColor = Color.FromArgb(255, RedTrackTb.Value, GreenTrackTb.Value, BlueTrackTb.Value);
        }

        private void cmdLogOut_Click(object sender, EventArgs e)
        {
            //CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
            //CustomMessageBox.show("User Added Successfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
            



            if(MessageBox.Show("Do You want To Really Logout This Application", "Logout] Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginFrm loginFrm = new LoginFrm();             
                loginFrm.Show();               
            }
        }
    }
}
