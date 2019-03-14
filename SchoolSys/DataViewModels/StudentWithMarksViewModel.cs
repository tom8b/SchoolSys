using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.DataViewModels
{
    public class StudentWithMarksViewModel
    {
        public Student student { get; set; }

        /// <summary>
        /// class student belongs to
        /// </summary>
        public Class StudentClass { get; set; }

        public IEnumerable<Mark> marks { get; set; }
    }
}
