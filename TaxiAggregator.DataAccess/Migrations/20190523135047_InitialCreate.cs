using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiAggregator.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatisticalData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    OriginLatitude = table.Column<double>(nullable: false),
                    OriginLongitude = table.Column<double>(nullable: false),
                    DestinationLatitude = table.Column<double>(nullable: false),
                    DestinationLongitude = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    TaxiService = table.Column<string>(nullable: true),
                    CarType = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    MinPrice = table.Column<int>(nullable: true),
                    MaxPrice = table.Column<int>(nullable: true),
                    SurgeMultiplier = table.Column<double>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatisticalData");
        }
    }
}
