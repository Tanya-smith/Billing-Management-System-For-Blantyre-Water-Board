using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMSystem.Classes
{
    class Reading
    {
        private string accNo;
        private int prevReading;

        public string AccNo
        {
            get { return accNo; }
            set { accNo = value; }
        }

        public int PrevReading
        {
            get { return prevReading; }
            set { prevReading = value; }
        }

        public void DefaultReading()
        {
            PrevReading = 0;
            string SQL = "INSERT INTO readings (Account_No, Previous_Reading) VALUES ('" + AccNo + "', " + PrevReading + ")";
            Global.dal.MyExecute(SQL);
        }

        public void SaveReading()
        {
            string SQL = "UPDATE readings SET Account_No='" + AccNo + "', Previous_Reading=" + PrevReading + " WHERE Account_No='" + AccNo + "';";
            Global.dal.MyExecute(SQL);
        }

        public int GetPrevReading(string _AccNo)
        {
            string SQL = "SELECT * FROM readings WHERE Account_No='" + _AccNo + "'";
            Global.dal.MyExecuteReader(SQL);
            while (Global.dal.SQLReader.Read())
            {
                PrevReading = Int32.Parse(Global.dal.SQLReader["Previous_Reading"].ToString());
            }

            return PrevReading;
        }
    }
}
