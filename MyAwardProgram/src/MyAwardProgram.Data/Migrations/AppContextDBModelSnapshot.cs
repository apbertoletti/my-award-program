﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAwardProgram.Data.Contexts;

namespace MyAwardProgram.Data.Migrations
{
    [DbContext(typeof(AppContextDB))]
    partial class AppContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Movements.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dots")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Occurrence")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Occurrence")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Partners.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Partners.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DotPrice")
                        .HasColumnType("int");

                    b.Property<int>("DotType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Users.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TB_UserAddress");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TB_User");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Movements.Movement", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Entities.Orders.Order", "Order")
                        .WithMany("Movements")
                        .HasForeignKey("OrderId");

                    b.HasOne("MyAwardProgram.Domain.Entities.Partners.Product", "Product")
                        .WithMany("Movements")
                        .HasForeignKey("ProductId");

                    b.HasOne("MyAwardProgram.Domain.Entities.Users.User", "User")
                        .WithMany("Movements")
                        .HasForeignKey("UserId");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Orders.Order", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Entities.Users.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId");

                    b.HasOne("MyAwardProgram.Domain.Entities.Users.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Partners.Product", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Entities.Partners.Partner", "Partner")
                        .WithMany("Products")
                        .HasForeignKey("PartnerId");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Users.Address", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Entities.Users.User", "User")
                        .WithMany("Adresses")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Entities.Orders.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAwardProgram.Domain.Entities.Partners.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Orders.Order", b =>
                {
                    b.Navigation("Movements");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Partners.Partner", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Partners.Product", b =>
                {
                    b.Navigation("Movements");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Users.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("Movements");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
