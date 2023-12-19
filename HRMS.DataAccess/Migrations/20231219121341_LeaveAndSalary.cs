using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LeaveAndSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_LeavePolicyMaster",
                columns: table => new
                {
                    LeavePolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeavePolicys = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LeavePolicyMaster", x => x.LeavePolicyId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PayElementMaster",
                columns: table => new
                {
                    PayElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayElements = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PayElementMaster", x => x.PayElementId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Leavepolicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LeavePolicyId = table.Column<int>(type: "int", nullable: true),
                    NoOfDays = table.Column<int>(type: "int", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Leavepolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Leavepolicy_tbl_LeavePolicyMaster_LeavePolicyId",
                        column: x => x.LeavePolicyId,
                        principalTable: "tbl_LeavePolicyMaster",
                        principalColumn: "LeavePolicyId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_SalaryStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PayElementId = table.Column<int>(type: "int", nullable: true),
                    TotalValue = table.Column<int>(type: "int", nullable: true),
                    Addition = table.Column<int>(type: "int", nullable: true),
                    Deduction = table.Column<int>(type: "int", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SalaryStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_SalaryStructure_tbl_PayElementMaster_PayElementId",
                        column: x => x.PayElementId,
                        principalTable: "tbl_PayElementMaster",
                        principalColumn: "PayElementId");
                });

            migrationBuilder.InsertData(
                table: "tbl_LeavePolicyMaster",
                columns: new[] { "LeavePolicyId", "CreatedBy", "CreatedDateTime", "IsActive", "LeavePolicys", "ModifiedBy", "ModifiedDateTime", "ShortName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2133), true, "Casual", 0, null, "CL" },
                    { 2, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2144), true, "Medical", 0, null, "ML" },
                    { 3, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2146), false, "Special Leave", 0, null, "SL" }
                });

            migrationBuilder.InsertData(
                table: "tbl_PayElementMaster",
                columns: new[] { "PayElementId", "CreatedBy", "CreatedDateTime", "IsActive", "ModifiedBy", "ModifiedDateTime", "PayElements", "ShortName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2328), true, 0, null, "Basic Salary", "Basic" },
                    { 2, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2331), true, 0, null, "Convaeyance Allownce", "CA" },
                    { 3, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2333), false, 0, null, "House Rent Allownce", "Rent" },
                    { 4, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2334), false, 0, null, "Special Allownce", "Special" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Leavepolicy",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "EmployeeId", "IsActive", "LeavePolicyId", "ModifiedBy", "ModifiedDateTime", "NoOfDays", "UserType" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2380), "Thlai123Dotnet", true, 1, 0, null, 2, null },
                    { 2, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2383), "Thlai123Dotnet", true, 2, 0, null, 2, null },
                    { 3, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2385), "Thlai123Dotnet", true, 3, 0, null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "tbl_SalaryStructure",
                columns: new[] { "Id", "Addition", "CreatedBy", "CreatedDateTime", "Deduction", "EmployeeId", "IsActive", "ModifiedBy", "ModifiedDateTime", "PayElementId", "TotalValue", "UserType" },
                values: new object[,]
                {
                    { 1, 2000, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2354), 2000, "Thlai123Dotnet", true, 0, null, 1, 10000, null },
                    { 2, 2000, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2357), 2000, "Thlai123Dotnet", true, 0, null, 2, 10000, null },
                    { 3, 2000, 1, new DateTime(2023, 12, 19, 17, 43, 41, 396, DateTimeKind.Local).AddTicks(2359), 2000, "Thlai123Dotnet", true, 0, null, 2, 10000, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Leavepolicy_LeavePolicyId",
                table: "tbl_Leavepolicy",
                column: "LeavePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SalaryStructure_PayElementId",
                table: "tbl_SalaryStructure",
                column: "PayElementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Leavepolicy");

            migrationBuilder.DropTable(
                name: "tbl_SalaryStructure");

            migrationBuilder.DropTable(
                name: "tbl_LeavePolicyMaster");

            migrationBuilder.DropTable(
                name: "tbl_PayElementMaster");
        }
    }
}
