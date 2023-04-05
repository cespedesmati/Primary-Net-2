﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimatesWallet.Infrastructure;

#nullable disable

namespace PrimatesWallet.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrimatesWallet.Core.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("creationDate");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("BIT")
                        .HasColumnName("isBlocked");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

                    b.Property<decimal?>("Money")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("money");

                    b.Property<int>("UserId")
                        .HasColumnType("INT")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

                    b.Property<int>("Points")
                        .HasColumnType("int")
                        .HasColumnName("points");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("product_description");

                    b.HasKey("Id");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.FixedTermDeposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Closing_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Creation_Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT")
                        .HasColumnName("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("FixedTermDeposits");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT")
                        .HasColumnName("isDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("VARCHAR(7)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Account_Id")
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount");

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("concept");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT")
                        .HasColumnName("idDeleted");

                    b.Property<int?>("To_Account_Id")
                        .HasColumnType("int")
                        .HasColumnName("to_account_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Account_Id");

                    b.HasIndex("To_Account_Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("email");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT")
                        .HasColumnName("idDeleted");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(max)")
                        .HasColumnName("password");

                    b.Property<int>("Points")
                        .HasColumnType("INT")
                        .HasColumnName("points");

                    b.Property<int>("Rol_Id")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Rol_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.Account", b =>
                {
                    b.HasOne("PrimatesWallet.Core.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("PrimatesWallet.Core.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.FixedTermDeposit", b =>
                {
                    b.HasOne("PrimatesWallet.Core.Models.Account", "Account")
                        .WithMany("FixedTermDeposit")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.Transaction", b =>
                {
                    b.HasOne("PrimatesWallet.Core.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("Account_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimatesWallet.Core.Models.Account", "ToAccount")
                        .WithMany()
                        .HasForeignKey("To_Account_Id");

                    b.Navigation("Account");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.User", b =>
                {
                    b.HasOne("PrimatesWallet.Core.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Rol_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.Account", b =>
                {
                    b.Navigation("FixedTermDeposit");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PrimatesWallet.Core.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
