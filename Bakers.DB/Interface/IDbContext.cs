using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.DB.Interface
{
    public interface IDbContext
    {

        int SaveChanges();

    }
}
