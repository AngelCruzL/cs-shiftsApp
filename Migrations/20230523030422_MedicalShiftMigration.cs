using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shifts.Migrations
{
    /// <inheritdoc />
    public partial class MedicalShiftMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatient = table.Column<int>(type: "int", unicode: false, nullable: false),
                    IdMedic = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ScheduleFrom = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    ScheduleUntil = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalShift_Medic_IdMedic",
                        column: x => x.IdMedic,
                        principalTable: "Medic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalShift_Patients_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalShift_IdMedic",
                table: "MedicalShift",
                column: "IdMedic");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalShift_IdPatient",
                table: "MedicalShift",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalShift");
        }
    }
}
