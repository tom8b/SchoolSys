using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public decimal TheMark { get; set; }

        
        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
