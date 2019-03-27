using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Data;
using SchoolSys.Services.Interfaces;

namespace SchoolSys.Controllers
{
    public class StudentController : Controller
    {
        private IManagerService _manager;
        private IStudentService _student;
        private UserManager<ApplicationUser> _userManager;

        public StudentController(IManagerService manager, IStudentService student, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _student = student;
            _userManager = userManager;
        }
        
        //[Authorize(AuthenticationSchemes = "Application.Identity")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public IActionResult MyMarks()
        {
           //var userId = _userManager.GetUserAsync(HttpContext.User).Id;
            var userId = _userManager.GetUserId(HttpContext.User);
            //var theStudentId = _manager.GetCurrentPersonId(userId);

            //var model = _student.GetStudentWithTheirMarks(theStudentId);

            var model = _manager.GetStudentWithTheirMarks(userId);

            return View(model);
        }
    }
}