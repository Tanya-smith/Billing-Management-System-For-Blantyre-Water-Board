using System;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace IBMSystem
{
    class Email
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage message;

        private string to;
        private string cc;
        private string subject;
        private string body;

        private string username;
        private string password;
        private string emilStmp;
        private string adminEA;
        private string ssl;
        private int port;

        public void Email_Send_Cancelled(string getPath)
        {
            //try
            //{
                LoadEmailCredentials();
                string stmp = "";
                login = new NetworkCredential(this.Username, this.Password);
                client = new SmtpClient(this.EmailStmp);
                client.Port = Convert.ToInt32(this.Port);
                client.EnableSsl = true;
                client.Credentials = login;
                message = new MailMessage { From = new MailAddress(this.Username + stmp.Replace("smtp.", "@"), this.Username, Encoding.UTF8) };
                message.To.Add(new MailAddress(To));

                if (!string.IsNullOrEmpty(CC))
                {
                    message.To.Add(new MailAddress(CC));
                }

                if (getPath != null)
                {
                    message.Attachments.Add(new Attachment(getPath));
                    message.Subject = Subject;
                    message.Body = Body;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.Normal;
                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    string userstate = "Sending....";
                    client.SendAsync(message, userstate);
                }
                else
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.Normal;
                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    string userstate = "Sending....";
                    client.SendAsync(message, userstate);
                }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send cancelled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LoadEmailCredentials()
        {
            string getCredentials = ("SELECT * FROM email_credentials");
            Global.dal.MyExecuteReader(getCredentials);

            while (Global.dal.SQLReader.Read())
            {
                this.Username = Global.dal.SQLReader["Username"].ToString();
                this.Password = Global.dal.SQLReader["Password"].ToString();
                this.Port = Convert.ToInt32(Global.dal.SQLReader["Port"].ToString());
                this.EmailStmp = Global.dal.SQLReader["Stmp"].ToString();
                this.AdminEA = Global.dal.SQLReader["Admin_Email_Address"].ToString();
                this.SSL = Global.dal.SQLReader["Socket"].ToString();
                Global.sms.From = Global.dal.SQLReader["From_SMS_No"].ToString();
            }
        }

        public void SendEmail()
        {
            try
            {
                LoadEmailCredentials();
                MailMessage message = new MailMessage();
                message.To.Add(To);
                message.From = new MailAddress(AdminEA);
                message.Body = Body;
                message.Subject = Subject;
                SmtpClient smtp = new SmtpClient(EmailStmp);
                smtp.EnableSsl = true;
                smtp.Port = Port;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(Username, Password);
                smtp.Send(message);
                MessageBox.Show("Email Send");
            }
            catch
            {

            }
        }
        public void EditEmailCredentials()
        {
            string Edit = "UPDATE email_Credentials SET Username='" + this.Username + "', Password='" + this.Password + "', Stmp='" +
                this.EmailStmp + "', Port='" + this.Port + "', Socket='" + this.SSL + "', From_SMS_No='" + Global.sms.From + "' WHERE Email_ID='EM001';";
            Global.dal.MyExecute(Edit);
            CustomMB_Frm CustomMessageBox = new CustomMB_Frm();
            CustomMessageBox.show("Details Saved Successfully", "Info", CustomMB_Frm.MessageBoxButtons.OK, CustomMB_Frm.MessageBoxIcons.Informative);
        }

        public void SendEmailToAllCustomers(string Subject, string Message)
        {
            List<string> EmailAddresses = new List<string>();
            string query = "SELECT COUNT(*) FROM customer";
            int count = 0;
            count = Global.dal.MyExecuteScaler(query);

            query = "SELECT * FROM customer";
            Global.dal.MyExecuteReader(query);

            while (Global.dal.SQLReader.Read())
            {
                EmailAddresses.Add(Global.dal.SQLReader["Email_Address"].ToString());
            }

            for (int i = 0; i < count; i++)
            {
                //string getPath = null;
                Global.email.To = EmailAddresses[i];
                Global.email.CC = "";
                Global.email.Subject = Subject;
                Global.email.Body = Message;
                Global.email.SendEmail();
            }
        }
        public string To
        {
            get { return to; }
            set { to = value; }
        }

        public string CC
        {
            get { return cc; }
            set { cc = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Body
        {
            get { return body; }
            set { body = value; }
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

        public string EmailStmp
        {
            get { return emilStmp; }
            set { emilStmp = value; }
        }

        public string AdminEA
        {
            get { return adminEA; }
            set { adminEA = value; }
        }

        public string SSL
        {
            get { return ssl; }
            set { ssl = value; }
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
    }
}
