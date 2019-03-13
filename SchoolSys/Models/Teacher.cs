using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Models
{
    public class Teacher 
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string Address { get; set; }
        public string MailAddress { get; set; }
        public string TelephoneNumber { get; set; }


        /// <summary>
        /// Class that the teacher is tutor for
        /// </summary>
        public virtual Class Class { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}
