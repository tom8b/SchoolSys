using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);

        #region classes
        IEnumerable<Class> GetAllClasses();
        IEnumerable<Student> GetStudentsFromClass(int classId);
        Class getClass(int classId);
        Class getClassByName(string className);
        
        #endregion
    }
}
