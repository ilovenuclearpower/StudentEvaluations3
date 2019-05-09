﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_Evaluation_3.Data;

namespace Student_Evaluation_3.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190508233257_maybesomeday")]
    partial class maybesomeday
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Student_Evaluation_3.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EnrollmentID");

                    b.Property<int?>("StakeholderID");

                    b.Property<string>("Title");

                    b.HasKey("CourseID");

                    b.HasIndex("EnrollmentID");

                    b.HasIndex("StakeholderID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Evaluation", b =>
                {
                    b.Property<int>("EvaluationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnrollmentID");

                    b.Property<int>("StakeholderID");

                    b.Property<string>("challenged_learn");

                    b.Property<string>("clear_goals");

                    b.Property<string>("clear_syllabus");

                    b.Property<string>("concern_understanding");

                    b.Property<string>("different_views");

                    b.Property<string>("effective_teaching");

                    b.Property<string>("enthusiastic_teaching");

                    b.Property<string>("good_because");

                    b.Property<string>("good_job");

                    b.Property<string>("grade");

                    b.Property<string>("grading_fair");

                    b.Property<string>("helpful_assignments");

                    b.Property<string>("hours_week");

                    b.Property<string>("improved_by");

                    b.Property<string>("instructor_interaction");

                    b.Property<string>("instructor_knowledgeable");

                    b.Property<string>("instructor_prepared");

                    b.Property<string>("life_connection");

                    b.Property<string>("reading_helpful");

                    b.Property<string>("relevant_materials");

                    b.Property<string>("student_improved");

                    b.Property<string>("successful_in");

                    b.Property<string>("suggested_improvement");

                    b.Property<string>("teaching_improved");

                    b.Property<string>("timely_manner");

                    b.Property<string>("why_course");

                    b.HasKey("EvaluationID");

                    b.HasIndex("EnrollmentID");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.FacultyGroup", b =>
                {
                    b.Property<int>("FacultyGroupID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupAssignmentID");

                    b.Property<string>("GroupName");

                    b.Property<int?>("StakeholderID");

                    b.HasKey("FacultyGroupID");

                    b.HasIndex("GroupAssignmentID");

                    b.HasIndex("StakeholderID");

                    b.ToTable("FacultyGroups");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.GroupAssignment", b =>
                {
                    b.Property<int>("GroupAssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultyGroupID");

                    b.Property<int>("InstructorID");

                    b.HasKey("GroupAssignmentID");

                    b.ToTable("GroupAssignments");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Stakeholder", b =>
                {
                    b.Property<int>("StakeholderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID");

                    b.Property<int?>("EvaluationID");

                    b.Property<int>("FacultyGroupID");

                    b.HasKey("StakeholderID");

                    b.HasIndex("EvaluationID");

                    b.ToTable("Stakeholders");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Instructor", b =>
                {
                    b.HasBaseType("Student_Evaluation_3.Models.User");

                    b.Property<string>("Department");

                    b.Property<int?>("DepartmentID");

                    b.Property<int?>("GroupAssignmentID");

                    b.Property<string>("InstructorID");

                    b.Property<string>("PhoneNumber");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("GroupAssignmentID");

                    b.ToTable("Instructor");

                    b.HasDiscriminator().HasValue("Instructor");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Student", b =>
                {
                    b.HasBaseType("Student_Evaluation_3.Models.User");

                    b.Property<int?>("DepartmentID")
                        .HasColumnName("Student_DepartmentID");

                    b.Property<int?>("EnrollmentID");

                    b.Property<DateTime>("GraduationYear");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("Student_PhoneNumber");

                    b.Property<int>("StudentID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("EnrollmentID");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Course", b =>
                {
                    b.HasOne("Student_Evaluation_3.Models.Enrollment")
                        .WithMany("Courses")
                        .HasForeignKey("EnrollmentID");

                    b.HasOne("Student_Evaluation_3.Models.Stakeholder")
                        .WithMany("Courses")
                        .HasForeignKey("StakeholderID");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Evaluation", b =>
                {
                    b.HasOne("Student_Evaluation_3.Models.Enrollment", "Enrollment")
                        .WithMany()
                        .HasForeignKey("EnrollmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.FacultyGroup", b =>
                {
                    b.HasOne("Student_Evaluation_3.Models.GroupAssignment")
                        .WithMany("FacultyGroups")
                        .HasForeignKey("GroupAssignmentID");

                    b.HasOne("Student_Evaluation_3.Models.Stakeholder")
                        .WithMany("Instructors")
                        .HasForeignKey("StakeholderID");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Stakeholder", b =>
                {
                    b.HasOne("Student_Evaluation_3.Models.Evaluation")
                        .WithMany("stakeholders")
                        .HasForeignKey("EvaluationID");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Instructor", b =>
                {
                    b.HasOne("Student_Evaluation_3.Models.Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("Student_Evaluation_3.Models.GroupAssignment")
                        .WithMany("Instructors")
                        .HasForeignKey("GroupAssignmentID");
                });

            modelBuilder.Entity("Student_Evaluation_3.Models.Student", b =>
                {
                    b.HasOne("Student_Evaluation_3.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID");

                    b.HasOne("Student_Evaluation_3.Models.Enrollment")
                        .WithMany("Students")
                        .HasForeignKey("EnrollmentID");
                });
#pragma warning restore 612, 618
        }
    }
}
