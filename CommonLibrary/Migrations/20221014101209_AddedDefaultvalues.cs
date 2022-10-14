using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonLibrary.Migrations
{
    public partial class AddedDefaultvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 14, 15, 42, 8, 395, DateTimeKind.Local).AddTicks(1358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 14, 15, 42, 8, 397, DateTimeKind.Local).AddTicks(1617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AllowcationPercentage",
                table: "Users",
                maxLength: 100,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 10, 14, 15, 42, 8, 395, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 10, 14, 15, 42, 8, 397, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.AlterColumn<int>(
                name: "AllowcationPercentage",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 100,
                oldDefaultValue: 0);
        }
    }
}
