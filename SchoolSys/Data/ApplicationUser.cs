using Microsoft.AspNetCore.Identity;
using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Data
{
    public class ApplicationUser : IdentityUser
    {

        public virtual Person ThePerson { get; set; }
    }
}
