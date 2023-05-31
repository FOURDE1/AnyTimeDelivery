using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySite.Migrations
{
    /// <inheritdoc />
    public partial class AddingDeliveryToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Orders");
        }
    }
}
