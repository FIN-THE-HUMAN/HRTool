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
        public DbSet<Resume> Resumes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Resume>()
                .HasOne(r => r.Applicant)
                .WithMany(r => r.Resumes);

            builder.Entity<Vacancy>()
                .HasMany(v => v.VacancyDuties)
                .WithOne(v => v.Vacancy);

            builder.Entity<Vacancy>()
                .HasMany(v => v.VacancyRequirements)
                .WithOne(v => v.Vacancy);

            #region Vacancy-applllicant

            builder.Entity<VacancyApplicant>()
                .HasKey(va => new {va.VacancyId, va.ApplicantId});

            builder.Entity<VacancyApplicant>()
                .HasOne(va => va.Vacancy)
                .WithMany(va => va.VacancyApplicants)
                .HasForeignKey(va => va.VacancyId);

            builder.Entity<VacancyApplicant>()
                .HasOne(va => va.Applicant)
                .WithMany(va => va.VacancyApllicants)
                .HasForeignKey(va => va.ApplicantId);

            #endregion

            #region Vacancy-duty

            builder.Entity<VacancyDuty>()
                .HasKey(vd => new {vd.VacancyId, vd.DutyId});

            builder.Entity<VacancyDuty>()
                .HasOne(vd => vd.Vacancy)
                .WithMany(vd => vd.VacancyDuties)
                .HasForeignKey(vd => vd.VacancyId);

            builder.Entity<VacancyDuty>()
                .HasOne(vd => vd.Duty)
                .WithMany(vd => vd.Vacancies)
                .HasForeignKey(vd => vd.DutyId);

            #endregion

            #region Vacancy-requirement

            builder.Entity<VacancyRequirement>()
                .HasKey(vr => new {vr.VacancyId, vr.RequirementId, vr.IsRequirementAdditional});

            builder.Entity<VacancyRequirement>()
                .HasOne(vr => vr.Vacancy)
                .WithMany(vr => vr.VacancyRequirements)
                .HasForeignKey(vr => vr.VacancyId);

            builder.Entity<VacancyRequirement>()
                .HasOne(vr => vr.Requirement)
                .WithMany(vr => vr.Vacancies)
                .HasForeignKey(vr => vr.RequirementId);

            #endregion
        }
    }
}