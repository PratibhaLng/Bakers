using Abp.Domain.Entities;
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
       // public DbSet<Order> Order { get; set; }
        public BakersDbcontext()
        {

        }

        public override int SaveChanges()
        {
            foreach ( var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if(entry.State == EntityState.Deleted && entity is ISoftDelete)
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("IsCancelled").SetValue(entity, true);
                }
            }
            return base.SaveChanges();  
        }
        public BakersDbcontext(DbContextOptions<BakersDbcontext> options) : base(options)
        {

        }



    }
}
