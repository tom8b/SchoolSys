using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Models
{
    public class Student : Person
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string PESEL { get; set; }
        //public string Address { get; set; }
        //public string MailAddress { get; set; }
        //public string TelephoneNumber { get; set; }


        public virtual Class Class { get; set; }
        public virtual IEnumerable<Mark> Marks { get; set; }
        public virtual IEnumerable<Parent> Parents { get; set; }
    }

    
    
}


