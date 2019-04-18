using SchoolSys.DataViewModels;
using SchoolSys.DTO;
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
        Task EditMarkAsync(int markId, decimal newMark);
        Task AddStudentToClassAsync(Student student, Class studentClass);
        //void AddSubject(Subject newSubject);
        Task AddSubjectAsync(Subject newSubject);

        Task UpdatePersonDetailsAsync(Person editedPerson);

        Mark GetMarkDetails(int markId);

        Task AddClassAsync(Class newClass);
        void RemoveMark(int markId);

        Subject GetSubject(int subjectId);
        Subject GetSubjectByName(string subjectName);

        Task<Student> GetStudentByMarkIdAsync(int markId);

        Task<IEnumerable<Subject>> GetAllSubjectsAsync();

        Task<PeopleDTO> GetPeopleAsync();

        Task<Person> GetPersonAsync(int personId);

        #region method based on asp net users
        int GetCurrentPersonId(int userId);
        StudentWithMarksViewModel GetStudentWithTheirMarks(string userId);
        #endregion
    }
}
