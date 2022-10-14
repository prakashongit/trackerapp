using CommonLibrary.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.UserName).IsRequired();
            builder.HasMany(c => c.Users).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Project).WithMany();
            builder.Property(c => c.AllowcationPercentage).HasMaxLength(100).HasDefaultValue(0);
            builder.Property(c => c.YearsOfExperience).HasDefaultValue(0);
            builder.Property(c => c.StartDate).HasDefaultValue(DateTime.Now);
            builder.Property(c => c.EndDate).HasDefaultValue(DateTime.Now);
            builder.Property(c => c.IsActive).HasDefaultValue(true);
        }
    }
}
