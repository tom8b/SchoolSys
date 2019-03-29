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
        public IActionResult StudentDetail(int id)
        {
            var model = _student.GetStudentWithTheirMarks(id);
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
        public IActionResult EditMark(Mark EdittedMark)
        {
            _manager.EditMark(EdittedMark.Id, EdittedMark.TheMark);
            var studentId = _student.GetStudentByMark(EdittedMark.Id).Id;
            return RedirectToAction("StudentDetail", new { id = studentId });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddClass()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddClass(Class newClass)
        {
            _manager.AddClass(newClass);
            return RedirectToAction("Index", "Information", null);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult AddMark(int id)
        {

            var model = new newMark();
            

            model.student = _student.GetStudentById(id);

            var subjects = _manager.GetAllSubjects();

            model.Subjects = subjects.Select(c => new SelectListItem
            {
                Value = c.SubjectName,
                Text = c.SubjectName
            });


            return View(model);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public IActionResult AddMark(newMark NewMark)
        {
            NewMark.TheMark.Student = _student.GetStudentById(NewMark.TheMark.Student.Id);

            NewMark.TheMark.Subject = _manager.GetSubjectByName(NewMark.TheMark.Subject.SubjectName);
            _manager.AddMark(NewMark.TheMark);
            

           
            return RedirectToAction("StudentDetail", new { id = NewMark.TheMark.Student.Id });
            
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteMark(int id)
        {
            var studentId = _manager.GetStudentByMarkId(id).Id;
            _manager.RemoveMark(id);

            return RedirectToAction("StudentDetail", new { id = studentId });
        }

        public IActionResult AddStudentToClass(int id)
        {
            var student = _student.GetStudentById(id);
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
        public IActionResult AddStudentToClass(StudentClassesViewModels input)
        {
            var student = _student.GetStudentById(input.StudentId);
            var studentClass = _student.getClassByName(input.ChoosenClass.ToString());
            _manager.AddStudentToClass(student, studentClass);

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
                //await new Task.Run(() => _manager.AddSubject(newSubject));
                // await _manager.AddSubject(newSubject);
                await Task.Run(() => _manager.AddSubject(newSubject));

            }
            return RedirectToAction("Index", "Home", null);
        }

        public async Task<IActionResult> UsersList()
        {
            var model = await Task.Run(() => _manager.GetPeople());

            return View(model);
        }

        public IActionResult EditUser(int id)
        {
           var model = _manager.GetPerson(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditUser(Person editedPerson)
        {
            _manager.UpdatePersonDetails(editedPerson);
            return RedirectToAction("UsersList");
        }

        public IActionResult TeacherDetail(int id)
        {
            var model = _manager.GetPerson(id);
            return View(model);

        }
    }
}