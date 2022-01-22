using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DbContexts
{
    public class ReservoomDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservoomDbContext>
    {
        public ReservoomDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder().UseSqlServer(@"Data Source=localhost;Initial Catalog=reservoom;Trusted_Connection=True;").Options;

            return new ReservoomDbContext(options);
        }
    }
}
