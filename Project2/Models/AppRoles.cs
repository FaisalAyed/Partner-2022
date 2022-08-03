using Microsoft.AspNetCore.Identity;

namespace Project2.Models
{
    public class AppRoles : IdentityRole
    {
        public AppRoles() : base() { }

        public AppRoles(string roleName) : base(roleName)
        {

        }
    }

}
