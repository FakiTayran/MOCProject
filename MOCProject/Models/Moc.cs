using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.Models
{
    public class Moc : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }
        public string Justification { get; set; }
        public string Benefit { get; set; }

        public virtual IEnumerable<Department> RelatedDepartments { get; set; }

        public virtual IEnumerable<IdentityUser> RelatedUsers { get; set;}

        public virtual IEnumerable<Task> Tasks { get; set; }

        public DateTime InitiationDate { get => DateTime.Now; }
        public DateTime ClosingDate { get; set; }
        public IdentityUser Creator { get; set; }
    }
}
