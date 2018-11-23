using Microsoft.EntityFrameworkCore.Migrations;

namespace CarForm.Data.Migrations
{
    public partial class AddDataAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_CarMarks_CarMarkId",
                table: "CarModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "Models");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_CarMarkId",
                table: "Models",
                newName: "IX_Models_CarMarkId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarMarks",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_CarMarks_CarMarkId",
                table: "Models",
                column: "CarMarkId",
                principalTable: "CarMarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_CarMarks_CarMarkId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "CarModel");

            migrationBuilder.RenameIndex(
                name: "IX_Models_CarMarkId",
                table: "CarModel",
                newName: "IX_CarModel_CarMarkId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarMarks",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarModel",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_CarMarks_CarMarkId",
                table: "CarModel",
                column: "CarMarkId",
                principalTable: "CarMarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
