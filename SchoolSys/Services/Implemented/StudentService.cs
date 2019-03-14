using Microsoft.EntityFrameworkCore;
using SchoolSys.Data;
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

        public IEnumerable<Student> GetStudentsFromClass(int classId)
        {
            return _context.Classes
                .Include(c => c.ClassMembers)
                .FirstOrDefault(c => c.Id == classId)
                .ClassMembers;
        }
    }
}
