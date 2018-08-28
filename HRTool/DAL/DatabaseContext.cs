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
            /*
            #region Vacancy-Duties

            builder.Entity<VacancyDuties>()
                .HasKey(vd => new {vd.VacancyId, vd.DutyId});
            builder.Entity<VacancyDuties>()
                .HasOne(vd => vd.Vacancy)
                .WithMany(vd => vd.Duties)
                .HasForeignKey(vd => vd.VacancyId);

            #endregion

            #region Vacancy-Requirements

            builder.Entity<VacancyRequirements>()
                .HasKey(vd => new {vd.VacancyId, vd.RequirementId});
            builder.Entity<VacancyRequirements>()
                .HasOne(vd => vd.Vacancy)
                .WithMany(vd => vd.Requirements)
                .HasForeignKey(vd => vd.VacancyId);

            #endregion

            #region Vacancy-AdditionalRequirements

            builder.Entity<VacancyAdditionalRequirements>()
                .HasKey(vd => new {vd.VacancyId, vd.AdditionalRequirementId});

            builder.Entity<VacancyAdditionalRequirements>()
                .HasOne(vd => vd.Vacancy)
                .WithMany(vd => vd.AdditionalRequirements)
                .HasForeignKey(vd => vd.VacancyId);

            #endregion
*/


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