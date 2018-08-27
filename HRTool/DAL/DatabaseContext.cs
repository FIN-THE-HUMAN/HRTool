using HRTool.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Requirement> Requirement { get; set; }
        public DbSet<Duty> Duties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VacancyApllicant>()
                .HasKey(va => new { va.VacancyId, va.ApplicantId });

            builder.Entity<VacancyApllicant>()
                .HasOne(va => va.Vacancy)
                .WithMany(va => va.VacancyApllicants)
                .HasForeignKey(va => va.VacancyId);

            builder.Entity<VacancyApllicant>()
                .HasOne(va => va.Applicant)
                .WithMany(va => va.VacancyApllicants)
                .HasForeignKey(va => va.ApplicantId);
        }
    }
}