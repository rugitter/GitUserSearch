using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GitUserSearch.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GitHubUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Followers = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitHubUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSearch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSearch_GitHubUser_UserId",
                        column: x => x.UserId,
                        principalTable: "GitHubUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSearch_UserId",
                table: "UserSearch",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSearch");

            migrationBuilder.DropTable(
                name: "GitHubUser");
        }
    }
}
