using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DbContexts
{
    public class ReservoomDbContextFactory
    {
        private readonly string _connectionString;

        public ReservoomDbContextFactory(string connectionString)
        {
            this._connectionString = connectionString;        
        }

        public ReservoomDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder().UseSqlServer(this._connectionString).Options;

            return new ReservoomDbContext(options);
        }
    }
}
