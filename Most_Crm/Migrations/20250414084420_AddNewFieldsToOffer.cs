using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Most_Crm.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Offers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Offers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OfferDate",
                table: "Offers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfferNumber",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceDetail",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status2",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferDate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferNumber",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ServiceDetail",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Status2",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Offers");
        }
    }
}
