﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasky.Server.Data;

#nullable disable

namespace Tasky.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220704191419_addTagsToTasks")]
    partial class addTagsToTasks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tasky.Shared.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Tasky.Shared.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Tasky.Shared.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"), 1L, 1);

                    b.Property<int>("AssignedToSubTask")
                        .HasColumnType("int");

                    b.Property<int>("AssignedToTask")
                        .HasColumnType("int");

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NoteModelTaskId")
                        .HasColumnType("int");

                    b.Property<int?>("SubTaskId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("NoteModelTaskId");

                    b.HasIndex("SubTaskId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Tasky.Shared.NoteModel", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<int>("Assignee")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LinkTo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityLevel")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isSubTask")
                        .HasColumnType("bit");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Tasky.Shared.SubTask", b =>
                {
                    b.Property<int>("SubTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubTaskId"), 1L, 1);

                    b.Property<int>("AssignedToTask")
                        .HasColumnType("int");

                    b.Property<int>("Assignee")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityLevel")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("SubTaskId");

                    b.ToTable("SubTasks");
                });

            modelBuilder.Entity("Tasky.Shared.Note", b =>
                {
                    b.HasOne("Tasky.Shared.NoteModel", null)
                        .WithMany("Notes")
                        .HasForeignKey("NoteModelTaskId");

                    b.HasOne("Tasky.Shared.SubTask", null)
                        .WithMany("Notes")
                        .HasForeignKey("SubTaskId");
                });

            modelBuilder.Entity("Tasky.Shared.NoteModel", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("Tasky.Shared.SubTask", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
