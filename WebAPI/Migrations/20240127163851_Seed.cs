using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cluster",
                columns: new[] { "ID", "Denominazione" },
                values: new object[] { 1L, "ASD" });

            migrationBuilder.InsertData(
                table: "ClusterStrutture",
                columns: new[] { "ID", "IDCluster", "IDStruttura", "Ordine" },
                values: new object[,]
                {
                    { 1L, 1L, 20L, 0L },
                    { 2L, 1L, 34L, 0L }
                });

            migrationBuilder.InsertData(
                table: "ClusterUtenti",
                columns: new[] { "ID", "IDCluster", "IDUtente" },
                values: new object[] { 1L, 1L, 18L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClusterStrutture",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ClusterStrutture",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ClusterUtenti",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cluster",
                keyColumn: "ID",
                keyValue: 1L);
        }
    }
}
