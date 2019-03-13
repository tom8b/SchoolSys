using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        public virtual Teacher SubjectTeacher { get; set; }
        public virtual IEnumerable<Student> SubjectStudents { get; set; }

    }
}
