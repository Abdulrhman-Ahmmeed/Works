using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanKProject
{
    class IdGenerate
    {
        
        DateTime d1= DateTime.Now;
        String id;
        int hes = 0;
        public string gen()
        {

            string date = d1.ToString("yyy-dd") ;
            id = date+ ++hes;
            return id;
        }
    }
}
