﻿// <auto-generated />
using System;
using BlogWebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogWebApi.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.6.20312.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogWebApi.Models.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"),
                            Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                            CreatedAt = new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(6614),
                            Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                            Title = "Augmented Reality iOS Application",
                            UpdatedAt = new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(6810)
                        },
                        new
                        {
                            Id = new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"),
                            Body = "Something interesting.",
                            CreatedAt = new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(8170),
                            Description = "Description about this title.",
                            Title = "Some random title",
                            UpdatedAt = new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(8180)
                        });
                });

            modelBuilder.Entity("BlogWebApi.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"),
                            BlogPostId = new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"),
                            TagName = "Android"
                        },
                        new
                        {
                            Id = new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"),
                            BlogPostId = new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"),
                            TagName = "IOS"
                        });
                });

            modelBuilder.Entity("BlogWebApi.Models.Tag", b =>
                {
                    b.HasOne("BlogWebApi.Models.BlogPost", "Blog")
                        .WithMany("TagList")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
