using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.DataViewModels
{
    public class StudentClassesViewModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }

        public string ChoosenClass { get; set; }
        public IEnumerable<SelectListItem> Classes { get; set; }
    }
}
