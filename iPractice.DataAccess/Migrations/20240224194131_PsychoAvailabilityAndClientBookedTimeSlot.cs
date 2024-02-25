using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iPractice.DataAccess.Entity.Migrations
{
    public partial class PsychoAvailabilityAndClientBookedTimeSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPsychologist");

            migrationBuilder.CreateTable(
                name: "ClientEntityPsychologistEntity",
                columns: table => new
                {
                    ClientsId = table.Column<long>(type: "INTEGER", nullable: false),
                    PsychologistsId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientEntityPsychologistEntity", x => new { x.ClientsId, x.PsychologistsId });
                    table.ForeignKey(
                        name: "FK_ClientEntityPsychologistEntity_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientEntityPsychologistEntity_Psychologists_PsychologistsId",
                        column: x => x.PsychologistsId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientsBookedTimeSlots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    From = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    To = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    ClientId = table.Column<long>(type: "INTEGER", nullable: true),
                    PsychologistId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsBookedTimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientsBookedTimeSlots_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientsBookedTimeSlots_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistAvailabilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    From = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    To = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    PsychologistId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsychologistAvailabilities_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientEntityPsychologistEntity_PsychologistsId",
                table: "ClientEntityPsychologistEntity",
                column: "PsychologistsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsBookedTimeSlots_ClientId",
                table: "ClientsBookedTimeSlots",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsBookedTimeSlots_PsychologistId",
                table: "ClientsBookedTimeSlots",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistAvailabilities_PsychologistId",
                table: "PsychologistAvailabilities",
                column: "PsychologistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientEntityPsychologistEntity");

            migrationBuilder.DropTable(
                name: "ClientsBookedTimeSlots");

            migrationBuilder.DropTable(
                name: "PsychologistAvailabilities");

            migrationBuilder.CreateTable(
                name: "ClientPsychologist",
                columns: table => new
                {
                    ClientsId = table.Column<long>(type: "INTEGER", nullable: false),
                    PsychologistsId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPsychologist", x => new { x.ClientsId, x.PsychologistsId });
                    table.ForeignKey(
                        name: "FK_ClientPsychologist_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientPsychologist_Psychologists_PsychologistsId",
                        column: x => x.PsychologistsId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPsychologist_PsychologistsId",
                table: "ClientPsychologist",
                column: "PsychologistsId");
        }
    }
}
