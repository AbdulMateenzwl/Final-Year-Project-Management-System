using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_MS
{
    public static class Person_Helper
    {
        public static int addPerson(string FirstName,string LastName,string Contact,string email,DateTime dateTime,int gender)
        {
            // ADD Perons to DateBase \\ id is assigned by DB

            // return the id assigned by db  
            return getLastPersonId();
        }
        public static int getLastPersonId()
        {
            return 0;
        }
        public static bool update(string FirstName, string LastName, string Contact, string email, DateTime dateTime, int gender,int PersonID)
        {
            return true;
        }
    }
}
