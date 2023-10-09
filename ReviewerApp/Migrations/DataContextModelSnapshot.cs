﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewerApp.Data;

#nullable disable

namespace ReviewerApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReviewerApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ReviewerApp.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ReviewerApp.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Gym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("ReviewerApp.Models.Pokeman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pokemans");
                });

            modelBuilder.Entity("ReviewerApp.Models.PokemanCategory", b =>
                {
                    b.Property<int>("PokemanId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("PokemanCategoryCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("PokemanCategoryPokemanId")
                        .HasColumnType("int");

                    b.HasKey("PokemanId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PokemanCategoryPokemanId", "PokemanCategoryCategoryId");

                    b.ToTable("PokemanCategories");
                });

            modelBuilder.Entity("ReviewerApp.Models.PokemanOwner", b =>
                {
                    b.Property<int>("PokemanId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("PokemanId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("PokemanOwners");
                });

            modelBuilder.Entity("ReviewerApp.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PokemanId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemanId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ReviewerApp.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("ReviewerApp.Models.Owner", b =>
                {
                    b.HasOne("ReviewerApp.Models.Country", "Country")
                        .WithMany("Owners")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ReviewerApp.Models.PokemanCategory", b =>
                {
                    b.HasOne("ReviewerApp.Models.Category", "Category")
                        .WithMany("PokemanCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviewerApp.Models.Pokeman", "Pokeman")
                        .WithMany("PokemanCategories")
                        .HasForeignKey("PokemanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviewerApp.Models.PokemanCategory", null)
                        .WithMany("PokemanCategories")
                        .HasForeignKey("PokemanCategoryPokemanId", "PokemanCategoryCategoryId");

                    b.Navigation("Category");

                    b.Navigation("Pokeman");
                });

            modelBuilder.Entity("ReviewerApp.Models.PokemanOwner", b =>
                {
                    b.HasOne("ReviewerApp.Models.Owner", "Owner")
                        .WithMany("PokemanOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviewerApp.Models.Pokeman", "Pokeman")
                        .WithMany("PokemanOwners")
                        .HasForeignKey("PokemanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pokeman");
                });

            modelBuilder.Entity("ReviewerApp.Models.Review", b =>
                {
                    b.HasOne("ReviewerApp.Models.Pokeman", "Pokeman")
                        .WithMany("Reviews")
                        .HasForeignKey("PokemanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviewerApp.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokeman");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("ReviewerApp.Models.Category", b =>
                {
                    b.Navigation("PokemanCategories");
                });

            modelBuilder.Entity("ReviewerApp.Models.Country", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("ReviewerApp.Models.Owner", b =>
                {
                    b.Navigation("PokemanOwners");
                });

            modelBuilder.Entity("ReviewerApp.Models.Pokeman", b =>
                {
                    b.Navigation("PokemanCategories");

                    b.Navigation("PokemanOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ReviewerApp.Models.PokemanCategory", b =>
                {
                    b.Navigation("PokemanCategories");
                });

            modelBuilder.Entity("ReviewerApp.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
