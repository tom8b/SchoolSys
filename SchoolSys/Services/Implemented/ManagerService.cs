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

        public void AddStudent(Student newStudent)
        {
            _context.Add(newStudent);
            _context.SaveChanges();
        }
    }
}
