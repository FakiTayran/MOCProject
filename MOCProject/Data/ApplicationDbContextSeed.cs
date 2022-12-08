using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MOCProject.Data
{
    public class ApplicationDbContextSeed
    {
        public static void SeedDepartments(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!db.Departments.Any())
                {
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "İSG",

                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Kalite",
                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Üretim",
                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Satın Alma",
                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Bilişim Teknolojileri",

                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Planlama",

                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Lojistik",

                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "İnsan Kaynakları",

                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Muhasebe ve Finans",

                    });
                    db.SaveChanges();

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "İdari İşler",

                    });
                    db.SaveChanges();
                }

            }
        }

        public static void SeedUser(
        UserManager<ApplicationUser> userManager, IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                var user1 = "testuser1@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user1,
                        Email = user1,
                        EmailConfirmed = true,
                        DepartmentId = 1
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }

                var user2 = "testuser2@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user2,
                        Email = user2,
                        EmailConfirmed = true,
                        DepartmentId = 2
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }
                var user3 = "testuser3@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user3,
                        Email = user3,
                        EmailConfirmed = true,
                        DepartmentId = 3
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }
                var user4 = "testuser4@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user4,
                        Email = user4,
                        EmailConfirmed = true,
                        DepartmentId = 4
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }
                var user5 = "testuser5@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user5,
                        Email = user5,
                        EmailConfirmed = true,
                        DepartmentId = 5
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }
                var user6 = "testuser6@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user6,
                        Email = user6,
                        EmailConfirmed = true,
                        DepartmentId = 6
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }
                var user7 = "testuser7@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user7,
                        Email = user7,
                        EmailConfirmed = true,
                        DepartmentId = 7
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }

                var user8 = "testuser8@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user8,
                        Email = user8,
                        EmailConfirmed = true,
                        DepartmentId = 8
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }

                var user9 = "testuser9@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user9,
                        Email = user9,
                        EmailConfirmed = true,
                        DepartmentId = 9
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }
                var user10 = "testuser10@example.com";
                if (true )
                {
                    var user = new ApplicationUser()
                    {
                        UserName = user10,
                        Email = user10,
                        EmailConfirmed = true,
                        DepartmentId = 10
                    };
                    userManager.CreateAsync(user, "Password1.");
                    db.Entry<ApplicationUser>(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                }
            }
        }

        public static void SeedMoc(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!db.Mocs.Any())
                {
                    db.Mocs.Add(new Models.Moc()
                    {
                        Name = "Seeded Moc For Admin",
                        Benefit = "Seeded Benefit Moc For Admin",
                        ClosingDate = null,
                        CreatorId = db.Users.FirstOrDefault(X => X.UserName == "testuser1@example.com").Id,
                        Definition = "Seeded Defination For Admin",
                        Justification = "Seeded Justification For Admin",
                        RelatedDepartments = db.Departments.Where(x => x.Id == 1).ToList(),
                        RelatedUsers = db.Users.Where(x => x.UserName == "testuser1@example.com").ToList()
                    });

                    db.SaveChanges();
                }

            }
        }
    }
}
