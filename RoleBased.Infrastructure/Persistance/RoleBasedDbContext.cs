using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Infrastructure.Persistance
{
    public class RoleBasedDbContext : DbContext
    {
        public RoleBasedDbContext(DbContextOptions<RoleBasedDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleBasedDbContext).Assembly);
        }
    }
}
