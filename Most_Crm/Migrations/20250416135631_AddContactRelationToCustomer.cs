using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Most_Crm.Migrations
{
    /// <inheritdoc />
    public partial class AddContactRelationToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactPeople",
                columns: table => new
                {
                    ContactPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ContactPersonID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPeople", x => x.ContactPersonID);
                    table.ForeignKey(
                        name: "FK_ContactPeople_ContactPeople_ContactPersonID1",
                        column: x => x.ContactPersonID1,
                        principalTable: "ContactPeople",
                        principalColumn: "ContactPersonID");
                    table.ForeignKey(
                        name: "FK_ContactPeople_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPeople_ContactPersonID1",
                table: "ContactPeople",
                column: "ContactPersonID1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPeople_CustomerID",
                table: "ContactPeople",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactPeople");
        }
    }
}
