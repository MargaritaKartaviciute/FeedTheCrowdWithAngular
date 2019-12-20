﻿// <auto-generated />
using System;
using FeedTheCrowd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FeedTheCrowd.Migrations
{
    [DbContext(typeof(FeedTheCrowdContext))]
    [Migration("20190314152527_double_quantity")]
    partial class double_quantity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FeedTheCrowd.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkRecipe");

                    b.Property<int?>("FkRecipeNavigationId");

                    b.Property<int>("FkUser");

                    b.Property<int?>("FkUserNavigationId");

                    b.Property<string>("TextField");

                    b.HasKey("Id");

                    b.HasIndex("FkRecipeNavigationId");

                    b.HasIndex("FkUserNavigationId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkRecipe");

                    b.Property<int?>("FkRecipeNavigationId");

                    b.Property<string>("Name");

                    b.Property<double>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("FkRecipeNavigationId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("FkUser");

                    b.Property<int?>("FkUserNavigationId");

                    b.Property<string>("Image");

                    b.Property<int>("Servings");

                    b.Property<string>("Time");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("FkUserNavigationId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.RecipeProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkProduct");

                    b.Property<int?>("FkProductNavigationId");

                    b.Property<int>("FkRecipe");

                    b.Property<int?>("FkRecipeNavigationId");

                    b.Property<double>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("FkProductNavigationId");

                    b.HasIndex("FkRecipeNavigationId");

                    b.ToTable("RecipeProduct");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.Comment", b =>
                {
                    b.HasOne("FeedTheCrowd.Models.Recipe", "FkRecipeNavigation")
                        .WithMany("Comment")
                        .HasForeignKey("FkRecipeNavigationId");

                    b.HasOne("FeedTheCrowd.Models.User", "FkUserNavigation")
                        .WithMany("Comment")
                        .HasForeignKey("FkUserNavigationId");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.Product", b =>
                {
                    b.HasOne("FeedTheCrowd.Models.Recipe", "FkRecipeNavigation")
                        .WithMany()
                        .HasForeignKey("FkRecipeNavigationId");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.Recipe", b =>
                {
                    b.HasOne("FeedTheCrowd.Models.User", "FkUserNavigation")
                        .WithMany("Recipe")
                        .HasForeignKey("FkUserNavigationId");
                });

            modelBuilder.Entity("FeedTheCrowd.Models.RecipeProduct", b =>
                {
                    b.HasOne("FeedTheCrowd.Models.Product", "FkProductNavigation")
                        .WithMany()
                        .HasForeignKey("FkProductNavigationId");

                    b.HasOne("FeedTheCrowd.Models.Recipe", "FkRecipeNavigation")
                        .WithMany("RecipeProduct")
                        .HasForeignKey("FkRecipeNavigationId");
                });
#pragma warning restore 612, 618
        }
    }
}
