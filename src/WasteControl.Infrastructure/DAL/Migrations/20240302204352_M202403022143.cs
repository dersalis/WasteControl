using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteControl.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class M202403022143 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WasteExports_TransportCompanyId",
                table: "WasteExports",
                column: "TransportCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteExports_TransportCompanies_TransportCompanyId",
                table: "WasteExports",
                column: "TransportCompanyId",
                principalTable: "TransportCompanies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteExports_TransportCompanies_TransportCompanyId",
                table: "WasteExports");

            migrationBuilder.DropIndex(
                name: "IX_WasteExports_TransportCompanyId",
                table: "WasteExports");
        }
    }
}
