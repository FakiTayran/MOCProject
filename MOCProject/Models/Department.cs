﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.Models
{
    public class Department : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<IdentityUser> DepartmentMember { get; set; }
    }
}
