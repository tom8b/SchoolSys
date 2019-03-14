using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSys.DTO;
using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.DataViewModels
{
    public class AddStudentViewModel
    {
        //public Student student { get; set; }
        public NewStudent newStudent { get; set; }


        public IEnumerable<SelectListItem> Classes { get; set; }
    }
}
