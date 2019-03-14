using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
                return View(newStudent) ;
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewStudent, Student>())
                .CreateMapper();

            var NewStudent = mapper.Map<Student>(newStudent);

            NewStudent.Class = _student.getClassByName(newStudent.ClassName);

            _manager.AddStudent(NewStudent);

            return RedirectToAction("Index", "Information", null);
        }

        public IActionResult StudentDetail(int id)
        {
            return View();
        }



    }
}