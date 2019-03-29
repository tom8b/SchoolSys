using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.DTO
{
    public class PeopleDTO
    {
        public IEnumerable<Student> students { get; set; }
        public IEnumerable<Teacher> teachers { get; set; }
        public IEnumerable<Admin> admins { get; set; }
    }
}
