using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBanKProject
{
    class Bank
    {
        object id;
        int idnum = 0;
        IdGenerate ig = new IdGenerate();
        DateCheck dc = new DateCheck();
        Credit cr = new Credit();
        debit db = new debit();
        Saving sv = new Saving();

        public object[] myId = new string[100];
        public string[] myName = new string[100];
        public string[] mydate = new string[100];
        public string[] myNomine = new string[100];
        public double[] myBalance = new double[100];
        public string[] AccType = new string[100];

        public bool val = true;
        public bool depval = true;
        private void GetAcc(object ID)
        {
            ID = this.id;
            myId[idnum] = ID;
            idnum++;
        }
        public  void Show_All()
        {
            Console.WriteLine("All accounts are:\n");
            for (int i = 0; i < idnum; i++)
            {
                Console.WriteLine(myId[i]);
            }
        }
        public void Show_Account()
        {
            int intdx;
            string idd;
            idd = Console.ReadLine();
            if (myId.Contains(idd))
            {
                intdx = Array.IndexOf(myId, idd);
                Console.WriteLine("name :"+myName[intdx]);
                Console.WriteLine("id :" + myId[intdx]);
                Console.WriteLine("Nomine :" + myNomine[intdx]);
                Console.WriteLine("date :" + mydate[intdx]);
                Console.WriteLine("balance :" + myBalance[intdx]);
                Console.WriteLine("AccType :" + AccType[intdx]);
            }
            else
            {
                Console.WriteLine("error Id");
            }
        }
        public  void Create_Account()
        {
            int choice;
            string Name;
            int d, m, y;
            string nominea;
            double balance;
            string acctype;
            Console.WriteLine("1.  Debit Account");
            Console.WriteLine("2.  Credit Account");
            Console.WriteLine("3.  Saving Account");
            choice = int.Parse(Console.ReadLine());
            if (choice==1)
            {
                acctype = "Debit";
                AccType[idnum] = acctype;
                Console.Write("Name:");
                Name = Console.ReadLine();
                myName[idnum] = Name;
                while (val == true)
                {
                    Console.WriteLine("Date:");
                    d = int.Parse(Console.ReadLine());
                    m = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                    dc.set(d, m, y);
                    if (dc.PrintDate() == false)
                    {
                        mydate[idnum] = Convert.ToString(d + "/" + m + "/" + y);

                        val = false;
                    }
                    else val = true;
                }
                val = true;
                Console.Write("Enter nominea Name:");
                nominea = Console.ReadLine();
                myNomine[idnum] = nominea;
                while (depval==true)
                {
                    Console.Write("Enter balance :");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance>db.maxBalance)
                    {
                        Console.WriteLine("you have break limite of dailytransfer");
                        depval= true;
                    }
                    else 
                    {
                        myBalance[idnum] = balance;
                        depval = false;
                    }       
                }
                depval = true;
                Console.Write("Created Debit Account Successfully...!\n");
                id = ig.gen();
                id = id + "Deb";
                Console.Write("Your Account Id" + id);
                GetAcc(id);
            }
            else if (choice == 2)
            {
                acctype = "Credit";
                AccType[idnum] = acctype;
                Console.Write("Name:");
                Name = Console.ReadLine();
                myName[idnum] = Name;
                while (val == true)
                {
                    Console.WriteLine("Date:");
                    d = int.Parse(Console.ReadLine());
                    m = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                    dc.set(d, m, y);
                    if (dc.PrintDate() == false)
                    {
                        mydate[idnum] = Convert.ToString(d + "/" + m + "/" + y);

                        val = false;
                    }

                    else val = true;
                }
                val = true;

                while (depval==true)
                {
                    Console.Write("Enter balance :");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance<cr.minBalance)
                    {
                        Console.WriteLine("You have break limit of minBalance : ");
                        depval = true;

                    }
                    else 
                    {
                        myBalance[idnum] = balance;
                        depval = false;

                    }
                }
                depval = true;

                Console.Write("Created Credit Account Successfully...!\n");
                id = ig.gen();
                id = id + "cre";
                Console.Write("Your Account Id" + id);
                GetAcc(id);
            }
            else if (choice == 3)
            {
                acctype = "Savings";
                AccType[idnum] = acctype;
                Console.Write("Name:");
                Name = Console.ReadLine();
                myName[idnum] = Name;
                while (val == true)
                {
                    Console.WriteLine("Date:");
                    d = int.Parse(Console.ReadLine());
                    m = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                    dc.set(d, m, y);
                    if (dc.PrintDate() == false)
                    {
                        mydate[idnum] = Convert.ToString(d + "/" + m + "/" + y);

                        val = false;
                    }

                    else val = true;
                }
                val = true;
                Console.WriteLine("Enter account balance: ");
                balance = Convert.ToDouble(Console.ReadLine());
                myBalance[idnum] = balance;
                Console.Write("Created Saving Account Successfully...!\n");
                id = ig.gen();
                id = id + "sev";
                Console.Write("Your Account Id" + id);
                GetAcc(id);
            }
            else
            {
                Console.WriteLine("Wrong Choice");
            }
        }
        public void deposit()
        {
            String stname = Console.ReadLine();
            int ind;
            if (myId.Contains(stname))
            {
                ind = Array.IndexOf(myId, stname);
                Console.WriteLine("Your Balance is Equal {0}", myBalance[ind]) ;
                Console.WriteLine("How much you want to deposit: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (AccType[ind]== "Debit")
                {
                    db.balance = myBalance[ind];
                    db.deposit(depval);
                    myBalance[ind] = db.balance;    


                }
                else if (AccType[ind] == "Credit")
                {
                   cr.balance = myBalance[ind];
                    cr.deposit(depval);
                    myBalance[ind] = cr.balance;
                }
                else if (AccType[ind] == "Savings")
                {
                    sv.balance = myBalance[ind];
                    sv.deposit(depval);
                    myBalance[ind] = sv.balance;
                }
            }
            else
            {
                Console.WriteLine("Error Id");
            }
        }
        public void withdraw()
        {
            string stname = Console.ReadLine();
            int ind;
            if (myId.Contains(stname))
            {
                ind = Array.IndexOf(myId, stname);
                Console.WriteLine("Your Balance is Equal {0}", myBalance[ind]);
                Console.WriteLine("How much you want to deposit: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (AccType[ind] == "Debit")
                {
                    db.balance = myBalance[ind];
                    db.withdraw(depval);
                    myBalance[ind] = db.balance;


                }
                else if (AccType[ind] == "Credit")
                {
                    cr.balance = myBalance[ind];
                    cr.withdraw(depval);
                    myBalance[ind] = cr.balance;
                }
                else if (AccType[ind] == "Savings")
                {
                    sv.balance = myBalance[ind];
                    sv.withdraw(depval);
                    myBalance[ind] = sv.balance;
                }
            }
            else
            {
                Console.WriteLine("Error Id");
            }
        }
    }
}
