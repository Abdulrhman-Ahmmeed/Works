using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanKProject
{
    class debit : Account
    {
        public double maxBalance = 100000;
        private double dailyTransLimit = 20000;

        public debit() : base()
        {
        }

        public debit(string noiname, string name, DateCheck dob, double balance) : base(noiname, name, dob, balance)
        {

        }
        public override bool deposit(double amount)
        {
            this.ammount = amount;
            if (amount > maxBalance)
            {
                Console.WriteLine("you have break limite of dailytransfer");
                return false;
            }
            else
            {
                this.balance = balance + ammount;
                Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
                return true;
            }
        }

        public override bool withdraw(double amount)
        {
            this.ammount = amount;
            if (amount > maxBalance)
            {
                Console.WriteLine("You have break limit of maxBalance : ");

                return false;
            }
            else if (amount > dailyTransLimit)

            {
                Console.WriteLine("You have break limit of dailyTransLimit : ");

                return false;
            }
            else
            {
                this.balance = balance - ammount;
                Console.WriteLine("You account balance has been withdraw.Balance is: " + balance);
                return true;
            }
        }
    }
}
