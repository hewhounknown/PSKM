using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSKM.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSpecialistFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpecialistId",
                table: "Doctor",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "SpecialistId1",
                table: "Doctor",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecialistId1",
                table: "Doctor",
                column: "SpecialistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Specialist_SpecialistId1",
                table: "Doctor",
                column: "SpecialistId1",
                principalTable: "Specialist",
                principalColumn: "SpecialistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Specialist_SpecialistId1",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_SpecialistId1",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "SpecialistId1",
                table: "Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialistId",
                table: "Doctor",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
