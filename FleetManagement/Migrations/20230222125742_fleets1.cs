using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement.Migrations
{
    /// <inheritdoc />
    public partial class fleets1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddOnMaster",
                columns: table => new
                {
                    AddOnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddOnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddOnDailyRate = table.Column<double>(type: "float", nullable: true),
                    RateValidUpto = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOnMaster", x => x.AddOnId);
                });

            migrationBuilder.CreateTable(
                name: "CarTypeMaster",
                columns: table => new
                {
                    CarTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyRate = table.Column<double>(type: "float", nullable: true),
                    WeeklyRate = table.Column<double>(type: "float", nullable: true),
                    MonthRate = table.Column<double>(type: "float", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypeMaster", x => x.CarTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StateMaster",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMaster", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    BookingDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    AddOnId = table.Column<int>(type: "int", nullable: true),
                    AddOnRate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => x.BookingDetailId);
                    table.ForeignKey(
                        name: "FK_BookingDetail_AddOnMaster_AddOnId",
                        column: x => x.AddOnId,
                        principalTable: "AddOnMaster",
                        principalColumn: "AddOnId");
                });

            migrationBuilder.CreateTable(
                name: "CityMaster",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMaster", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityMaster_StateMaster_StateId",
                        column: x => x.StateId,
                        principalTable: "StateMaster",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNum = table.Column<long>(type: "bigint", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    AdhaarCardNum = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_CityMaster_CityId",
                        column: x => x.CityId,
                        principalTable: "CityMaster",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "HubMaster",
                columns: table => new
                {
                    HubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HubAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubMaster", x => x.HubId);
                    table.ForeignKey(
                        name: "FK_HubMaster_CityMaster_CityId",
                        column: x => x.CityId,
                        principalTable: "CityMaster",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_HubMaster_StateMaster_StateId",
                        column: x => x.StateId,
                        principalTable: "StateMaster",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "BookingHeader",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHeader", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingHeader_CarTypeMaster_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarTypeMaster",
                        principalColumn: "CarTypeId");
                    table.ForeignKey(
                        name: "FK_BookingHeader_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "AirportMaster",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    HubId = table.Column<int>(type: "int", nullable: true),
                    AirportCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportMaster", x => x.AirportId);
                    table.ForeignKey(
                        name: "FK_AirportMaster_CityMaster_CityId",
                        column: x => x.CityId,
                        principalTable: "CityMaster",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_AirportMaster_HubMaster_HubId",
                        column: x => x.HubId,
                        principalTable: "HubMaster",
                        principalColumn: "HubId");
                    table.ForeignKey(
                        name: "FK_AirportMaster_StateMaster_StateId",
                        column: x => x.StateId,
                        principalTable: "StateMaster",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "CarMaster",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartypeId = table.Column<int>(type: "int", nullable: true),
                    HubId = table.Column<int>(type: "int", nullable: true),
                    CarDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceDueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMaster", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_CarMaster_CarTypeMaster_CartypeId",
                        column: x => x.CartypeId,
                        principalTable: "CarTypeMaster",
                        principalColumn: "CarTypeId");
                    table.ForeignKey(
                        name: "FK_CarMaster_HubMaster_HubId",
                        column: x => x.HubId,
                        principalTable: "HubMaster",
                        principalColumn: "HubId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeader",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    Odate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    HandoverDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentalAmount = table.Column<double>(type: "float", nullable: true),
                    TotalAddOnAmount = table.Column<double>(type: "float", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
                    CustomerDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeader", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_BookingHeader_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingHeader",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_CarMaster_CarId",
                        column: x => x.CarId,
                        principalTable: "CarMaster",
                        principalColumn: "CarId");
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    AddOnId = table.Column<int>(type: "int", nullable: true),
                    AddOnAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_AddOnMaster_AddOnId",
                        column: x => x.AddOnId,
                        principalTable: "AddOnMaster",
                        principalColumn: "AddOnId");
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_InvoiceHeader_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceHeader",
                        principalColumn: "InvoiceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportMaster_CityId",
                table: "AirportMaster",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportMaster_HubId",
                table: "AirportMaster",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportMaster_StateId",
                table: "AirportMaster",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_AddOnId",
                table: "BookingDetail",
                column: "AddOnId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_CarTypeId",
                table: "BookingHeader",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_CustomerId",
                table: "BookingHeader",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarMaster_CartypeId",
                table: "CarMaster",
                column: "CartypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarMaster_HubId",
                table: "CarMaster",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_CityMaster_StateId",
                table: "CityMaster",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HubMaster_CityId",
                table: "HubMaster",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HubMaster_StateId",
                table: "HubMaster",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_AddOnId",
                table: "InvoiceDetail",
                column: "AddOnId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_BookingId",
                table: "InvoiceHeader",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_CarId",
                table: "InvoiceHeader",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_CustomerId",
                table: "InvoiceHeader",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportMaster");

            migrationBuilder.DropTable(
                name: "BookingDetail");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "AddOnMaster");

            migrationBuilder.DropTable(
                name: "InvoiceHeader");

            migrationBuilder.DropTable(
                name: "BookingHeader");

            migrationBuilder.DropTable(
                name: "CarMaster");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CarTypeMaster");

            migrationBuilder.DropTable(
                name: "HubMaster");

            migrationBuilder.DropTable(
                name: "CityMaster");

            migrationBuilder.DropTable(
                name: "StateMaster");
        }
    }
}
