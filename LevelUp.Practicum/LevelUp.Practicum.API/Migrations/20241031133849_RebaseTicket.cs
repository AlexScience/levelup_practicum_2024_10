using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevelUp.Practicum.API.Migrations
{
    /// <inheritdoc />
    public partial class RebaseTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ticket",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "ticket",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ticket_VehicleId",
                table: "ticket",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_vehicle_VehicleId",
                table: "ticket",
                column: "VehicleId",
                principalTable: "vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_vehicle_VehicleId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_VehicleId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "ticket");
        }
    }
}
