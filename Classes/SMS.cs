using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace IBMSystem
{
    class SMS
    {
        private string authToken;
        private string accountSID;
        private string from;
        private string to;
        private string body;

        public void SendSMS()
        {
            AccountSID = Environment.GetEnvironmentVariable("TwilioSID");
            AuthToken = Environment.GetEnvironmentVariable("TwilioAuth");
            From = "+15406031363";
            Body = "You Have 3 remaining\nTo Pay your Bill";


            TwilioClient.Init(AccountSID, AuthToken);

            var message = MessageResource.Create
                (
                    body: Body,
                    from: new Twilio.Types.PhoneNumber(From),
                    to: new Twilio.Types.PhoneNumber(To)
                );
            MessageBox.Show(message.Sid);
        }

        private string AuthToken
        {
            set { authToken = value; }
            get { return authToken; }
        }

        private string AccountSID
        {
            set { accountSID = value; }
            get { return accountSID; }
        }

        public string From
        {
            set { from = value; }
            get { return from; }
        }

        public string To
        {
            set { to = value; }
            get { return to; }
        }

        public string Body
        {
            set { body= value; }
            get { return body; }
        }
    }
}
