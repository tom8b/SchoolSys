﻿using SchoolSys.DataViewModels;
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
        Task<Student> GetStudentByIdAsync(int id);
       // Student GetStudentByMark(int MarkId);
        Task<StudentWithMarksViewModel> GetStudentWithTheirMarksAsync(int id);

        #region classes
        IEnumerable<Class> GetAllClasses();
        IEnumerable<Student> GetStudentsFromClass(int classId);
        Class getClass(int classId);
        Task<Class> getClassByNameAsync(string className);
        
        #endregion
    }
}
