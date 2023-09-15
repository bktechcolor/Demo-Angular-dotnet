using DemoBusiness.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace DemoBusiness.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //User
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>() {
                      new User()
                      {
                          Name= "Son Dang",
                          Email="dangsonbk08@gmail.com"
                      },
                      new User()
                      {
                          Name= "Cuong Tran",
                          Email="giacuong06@gmail.com"
                      },
                      new User()
                      {
                          Name="Tien Dung",
                          Email = "Tiendung123@gmail.com"
                      }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
