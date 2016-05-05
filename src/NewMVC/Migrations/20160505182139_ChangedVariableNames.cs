using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace NewMVC.Migrations
{
    public partial class ChangedVariableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Trip");
            migrationBuilder.DropColumn(name: "TripName", table: "Trip");
            migrationBuilder.DropColumn(name: "StopName", table: "Stop");
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trip",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stop",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DateCreated", table: "Trip");
            migrationBuilder.DropColumn(name: "Name", table: "Trip");
            migrationBuilder.DropColumn(name: "Name", table: "Stop");
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "TripName",
                table: "Trip",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "StopName",
                table: "Stop",
                nullable: true);
        }
    }
}
