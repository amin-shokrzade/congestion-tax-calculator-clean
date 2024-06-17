using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    partial class CongestionTaxCalculatorTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
               name: "VehicleTypes",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                   SortOrder = table.Column<int>(type: "int", nullable: false),
                   CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   Deleted = table.Column<bool>(type: "bit", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_VehicleTypes", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Vehicles",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                   PlateNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                   VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   Deleted = table.Column<bool>(type: "bit", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Vehicles", x => x.Id);

                   table.ForeignKey(
                   name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                   column: x => x.VehicleTypeId,
                   principalTable: "VehicleTypes",
                   principalColumn: "Id");
               });

            migrationBuilder.CreateTable(
               name: "Cities",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                   MaxDailyTax = table.Column<int>(type: "int", nullable: false),
                   SingleChargeRuleTimeInMinute = table.Column<int>(type: "int", nullable: false),
                   TaxFreeWeekDays = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                   TaxFreeMonths = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                   CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   Deleted = table.Column<bool>(type: "bit", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Cities", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "TaxFreeDates",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   FreeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   Deleted = table.Column<bool>(type: "bit", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_TaxFreeDates", x => x.Id);

                   table.ForeignKey(
                   name: "FK_TaxFreeDates_Cities_CityId",
                   column: x => x.CityId,
                   principalTable: "Cities",
                   principalColumn: "Id");
               }
               );

            migrationBuilder.CreateTable(
               name: "TaxFreeVehicles",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   Deleted = table.Column<bool>(type: "bit", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_TaxFreeVehicles", x => x.Id);

                   table.ForeignKey(
                   name: "FK_TaxFreeVehicles_Cities_CityId",
                   column: x => x.CityId,
                   principalTable: "Cities",
                   principalColumn: "Id");

                   table.ForeignKey(
                   name: "FK_TaxFreeVehicles_VehicleTypes_VehicleTypeId",
                   column: x => x.VehicleTypeId,
                   principalTable: "VehicleTypes",
                   principalColumn: "Id");
               });

            migrationBuilder.CreateTable(
               name: "TimeAndTaxAmounts",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   From = table.Column<TimeSpan>(type: "time", nullable: false),
                   To = table.Column<TimeSpan>(type: "time", nullable: false),
                   Amount = table.Column<int>(type: "int", nullable: false),
                   CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                   Deleted = table.Column<bool>(type: "bit", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_TimeAndTaxAmounts", x => x.Id);

                   table.ForeignKey(
                   name: "FK_TimeAndTaxAmounts_Cities_CityId",
                   column: x => x.CityId,
                   principalTable: "Cities",
                   principalColumn: "Id");
               });


            migrationBuilder.CreateIndex(
               name: "IX_Vehicles_VehicleTypeId",
               table: "Vehicles",
               column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
               name: "IX_TaxFreeDates_CityId",
               table: "TaxFreeDates",
               column: "CityId");

            migrationBuilder.CreateIndex(
               name: "IX_TaxFreeVehicles_CityId",
               table: "TaxFreeVehicles",
               column: "CityId");

            migrationBuilder.CreateIndex(
               name: "IX_TaxFreeVehicles_VehicleTypeId",
               table: "TaxFreeVehicles",
               column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
               name: "IX_TimeAndTaxAmounts_CityId",
               table: "TimeAndTaxAmounts",
               column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Cities");

            migrationBuilder.DropTable(
              name: "TaxFreeDates");

            migrationBuilder.DropTable(
              name: "TaxFreeVehicles");

            migrationBuilder.DropTable(
              name: "TimeAndTaxAmounts");

            migrationBuilder.DropTable(
              name: "Vehicles");

            migrationBuilder.DropTable(
              name: "VehicleTypes");
        }
    }
}
