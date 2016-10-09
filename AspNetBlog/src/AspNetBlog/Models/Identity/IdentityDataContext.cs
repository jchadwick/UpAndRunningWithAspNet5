using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TieWeb.Models.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {

        public IdentityDataContext()
        {
            Database.EnsureCreated();
        }
    }
}
