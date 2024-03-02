using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteControl.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class M202403022205 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WasteExports_ReceivingCompanyId",
                table: "WasteExports",
                column: "ReceivingCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteExports_ReceivingCompanies_ReceivingCompanyId",
                table: "WasteExports",
                column: "ReceivingCompanyId",
                principalTable: "ReceivingCompanies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteExports_ReceivingCompanies_ReceivingCompanyId",
                table: "WasteExports");

            migrationBuilder.DropIndex(
                name: "IX_WasteExports_ReceivingCompanyId",
                table: "WasteExports");
        }
    }
}
