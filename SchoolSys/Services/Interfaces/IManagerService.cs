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
    }
}
