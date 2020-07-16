using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace R_PROPERTY.Migrations
{
    public partial class rent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "property_details",
                columns: table => new
                {
                    property_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    property_name = table.Column<string>(nullable: true),
                    property_type = table.Column<string>(nullable: true),
                    property_address = table.Column<string>(nullable: true),
                    property_value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_details", x => x.property_id);
                });

            migrationBuilder.CreateTable(
                name: "user_details",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(nullable: true),
                    user_phone_number = table.Column<string>(nullable: true),
                    user_address = table.Column<string>(nullable: true),
                    user_email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_details", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "wishlist",
                columns: table => new
                {
                    wishlist_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    property_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishlist", x => x.wishlist_id);
                });

            migrationBuilder.CreateTable(
                name: "inquiry",
                columns: table => new
                {
                    inquiry_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    user_detailsuser_id = table.Column<int>(nullable: true),
                    property_id = table.Column<int>(nullable: false),
                    property_Detailsproperty_id = table.Column<int>(nullable: true),
                    user_massege = table.Column<string>(nullable: true),
                    dateTime_inquiry = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inquiry", x => x.inquiry_id);
                    table.ForeignKey(
                        name: "FK_inquiry_property_details_property_Detailsproperty_id",
                        column: x => x.property_Detailsproperty_id,
                        principalTable: "property_details",
                        principalColumn: "property_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inquiry_user_details_user_detailsuser_id",
                        column: x => x.user_detailsuser_id,
                        principalTable: "user_details",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inquiry_property_Detailsproperty_id",
                table: "inquiry",
                column: "property_Detailsproperty_id");

            migrationBuilder.CreateIndex(
                name: "IX_inquiry_user_detailsuser_id",
                table: "inquiry",
                column: "user_detailsuser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inquiry");

            migrationBuilder.DropTable(
                name: "wishlist");

            migrationBuilder.DropTable(
                name: "property_details");

            migrationBuilder.DropTable(
                name: "user_details");
        }
    }
}
