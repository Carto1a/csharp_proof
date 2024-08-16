using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CancellationTokenProof.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: false),
                    HighScoreId = table.Column<int>(type: "int", nullable: true),
                    LastScoreId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_HighScoreId",
                table: "Players",
                column: "HighScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LastScoreId",
                table: "Players",
                column: "LastScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Scores_HighScoreId",
                table: "Players",
                column: "HighScoreId",
                principalTable: "Scores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Scores_LastScoreId",
                table: "Players",
                column: "LastScoreId",
                principalTable: "Scores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Scores_HighScoreId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Scores_LastScoreId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
