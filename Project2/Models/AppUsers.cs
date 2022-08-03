using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class AppUsers:IdentityUser
    {
        [DisplayName("الاسم الأول")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [DisplayName("الاسم الثاني")]
        [MaxLength(50)]
        public string LastName { get; set; }

    }
}
