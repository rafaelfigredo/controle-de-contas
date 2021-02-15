using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ControleContas.Infra.Data.Migrations
{
    public partial class TabelasControleContas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ContasTiposId = table.Column<int>(type: "integer", nullable: false),
                    Cor = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    VencimentoDia = table.Column<int>(type: "integer", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_ContasTipos_ContasTiposId",
                        column: x => x.ContasTiposId,
                        principalTable: "ContasTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ParcelasTotal = table.Column<int>(type: "integer", nullable: false),
                    ContasId = table.Column<int>(type: "integer", nullable: false),
                    CategoriasId = table.Column<int>(type: "integer", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Contas_ContasId",
                        column: x => x.ContasId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParcelaNumero = table.Column<int>(type: "integer", nullable: false),
                    ParcelaValor = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    AnoCobranca = table.Column<int>(type: "integer", nullable: false),
                    MesCobranca = table.Column<int>(type: "integer", nullable: false),
                    LancamentosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Lancamentos_LancamentosId",
                        column: x => x.LancamentosId,
                        principalTable: "Lancamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ContasTiposId",
                table: "Contas",
                column: "ContasTiposId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_CategoriasId",
                table: "Lancamentos",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContasId",
                table: "Lancamentos",
                column: "ContasId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_LancamentosId",
                table: "Parcelas",
                column: "LancamentosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "ContasTipos");
        }
    }
}
