using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Assignment___shirts4uz.Data
{
    public class InitialiseUsers
    {
        public static void SeedData(UserManager<Models.ApplicationUser> userManager,RoleManager<Models.ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<Models.ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("productmanager@gmail.com").Result == null)
            {
                Models.ApplicationUser user = new Models.ApplicationUser();
                user.UserName = "productmanager@gmail.com";
                user.Email = "productmanager@gmail.com";
                user.FullName = "productmanager@gmail.com";
                user.BirthDate = new DateTime(1960, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssw0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Product Manager").Wait();
                }
            }


            if (userManager.FindByNameAsync("administrator@gmail.com").Result == null)
            {
                Models.ApplicationUser user = new Models.ApplicationUser();
                user.UserName = "administrator@gmail.com";
                user.Email = "administrator@gmail.com";
                user.FullName = "Administrator";
                user.BirthDate = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssw0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Administrator").Wait();
                }
            }

            if (userManager.FindByNameAsync("auditor@gmail.com").Result == null)
            {
                Models.ApplicationUser user = new Models.ApplicationUser();
                user.UserName = "auditor@gmail.com";
                user.Email = "auditor@gmail.com";
                user.FullName = "Auditor";
                user.BirthDate = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssw0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Auditor").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<Models.ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Product Manager").Result)
            {
                Models.ApplicationRole role = new Models.ApplicationRole();
                role.Name = "Product Manager";
                role.Description = "Manages product specifics.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                Models.ApplicationRole role = new Models.ApplicationRole();
                role.Name = "Administrator";
                role.Description = "Manage user roles and privileges.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Auditor").Result)
            {
                Models.ApplicationRole role = new Models.ApplicationRole();
                role.Name = "Auditor";
                role.Description = "Manage audit logs.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
