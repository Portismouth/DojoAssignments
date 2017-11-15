using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeddingPlanner.Migrations
{
    public partial class AddGuestWeddingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    weddingid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    address = table.Column<string>(nullable: true),
                    createdat = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    wedderone = table.Column<string>(nullable: true),
                    weddertwo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.weddingid);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    guestid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<int>(nullable: false),
                    weddingid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.guestid);
                    table.ForeignKey(
                        name: "FK_Guests_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guests_Weddings_weddingid",
                        column: x => x.weddingid,
                        principalTable: "Weddings",
                        principalColumn: "weddingid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_userid",
                table: "Guests",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_weddingid",
                table: "Guests",
                column: "weddingid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Weddings");
        }
    }
}
