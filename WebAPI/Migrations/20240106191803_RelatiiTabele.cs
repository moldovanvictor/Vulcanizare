using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class RelatiiTabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TireHotel_UserId",
                table: "TireHotel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_AppointmentId",
                table: "CartItem",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_TireId",
                table: "CartItem",
                column: "TireId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TireId",
                table: "Appointment",
                column: "TireId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Tire_TireId",
                table: "Appointment",
                column: "TireId",
                principalTable: "Tire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_User_UserId",
                table: "Appointment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Appointment_AppointmentId",
                table: "CartItem",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Tire_TireId",
                table: "CartItem",
                column: "TireId",
                principalTable: "Tire",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TireHotel_User_UserId",
                table: "TireHotel",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Tire_TireId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_User_UserId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Appointment_AppointmentId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Tire_TireId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TireHotel_User_UserId",
                table: "TireHotel");

            migrationBuilder.DropIndex(
                name: "IX_TireHotel_UserId",
                table: "TireHotel");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_AppointmentId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_TireId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_TireId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment");
        }
    }
}
