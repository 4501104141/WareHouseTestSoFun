﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Migrations
{
    [DbContext(typeof(WareHouseDbContext))]
    [Migration("20221018090652_DatabaseCreation")]
    partial class DatabaseCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WareHouseApplication.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("WareHouseApplication.Model.InventoryAdjustment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountedQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Difference")
                        .HasColumnType("int");

                    b.Property<int>("OnHandQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StaffId");

                    b.ToTable("InventoryAdjustments");
                });

            modelBuilder.Entity("WareHouseApplication.Model.OperationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationTypes");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Pallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MaximumCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PalletConfiguration");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WareHouseApplication.Model.ProductInCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInCategories");
                });

            modelBuilder.Entity("WareHouseApplication.Model.ProductInPallet", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PalletId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "PalletId");

                    b.HasIndex("PalletId");

                    b.ToTable("ProductInPallets");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperationTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("OperationTypeID");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("WareHouseApplication.Model.TransfersDetail", b =>
                {
                    b.Property<int>("TransferId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("TransferId");

                    b.HasIndex("ProductId");

                    b.ToTable("TransfersDetails");
                });

            modelBuilder.Entity("WareHouseApplication.Model.InventoryAdjustment", b =>
                {
                    b.HasOne("WareHouseApplication.Model.Product", "Product")
                        .WithMany("InventorAdjustments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseApplication.Model.Staff", "Staff")
                        .WithMany("InventoryAdjustmentes")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("WareHouseApplication.Model.ProductInCategory", b =>
                {
                    b.HasOne("WareHouseApplication.Model.Category", "Category")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseApplication.Model.Product", "Product")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WareHouseApplication.Model.ProductInPallet", b =>
                {
                    b.HasOne("WareHouseApplication.Model.Pallet", "Pallet")
                        .WithMany("ProductInPallets")
                        .HasForeignKey("PalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseApplication.Model.Product", "Product")
                        .WithMany("ProductInPallets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pallet");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Transfer", b =>
                {
                    b.HasOne("WareHouseApplication.Model.Contact", "Contact")
                        .WithMany("Transfers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseApplication.Model.OperationType", "OperationType")
                        .WithMany("Transfers")
                        .HasForeignKey("OperationTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("OperationType");
                });

            modelBuilder.Entity("WareHouseApplication.Model.TransfersDetail", b =>
                {
                    b.HasOne("WareHouseApplication.Model.Product", "Product")
                        .WithMany("TransfersDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseApplication.Model.Transfer", "Transfer")
                        .WithMany("TransfersDetails")
                        .HasForeignKey("TransferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Category", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Contact", b =>
                {
                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("WareHouseApplication.Model.OperationType", b =>
                {
                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Pallet", b =>
                {
                    b.Navigation("ProductInPallets");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Product", b =>
                {
                    b.Navigation("InventorAdjustments");

                    b.Navigation("ProductInCategories");

                    b.Navigation("ProductInPallets");

                    b.Navigation("TransfersDetails");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Staff", b =>
                {
                    b.Navigation("InventoryAdjustmentes");
                });

            modelBuilder.Entity("WareHouseApplication.Model.Transfer", b =>
                {
                    b.Navigation("TransfersDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
