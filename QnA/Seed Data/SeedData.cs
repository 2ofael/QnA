using GlobalEntity.Models;
using Microsoft.AspNetCore.Identity;

namespace QnA.Seed_Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Moderator" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {

                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            await SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByEmailAsync("moderator@example.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "ModeratorUser",
                    Email = "moderator@example.com"
                };

                var result = await userManager.CreateAsync(user, "hexhexhex9H!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Moderator");
                }
            }
        }
    }
}
