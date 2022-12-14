using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.Models
{
    public class Department : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> DepartmentMembers { get; set; }
        public virtual ICollection<Moc> Mocs { get; set; }
    }
}
