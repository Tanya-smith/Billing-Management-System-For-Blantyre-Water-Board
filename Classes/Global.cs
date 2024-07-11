using IBMSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMSystem
{
    class Global
    {
        // Classes

        public static Cart cart = new Cart();
        public static Schedule schedule = new Schedule();
        public static Job job = new Job();
        public static Account Acc = new Account();
        public static User user = new User();
        public static BillGenerator billGenerator = new BillGenerator();
        public static Reading reading = new Reading();
        public static Employee Emp = new Employee();
        public static Email email = new Email();
        public static DAL dal = new DAL();
        public static Customer Cust = new Customer();
        public static Bill bill = new Bill();
        public static Statement statement = new Statement();
        public static ExtraMethods extraMethods = new ExtraMethods();
        public static Printer printer = new Printer();
        public static SMS sms = new SMS();
        public static Payment payment = new Payment();

        // Forms
        //public static CustomMB_Frm MessageBox = new CustomMB_Frm();
    }
}
