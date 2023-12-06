using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Candidates",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Candidate_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Date_of_Brith = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Email_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Alternate_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Candidate_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Id_Proof = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Job_Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Candidate_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        interview_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Result = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Candidates", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_CandidateDocument",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CandidateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Upload = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Is_Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CandidateDocument", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Department",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Is_Active = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Department", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Experience",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CTC = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Experience", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_JobRole",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        JobRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Is_Active = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_JobRole", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Qualification",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        year_Of_Passing = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Percentage = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Qualification", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "tbl_CandidateExperience",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Domain = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Year_Of_Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Current_CTC = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Expected_CTC = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        is_Active = table.Column<bool>(type: "bit", nullable: true),
            //        CandidateId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CandidateExperience", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_tbl_CandidateExperience_Candidates_CandidateId",
            //            column: x => x.CandidateId,
            //            principalTable: "Candidates",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_CandidateQualification",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Year_Of_Passing = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        _Percentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        is_Active = table.Column<bool>(type: "bit", nullable: true),
            //        CandidateId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CandidateQualification", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_tbl_CandidateQualification_Candidates_CandidateId",
            //            column: x => x.CandidateId,
            //            principalTable: "Candidates",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_CandidateExperience_CandidateId",
            //    table: "tbl_CandidateExperience",
            //    column: "CandidateId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_CandidateQualification_CandidateId",
            //    table: "tbl_CandidateQualification",
            //    column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CandidateDocument");

            migrationBuilder.DropTable(
                name: "tbl_CandidateExperience");

            migrationBuilder.DropTable(
                name: "tbl_CandidateQualification");

            migrationBuilder.DropTable(
                name: "tbl_Department");

            migrationBuilder.DropTable(
                name: "tbl_Experience");

            migrationBuilder.DropTable(
                name: "tbl_JobRole");

            migrationBuilder.DropTable(
                name: "tbl_Qualification");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
