using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PFinal.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MateriasPrimas",
                columns: table => new
                {
                    MateriaPrimaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasPrimas", x => x.MateriaPrimaId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeProducciones",
                columns: table => new
                {
                    OrdenDeProduccionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeProducciones", x => x.OrdenDeProduccionId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecetaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    RecetaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.RecetaId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenDeProduccion",
                columns: table => new
                {
                    DetelleOrdenDeProduccionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenDeProduccionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenDeProduccion", x => x.DetelleOrdenDeProduccionID);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenDeProduccion_OrdenDeProducciones_OrdenDeProduccionId",
                        column: x => x.OrdenDeProduccionId,
                        principalTable: "OrdenDeProducciones",
                        principalColumn: "OrdenDeProduccionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleRecetas",
                columns: table => new
                {
                    DetalleRecetaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecetaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MateriaPrimaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleRecetas", x => x.DetalleRecetaId);
                    table.ForeignKey(
                        name: "FK_DetalleRecetas_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "RecetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MateriasPrimas",
                columns: new[] { "MateriaPrimaId", "Descripcion", "Existencia", "Fecha", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "azucar", 100, new DateTime(2023, 4, 11, 12, 38, 4, 997, DateTimeKind.Local).AddTicks(6371), "morena", 50.0 },
                    { 2, "Harina", 100, new DateTime(2023, 4, 11, 12, 38, 4, 997, DateTimeKind.Local).AddTicks(6375), "Blanca", 50.0 },
                    { 3, "Elevadura", 100, new DateTime(2023, 4, 11, 12, 38, 4, 997, DateTimeKind.Local).AddTicks(6377), "no se", 50.0 },
                    { 4, "sal", 100, new DateTime(2023, 4, 11, 12, 38, 4, 997, DateTimeKind.Local).AddTicks(6378), "molida", 50.0 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Descripcion", "Existencia", "Fecha", "Nombre", "Precio", "RecetaId" },
                values: new object[,]
                {
                    { 1, "Dulce de leche", 100, new DateTime(2023, 4, 11, 12, 38, 4, 997, DateTimeKind.Local).AddTicks(6224), "Bizcocho", 500.0, 0 },
                    { 2, "De agua", 100, new DateTime(2023, 4, 11, 12, 38, 4, 997, DateTimeKind.Local).AddTicks(6236), "Pan", 50.0, 0 },
                    { 3, "De coco", 100, new DateTime(2023, 4, 11, 12, 38, 4, 997, DateTimeKind.Local).AddTicks(6238), "Galletas", 50.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenDeProduccion_OrdenDeProduccionId",
                table: "DetalleOrdenDeProduccion",
                column: "OrdenDeProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecetas_RecetaId",
                table: "DetalleRecetas",
                column: "RecetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrdenDeProduccion");

            migrationBuilder.DropTable(
                name: "DetalleRecetas");

            migrationBuilder.DropTable(
                name: "MateriasPrimas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "OrdenDeProducciones");

            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}
