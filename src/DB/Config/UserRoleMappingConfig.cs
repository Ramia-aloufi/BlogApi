using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.src.DB.Config
{
    public class UserRoleMappingConfig : IEntityTypeConfiguration<UserRoleMapping>
    {
        public void Configure(EntityTypeBuilder<UserRoleMapping> builder)
        {
           builder.HasIndex(n => new { n.userId, n.roleId }, "UK_UserRoleMapping").IsUnique();
            builder.HasOne(n => n.role)
            .WithMany(n => n.UserRoleMappings)
            .HasForeignKey(n => n.roleId)
            .HasConstraintName("FK_UserRoleMapping_Role");
            builder.HasOne(n => n.user)
            .WithMany(n => n.UserRoleMappings)
            .HasForeignKey(n => n.userId )
            .HasConstraintName("FK_UserRoleMapping_User");
        }
    }
}