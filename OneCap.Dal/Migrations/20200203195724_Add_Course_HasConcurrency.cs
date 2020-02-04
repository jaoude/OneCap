using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneCap.Dal.Migrations
{
    public partial class Add_Course_HasConcurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Course",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Course");
        }
    }
}
