using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRTool.Migrations
{
    public partial class VacancyApplicants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Vacancies",
                newName: "SalaryRangeTo");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Vacancies",
                newName: "WorkHours");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vacancies",
                newName: "VacancyId");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "AspNetUsers",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Applicants",
                newName: "WantedPosition");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Applicants",
                newName: "ResultDescription");

            migrationBuilder.RenameColumn(
                name: "CareerObjectiveName",
                table: "Applicants",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentType",
                table: "Vacancies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchOfficeCity",
                table: "Vacancies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactMail",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartureName",
                table: "Vacancies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RequiredExperienceRange",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryRangeFrom",
                table: "Vacancies",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "VacancyHolderName",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyStatus",
                table: "Vacancies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Branch",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Interviewed",
                table: "Applicants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    DutyId = table.Column<Guid>(nullable: false),
                    DutyName = table.Column<string>(nullable: true),
                    VacancyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.DutyId);
                    table.ForeignKey(
                        name: "FK_Duties_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    RequirementId = table.Column<Guid>(nullable: false),
                    RequirementName = table.Column<string>(nullable: true),
                    VacancyId = table.Column<Guid>(nullable: true),
                    VacancyId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.RequirementId);
                    table.ForeignKey(
                        name: "FK_Requirement_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requirement_Vacancies_VacancyId1",
                        column: x => x.VacancyId1,
                        principalTable: "Vacancies",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacancyApllicant",
                columns: table => new
                {
                    VacancyId = table.Column<Guid>(nullable: false),
                    ApplicantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyApllicant", x => new { x.VacancyId, x.ApplicantId });
                    table.ForeignKey(
                        name: "FK_VacancyApllicant_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyApllicant_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duties_VacancyId",
                table: "Duties",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_VacancyId",
                table: "Requirement",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_VacancyId1",
                table: "Requirement",
                column: "VacancyId1");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyApllicant_ApplicantId",
                table: "VacancyApllicant",
                column: "ApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "VacancyApllicant");

            migrationBuilder.DropColumn(
                name: "BranchOfficeCity",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "ContactMail",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "DepartureName",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RequiredExperienceRange",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "SalaryRangeFrom",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "VacancyHolderName",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "VacancyStatus",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Interviewed",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "WorkHours",
                table: "Vacancies",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "SalaryRangeTo",
                table: "Vacancies",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "VacancyId",
                table: "Vacancies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "AspNetUsers",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "WantedPosition",
                table: "Applicants",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ResultDescription",
                table: "Applicants",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Applicants",
                newName: "CareerObjectiveName");

            migrationBuilder.AlterColumn<string>(
                name: "EmploymentType",
                table: "Vacancies",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
