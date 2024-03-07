﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopLand.Infrastructure.Persistance.Context;

#nullable disable

namespace ShopLand.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240302113948_ProductMig")]
    partial class ProductMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopLand.Domain.Account.Roles.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("46ca689b-fe91-4885-9e87-bb7bdd5ff7e2"),
                            Name = "Customer"
                        },
                        new
                        {
                            Id = new Guid("19f5ce16-c1de-41d8-b56b-9364d13cb5c9"),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("ShopLand.Domain.Account.Users.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("FullName");

                    b.Property<string>("_password")
                        .HasColumnType("text")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("83736bc7-2cf2-4abe-8577-c2e100a6d6b8"),
                            Email = "mmad.kr5@gmail.com",
                            FullName = "kazem,Ramzani",
                            _password = "9Wxxyx20MXL2dMgahWL1yjVPYaS+wlQNPfbz0hLesJE="
                        });
                });

            modelBuilder.Entity("ShopLand.Domain.Account.Users.ValueObject.UserInRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Role")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRoles");
                });

            modelBuilder.Entity("ShopLand.Domain.Products.Category_Aggregate.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text")
                        .HasColumnName("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShopLand.Domain.Products.Product_Aggregate.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text")
                        .HasColumnName("Brand");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<uint?>("Inventory")
                        .HasColumnType("bigint")
                        .HasColumnName("Inventory");

                    b.Property<uint?>("Price")
                        .HasColumnType("bigint")
                        .HasColumnName("Price");

                    b.Property<string>("ProductName")
                        .HasColumnType("text")
                        .HasColumnName("ProductName");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopLand.Domain.Products.Product_Aggregate.ValueObject.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Category")
                        .HasColumnType("uuid")
                        .HasColumnName("Category");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("ShopLand.Domain.Account.Users.ValueObject.UserInRole", b =>
                {
                    b.HasOne("ShopLand.Domain.Account.Users.Entities.User", null)
                        .WithMany("UsedInRoles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ShopLand.Domain.Products.Product_Aggregate.ValueObject.ProductCategory", b =>
                {
                    b.HasOne("ShopLand.Domain.Products.Product_Aggregate.Entities.Product", null)
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ShopLand.Domain.Account.Users.Entities.User", b =>
                {
                    b.Navigation("UsedInRoles");
                });

            modelBuilder.Entity("ShopLand.Domain.Products.Product_Aggregate.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
