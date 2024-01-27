using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cluster",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denominazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cluster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClusterStrutture",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCluster = table.Column<long>(type: "bigint", nullable: false),
                    IDStruttura = table.Column<long>(type: "bigint", nullable: false),
                    Ordine = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterStrutture", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClusterStrutture_Cluster",
                        column: x => x.IDCluster,
                        principalTable: "Cluster",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ClusterUtenti",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCluster = table.Column<long>(type: "bigint", nullable: false),
                    IDUtente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterUtenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClusterUtenti_Cluster",
                        column: x => x.IDCluster,
                        principalTable: "Cluster",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClusterStrutture_IDCluster",
                table: "ClusterStrutture",
                column: "IDCluster");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterUtenti_IDCluster",
                table: "ClusterUtenti",
                column: "IDCluster");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClusterStrutture");

            migrationBuilder.DropTable(
                name: "ClusterUtenti");

            migrationBuilder.DropTable(
                name: "Cluster");
        }
    }
}
