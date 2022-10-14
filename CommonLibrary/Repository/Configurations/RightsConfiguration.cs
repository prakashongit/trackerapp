using CommonLibrary.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Configurations
{
    public class RightsConfiguration : IEntityTypeConfiguration<Rights>
    {
        public void Configure(EntityTypeBuilder<Rights> builder)
        {
            //builder.HasKey(r => r.Id);
            //builder.Property(r => r.Id).UseIdentityColumn();
            //builder.HasData(new Rights { Name = "All", RightsId = 1 });
            //builder.HasData(new Rights { Name = "ManageTask", RightsId = 2 });
            //builder.HasData(new Rights { Name = "AssignTask", RightsId = 2 });
        }
    }
}
