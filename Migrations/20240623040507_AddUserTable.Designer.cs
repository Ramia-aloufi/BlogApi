﻿// <auto-generated />
using System;
using BlogApi.src.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApi.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240623040507_AddUserTable")]
    partial class AddUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is a sample comment.",
                            CreatedAt = new DateTime(2024, 6, 23, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(5260),
                            PostId = 3
                        });
                });

            modelBuilder.Entity("BlogApi.src.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

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

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "ASP.NET Core is a free and open-source web framework developed by Microsoft.",
                            CreatedAt = new DateTime(2024, 6, 13, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4710),
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTB8vWxHzX5mIpJz5aVrqHrDRRfvrb69esckGkGlm6HPw&s",
                            Title = "Introduction to ASP.NET Core",
                            UpdatedAt = new DateTime(2024, 6, 22, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720)
                        },
                        new
                        {
                            Id = 2,
                            Content = "Entity Framework Core is a lightweight, extensible, and cross-platform version of the popular Entity Framework data access technology.",
                            CreatedAt = new DateTime(2024, 6, 15, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720),
                            ImageUrl = "https://media.licdn.com/dms/image/D4D12AQEKTlrp8y_g0A/article-cover_image-shrink_720_1280/0/1683976532326?e=2147483647&v=beta&t=41WsN7UYuouE7WcA_pmij4yF__uReRR5qm8rdtngHOM",
                            Title = "Getting Started with Entity Framework Core",
                            UpdatedAt = new DateTime(2024, 6, 21, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720)
                        },
                        new
                        {
                            Id = 3,
                            Content = "Middleware is software that's assembled into an application pipeline to handle requests and responses.",
                            CreatedAt = new DateTime(2024, 6, 18, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720),
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSv3lYL2b29XYVOoFeRIBDWQ9Sb9NL7MS1eBeApMQ8GOw&s",
                            Title = "Understanding Middleware in ASP.NET Core",
                            UpdatedAt = new DateTime(2024, 6, 20, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720)
                        },
                        new
                        {
                            Id = 4,
                            Content = "Razor Pages is a page-based programming model that makes building web UI easier and more productive.",
                            CreatedAt = new DateTime(2024, 6, 20, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720),
                            ImageUrl = "https://www.examturf.com/eqtkhtabd/wp-content/uploads/2021/02/ASP.NET-Framework.jpg",
                            Title = "Exploring Razor Pages in ASP.NET Core",
                            UpdatedAt = new DateTime(2024, 6, 22, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720)
                        },
                        new
                        {
                            Id = 5,
                            Content = "Blazor is a framework for building interactive web applications with .NET and C#.",
                            CreatedAt = new DateTime(2024, 6, 22, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720),
                            ImageUrl = "https://positiwise.com/blog/wp-content/uploads/2023/01/common-architectures-in-asp-.net-core.jpg",
                            Title = "Introduction to Blazor",
                            UpdatedAt = new DateTime(2024, 6, 23, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4730)
                        });
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

                    b.Property<int>("userType")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
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
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
