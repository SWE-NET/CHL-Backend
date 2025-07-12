using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newsupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Clubs_club_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Coaches_coach_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Games_game_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Players_player_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Referees_referee_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Stadiums_stadium_id",
                table: "News");

            migrationBuilder.AlterColumn<Guid>(
                name: "stadium_id",
                table: "News",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "referee_id",
                table: "News",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "player_id",
                table: "News",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "game_id",
                table: "News",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "coach_id",
                table: "News",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Clubs_club_id",
                table: "News",
                column: "club_id",
                principalTable: "Clubs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Coaches_coach_id",
                table: "News",
                column: "coach_id",
                principalTable: "Coaches",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Games_game_id",
                table: "News",
                column: "game_id",
                principalTable: "Games",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Players_player_id",
                table: "News",
                column: "player_id",
                principalTable: "Players",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Referees_referee_id",
                table: "News",
                column: "referee_id",
                principalTable: "Referees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Stadiums_stadium_id",
                table: "News",
                column: "stadium_id",
                principalTable: "Stadiums",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Clubs_club_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Coaches_coach_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Games_game_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Players_player_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Referees_referee_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Stadiums_stadium_id",
                table: "News");

            migrationBuilder.AlterColumn<Guid>(
                name: "stadium_id",
                table: "News",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "referee_id",
                table: "News",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "player_id",
                table: "News",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "game_id",
                table: "News",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "coach_id",
                table: "News",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Clubs_club_id",
                table: "News",
                column: "club_id",
                principalTable: "Clubs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Coaches_coach_id",
                table: "News",
                column: "coach_id",
                principalTable: "Coaches",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Games_game_id",
                table: "News",
                column: "game_id",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Players_player_id",
                table: "News",
                column: "player_id",
                principalTable: "Players",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Referees_referee_id",
                table: "News",
                column: "referee_id",
                principalTable: "Referees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Stadiums_stadium_id",
                table: "News",
                column: "stadium_id",
                principalTable: "Stadiums",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
