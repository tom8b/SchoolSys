using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.DTO
{
    public class newMark
    {
        public Student student { get; set; }
        //public Subject subject { get; set; }
        public Mark TheMark { get; set; }
        public IEnumerable<SelectListItem> Subjects { get; set; }
    }
}
