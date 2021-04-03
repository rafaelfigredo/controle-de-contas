using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleContas.Infra.Data.Migrations.UsersDb
{
    public partial class AlterarIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioToken",
                table: "UsuarioToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioPapel",
                table: "UsuarioPapel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PapelClaim",
                table: "PapelClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Papeis",
                table: "Papeis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logins",
                table: "Logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claims",
                table: "Claims");

            migrationBuilder.RenameTable(
                name: "UsuarioToken",
                newName: "ASpNetIdUsuarioToken");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "ASpNetIdUsuarios");

            migrationBuilder.RenameTable(
                name: "UsuarioPapel",
                newName: "ASpNetIdUsuarioPapel");

            migrationBuilder.RenameTable(
                name: "PapelClaim",
                newName: "ASpNetIdPapelClaim");

            migrationBuilder.RenameTable(
                name: "Papeis",
                newName: "ASpNetIdPapeis");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "ASpNetIdLogins");

            migrationBuilder.RenameTable(
                name: "Claims",
                newName: "ASpNetIdClaims");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioPapel_RoleId",
                table: "ASpNetIdUsuarioPapel",
                newName: "IX_ASpNetIdUsuarioPapel_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PapelClaim_RoleId",
                table: "ASpNetIdPapelClaim",
                newName: "IX_ASpNetIdPapelClaim_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Logins_UserId",
                table: "ASpNetIdLogins",
                newName: "IX_ASpNetIdLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Claims_UserId",
                table: "ASpNetIdClaims",
                newName: "IX_ASpNetIdClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASpNetIdUsuarioToken",
                table: "ASpNetIdUsuarioToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASpNetIdUsuarios",
                table: "ASpNetIdUsuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASpNetIdUsuarioPapel",
                table: "ASpNetIdUsuarioPapel",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASpNetIdPapelClaim",
                table: "ASpNetIdPapelClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASpNetIdPapeis",
                table: "ASpNetIdPapeis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASpNetIdLogins",
                table: "ASpNetIdLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ASpNetIdClaims",
                table: "ASpNetIdClaims",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ASpNetIdUsuarioToken",
                table: "ASpNetIdUsuarioToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASpNetIdUsuarios",
                table: "ASpNetIdUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASpNetIdUsuarioPapel",
                table: "ASpNetIdUsuarioPapel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASpNetIdPapelClaim",
                table: "ASpNetIdPapelClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASpNetIdPapeis",
                table: "ASpNetIdPapeis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASpNetIdLogins",
                table: "ASpNetIdLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ASpNetIdClaims",
                table: "ASpNetIdClaims");

            migrationBuilder.RenameTable(
                name: "ASpNetIdUsuarioToken",
                newName: "UsuarioToken");

            migrationBuilder.RenameTable(
                name: "ASpNetIdUsuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "ASpNetIdUsuarioPapel",
                newName: "UsuarioPapel");

            migrationBuilder.RenameTable(
                name: "ASpNetIdPapelClaim",
                newName: "PapelClaim");

            migrationBuilder.RenameTable(
                name: "ASpNetIdPapeis",
                newName: "Papeis");

            migrationBuilder.RenameTable(
                name: "ASpNetIdLogins",
                newName: "Logins");

            migrationBuilder.RenameTable(
                name: "ASpNetIdClaims",
                newName: "Claims");

            migrationBuilder.RenameIndex(
                name: "IX_ASpNetIdUsuarioPapel_RoleId",
                table: "UsuarioPapel",
                newName: "IX_UsuarioPapel_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ASpNetIdPapelClaim_RoleId",
                table: "PapelClaim",
                newName: "IX_PapelClaim_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ASpNetIdLogins_UserId",
                table: "Logins",
                newName: "IX_Logins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ASpNetIdClaims_UserId",
                table: "Claims",
                newName: "IX_Claims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioToken",
                table: "UsuarioToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioPapel",
                table: "UsuarioPapel",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PapelClaim",
                table: "PapelClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Papeis",
                table: "Papeis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logins",
                table: "Logins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claims",
                table: "Claims",
                column: "Id");
        }
    }
}
