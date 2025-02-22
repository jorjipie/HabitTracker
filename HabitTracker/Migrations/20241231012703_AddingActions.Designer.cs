﻿// <auto-generated />
using System;
using HabitTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HabitTracker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241231012703_AddingActions")]
    partial class AddingActions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("HabitTracker.Models.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HabitId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HabitId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("HabitTracker.Models.Habit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("HabitTracker.Models.Action", b =>
                {
                    b.HasOne("HabitTracker.Models.Habit", "Habit")
                        .WithMany()
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");
                });
#pragma warning restore 612, 618
        }
    }
}
