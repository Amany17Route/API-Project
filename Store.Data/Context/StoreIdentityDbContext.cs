using Microsoft.As
using Microsoft.EntityFrameworkCore;
using Store.Data.Entity.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Context
{
    public class StoreIdentityDbContext :StoreIdentityDbContext<AppUser>
    {
        
public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options)
: base(options)
        {

        }

    }
}
