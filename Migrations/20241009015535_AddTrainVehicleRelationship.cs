using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrensManager.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainVehicleRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vahicle_Train_TrainId",
                table: "Vahicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vahicle",
                table: "Vahicle");

            migrationBuilder.RenameTable(
                name: "Vahicle",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vahicle_TrainId",
                table: "Vehicle",
                newName: "IX_Vehicle_TrainId");

            migrationBuilder.AddColumn<string>(
                name: "VehicleCodes",
                table: "Train",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Train_TrainId",
                table: "Vehicle",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Train_TrainId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleCodes",
                table: "Train");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vahicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_TrainId",
                table: "Vahicle",
                newName: "IX_Vahicle_TrainId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vahicle",
                table: "Vahicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vahicle_Train_TrainId",
                table: "Vahicle",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id");
        }
    }
}
