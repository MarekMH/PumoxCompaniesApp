using PumoxCompaniesApp.API.Identity.Model;
using System.Collections.Generic;
using System.Linq;

namespace PumoxCompaniesApp.API.Identity.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<AppUser> WithoutPasswords(this IEnumerable<AppUser> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static AppUser WithoutPassword(this AppUser user)
        {
            user.Password = null;
            return user;
        }
    }
}