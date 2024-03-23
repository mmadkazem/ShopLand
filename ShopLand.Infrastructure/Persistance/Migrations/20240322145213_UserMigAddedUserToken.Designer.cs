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
    [Migration("20240322145213_UserMigAddedUserToken")]
    partial class UserMigAddedUserToken
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

            modelBuilder.Entity("ShopLand.Domain.Account.Users.ValueObject.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("AccessTokenExpiresDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AccessTokenHash")
                        .HasColumnType("text");

                    b.Property<bool>("IsExpire")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("RefreshTokenExpiresDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RefreshTokenIdHash")
                        .HasColumnType("text");

                    b.Property<string>("RefreshTokenIdSerial")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("ShopLand.Domain.Carts.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("CartId");

                    b.Property<bool>("Finished")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ShopLand.Domain.Carts.ValueObject.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uuid")
                        .HasColumnName("CartId");

                    b.Property<uint?>("Count")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ShopLand.Domain.Finances.Entities.RequestPay", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("Authority")
                        .HasColumnType("text");

                    b.Property<bool>("IsPay")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("PayDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("RefId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("requestPays");
                });

            modelBuilder.Entity("ShopLand.Domain.Orders.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("OrderState")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RequestPayId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShopLand.Domain.Orders.ValueObject.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("OrderId");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
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

            modelBuilder.Entity("ShopLand.Domain.Account.Users.ValueObject.UserToken", b =>
                {
                    b.HasOne("ShopLand.Domain.Account.Users.Entities.User", null)
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ShopLand.Domain.Carts.ValueObject.CartItem", b =>
                {
                    b.HasOne("ShopLand.Domain.Carts.Entities.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("ShopLand.Domain.Orders.ValueObject.OrderDetail", b =>
                {
                    b.HasOne("ShopLand.Domain.Orders.Entities.Order", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");
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

                    b.Navigation("UserTokens");
                });

            modelBuilder.Entity("ShopLand.Domain.Carts.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ShopLand.Domain.Orders.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ShopLand.Domain.Products.Product_Aggregate.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
