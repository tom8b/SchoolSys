using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Services.Interfaces;

namespace SchoolSys.Controllers
{
    public class StudentController : Controller
    {
        private IManagerService _manager;
        private IStudentService _student;

        public StudentController(IManagerService manager, IStudentService student)
        {
            _manager = manager;
            _student = student;
        }
        
        //[Authorize(AuthenticationSchemes = "Application.Identity")]
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult MyMarks(int id)
        //{
        //    var model = _student.GetStudentWithTheirMarks(id);
        //    return View(model);
        //}
    }
}