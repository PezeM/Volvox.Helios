using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvox.Helios.Service.Migrations
{
    public partial class LFGTableChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupSession_LookingForGroupSettings_LookingForGroupSettingsGuildId",
                table: "LookingForGroupSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookingForGroupSession",
                table: "LookingForGroupSession");

            migrationBuilder.DropIndex(
                name: "IX_LookingForGroupSession_LookingForGroupSettingsGuildId",
                table: "LookingForGroupSession");

            migrationBuilder.DropColumn(
                name: "LookingForGroupSettingsGuildId",
                table: "LookingForGroupSession");

            migrationBuilder.AddColumn<decimal>(
                name: "GuildId",
                table: "LookingForGroupSession",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "HasMaximumCapacity",
                table: "LookingForGroupSession",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaximumMembers",
                table: "LookingForGroupSession",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortIdentifyer",
                table: "LookingForGroupSession",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookingForGroupSession",
                table: "LookingForGroupSession",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateTable(
                name: "LookingForGroupPlayerRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GuildId = table.Column<decimal>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    LookingForGroupSessionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookingForGroupPlayerRole", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_LookingForGroupPlayerRole_LookingForGroupSession_LookingForGroupSessionId",
                        column: x => x.LookingForGroupSessionId,
                        principalTable: "LookingForGroupSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookingForGroupRoleRestriction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GuildId = table.Column<decimal>(nullable: false),
                    SessionId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<decimal>(nullable: false),
                    LookingForGroupSessionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookingForGroupRoleRestriction", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_LookingForGroupRoleRestriction_LookingForGroupSession_LookingForGroupSessionId",
                        column: x => x.LookingForGroupSessionId,
                        principalTable: "LookingForGroupSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookingForGroupRoleRestriction_LookingForGroupSession_SessionId",
                        column: x => x.SessionId,
                        principalTable: "LookingForGroupSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookingForGroupPlayerRoleMap",
                columns: table => new
                {
                    GuildId = table.Column<decimal>(nullable: false),
                    PlayerRoleId = table.Column<Guid>(nullable: false),
                    SessionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookingForGroupPlayerRoleMap", x => new { x.PlayerRoleId, x.SessionId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_LookingForGroupPlayerRoleMap_LookingForGroupPlayerRole_PlayerRoleId",
                        column: x => x.PlayerRoleId,
                        principalTable: "LookingForGroupPlayerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookingForGroupPlayerRoleMap_LookingForGroupSession_SessionId",
                        column: x => x.SessionId,
                        principalTable: "LookingForGroupSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LookingForGroupSession",
                columns: new[] { "Id", "Description", "GuildId", "HasMaximumCapacity", "MaximumMembers", "ShortIdentifyer", "Title" },
                values: new object[] { new Guid("6bac483a-4216-4911-8529-193605476008"), "Test LFG for things and whatnot", 486220073933996043m, true, 24, "TLG", "Test LFG" });

            migrationBuilder.CreateIndex(
                name: "IX_LookingForGroupSession_GuildId",
                table: "LookingForGroupSession",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_LookingForGroupPlayerRole_LookingForGroupSessionId",
                table: "LookingForGroupPlayerRole",
                column: "LookingForGroupSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_LookingForGroupPlayerRoleMap_SessionId",
                table: "LookingForGroupPlayerRoleMap",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_LookingForGroupRoleRestriction_LookingForGroupSessionId",
                table: "LookingForGroupRoleRestriction",
                column: "LookingForGroupSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_LookingForGroupRoleRestriction_SessionId",
                table: "LookingForGroupRoleRestriction",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupSession_LookingForGroupSettings_GuildId",
                table: "LookingForGroupSession",
                column: "GuildId",
                principalTable: "LookingForGroupSettings",
                principalColumn: "GuildId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupSession_LookingForGroupSettings_GuildId",
                table: "LookingForGroupSession");

            migrationBuilder.DropTable(
                name: "LookingForGroupPlayerRoleMap");

            migrationBuilder.DropTable(
                name: "LookingForGroupRoleRestriction");

            migrationBuilder.DropTable(
                name: "LookingForGroupPlayerRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookingForGroupSession",
                table: "LookingForGroupSession");

            migrationBuilder.DropIndex(
                name: "IX_LookingForGroupSession_GuildId",
                table: "LookingForGroupSession");

            migrationBuilder.DeleteData(
                table: "LookingForGroupSession",
                keyColumn: "Id",
                keyValue: new Guid("6bac483a-4216-4911-8529-193605476008"));

            migrationBuilder.DropColumn(
                name: "GuildId",
                table: "LookingForGroupSession");

            migrationBuilder.DropColumn(
                name: "HasMaximumCapacity",
                table: "LookingForGroupSession");

            migrationBuilder.DropColumn(
                name: "MaximumMembers",
                table: "LookingForGroupSession");

            migrationBuilder.DropColumn(
                name: "ShortIdentifyer",
                table: "LookingForGroupSession");

            migrationBuilder.AddColumn<decimal>(
                name: "LookingForGroupSettingsGuildId",
                table: "LookingForGroupSession",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookingForGroupSession",
                table: "LookingForGroupSession",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LookingForGroupSession_LookingForGroupSettingsGuildId",
                table: "LookingForGroupSession",
                column: "LookingForGroupSettingsGuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupSession_LookingForGroupSettings_LookingForGroupSettingsGuildId",
                table: "LookingForGroupSession",
                column: "LookingForGroupSettingsGuildId",
                principalTable: "LookingForGroupSettings",
                principalColumn: "GuildId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
