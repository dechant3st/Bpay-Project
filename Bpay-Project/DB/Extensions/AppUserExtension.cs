using Bpay_Project.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Extensions
{
    public static class AppUserExtension
    {
        public static AppUser WithoutPassword(this AppUser user)
        {
            user.PasswordHash = string.Empty;
            return user;
        }

        public static List<AppUser> WithoutPassword(this List<AppUser> users)
        {
            users.ForEach(x => x.PasswordHash = string.Empty);
            return users;
        }
    }
}
