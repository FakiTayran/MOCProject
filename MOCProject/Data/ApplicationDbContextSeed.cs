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
                        Name = "İSG Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Kalite Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Üretim, Satın Alma Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Bilişim Teknolojileri Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Planlama Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Lojistik Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "İnsan Kaynakları Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "Muhasebe ve Finans Departmanı",

                    });
                    db.Departments.Add(new Models.Department()
                    {
                        Name = "İdari İşler Departmanı",

                    });

                    db.SaveChanges();
                }
            }
        }
    }
}
