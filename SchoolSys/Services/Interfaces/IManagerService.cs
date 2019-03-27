using SchoolSys.DataViewModels;
using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Services.Interfaces
{
    public interface IManagerService
    {
        void AddStudent(Student newStudent);
        void AddMark(Mark newMark);
        void EditMark(int markId, decimal newMark);
        void AddStudentToClass(Student student, Class studentClass);
        void AddSubject(Subject newSubject);

        Mark GetMarkDetails(int markId);

        void AddClass(Class newClass);
        void RemoveMark(int markId);

        Subject GetSubject(int subjectId);
        Subject GetSubjectByName(string subjectName);

        Student GetStudentByMarkId(int markId);

        IEnumerable<Subject> GetAllSubjects();

        #region method based on asp net users
        int GetCurrentPersonId(int userId);
        StudentWithMarksViewModel GetStudentWithTheirMarks(string userId);
        #endregion
    }
}
