﻿// <auto-generated />
using System;
using BlogApi.src.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApi.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("blog")
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogApi.src.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Category", "blog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            name = "Angular"
                        },
                        new
                        {
                            Id = 2,
                            name = "Laravel"
                        });
                });

            modelBuilder.Entity("BlogApi.src.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments", "blog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is a sample comment.",
                            CreatedAt = new DateTime(2024, 7, 16, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(1040),
                            PostId = 3
                        });
                });

            modelBuilder.Entity("BlogApi.src.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts", "blog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "ASP.NET Core is a free and open-source web framework developed by Microsoft.",
                            CreatedAt = new DateTime(2024, 7, 6, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(490),
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTB8vWxHzX5mIpJz5aVrqHrDRRfvrb69esckGkGlm6HPw&s",
                            Title = "Introduction to ASP.NET Core",
                            UpdatedAt = new DateTime(2024, 7, 15, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(490)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Content = "Entity Framework Core is a lightweight, extensible, and cross-platform version of the popular Entity Framework data access technology.",
                            CreatedAt = new DateTime(2024, 7, 8, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(500),
                            ImageUrl = "https://media.licdn.com/dms/image/D4D12AQEKTlrp8y_g0A/article-cover_image-shrink_720_1280/0/1683976532326?e=2147483647&v=beta&t=41WsN7UYuouE7WcA_pmij4yF__uReRR5qm8rdtngHOM",
                            Title = "Getting Started with Entity Framework Core",
                            UpdatedAt = new DateTime(2024, 7, 14, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(500)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Content = "Middleware is software that's assembled into an application pipeline to handle requests and responses.",
                            CreatedAt = new DateTime(2024, 7, 11, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(500),
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSv3lYL2b29XYVOoFeRIBDWQ9Sb9NL7MS1eBeApMQ8GOw&s",
                            Title = "Understanding Middleware in ASP.NET Core",
                            UpdatedAt = new DateTime(2024, 7, 13, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(500)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Content = "Razor Pages is a page-based programming model that makes building web UI easier and more productive.",
                            CreatedAt = new DateTime(2024, 7, 13, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(500),
                            ImageUrl = "https://www.examturf.com/eqtkhtabd/wp-content/uploads/2021/02/ASP.NET-Framework.jpg",
                            Title = "Exploring Razor Pages in ASP.NET Core",
                            UpdatedAt = new DateTime(2024, 7, 15, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(540)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Content = "Blazor is a framework for building interactive web applications with .NET and C#.",
                            CreatedAt = new DateTime(2024, 7, 15, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(540),
                            ImageUrl = "https://positiwise.com/blog/wp-content/uploads/2023/01/common-architectures-in-asp-.net-core.jpg",
                            Title = "Introduction to Blazor",
                            UpdatedAt = new DateTime(2024, 7, 16, 4, 6, 27, 103, DateTimeKind.Utc).AddTicks(540)
                        });
                });

            modelBuilder.Entity("BlogApi.src.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("createdDte")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<bool>("iActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "blog");
                });

            modelBuilder.Entity("BlogApi.src.Models.RolePrivilege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("RolePrivilegeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("createdDte")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePrivileges", "blog");
                });

            modelBuilder.Entity("BlogApi.src.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("createdDte")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("userTypeId");

                    b.ToTable("Users", "blog");
                });

            modelBuilder.Entity("BlogApi.src.Models.UserRoleMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("roleId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("roleId");

                    b.HasIndex(new[] { "userId", "roleId" }, "UK_UserRoleMapping")
                        .IsUnique();

                    b.ToTable("UserRoleMappings", "blog");
                });

            modelBuilder.Entity("BlogApi.src.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes", "blog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            description = "Administrator with full access",
                            name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            description = "Editor with content management access",
                            name = "Editor"
                        },
                        new
                        {
                            Id = 3,
                            description = "Regular user with limited access",
                            name = "User"
                        });
                });

            modelBuilder.Entity("BlogApi.src.Models.Comment", b =>
                {
                    b.HasOne("BlogApi.src.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BlogApi.src.Models.Post", b =>
                {
                    b.HasOne("BlogApi.src.Models.Category", "category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("BlogApi.src.Models.RolePrivilege", b =>
                {
                    b.HasOne("BlogApi.src.Models.Role", "Role")
                        .WithMany("RolePrivileges")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RolePrivilege_Roles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BlogApi.src.Models.User", b =>
                {
                    b.HasOne("BlogApi.src.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("userTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_UserType");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("BlogApi.src.Models.UserRoleMapping", b =>
                {
                    b.HasOne("BlogApi.src.Models.Role", "role")
                        .WithMany("UserRoleMappings")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRoleMapping_Role");

                    b.HasOne("BlogApi.src.Models.User", "user")
                        .WithMany("UserRoleMappings")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRoleMapping_User");

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("BlogApi.src.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BlogApi.src.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BlogApi.src.Models.Role", b =>
                {
                    b.Navigation("RolePrivileges");

                    b.Navigation("UserRoleMappings");
                });

            modelBuilder.Entity("BlogApi.src.Models.User", b =>
                {
                    b.Navigation("UserRoleMappings");
                });

            modelBuilder.Entity("BlogApi.src.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
