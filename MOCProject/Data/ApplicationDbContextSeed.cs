using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void SeedDepartments(ApplicationDbContext db)
        {
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
        public static async Task<IHost> SeedAsync(this IHost host)
        {
            // http://www.binaryintellect.net/articles/5e180dfa-4438-45d8-ac78-c7cc11735791.aspx
            // https://github.com/dotnet-architecture/eShopOnWeb/blob/master/src/Web/Startup.cs
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var env = serviceProvider.GetRequiredService<IHostEnvironment>();
                var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    SeedDepartments(db);
                }
            }
            return host;
        }
    }
}
