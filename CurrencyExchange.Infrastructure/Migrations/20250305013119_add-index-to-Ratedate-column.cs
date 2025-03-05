using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addindextoRatedatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_RateDate",
                table: "ExchangeRates",
                column: "RateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_RateDate",
                table: "ExchangeRates");
        }
    }
}
