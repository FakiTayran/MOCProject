using Microsoft.AspNetCore.Identity;
using MOCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.ModelViews
{
    public class MocCreateViewModel
    {
        public Moc Moc { get; set; }
        public List<Department> Departments { get; set; }
    }
}
