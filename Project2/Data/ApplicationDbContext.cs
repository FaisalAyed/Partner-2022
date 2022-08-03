using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project2.Models;
using Project2.ModelView;

namespace Project2.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers,AppRoles,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PartnerOrder> partnerOrders{ get; set; }
        public DbSet<OrderState> orderStates{ get; set; }

        public DbSet<Project2.ModelView.MyUser>? MyUser { get; set; }


    }
}