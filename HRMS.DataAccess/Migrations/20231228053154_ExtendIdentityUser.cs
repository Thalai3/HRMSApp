using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_LeavePolicyMaster",
                keyColumn: "LeavePolicyId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "tbl_LeavePolicyMaster",
                keyColumn: "LeavePolicyId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "tbl_LeavePolicyMaster",
                keyColumn: "LeavePolicyId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "tbl_Leavepolicy",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "tbl_Leavepolicy",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "tbl_Leavepolicy",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "tbl_SalaryStructure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "tbl_SalaryStructure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "tbl_SalaryStructure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 11, 1, 54, 2, DateTimeKind.Local).AddTicks(2360));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "tbl_LeavePolicyMaster",
                keyColumn: "LeavePolicyId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "tbl_LeavePolicyMaster",
                keyColumn: "LeavePolicyId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "tbl_LeavePolicyMaster",
                keyColumn: "LeavePolicyId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "tbl_Leavepolicy",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "tbl_Leavepolicy",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "tbl_Leavepolicy",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "tbl_PayElementMaster",
                keyColumn: "PayElementId",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "tbl_SalaryStructure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "tbl_SalaryStructure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3466));

            migrationBuilder.UpdateData(
                table: "tbl_SalaryStructure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 28, 10, 48, 39, 294, DateTimeKind.Local).AddTicks(3468));
        }
    }
}
