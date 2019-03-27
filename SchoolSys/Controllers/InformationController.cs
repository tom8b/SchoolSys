using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Services.Interfaces;

namespace SchoolSys.Controllers
{
    public class InformationController : Controller
    {
        private IStudentService _student;

        public InformationController(IStudentService student)
        {
            _student = student;
        }

        [Authorize(Roles = "Teacher,Admin")]
        public IActionResult Index()
        {
            var model = _student.GetAllClasses();

            return View(model);
        }

        [Authorize(Roles = "Teacher,Admin")]
        public IActionResult ClassDetail(int id)
        {
            var model = _student.GetStudentsFromClass(id);
            return View(model);
        }
    }
}