using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMSystem
{
    class ExtraMethods
    {
        public string MoneyFormat(string m)
        {
            double X = Convert.ToDouble(m);
            X = Math.Round(X, 2);
            return string.Format("{0:n}", X);
        }

        public bool FirstTimeInstallation()
        {
            string GetAns = null;
            string SQL = "SELECT * FROM first_Time_Install";
            Global.dal.MyExecuteReader(SQL);

            while (Global.dal.SQLReader.Read())
            {
                GetAns = Global.dal.SQLReader["First_Time"].ToString();
            }

            if (GetAns == "Yes") return true;
            else return false;
        }
    }
}
