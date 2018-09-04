using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvox.Helios.Service.Migrations
{
    public partial class LFGSessionExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookingForGroupSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LookingForGroupSettingsGuildId = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookingForGroupSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookingForGroupSession_LookingForGroupSettings_LookingForGroupSettingsGuildId",
                        column: x => x.LookingForGroupSettingsGuildId,
                        principalTable: "LookingForGroupSettings",
                        principalColumn: "GuildId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookingForGroupSession_LookingForGroupSettingsGuildId",
                table: "LookingForGroupSession",
                column: "LookingForGroupSettingsGuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookingForGroupSession");
        }
    }
}
