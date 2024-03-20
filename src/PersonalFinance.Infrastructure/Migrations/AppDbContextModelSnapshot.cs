﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalFinance.Infrastructure.Context;

#nullable disable

namespace PersonalFinance.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonalFinance.Domain.Entities.Expenditure", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<long>("ExpenditureCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExpenditureCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Expenditures");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.ExpenditureCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExpenditureCategories");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.Revenue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<long>("RevenueCategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("RevenueCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Revenues");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.RevenueCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RevenueCategories");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsEmailValid")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserRoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.Expenditure", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Entities.ExpenditureCategory", "ExpenditureCategory")
                        .WithMany("Expenditures")
                        .HasForeignKey("ExpenditureCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalFinance.Domain.Entities.User", "User")
                        .WithMany("Expenditures")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenditureCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.ExpenditureCategory", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Entities.User", "User")
                        .WithMany("ExpenditureCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.Revenue", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Entities.RevenueCategory", "RevenueCategory")
                        .WithMany("Revenues")
                        .HasForeignKey("RevenueCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalFinance.Domain.Entities.User", "User")
                        .WithMany("Revenues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RevenueCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.RevenueCategory", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Entities.User", "User")
                        .WithMany("RevenueCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.User", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.ExpenditureCategory", b =>
                {
                    b.Navigation("Expenditures");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.RevenueCategory", b =>
                {
                    b.Navigation("Revenues");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.User", b =>
                {
                    b.Navigation("ExpenditureCategories");

                    b.Navigation("Expenditures");

                    b.Navigation("RevenueCategories");

                    b.Navigation("Revenues");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
