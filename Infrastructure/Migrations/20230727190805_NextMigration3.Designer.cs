﻿// <auto-generated />
using Infrastructure.Context;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiftLog.Migrations
{
    [DbContext(typeof(LiftLogContext))]
    [Migration("20230727190805_NextMigration3")]
    partial class NextMigration3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LiftLog.Entities.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Exercise")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutProgramId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("LiftLog.Entities.WorkoutProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutPrograms");
                });

            modelBuilder.Entity("LiftLog.Entities.Set", b =>
                {
                    b.HasOne("LiftLog.Entities.WorkoutProgram", "WorkoutProgram")
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutProgramId");

                    b.Navigation("WorkoutProgram");
                });

            modelBuilder.Entity("LiftLog.Entities.WorkoutProgram", b =>
                {
                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
