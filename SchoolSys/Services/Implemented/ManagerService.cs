using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolSys.Data;
using SchoolSys.DataViewModels;
using SchoolSys.DTO;
using SchoolSys.Models;
using SchoolSys.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Services.Implemented
{
    public class ManagerService : IManagerService
    {
        private SchoolContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ManagerService(SchoolContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task AddClassAsync(Class newClass)
        {
            await _context.AddAsync(newClass);
            await _context.SaveChangesAsync();
        }

        public void AddMark(Mark newMark)
        {
            _context.Add(newMark);
            _context.SaveChanges();
        }

        public void AddStudent(Student newStudent)
        {
            _context.Add(newStudent);
            _context.SaveChanges();
        }

        public async Task EditMarkAsync(int markId, decimal newMark)
        {
            var mark = await _context.Marks.FirstOrDefaultAsync(m => m.Id == markId);
            _context.Update(mark);
            mark.TheMark = newMark;
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await Task.Run(() => _context.Subjects);
        }

        /// <summary>
        /// Returns Person Id of the current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetCurrentPersonId(int userId)
        {
            var personId = _context.Users
                .Include(u => u.ThePerson)
                .FirstOrDefault(u => u.Id.Equals(userId.ToString()))
                .ThePerson.Id;

            return personId;
        }

        //testowa klasa
        public StudentWithMarksViewModel GetStudentWithTheirMarks(string userId)
        {

            var model = new StudentWithMarksViewModel();

            var student = (Student)_context.Users
                .Include(u => u.ThePerson)
                .FirstOrDefault(u => u.Id.Equals(userId.ToString()))
                .ThePerson;

            var marks = _context.Marks
                .Include(m => m.Subject)
                .Where(m => m.Student.Id == student.Id)
                .OrderBy(m => m.Subject.Id);

            model.marks = marks;
            model.student = student;
            model.StudentClass = student.Class;

            return model;

        }

        public Mark GetMarkDetails(int markId)
        {
            return _context.Marks.Include(m => m.Student).Include(m => m.Subject).FirstOrDefault(m => m.Id == markId);
        }

        public async Task<Student> GetStudentByMarkIdAsync(int markId)
        {
            var mark = await _context.Marks.Include(m=>m.Student).FirstOrDefaultAsync(m => m.Id == markId);
            return mark.Student;
        }

        public Subject GetSubject(int subjectId)
        {
            return _context.Subjects
                .FirstOrDefault(s => s.Id == subjectId);
        }

        public Subject GetSubjectByName(string subjectName)
        {
            return _context.Subjects.FirstOrDefault(s => s.SubjectName.Equals(subjectName));
        }

        public void RemoveMark(int markId)
        {
            var mark = _context.Marks.FirstOrDefault(m => m.Id == markId);
            _context.Remove(mark);
            _context.SaveChanges();
        }

       public async Task AddStudentToClassAsync(Student student, Class studentClass)
        {
            await Task.Run(() =>_context.Update(student));
            student.Class = studentClass;
            await _context.SaveChangesAsync();

        }

        public async Task AddSubjectAsync(Subject newSubject)
        {
            await _context.AddAsync(newSubject);
            await _context.SaveChangesAsync();
        }

        //public void AddSubject(Subject newSubject)
        //{
        //    _context.Add(newSubject);
        //    _context.SaveChanges();
        //}

        public async Task<PeopleDTO> GetPeopleAsync()
        {

            var people = new PeopleDTO();

            people.admins = await Task.Run(() => _context.Admins);
            people.students = await Task.Run(() => _context.Students.Include(s => s.Class));
            people.teachers = await Task.Run(() => _context.Teachers);

            return people;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="kindOfUser">Student, Admin, or Teacher</param>
        /// <returns></returns>
        public async Task<Person> GetPersonAsync(int personId)
        {
            // Person person = await Task.Run(() => _context.Students.FirstOrDefault(s => s.Id == personId));
            //person = await Task.Run(() => _context.Teachers.FirstOrDefault(t => t.Id == personId));
            //person = await Task.Run(() => _context.Admins.FirstOrDefault(a => a.Id == personId));
            var person = new Person();
       
                    if((person = await _context.Students.FirstOrDefaultAsync(s => s.Id == personId) )== null)
            {
                if((person = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == personId))== null)
                {
                    person = await _context.Admins.FirstOrDefaultAsync(a => a.Id == personId);
                }
            }
                    

                            
            

            return person;

        }

        public async Task UpdatePersonDetailsAsync(Person editedPerson)
        {
            _context.Update(editedPerson);
            await _context.SaveChangesAsync();
        }
    }
}