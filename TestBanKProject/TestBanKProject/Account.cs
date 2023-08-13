using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanKProject
{
   abstract class Account
    {

        public readonly string id;
        public readonly string name;
        public readonly string noinem;
        public  double balance;
        public readonly DateCheck data;
        public  double ammount;
        public readonly string acctype;

        public abstract bool deposit(double amount);

        public abstract bool withdraw(double amount);

        public Double GetBalance()
        {
            return balance;

        }
        public string GetAccType()
        {
            string acctypee;

            acctypee = Console.ReadLine();
            return acctypee;
        }

        public void PrintData()
        {
            Console.WriteLine("Id:"+noinem); 
            Console.WriteLine("name:" + name);
            Console.WriteLine("Id:" + balance);
            Console.WriteLine("Id:" + data);
        }

        public Account(string name)
        {

        }
        public Account(string noiname,string name,DateCheck dob,double balance)
        {
            this.noinem = noiname;
            this.name = name;
            this.data = dob;
            this.balance = balance;
        
        }

        protected Account()
        {
        }
    }
}
