using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSys.DataViewModels;
using SchoolSys.DTO;
using SchoolSys.Models;
using SchoolSys.Services.Interfaces;

namespace SchoolSys.Controllers
{
    public class ManagerController : Controller
    {
        private IManagerService _manager;
        private IStudentService _student;

        public ManagerController(IManagerService manager, IStudentService student)
        {
            _manager = manager;
            _student = student;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult AddStudent()
        {
            var classes = _student.GetAllClasses();
            var classesModel = classes.Select(c => new SelectListItem
            {
                Text = c.ClassName,
                Value = c.ClassName
                
                            
            });

            var model = new AddStudentViewModel();
            model.Classes = classesModel;
            
            return View(model);
        }

        [HttpPost]
        public IActionResult AddStudent(NewStudent newStudent)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var NewStudent = new Student();

            NewStudent.FirstName = newStudent.FirstName;
                 NewStudent.LastName = newStudent.LastName;
                 NewStudent.Address = newStudent.Address;
                 NewStudent.PESEL = newStudent.PESEL;
                 NewStudent.MailAddress = newStudent.MailAddress;
                 NewStudent.TelephoneNumber = newStudent.TelephoneNumber;
                 NewStudent.Class = _student.getClassByName(newStudent.ClassName);
            

            _manager.AddStudent(NewStudent);

            return RedirectToAction("Index", "Information", null);
        }



    }
}