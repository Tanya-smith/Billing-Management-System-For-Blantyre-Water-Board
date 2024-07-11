using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IBMSystem
{
    public partial class SettingsFrm : Form
    {
        //MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        //MySqlCommand command;
        //MySqlDataAdapter da;
        public SettingsFrm()
        {
            InitializeComponent();
        }
        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            LoadBillSettingsDetails();
            SettingsTC.SelectedTab = BillTP;
        }
        private void Onclick(object sender, EventArgs e)
        {
            slider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            slider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;
        }
        private void BillSettings_CMD_Click(object sender, EventArgs e)
        {
            Onclick(BillSettings_CMD, e);
            SettingsTC.SelectedTab = BillTP;
        }

        private void EmailSettings_CMD_Click(object sender, EventArgs e)
        {
            Onclick(EmailSettings_CMD, e);
            SettingsTC.SelectedTab = EmailTP;
            LoadEmailData();
        }

        private void LoadBillSettingsDetails()
        {
            string SQL = ("SELECT * FROM bill_settings");
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                BillCode_LBL.Text = Global.dal.SQLReader["ID"].ToString();
                ReadingCharge_LBL.Text = Global.dal.SQLReader["Reading_Charge"].ToString();
                RentalCharge_LBL.Text = Global.dal.SQLReader["Rental_Charge"].ToString();
                PerKilo_LBL.Text = Global.dal.SQLReader["Charge_Per_Kilo"].ToString();
                VAT_LBL.Text = Global.dal.SQLReader["VAT"].ToString();
            }
        }

        private void UpdateBill_CMD_Click(object sender, EventArgs e)
        {
            BillForm_PNL.Visible = true;
            Code_TXT.Text = BillCode_LBL.Text;
            ReadingCharge_TXT.Text = ReadingCharge_LBL.Text;
            RentalCharge_TXT.Text = RentalCharge_LBL.Text;
            PerKilo_TXT.Text = PerKilo_LBL.Text;
            VAT_TXT.Text = VAT_LBL.Text;

        }

        private void BillFormClose_CMD_Click(object sender, EventArgs e)
        {
            BillForm_PNL.Visible = false;
            ClearControls();
        }

        private void ClearControls()
        {
            Code_TXT.Text = "";
            ReadingCharge_TXT.Text = "";
            RentalCharge_TXT.Text = "";
            PerKilo_TXT.Text = "";
            VAT_TXT.Text = "";
        }

        private void BillSettingsSave_CMD_Click(object sender, EventArgs e)
        {
            UpdateBillSettings();
            LoadBillSettingsDetails();
            ClearControls();
            BillForm_PNL.Visible = false;
        }

        private void UpdateBillSettings()
        {
            string SQL = ("UPDATE bill_settings SET ID='" + Code_TXT.Text + "', Reading_Charge='" + ReadingCharge_TXT.Text + "', Rental_Charge='" + RentalCharge_TXT.Text + "', Charge_Per_Kilo='" + PerKilo_TXT.Text + "', VAT='" + VAT_TXT.Text + "' WHERE ID='" + Code_TXT.Text + "';");
            Global.dal.MyExecute(SQL);
            CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
            CustomMessageBox.show("Date Updated Successfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
        }

        /// <summary>
        /// Email Code Start Heres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void EmailClose_CMD_Click(object sender, EventArgs e)
        {
            EmailForm_PNL.Visible = false;
        }

        private void UpdateEmail_BTN_Click(object sender, EventArgs e)
        {
            EmailForm_PNL.Visible = true;
            EmailAddress_TXT.Text = BWBEmail_LBL.Text;
            PasswordEmail_TXT.Text = PasswordEmail_LBL.Text;
            SMTPEmail_TXT.Text = SMTPEmail_LBL.Text;
            PortNoEmail_TXT.Text = PortEmail_LBL.Text;
            FromSmsNo_TXT.Text = FromSmsNo_LBL.Text;

            string check = SSLEmail_LBL.Text;
            if (check == "Checked")
                chkEM_EmailSSL.Checked = true;
            else
                chkEM_EmailSSL.Checked = false;
        }

        private void EmailSave_CMD_Click(object sender, EventArgs e)
        {
            if (PasswordEmail_TXT.Text == "" || PortNoEmail_TXT.Text == "" || SMTPEmail_TXT.Text == "" ||
                EmailAddress_TXT.Text == "" || FromSmsNo_TXT.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string check;
                Global.email.Username = EmailAddress_TXT.Text;
                Global.email.Password = PasswordEmail_TXT.Text;
                Global.email.EmailStmp = SMTPEmail_TXT.Text;
                Global.email.Port = Convert.ToInt32(PortNoEmail_TXT.Text);
                Global.sms.From = FromSmsNo_TXT.Text;

                if (chkEM_EmailSSL.Checked == true)
                    check = "Checked";
                else
                    check = "Not Checked";
                Global.email.SSL = check;

                Global.email.EditEmailCredentials();
                LoadEmailData();
                EmailForm_PNL.Visible = false;
            }
        }

        private void LoadEmailData()
        {
            Global.email.LoadEmailCredentials();
            BWBEmail_LBL.Text = Global.email.Username;
            PasswordEmail_LBL.Text = Global.email.Password;
            SMTPEmail_LBL.Text = Global.email.EmailStmp;
            PortEmail_LBL.Text = Global.email.Port.ToString();
            SSLEmail_LBL.Text = Global.email.SSL;
            FromSmsNo_LBL.Text = Global.sms.From;
        }



        // Email code Ends Here

        private void Upload_BTN_Click(object sender, EventArgs e)
        {
            Onclick(Upload_BTN, e);
            SettingsTC.SelectedTab = SMSTP;
        }

        private void UploadImage_CMD_Click(object sender, EventArgs e)
        {
            //MemoryStream ms = new MemoryStream();
            //Image_PB.Image.Save(ms, Image_PB.Image.RawFormat);
            //byte[] img = ms.ToArray();

            //string SQL = "INSERT INTO ibms_database.Image VALUES ('" + ImageID_TXT.Text + "', '" + ImageName_TXT.Text + "', '" + img + "')";
            //Global.dal.MyExecute(SQL);

            //MySqlDataAdapter da = new MySqlDataAdapter(Global.dal.MyExecute(SQL));

            //string SQL = "SELECT * FROM Image";
            //Global.dal.MyExecuteReader(SQL);
            //while (Global.dal.SQLReader.Read())
            //{
            //    ImageID_TXT.Text = Global.dal.SQLReader["Image_ID"].ToString();
            //    ImageName_TXT.Text = Global.dal.SQLReader["Image_Name"].ToString();
            //   // img = Global.dal.SQLReader["Image_File"];

            //    byte[] _img = (byte[])Global.dal.SQLReader["Image_File"];
            //    MemoryStream _ms = new MemoryStream(_img);
            //    Image_PB.Image = Image.FromStream(_ms);
            //}

            //string SQL = "SELECT * FROM ibms_database.Image";
            //command = new MySqlCommand(SQL, connection);
            //da = new MySqlDataAdapter(command);
            //DataTable table = new DataTable();

            //da.Fill(table);
            //ImageID_TXT.Text = table.Rows[0][0].ToString();
            //ImageName_TXT.Text = table.Rows[0][1].ToString();

            //byte[] img = (byte[])table.Rows[0][2];

            //MemoryStream ms = new MemoryStream(img);

            //Image_PB.Image = Image.FromStream(ms);
            //da.Dispose();

        }
    }
}
