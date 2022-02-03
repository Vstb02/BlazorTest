using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());

            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
