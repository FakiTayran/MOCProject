using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Kalite",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Üretim",

                    });

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Satın Alma",

                    });

                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Bilişim Teknolojileri",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Planlama",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Lojistik",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "İnsan Kaynakları",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Muhasebe ve Finans",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "İdari İşler",

                    });

                    db.SaveChanges();
                }
            }
        }
    }
}
