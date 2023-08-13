using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanKProject
{
    class Saving : Account
    {

        public Saving() : base()
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
            this.balance = balance - ammount;
            Console.WriteLine("You account balance has been withdraw.Balance is: " + balance);
            return true;
        }
    }
}
