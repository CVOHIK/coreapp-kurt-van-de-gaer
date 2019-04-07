using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMM.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace GMM.Data
{
    public class DbIdentityInitializer
    {
        public static async Task Initialize(GmmDbContext pContext, UserManager<ApplicationUser> pUserManager, RoleManager<ApplicationRole> pRoleManager)
        {
            pContext.Database.EnsureCreated();

            string _adminId1 = "";
            string _adminId2 = "";

            string _role1 = "Admin";
            string _role1Description = "This is an administrator role";
            string _role2 = "Member ";
            string _role2Description = "This is an members role";

            string _password = "P@$$W0rd";

            // Create an entry for the admin user & role
            if (await pRoleManager.FindByNameAsync(_role1) == null) await pRoleManager.CreateAsync(new ApplicationRole(_role1, _role1Description, DateTime.Now));
            if (await pRoleManager.FindByNameAsync(_role2) == null) await pRoleManager.CreateAsync(new ApplicationRole(_role2, _role2Description, DateTime.Now));

            if (await pUserManager.FindByNameAsync("Admin") == null)
            {
                var user = new ApplicationUser { UserName = _adminId1, Voornaam = "", Achternaam = "", Adres = "", Postcode = "", Gemeente = "", Land = "", Email = "" };
                var result = await pUserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await pUserManager.AddPasswordAsync(user, _password);
                    await pUserManager.AddToRoleAsync(user, _role1);

                    _adminId1 = user.Id;
                }
            }

            if (await pUserManager.FindByNameAsync("Gmm") == null)
            {
                var user = new ApplicationUser { UserName = _adminId2, Voornaam = "", Achternaam = "", Adres = "", Postcode = "", Gemeente = "", Land = "", Email = "" };
                var result = await pUserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await pUserManager.AddPasswordAsync(user, _password);
                    await pUserManager.AddToRoleAsync(user, _role1);

                    _adminId2 = user.Id;
                }
            }
        }
    }
}
