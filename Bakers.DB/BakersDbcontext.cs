using Bakers.DB.Interface;
using Bakers.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using static Bakers.DB.BakersDbcontext;

namespace Bakers.DB
{
    public class BakersDbcontext : IdentityDbContext, IBakersDbContext

    {
     
        public DbSet<Category> Category { get ; set ; }
        public DbSet<Customer> Customers { get ; set ; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public BakersDbcontext()
        {

        }
        public BakersDbcontext(DbContextOptions<BakersDbcontext> options) : base(options)
        {

        }



    }
}
