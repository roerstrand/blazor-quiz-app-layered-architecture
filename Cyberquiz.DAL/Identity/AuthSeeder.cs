using Microsoft.AspNetCore.Identity;

namespace Cyberquiz.DAL.Identity
{
    public static class AuthSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByNameAsync("user") != null)
                return;

            var user = new ApplicationUser
            {
                UserName = "user",
                Email = "user@cyberquiz.se",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(user, "Password1234!");
        }
    }
}
