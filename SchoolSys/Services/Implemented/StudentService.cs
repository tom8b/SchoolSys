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

        public async Task<Class> getClassByNameAsync(string className)
        {
            return await _context.Classes.FirstOrDefaultAsync(c => c.ClassName.Equals(className));
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        //public Student GetStudentByMark(int MarkId)
        //{
        //    return _context.Marks
        //        .Include(m => m.Student)
        //        .FirstOrDefault(m => m.Id == MarkId)
        //        .Student;
        //}

        public IEnumerable<Student> GetStudentsFromClass(int classId)
        {
            return _context.Classes
                .Include(c => c.ClassMembers)
                .FirstOrDefault(c => c.Id == classId)
                .ClassMembers;
        }

        public async Task<StudentWithMarksViewModel> GetStudentWithTheirMarksAsync(int id)
        {
            var model = new StudentWithMarksViewModel();

            var student = await _context.Students
                .Include(s => s.Class)
                .FirstOrDefaultAsync(s => s.Id == id);

            var marks = await Task.Run(() => _context.Marks
                .Include(m => m.Subject)
                .Where(m => m.Student.Id == id)
                .OrderBy(m => m.Subject.Id));

            model.marks = marks;
            model.student = student;
            model.StudentClass = student.Class;
            
            return model;

        }
    }
}
