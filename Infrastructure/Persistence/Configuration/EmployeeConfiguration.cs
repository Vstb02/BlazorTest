using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.HasIndex(employee => employee.Id).IsUnique();
            builder.Property(employee => employee.Name).HasMaxLength(250);
            builder.Property(employee => employee.Surname).HasMaxLength(250);
            builder.Property(employee => employee.Patronymic).HasMaxLength(250);
        }
    }
}
