﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webshop.DAL.AppDbContext;

namespace Webshop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220521102256_orderOrderItemsRelationship")]
    partial class orderOrderItemsRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DbProduct");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbComputer", b =>
                {
                    b.HasBaseType("Webshop.DAL.AppDbContext.DbProduct");

                    b.Property<string>("Battery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraphicsCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HardDrive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DbComputer");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbGardenTool", b =>
                {
                    b.HasBaseType("Webshop.DAL.AppDbContext.DbProduct");

                    b.HasDiscriminator().HasValue("DbGardenTool");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbHomeAppliance", b =>
                {
                    b.HasBaseType("Webshop.DAL.AppDbContext.DbProduct");

                    b.Property<int?>("CubicCapacity")
                        .HasColumnType("int");

                    b.Property<string>("EnergyClass")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DbHomeAppliance");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbTelephone", b =>
                {
                    b.HasBaseType("Webshop.DAL.AppDbContext.DbProduct");

                    b.Property<string>("OperatingSystem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sim")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DbTelephone");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbOrder", b =>
                {
                    b.HasOne("Webshop.DAL.AppDbContext.DbCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbOrderItem", b =>
                {
                    b.HasOne("Webshop.DAL.AppDbContext.DbOrder", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webshop.DAL.AppDbContext.DbProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Webshop.DAL.AppDbContext.DbOrder", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
