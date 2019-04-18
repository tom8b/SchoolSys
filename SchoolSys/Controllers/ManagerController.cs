using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
//[Authorize]
//        public IActionResult AddStudent()
//        {
//            var classes = _student.GetAllClasses();
//            var classesModel = classes.Select(c => new SelectListItem
//            {
//                Text = c.ClassName,
//                Value = c.ClassName
                
                            
//            });

//            var model = new AddStudentViewModel();
//            model.Classes = classesModel;
            
//            return View(model);
//        }

        //[HttpPost]
        //public IActionResult AddStudent(NewStudent newStudent)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return View(newStudent) ;
        //    }
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewStudent, Student>())
        //        .CreateMapper();

        //    var NewStudent = mapper.Map<Student>(newStudent);

        //    NewStudent.Class = _student.getClassByName(newStudent.ClassName);

        //    _manager.AddStudent(NewStudent);

        //    return RedirectToAction("Index", "Information", null);
        //}

        [Authorize(Roles ="Teacher,Admin")]
        public async Task<IActionResult> StudentDetail(int id)
        {
            var model = await _student.GetStudentWithTheirMarksAsync(id);
            return View(model);
            
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult EditMark(int id)
        {
            var model = _manager.GetMarkDetails(id);

            return View(model);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task<IActionResult> EditMark(Mark EdittedMark)
        {
            await _manager.EditMarkAsync(EdittedMark.Id, EdittedMark.TheMark);
            var studentId = (await _manager.GetStudentByMarkIdAsync(EdittedMark.Id)).Id;
            return RedirectToAction("StudentDetail", new { id = studentId });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddClass()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddClass(Class newClass)
        {
            await _manager.AddClassAsync(newClass);
            return RedirectToAction("Index", "Information", null);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddMark(int id)
        {

            var model = new newMark();
            

            model.student = await _student.GetStudentByIdAsync(id);

            var subjects = await _manager.GetAllSubjectsAsync();

            model.Subjects = subjects.Select(c => new SelectListItem
            {
                Value = c.SubjectName,
                Text = c.SubjectName
            });


            return View(model);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task<IActionResult> AddMark(newMark NewMark)
        {
            NewMark.TheMark.Student = await _student.GetStudentByIdAsync(NewMark.TheMark.Student.Id);

            NewMark.TheMark.Subject = _manager.GetSubjectByName(NewMark.TheMark.Subject.SubjectName);
            _manager.AddMark(NewMark.TheMark);
            

           
            return RedirectToAction("StudentDetail", new { id = NewMark.TheMark.Student.Id });
            
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteMark(int id)
        {
            var studentId = (await _manager.GetStudentByMarkIdAsync(id)).Id;
            _manager.RemoveMark(id);

            return RedirectToAction("StudentDetail", new { id = studentId });
        }

        public async Task<IActionResult> AddStudentToClass(int id)
        {
            var student = await _student.GetStudentByIdAsync(id);
            var classes = _student.GetAllClasses().Select(c => new SelectListItem
            {
                Value = c.ClassName,
                Text = c.ClassName
            });

            var model = new StudentClassesViewModels()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Classes = classes,
                StudentId = student.Id
                
            };

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddStudentToClass(StudentClassesViewModels input)
        {
            var student = await _student.GetStudentByIdAsync(input.StudentId);
            var studentClass = await _student.getClassByNameAsync(input.ChoosenClass.ToString());
            await _manager.AddStudentToClassAsync(student, studentClass);

            return RedirectToAction("Index", "Home", null);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult AddSubject()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddSubject(Subject newSubject)
        {
            if(ModelState.IsValid)
            {
                await _manager.AddSubjectAsync(newSubject);
            }
            return RedirectToAction("Index", "Home", null);
        }

        public async Task<IActionResult> UsersList()
        {
            var model = await Task.Run(() => _manager.GetPeopleAsync());

            return View(model);
        }

        public async Task<IActionResult> EditUser(int id)
        {
           var model = await _manager.GetPersonAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(Person editedPerson)
        {
            await _manager.UpdatePersonDetailsAsync(editedPerson);
            return RedirectToAction("UsersList");
        }

        public async Task<IActionResult> TeacherDetail(int id)
        {
            var model = await _manager.GetPersonAsync(id);

            return View(model);

        }
    }
}