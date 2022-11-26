using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOCProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOCProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            public DbSet<Moc> Mocs { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Task> Tasks { get; set; }
    }
}
