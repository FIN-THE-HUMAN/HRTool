using System;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;
using HRTool.DAL.Models.IntermediateModels;
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


            builder.Entity<Vacancy>()
                .HasMany(v => v.Duties)
                .WithOne(v => v.Vacancy);

            builder.Entity<Vacancy>()
                .HasMany(v => v.Requirements)
                .WithOne(v => v.Vacancy);

            builder.Entity<VacancyApplicant>()
                .HasKey(va => new {va.VacancyId, va.ApplicantId});

            builder.Entity<VacancyApplicant>()
                .HasOne(va => va.Vacancy)
                .WithMany(va => va.Applicants)
                .HasForeignKey(va => va.VacancyId);

            builder.Entity<VacancyApplicant>()
                .HasOne(va => va.Applicant)
                .WithMany(va => va.Vacancies)
                .HasForeignKey(va => va.ApplicantId);
        }
    }
}