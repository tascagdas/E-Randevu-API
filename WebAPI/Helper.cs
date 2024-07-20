using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebAPI;

public class Helper
{
    public static async Task CreateAdminAsync(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(new AppUser()
                {
                    FirstName = "Çağdaş",
                    LastName = "Taş",
                    Email = "tascagdas@gmail.com",
                    UserName = "admin"
                }, "12345");
            }
        }
    }
}