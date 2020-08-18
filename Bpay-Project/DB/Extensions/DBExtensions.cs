using Bpay_Project.DB.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Extensions
{
    public static class DBExtensions
    {
        public static void SetTableName(this ModelBuilder builder)
        {
            builder.Entity<AppUser>(x => { x.ToTable("B_Users"); });
            builder.Entity<IdentityRole<int>>(x => { x.ToTable("B_Roles"); });
            builder.Entity<IdentityRoleClaim<int>>(x => { x.ToTable("B_RoleClaims"); });
            builder.Entity<IdentityUserRole<int>>(x => { x.ToTable("B_UserRoles"); });
            builder.Entity<IdentityUserLogin<int>>(x => { x.ToTable("B_UserLogins"); });
            builder.Entity<IdentityUserClaim<int>>(x => { x.ToTable("B_UserClaims"); });
            builder.Entity<IdentityUserToken<int>>(x => { x.ToTable("B_UserTokens"); });
        }
    }
}
