using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonLibrary.Migrations
{
    public partial class UpdatedYearsOfExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearsOfExperience",
                table: "Users",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 15, 1, 21, 33, 236, DateTimeKind.Local).AddTicks(3916),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 15, 1, 17, 16, 155, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 15, 1, 21, 33, 237, DateTimeKind.Local).AddTicks(7384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 15, 1, 17, 16, 158, DateTimeKind.Local).AddTicks(1667));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearsOfExperience",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 15, 1, 17, 16, 155, DateTimeKind.Local).AddTicks(9641),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 10, 15, 1, 21, 33, 236, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 15, 1, 17, 16, 158, DateTimeKind.Local).AddTicks(1667),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 10, 15, 1, 21, 33, 237, DateTimeKind.Local).AddTicks(7384));
        }
    }
}
