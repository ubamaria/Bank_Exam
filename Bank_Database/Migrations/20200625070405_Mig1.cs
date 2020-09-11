using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank_Database.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepositBindingModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(nullable: false),
                    ClientFIO = table.Column<string>(nullable: true),
                    SizeDeposit = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    TypeValue = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: true),
                    DateTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositBindingModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositBindingModel_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(nullable: false),
                    ClientFIO = table.Column<string>(nullable: true),
                    SizeDeposit = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    TypeValue = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: true),
                    DateTo = table.Column<DateTime>(nullable: true),
                    DepositId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_Banks_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositBindingModel_BankId",
                table: "DepositBindingModel",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_DepositId",
                table: "Deposits",
                column: "DepositId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositBindingModel");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
