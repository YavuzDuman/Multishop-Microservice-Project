using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Cargo.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceiverCustomer",
                table: "CargoDetails",
                newName: "ReceiverCustomerId");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "CargoCompanies",
                newName: "CargoCompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceiverCustomerId",
                table: "CargoDetails",
                newName: "ReceiverCustomer");

            migrationBuilder.RenameColumn(
                name: "CargoCompanyName",
                table: "CargoCompanies",
                newName: "CompanyName");
        }
    }
}
