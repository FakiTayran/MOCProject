using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        
        public virtual ICollection<Moc> Mocs { get; set; }
        
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
