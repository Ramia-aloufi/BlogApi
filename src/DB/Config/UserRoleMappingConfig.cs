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
           builder.HasIndex(n => new { n.UserId, n.RoleId }, "UK_UserRoleMapping").IsUnique();
            builder.HasOne(n => n.Role)
            .WithMany(n => n.UserRoleMappings)
            .HasForeignKey(n => n.RoleId)
            .HasConstraintName("FK_UserRoleMapping_Role");
            builder.HasOne(n => n.User)
            .WithMany(n => n.UserRoleMappings)
            .HasForeignKey(n => n.UserId )
            .HasConstraintName("FK_UserRoleMapping_User");
        }
    }
}