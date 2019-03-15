using Microsoft.EntityFrameworkCore;
using SchoolSys.Data;
using SchoolSys.DataViewModels;
using SchoolSys.Models;
using SchoolSys.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Services.Implemented
{
    public class StudentService : IStudentService
    {
        private SchoolContext _context;

        public StudentService(SchoolContext context)
        {
            _context = context;
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _context.Classes;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students;
        }

        public Class getClass(int classId)
        {
            return _context.Classes.FirstOrDefault(c => c.Id == classId);
        }

        public Class getClassByName(string className)
        {
            return _context.Classes.FirstOrDefault(c => c.ClassName.Equals(className));
        }

        public Student GetStudentById(int id)
        {
            return _context.Students
                .FirstOrDefault(s => s.Id == id);
        }

        public Student GetStudentByMark(int MarkId)
        {
            return _context.Marks
                .Include(m => m.Student)
                .FirstOrDefault(m => m.Id == MarkId)
                .Student;
        }

        public IEnumerable<Student> GetStudentsFromClass(int classId)
        {
            return _context.Classes
                .Include(c => c.ClassMembers)
                .FirstOrDefault(c => c.Id == classId)
                .ClassMembers;
        }

        public StudentWithMarksViewModel GetStudentWithTheirMarks(int id)
        {
            var model = new StudentWithMarksViewModel();

            var student = _context.Students
                .Include(s => s.Class)
                .FirstOrDefault(s => s.Id == id);

            var marks = _context.Marks
                .Include(m => m.Subject)
                .Where(m => m.Student.Id == id)
                .OrderBy(m => m.Subject.Id);

            model.marks = marks;
            model.student = student;
            model.StudentClass = student.Class;
            
            return model;

        }
    }
}
