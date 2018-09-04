using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvox.Helios.Service.Migrations
{
    public partial class LFGSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupPlayerRole_LookingForGroupSession_LookingForGroupSessionId",
                table: "LookingForGroupPlayerRole");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupPlayerRoleMap_LookingForGroupSession_SessionId",
                table: "LookingForGroupPlayerRoleMap");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSession_LookingForGroupSessionId",
                table: "LookingForGroupRoleRestriction");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSession_SessionId",
                table: "LookingForGroupRoleRestriction");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupSession_LookingForGroupSettings_GuildId",
                table: "LookingForGroupSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookingForGroupSession",
                table: "LookingForGroupSession");

            migrationBuilder.DeleteData(
                table: "LookingForGroupSession",
                keyColumn: "Id",
                keyValue: new Guid("6bac483a-4216-4911-8529-193605476008"));

            migrationBuilder.EnsureSchema(
                name: "lfg");

            migrationBuilder.RenameTable(
                name: "LookingForGroupSettings",
                newName: "LookingForGroupSettings",
                newSchema: "lfg");

            migrationBuilder.RenameTable(
                name: "LookingForGroupRoleRestriction",
                newName: "LookingForGroupRoleRestriction",
                newSchema: "lfg");

            migrationBuilder.RenameTable(
                name: "LookingForGroupPlayerRoleMap",
                newName: "LookingForGroupPlayerRoleMap",
                newSchema: "lfg");

            migrationBuilder.RenameTable(
                name: "LookingForGroupPlayerRole",
                newName: "LookingForGroupPlayerRole",
                newSchema: "lfg");

            migrationBuilder.RenameTable(
                name: "LookingForGroupSession",
                newName: "LookingForGroupSessions",
                newSchema: "lfg");

            migrationBuilder.RenameIndex(
                name: "IX_LookingForGroupSession_GuildId",
                schema: "lfg",
                table: "LookingForGroupSessions",
                newName: "IX_LookingForGroupSessions_GuildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookingForGroupSessions",
                schema: "lfg",
                table: "LookingForGroupSessions",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.InsertData(
                schema: "lfg",
                table: "LookingForGroupSessions",
                columns: new[] { "Id", "Description", "GuildId", "HasMaximumCapacity", "MaximumMembers", "ShortIdentifyer", "Title" },
                values: new object[] { new Guid("62aa88a8-b7e1-4b9d-8802-5bdec352660c"), "Test LFG for things and whatnot", 486220073933996043m, true, 24, "TLG", "Test LFG" });

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupPlayerRole_LookingForGroupSessions_LookingForGroupSessionId",
                schema: "lfg",
                table: "LookingForGroupPlayerRole",
                column: "LookingForGroupSessionId",
                principalSchema: "lfg",
                principalTable: "LookingForGroupSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupPlayerRoleMap_LookingForGroupSessions_SessionId",
                schema: "lfg",
                table: "LookingForGroupPlayerRoleMap",
                column: "SessionId",
                principalSchema: "lfg",
                principalTable: "LookingForGroupSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSessions_LookingForGroupSessionId",
                schema: "lfg",
                table: "LookingForGroupRoleRestriction",
                column: "LookingForGroupSessionId",
                principalSchema: "lfg",
                principalTable: "LookingForGroupSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSessions_SessionId",
                schema: "lfg",
                table: "LookingForGroupRoleRestriction",
                column: "SessionId",
                principalSchema: "lfg",
                principalTable: "LookingForGroupSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupSessions_LookingForGroupSettings_GuildId",
                schema: "lfg",
                table: "LookingForGroupSessions",
                column: "GuildId",
                principalSchema: "lfg",
                principalTable: "LookingForGroupSettings",
                principalColumn: "GuildId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupPlayerRole_LookingForGroupSessions_LookingForGroupSessionId",
                schema: "lfg",
                table: "LookingForGroupPlayerRole");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupPlayerRoleMap_LookingForGroupSessions_SessionId",
                schema: "lfg",
                table: "LookingForGroupPlayerRoleMap");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSessions_LookingForGroupSessionId",
                schema: "lfg",
                table: "LookingForGroupRoleRestriction");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSessions_SessionId",
                schema: "lfg",
                table: "LookingForGroupRoleRestriction");

            migrationBuilder.DropForeignKey(
                name: "FK_LookingForGroupSessions_LookingForGroupSettings_GuildId",
                schema: "lfg",
                table: "LookingForGroupSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookingForGroupSessions",
                schema: "lfg",
                table: "LookingForGroupSessions");

            migrationBuilder.DeleteData(
                schema: "lfg",
                table: "LookingForGroupSessions",
                keyColumn: "Id",
                keyValue: new Guid("62aa88a8-b7e1-4b9d-8802-5bdec352660c"));

            migrationBuilder.RenameTable(
                name: "LookingForGroupSettings",
                schema: "lfg",
                newName: "LookingForGroupSettings");

            migrationBuilder.RenameTable(
                name: "LookingForGroupRoleRestriction",
                schema: "lfg",
                newName: "LookingForGroupRoleRestriction");

            migrationBuilder.RenameTable(
                name: "LookingForGroupPlayerRoleMap",
                schema: "lfg",
                newName: "LookingForGroupPlayerRoleMap");

            migrationBuilder.RenameTable(
                name: "LookingForGroupPlayerRole",
                schema: "lfg",
                newName: "LookingForGroupPlayerRole");

            migrationBuilder.RenameTable(
                name: "LookingForGroupSessions",
                schema: "lfg",
                newName: "LookingForGroupSession");

            migrationBuilder.RenameIndex(
                name: "IX_LookingForGroupSessions_GuildId",
                table: "LookingForGroupSession",
                newName: "IX_LookingForGroupSession_GuildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookingForGroupSession",
                table: "LookingForGroupSession",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.InsertData(
                table: "LookingForGroupSession",
                columns: new[] { "Id", "Description", "GuildId", "HasMaximumCapacity", "MaximumMembers", "ShortIdentifyer", "Title" },
                values: new object[] { new Guid("6bac483a-4216-4911-8529-193605476008"), "Test LFG for things and whatnot", 0m, true, 24, "TLG", "Test LFG" });

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupPlayerRole_LookingForGroupSession_LookingForGroupSessionId",
                table: "LookingForGroupPlayerRole",
                column: "LookingForGroupSessionId",
                principalTable: "LookingForGroupSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupPlayerRoleMap_LookingForGroupSession_SessionId",
                table: "LookingForGroupPlayerRoleMap",
                column: "SessionId",
                principalTable: "LookingForGroupSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSession_LookingForGroupSessionId",
                table: "LookingForGroupRoleRestriction",
                column: "LookingForGroupSessionId",
                principalTable: "LookingForGroupSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupRoleRestriction_LookingForGroupSession_SessionId",
                table: "LookingForGroupRoleRestriction",
                column: "SessionId",
                principalTable: "LookingForGroupSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LookingForGroupSession_LookingForGroupSettings_GuildId",
                table: "LookingForGroupSession",
                column: "GuildId",
                principalTable: "LookingForGroupSettings",
                principalColumn: "GuildId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
