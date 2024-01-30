﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using parus_test_khokhlov.Repository;

#nullable disable

namespace parus_test_khokhlov.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240130073452_base_init_vol_3")]
    partial class base_init_vol_3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("parus_test_khokhlov.Repository.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Change_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Created_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Project_taskId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Project_taskId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Change_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Created_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.Project_task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Change_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Created_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Change_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Created_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.Comment", b =>
                {
                    b.HasOne("parus_test_khokhlov.Repository.Project_task", null)
                        .WithMany("Comments")
                        .HasForeignKey("Project_taskId");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.Project_task", b =>
                {
                    b.HasOne("parus_test_khokhlov.Repository.Project", null)
                        .WithMany("Project_tasks")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.User", b =>
                {
                    b.HasOne("parus_test_khokhlov.Repository.Project", null)
                        .WithMany("Users")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.Project", b =>
                {
                    b.Navigation("Project_tasks");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("parus_test_khokhlov.Repository.Project_task", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
