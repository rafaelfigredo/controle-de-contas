using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ControleContas.Infra.Data.Migrations
{
    public partial class PrimeiraParcela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrimeiraParcela",
                table: "Lancamentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPrimeiraParcela",
                table: "Lancamentos");
        }
    }
}
