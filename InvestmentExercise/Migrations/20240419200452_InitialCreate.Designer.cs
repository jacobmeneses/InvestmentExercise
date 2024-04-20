﻿// <auto-generated />
using System;
using InvestmentExercise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvestmentExercise.Migrations
{
    [DbContext(typeof(InvestmentExerciseContext))]
    [Migration("20240419200452_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("InvestmentExercise.Models.Investment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OportunityID")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Total")
                        .HasColumnType("REAL");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("OportunityID");

                    b.HasIndex("UserID");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("InvestmentExercise.Models.Oportunity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<float>("Rate")
                        .HasColumnType("REAL");

                    b.Property<float>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Oportunities");
                });

            modelBuilder.Entity("InvestmentExercise.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Balance")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InvestmentExercise.Models.Investment", b =>
                {
                    b.HasOne("InvestmentExercise.Models.Oportunity", null)
                        .WithMany("Investments")
                        .HasForeignKey("OportunityID");

                    b.HasOne("InvestmentExercise.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InvestmentExercise.Models.Oportunity", b =>
                {
                    b.Navigation("Investments");
                });
#pragma warning restore 612, 618
        }
    }
}
