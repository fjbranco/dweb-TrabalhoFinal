using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dweb_TrabalhoFinal.Data.Migrations
{
    /// <inheritdoc />
    public partial class correcaoCriacaoModeloDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilhetes_Cliente_ClienteBilheteId",
                table: "Bilhetes");

            migrationBuilder.DropForeignKey(
                name: "FK_Bilhetes_Sessao_SessaoBilheteId",
                table: "Bilhetes");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Genero_ListOfGeneroId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filmes_FilmeSessaoId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Salas_SalaSessaoId",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Sessao",
                newName: "Sessoes");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_Sessao_SalaSessaoId",
                table: "Sessoes",
                newName: "IX_Sessoes_SalaSessaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessao_FilmeSessaoId",
                table: "Sessoes",
                newName: "IX_Sessoes_FilmeSessaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilhetes_Clientes_ClienteBilheteId",
                table: "Bilhetes",
                column: "ClienteBilheteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bilhetes_Sessoes_SessaoBilheteId",
                table: "Bilhetes",
                column: "SessaoBilheteId",
                principalTable: "Sessoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Generos_ListOfGeneroId",
                table: "FilmeGenero",
                column: "ListOfGeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeSessaoId",
                table: "Sessoes",
                column: "FilmeSessaoId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Salas_SalaSessaoId",
                table: "Sessoes",
                column: "SalaSessaoId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilhetes_Clientes_ClienteBilheteId",
                table: "Bilhetes");

            migrationBuilder.DropForeignKey(
                name: "FK_Bilhetes_Sessoes_SessaoBilheteId",
                table: "Bilhetes");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Generos_ListOfGeneroId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeSessaoId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Salas_SalaSessaoId",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Sessoes",
                newName: "Sessao");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_SalaSessaoId",
                table: "Sessao",
                newName: "IX_Sessao_SalaSessaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_FilmeSessaoId",
                table: "Sessao",
                newName: "IX_Sessao_FilmeSessaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilhetes_Cliente_ClienteBilheteId",
                table: "Bilhetes",
                column: "ClienteBilheteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bilhetes_Sessao_SessaoBilheteId",
                table: "Bilhetes",
                column: "SessaoBilheteId",
                principalTable: "Sessao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Genero_ListOfGeneroId",
                table: "FilmeGenero",
                column: "ListOfGeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filmes_FilmeSessaoId",
                table: "Sessao",
                column: "FilmeSessaoId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Salas_SalaSessaoId",
                table: "Sessao",
                column: "SalaSessaoId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
