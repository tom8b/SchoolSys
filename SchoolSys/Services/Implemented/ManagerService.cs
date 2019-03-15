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
    public class ManagerService : IManagerService
    {
        private SchoolContext _context;

        public ManagerService(SchoolContext context)
        {
            _context = context;
        }

        public void AddClass(Class newClass)
        {
            _context.Add(newClass);
            _context.SaveChanges();
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

        public void EditMark(int markId, decimal newMark)
        {
            var mark = _context.Marks.FirstOrDefault(m => m.Id == markId);
            _context.Update(mark);
            mark.TheMark = newMark;
            _context.SaveChanges();

        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Subjects;
        }

        public Mark GetMarkDetails(int markId)
        {
            return _context.Marks.Include(m => m.Student).Include(m => m.Subject).FirstOrDefault(m => m.Id == markId);
        }

        public Student GetStudentByMarkId(int markId)
        {
            var mark = _context.Marks.Include(m=>m.Student).FirstOrDefault(m => m.Id == markId);
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
    }
}