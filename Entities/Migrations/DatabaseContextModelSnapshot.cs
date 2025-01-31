﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Household", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Households");
                });

            modelBuilder.Entity("Entities.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPR")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<int>("MemberTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("MemberTypeId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Entities.Models.MemberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MemberTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Aktivt Medlem"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Passivt Medlem"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Medlem af Bestyrelse"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Forælder"
                        });
                });

            modelBuilder.Entity("Entities.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<decimal>("MemberShipFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MemberShipFee = 800m,
                            Name = "Fodbold"
                        },
                        new
                        {
                            Id = 2,
                            MemberShipFee = 700m,
                            Name = "Håndbold"
                        },
                        new
                        {
                            Id = 3,
                            MemberShipFee = 600m,
                            Name = "Gymnastik"
                        },
                        new
                        {
                            Id = 4,
                            MemberShipFee = 500m,
                            Name = "Bamsekarate (Zumba)"
                        });
                });

            modelBuilder.Entity("Entities.Models.Member", b =>
                {
                    b.HasOne("Entities.Models.Household", "Household")
                        .WithMany()
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.MemberType", "MemberType")
                        .WithMany()
                        .HasForeignKey("MemberTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");

                    b.Navigation("MemberType");
                });

            modelBuilder.Entity("Entities.Models.Sport", b =>
                {
                    b.HasOne("Entities.Models.Member", null)
                        .WithMany("Sports")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("Entities.Models.Member", b =>
                {
                    b.Navigation("Sports");
                });
#pragma warning restore 612, 618
        }
    }
}
