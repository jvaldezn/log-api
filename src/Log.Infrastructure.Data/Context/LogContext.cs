using System;
using Microsoft.EntityFrameworkCore;
using Log.Domain.Entities;

namespace Log.Infrastructure.Data.Context
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Log> Log { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
