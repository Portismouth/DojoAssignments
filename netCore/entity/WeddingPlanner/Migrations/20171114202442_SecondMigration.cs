using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Users",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Users",
                newName: "id");
        }
    }
}
