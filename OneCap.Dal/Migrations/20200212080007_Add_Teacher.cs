using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneCap.Dal.Migrations
{
    public partial class Add_Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Student",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherFamilyName",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Course",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TeacherFamilyName",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Course");
        }
    }
}
