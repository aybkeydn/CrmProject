using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Most_Crm.Migrations
{
    /// <inheritdoc />
    public partial class AddContactPersonToOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactPersonID",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ContactPersonID",
                table: "Offers",
                column: "ContactPersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ContactPeople_ContactPersonID",
                table: "Offers",
                column: "ContactPersonID",
                principalTable: "ContactPeople",
                principalColumn: "ContactPersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ContactPeople_ContactPersonID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ContactPersonID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContactPersonID",
                table: "Offers");
        }
    }
}
