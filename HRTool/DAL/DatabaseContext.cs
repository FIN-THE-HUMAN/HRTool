﻿using System;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRTool.DAL
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Duty> Duties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VacancyApplicant>()
                .HasKey(va => new {va.VacancyId, va.ApplicantId});

            builder.Entity<VacancyApplicant>()
                .HasOne(va => va.Vacancy)
                .WithMany(va => va.VacanciesApplicants)
                .HasForeignKey(va => va.VacancyId);

            builder.Entity<VacancyApplicant>()
                .HasOne(va => va.Applicant)
                .WithMany(va => va.VacancyApllicants)
                .HasForeignKey(va => va.ApplicantId);
        }
    }
}