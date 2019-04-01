using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModelDesigner.Designer.Host.Migrations
{
    public partial class Fields_Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldSourceId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "FieldSourceTypeId",
                table: "Fields");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FieldSourceId",
                table: "Fields",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "FieldSourceTypeId",
                table: "Fields",
                nullable: false,
                defaultValue: 0);
        }
    }
}
