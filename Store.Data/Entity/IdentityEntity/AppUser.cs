using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entity.IdentityEntity
{
    public class AppUser: IdentityUser
    {
        
public string DisplayName { get; set; }


public Address Address  { get; set; }
    }
}
