using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shifts.Migrations
{
    /// <inheritdoc />
    public partial class MedicMedicalSpecialityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicMedicalSpeciality",
                columns: table => new
                {
                    IdMedic = table.Column<int>(type: "int", nullable: false),
                    IdMedicalSpeciality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicMedicalSpeciality", x => new { x.IdMedic, x.IdMedicalSpeciality });
                    table.ForeignKey(
                        name: "FK_MedicMedicalSpeciality_Medic_IdMedic",
                        column: x => x.IdMedic,
                        principalTable: "Medic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicMedicalSpeciality_MedicalSpecialities_IdMedicalSpeciality",
                        column: x => x.IdMedicalSpeciality,
                        principalTable: "MedicalSpecialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicMedicalSpeciality_IdMedicalSpeciality",
                table: "MedicMedicalSpeciality",
                column: "IdMedicalSpeciality");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicMedicalSpeciality");
        }
    }
}
