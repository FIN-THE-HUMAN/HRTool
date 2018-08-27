﻿// <auto-generated />
using System;
using HRTool.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HRTool.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HRTool.DAL.Models.Applicant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<int>("Age");

                    b.Property<DateTime>("ApplicationDate");

                    b.Property<int>("Branch");

                    b.Property<string>("ContactMail");

                    b.Property<string>("ContactPhone");

                    b.Property<string>("Experience");

                    b.Property<bool>("Interviewed");

                    b.Property<string>("Name");

                    b.Property<int>("Result");

                    b.Property<string>("ResultDescription");

                    b.Property<decimal>("Salary");

                    b.Property<bool>("Sex");

                    b.Property<int>("Source");

                    b.Property<string>("WantedPosition");

                    b.HasKey("Id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("HRTool.DAL.Models.Duty", b =>
                {
                    b.Property<Guid>("DutyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DutyName");

                    b.Property<Guid?>("VacancyId");

                    b.HasKey("DutyId");

                    b.HasIndex("VacancyId");

                    b.ToTable("Duties");
                });

            modelBuilder.Entity("HRTool.DAL.Models.Requirement", b =>
                {
                    b.Property<Guid>("RequirementId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RequirementName");

                    b.Property<Guid?>("VacancyId");

                    b.Property<Guid?>("VacancyId1");

                    b.HasKey("RequirementId");

                    b.HasIndex("VacancyId");

                    b.HasIndex("VacancyId1");

                    b.ToTable("Requirement");
                });

            modelBuilder.Entity("HRTool.DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Position");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HRTool.DAL.Models.Vacancy", b =>
                {
                    b.Property<Guid>("VacancyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BranchOfficeCity");

                    b.Property<string>("ContactMail");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("ContactPhone");

                    b.Property<int>("DepartureName");

                    b.Property<string>("Description");

                    b.Property<int>("EmploymentType");

                    b.Property<string>("Name");

                    b.Property<string>("RequiredExperienceRange");

                    b.Property<decimal>("SalaryRangeFrom");

                    b.Property<decimal>("SalaryRangeTo");

                    b.Property<string>("VacancyHolderName");

                    b.Property<int>("VacancyStatus");

                    b.Property<string>("WorkHours");

                    b.HasKey("VacancyId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("HRTool.DAL.Models.VacancyApllicant", b =>
                {
                    b.Property<Guid>("VacancyId");

                    b.Property<Guid>("ApplicantId");

                    b.HasKey("VacancyId", "ApplicantId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("VacancyApllicant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HRTool.DAL.Models.Duty", b =>
                {
                    b.HasOne("HRTool.DAL.Models.Vacancy", "Vacancy")
                        .WithMany("Duties")
                        .HasForeignKey("VacancyId");
                });

            modelBuilder.Entity("HRTool.DAL.Models.Requirement", b =>
                {
                    b.HasOne("HRTool.DAL.Models.Vacancy")
                        .WithMany("AdditionalRequirements")
                        .HasForeignKey("VacancyId");

                    b.HasOne("HRTool.DAL.Models.Vacancy")
                        .WithMany("Requirements")
                        .HasForeignKey("VacancyId1");
                });

            modelBuilder.Entity("HRTool.DAL.Models.VacancyApllicant", b =>
                {
                    b.HasOne("HRTool.DAL.Models.Applicant", "Applicant")
                        .WithMany("VacancyApllicants")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRTool.DAL.Models.Vacancy", "Vacancy")
                        .WithMany("VacancyApllicants")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HRTool.DAL.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HRTool.DAL.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRTool.DAL.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HRTool.DAL.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
