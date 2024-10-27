using Microsoft.AspNetCore.Identity;
using Store.Data.Context;
using Store.Data.Entity.IdentityEntity;

namespace Store.Web.Extensions
{
    public static class IdentityServicesExtensions
    {

        public static IServiceCollection AddIdentittyService(this IServiceCollection services)
        {

            var builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType, builder.Services);

            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;
        }
    }
}
