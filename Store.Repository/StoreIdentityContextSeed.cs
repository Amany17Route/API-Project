using Microsoft.AspNet.Identity;
using Store.Data.Entity.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {

        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Amany Mohamed",
                    Email = "amany@gmail.com",
                    UserName = "AmanyMohamed",
                    Address = new Address
                    {
                        FirstName = "Amany",
                        LastName = "Mohamed",
                        City = "Fayoum",
                        State = "Menshiaa",
                        Street = "3",
                        PostalCode = "66547"
                    }
                };
                await userManager.CreateAsync(user ,"Password2345*");
            }
        }
    }
}
