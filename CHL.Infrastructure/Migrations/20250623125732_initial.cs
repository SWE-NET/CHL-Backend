using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<string>(type: "text", nullable: false),
                    nation = table.Column<string>(type: "text", nullable: false),
                    logo = table.Column<string>(type: "text", nullable: false),
                    instagram = table.Column<string>(type: "text", nullable: false),
                    twitter = table.Column<string>(type: "text", nullable: false),
                    prezident = table.Column<string>(type: "text", nullable: false),
                    overall_score = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    img = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<string>(type: "text", nullable: false),
                    nation = table.Column<string>(type: "text", nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    img = table.Column<string>(type: "text", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.id);
                    table.ForeignKey(
                        name: "FK_Coaches_Clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "Clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<int>(type: "integer", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    img = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<string>(type: "text", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.id);
                    table.ForeignKey(
                        name: "FK_Stadiums_Clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "Clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    goals = table.Column<string>(type: "text", nullable: false),
                    coach_id = table.Column<Guid>(type: "uuid", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teams_Clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "Clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Coaches_coach_id",
                        column: x => x.coach_id,
                        principalTable: "Coaches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    minutes_added = table.Column<int>(type: "integer", nullable: false),
                    club1_id = table.Column<Guid>(type: "uuid", nullable: false),
                    club2_id = table.Column<Guid>(type: "uuid", nullable: false),
                    team1_id = table.Column<Guid>(type: "uuid", nullable: true),
                    team2_id = table.Column<Guid>(type: "uuid", nullable: true),
                    referee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    stadium_id = table.Column<Guid>(type: "uuid", nullable: false),
                    coach_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                    table.ForeignKey(
                        name: "FK_Games_Clubs_club1_id",
                        column: x => x.club1_id,
                        principalTable: "Clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Clubs_club2_id",
                        column: x => x.club2_id,
                        principalTable: "Clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Coaches_coach_id",
                        column: x => x.coach_id,
                        principalTable: "Coaches",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Games_Referees_referee_id",
                        column: x => x.referee_id,
                        principalTable: "Referees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Stadiums_stadium_id",
                        column: x => x.stadium_id,
                        principalTable: "Stadiums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_team1_id",
                        column: x => x.team1_id,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_team2_id",
                        column: x => x.team2_id,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    red_cards = table.Column<int>(type: "integer", nullable: false),
                    yellow_cards = table.Column<int>(type: "integer", nullable: false),
                    img = table.Column<string>(type: "text", nullable: false),
                    overall_goals = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<string>(type: "text", nullable: false),
                    is_injured = table.Column<bool>(type: "boolean", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: false),
                    team_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                    table.ForeignKey(
                        name: "FK_Players_Clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "Clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Games_game_id",
                        column: x => x.game_id,
                        principalTable: "Games",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Players_Teams_team_id",
                        column: x => x.team_id,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    img = table.Column<string>(type: "text", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: true),
                    player_id = table.Column<Guid>(type: "uuid", nullable: false),
                    coach_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    referee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    stadium_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                    table.ForeignKey(
                        name: "FK_News_Clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "Clubs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Coaches_coach_id",
                        column: x => x.coach_id,
                        principalTable: "Coaches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Games_game_id",
                        column: x => x.game_id,
                        principalTable: "Games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Players_player_id",
                        column: x => x.player_id,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Referees_referee_id",
                        column: x => x.referee_id,
                        principalTable: "Referees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Stadiums_stadium_id",
                        column: x => x.stadium_id,
                        principalTable: "Stadiums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    img = table.Column<string>(type: "text", nullable: false),
                    game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Scenes_Games_game_id",
                        column: x => x.game_id,
                        principalTable: "Games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_Players_player_id",
                        column: x => x.player_id,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_club_id",
                table: "Coaches",
                column: "club_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_club1_id",
                table: "Games",
                column: "club1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_club2_id",
                table: "Games",
                column: "club2_id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_coach_id",
                table: "Games",
                column: "coach_id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_referee_id",
                table: "Games",
                column: "referee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_stadium_id",
                table: "Games",
                column: "stadium_id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_team1_id",
                table: "Games",
                column: "team1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_team2_id",
                table: "Games",
                column: "team2_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_club_id",
                table: "News",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_coach_id",
                table: "News",
                column: "coach_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_game_id",
                table: "News",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_player_id",
                table: "News",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_referee_id",
                table: "News",
                column: "referee_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_stadium_id",
                table: "News",
                column: "stadium_id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_club_id",
                table: "Players",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_game_id",
                table: "Players",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_team_id",
                table: "Players",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_game_id",
                table: "Scenes",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_player_id",
                table: "Scenes",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_club_id",
                table: "Stadiums",
                column: "club_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_club_id",
                table: "Teams",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_coach_id",
                table: "Teams",
                column: "coach_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Referees");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
