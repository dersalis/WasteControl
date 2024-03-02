using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteControl.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class M202403022214 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Wastes_CreatedById",
                table: "Wastes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Wastes_ModifiedById",
                table: "Wastes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_WasteExports_CreatedById",
                table: "WasteExports",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WasteExports_ModifiedById",
                table: "WasteExports",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCompanies_CreatedById",
                table: "TransportCompanies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCompanies_ModifiedById",
                table: "TransportCompanies",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingCompanies_CreatedById",
                table: "ReceivingCompanies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingCompanies_ModifiedById",
                table: "ReceivingCompanies",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingCompanies_Users_CreatedById",
                table: "ReceivingCompanies",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingCompanies_Users_ModifiedById",
                table: "ReceivingCompanies",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCompanies_Users_CreatedById",
                table: "TransportCompanies",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCompanies_Users_ModifiedById",
                table: "TransportCompanies",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteExports_Users_CreatedById",
                table: "WasteExports",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteExports_Users_ModifiedById",
                table: "WasteExports",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wastes_Users_CreatedById",
                table: "Wastes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wastes_Users_ModifiedById",
                table: "Wastes",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingCompanies_Users_CreatedById",
                table: "ReceivingCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingCompanies_Users_ModifiedById",
                table: "ReceivingCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportCompanies_Users_CreatedById",
                table: "TransportCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportCompanies_Users_ModifiedById",
                table: "TransportCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ModifiedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WasteExports_Users_CreatedById",
                table: "WasteExports");

            migrationBuilder.DropForeignKey(
                name: "FK_WasteExports_Users_ModifiedById",
                table: "WasteExports");

            migrationBuilder.DropForeignKey(
                name: "FK_Wastes_Users_CreatedById",
                table: "Wastes");

            migrationBuilder.DropForeignKey(
                name: "FK_Wastes_Users_ModifiedById",
                table: "Wastes");

            migrationBuilder.DropIndex(
                name: "IX_Wastes_CreatedById",
                table: "Wastes");

            migrationBuilder.DropIndex(
                name: "IX_Wastes_ModifiedById",
                table: "Wastes");

            migrationBuilder.DropIndex(
                name: "IX_WasteExports_CreatedById",
                table: "WasteExports");

            migrationBuilder.DropIndex(
                name: "IX_WasteExports_ModifiedById",
                table: "WasteExports");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ModifiedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TransportCompanies_CreatedById",
                table: "TransportCompanies");

            migrationBuilder.DropIndex(
                name: "IX_TransportCompanies_ModifiedById",
                table: "TransportCompanies");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingCompanies_CreatedById",
                table: "ReceivingCompanies");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingCompanies_ModifiedById",
                table: "ReceivingCompanies");
        }
    }
}
