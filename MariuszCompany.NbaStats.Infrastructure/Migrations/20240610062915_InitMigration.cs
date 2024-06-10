using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MariuszCompany.NbaStats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntegrationProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    StartDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntegrationId = table.Column<int>(type: "int", nullable: false),
                    Conference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Division = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Full_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntegrationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postseason = table.Column<bool>(type: "bit", nullable: true),
                    Home_team_score = table.Column<int>(type: "int", nullable: true),
                    Visitor_team_score = table.Column<int>(type: "int", nullable: true),
                    HomeTeamIntegrationId = table.Column<int>(type: "int", nullable: true),
                    VisitorTeamIntegrationId = table.Column<int>(type: "int", nullable: true),
                    HomeTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VisitorTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Teams_VisitorTeamId",
                        column: x => x.VisitorTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntegrationId = table.Column<int>(type: "int", nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Jersey_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Draft_year = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    TeamIntegrationId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_VisitorTeamId",
                table: "Games",
                column: "VisitorTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Country",
                table: "Players",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Draft_year",
                table: "Players",
                column: "Draft_year");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "IntegrationProcesses");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
