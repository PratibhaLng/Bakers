using Bakers.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.DB.Interface
{
    public interface IBakersDbContext: IDisposable, IDbContext
    {
         DbSet<Category> Category { get; set; }
         DbSet<Customer> Customers { get; set; }
         DbSet<Item> Items { get; set; }
    }

}

