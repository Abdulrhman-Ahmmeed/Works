using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanKProject
{
    class Credit : Account
    {

        public double minBalance = -100000;
        private double dailyWithdrawLimit = 20000;

        public Credit():base()
        {
        }

        public Credit(string noiname, string name, DateCheck dob, double balance) : base(noiname, name, dob, balance)
        {

        }
        public override bool deposit(double amount)
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
            return true;
        }

        public override bool withdraw(double amount)
        {
            this.ammount = amount;
            if (amount> dailyWithdrawLimit)
            {
                Console.WriteLine("You have break limit of dailyWithdraw : " );

                return false;
            }
            else if (amount < minBalance)

            {
                Console.WriteLine("You have break limit of minBalance : ");

                return false;
            }
            else
            {
                this.ammount = amount;
                this.balance = balance - ammount;
                Console.WriteLine("You account balance has been withdraw.Balance is: " + balance);
                return true;
            }
        }
    }
}
