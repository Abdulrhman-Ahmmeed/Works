using System;

namespace TestBanKProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bn = new Bank();
            Console.WriteLine("*** Welcome To Abdelrhman Bank ***");
            Console.WriteLine("==================================");
            while (true)
            {
                Console.WriteLine("What You Want To Do Sir");
                Console.WriteLine("1.  Creat Account");
                Console.WriteLine("2.  Show Account information");
                Console.WriteLine("3.  Deposit from Account");
                Console.WriteLine("4.  withdraw from Account");
                Console.WriteLine("5.  Show All Account With Id");
                Console.WriteLine("6.  Clear Screen");
                Console.WriteLine("7.  Exit");
                int x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Enter Account Type:");
                    bn.Create_Account();
                }
                else if (x == 2)
                {
                    Console.Write("Enter Account ID:");
                    bn.Show_Account();

                }

                else if (x == 3)
                {
                    Console.Write("Enter Account ID:");
                    bn.deposit();
                }
                else if (x == 4)
                {
                    Console.Write("Enter Account ID:");
                    bn.withdraw();
                }
                else if (x == 5)
                {
                    bn.Show_All();
                }
                else if (x == 6)
                {
                    Console.Clear();
                }
                else if (x == 7)
                {
                    Environment.Exit(0);
                }Console.ReadKey();
            }


        }
    }
}
