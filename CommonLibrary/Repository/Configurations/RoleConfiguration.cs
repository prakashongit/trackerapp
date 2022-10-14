using CommonLibrary.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //builder.HasKey(r => r.RoleId);
            //builder.Property(r => r.RoleId).UseIdentityColumn();
            //builder.HasData(new Role { RoleName = "Admin", RightsId = 1 });
            //builder.HasData(new Role { RoleName = "Memeber", RightsId = 2 });
        }
    }
}
