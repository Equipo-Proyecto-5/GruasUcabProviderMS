using Microsoft.EntityFrameworkCore;
using ProviderMS.Core.Database;
using ProviderMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Infrastructure.Database
{
    public class ProviderDbContext : DbContext, IProviderDbContext
    {
        public ProviderDbContext(
          DbContextOptions<ProviderDbContext> options
      )
          : base(options) { }
        public DbContext DbContext
        {
            get { return this; }
        }

        public DbSet<Proveedor> Proveedor {  get; set; }
        public DbSet<Grua> Grua { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
