﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAwardProgram.Data.Contexts;

namespace MyAwardProgram.Data.Migrations
{
    [DbContext(typeof(AppContextDB))]
    [Migration("20210518010628_NewColumnUserIdTableMovement")]
    partial class NewColumnUserIdTableMovement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Movements.Entities.Movement", b =>
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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("TB_Movement");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Orders.Entities.Order", b =>
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

                    b.ToTable("TB_Order");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Orders.Entities.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("TB_OrderProduct");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Partners.Entities.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TB_Partner");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Partners.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DotPrice")
                        .HasColumnType("int");

                    b.Property<int>("DotType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("TB_PartnerProduct");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Users.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TB_UserAddress");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Users.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_User");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Movements.Entities.Movement", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Aggregates.Orders.Entities.Order", "Order")
                        .WithMany("Movements")
                        .HasForeignKey("OrderId");

                    b.HasOne("MyAwardProgram.Domain.Aggregates.Partners.Entities.Product", "Product")
                        .WithMany("Movements")
                        .HasForeignKey("ProductId");

                    b.HasOne("MyAwardProgram.Domain.Aggregates.Users.Entities.User", "User")
                        .WithMany("Movements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Orders.Entities.Order", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Aggregates.Users.Entities.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId");

                    b.HasOne("MyAwardProgram.Domain.Aggregates.Users.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Orders.Entities.OrderProduct", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Aggregates.Orders.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAwardProgram.Domain.Aggregates.Partners.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Partners.Entities.Product", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Aggregates.Partners.Entities.Partner", "Partner")
                        .WithMany("Products")
                        .HasForeignKey("PartnerId");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Users.Entities.Address", b =>
                {
                    b.HasOne("MyAwardProgram.Domain.Aggregates.Users.Entities.User", "User")
                        .WithMany("Adresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Users.Entities.User", b =>
                {
                    b.OwnsOne("MyAwardProgram.Shared.Types.CPF", "CPF", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar(11)")
                                .HasColumnName("CPF");

                            b1.HasKey("UserId");

                            b1.ToTable("TB_User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("CPF");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Orders.Entities.Order", b =>
                {
                    b.Navigation("Movements");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Partners.Entities.Partner", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Partners.Entities.Product", b =>
                {
                    b.Navigation("Movements");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Users.Entities.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MyAwardProgram.Domain.Aggregates.Users.Entities.User", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("Movements");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
