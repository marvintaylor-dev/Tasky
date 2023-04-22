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
    [Migration("20230419084030_updateNoteModel")]
    partial class updateNoteModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MemberSprintModel", b =>
                {
                    b.Property<int>("MembersWithPlannedLeaveMemberId")
                        .HasColumnType("int");

                    b.Property<int>("SprintsAssignedToSprintId")
                        .HasColumnType("int");

                    b.HasKey("MembersWithPlannedLeaveMemberId", "SprintsAssignedToSprintId");

                    b.HasIndex("SprintsAssignedToSprintId");

                    b.ToTable("MemberSprintModel");
                });

            modelBuilder.Entity("Tasky.Shared.EstimationGroup", b =>
                {
                    b.Property<int>("EstimationGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstimationGroupId"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("EstimationGroupId");

                    b.ToTable("EstimationGroups");
                });

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

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkAssigned")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Tasky.Shared.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"), 1L, 1);

                    b.Property<int>("AssignedToTask")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Tasky.Shared.NoteModel", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<string>("AcceptanceCriteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AssignedToSprintId")
                        .HasColumnType("int");

                    b.Property<int>("Assignee")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LinkTo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("PriorityLevel")
                        .HasColumnType("int");

                    b.Property<int?>("SizeEstimate")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("Tag")
                        .HasColumnType("int");

                    b.Property<int?>("UserStory")
                        .HasColumnType("int");

                    b.Property<bool?>("isSubTask")
                        .HasColumnType("bit");

                    b.HasKey("TaskId");

                    b.HasIndex("AssignedToSprintId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Tasky.Shared.RelativeEstimation", b =>
                {
                    b.Property<int>("EstimationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstimationId"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimationGroup")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstimationId");

                    b.ToTable("RelativeEstimates");
                });

            modelBuilder.Entity("Tasky.Shared.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"), 1L, 1);

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Tasky.Shared.sectionNoteModel", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("TaskId", "SectionId");

                    b.ToTable("SectionNoteModels");
                });

            modelBuilder.Entity("Tasky.Shared.SprintModel", b =>
                {
                    b.Property<int>("SprintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SprintId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentMaxCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentMinCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Holidays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PercentOfTimeBuffer")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("PercentOfTimeOnDebt")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("PercentOfTimeOnFeatures")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("PercentOfTimeOnOther")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("PlannedTraining")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PreviousVelocity")
                        .HasColumnType("int");

                    b.Property<decimal>("SprintBudget")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int?>("SprintNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("SprintId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("Tasky.Shared.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusDefinitionOfFinished")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StatusOrder")
                        .HasColumnType("int");

                    b.Property<int>("WorkInProgressLimit")
                        .HasColumnType("int");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Tasky.Shared.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"), 1L, 1);

                    b.Property<int?>("Color")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Tasky.Shared.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tasky.Shared.UserStory", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoryId"), 1L, 1);

                    b.Property<string>("As")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("So")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Want")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoryId");

                    b.ToTable("UserStories");
                });

            modelBuilder.Entity("MemberSprintModel", b =>
                {
                    b.HasOne("Tasky.Shared.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersWithPlannedLeaveMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasky.Shared.SprintModel", null)
                        .WithMany()
                        .HasForeignKey("SprintsAssignedToSprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tasky.Shared.NoteModel", b =>
                {
                    b.HasOne("Tasky.Shared.SprintModel", "AssignedToSprint")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("AssignedToSprintId");

                    b.Navigation("AssignedToSprint");
                });

            modelBuilder.Entity("Tasky.Shared.SprintModel", b =>
                {
                    b.Navigation("AssignedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
