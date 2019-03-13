using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int TutorForeignKey { get; set; }

        public virtual IEnumerable<Student> ClassMembers { get; set; }

        [ForeignKey("TutorForeignKey")]
        public virtual Teacher Tutor { get; set; }
    }
}
