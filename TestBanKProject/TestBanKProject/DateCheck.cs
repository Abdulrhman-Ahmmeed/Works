using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanKProject
{
    class DateCheck
    {

       private int Day;
       private int Month;
       private int Year;


        public void set(int d,int m ,int y)
        {
            this.Day=d ;
            this.Month = m;
            this.Year = y;
        }
       

        public bool checkdate()
        {
            if (Day > 31 || Month > 12 || Year > 2020)
            {
                Console.WriteLine("Invalid date ");
                return false;

            }
            else
                return true;
            
        }

        public bool PrintDate()
        {
            if (checkdate() == true)
            {
                Console.WriteLine("Date is : " + Day + "-" + Month + "-" + Year);
                return false;
            }
            else
                Console.WriteLine("please enter date again");
            return true;
        }






    }
}
