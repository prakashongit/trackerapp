using CommonLibrary.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Property(c => c.StartDate).HasDefaultValue(DateTime.Now);
            builder.Property(c => c.EndDate).HasDefaultValue(DateTime.Now);
        }
    }
}
