using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ReCommerce.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rua = table.Column<string>(nullable: true),
                    Residencia = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    preco = table.Column<double>(nullable: false),
                    marca = table.Column<string>(nullable: true),
                    tempoDeUso = table.Column<double>(nullable: false),
                    qtdEstoque = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Troca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutosUsuarioUmId = table.Column<int>(nullable: false),
                    ProdutosUsuarioDoisId = table.Column<int>(nullable: false),
                    dia = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    UsuarioUmId = table.Column<int>(nullable: false),
                    UsuarioDoisId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Troca_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Troca_Produto_ProdutosUsuarioDoisId",
                        column: x => x.ProdutosUsuarioDoisId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Troca_Produto_ProdutosUsuarioUmId",
                        column: x => x.ProdutosUsuarioUmId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Troca_Usuario_UsuarioDoisId",
                        column: x => x.UsuarioDoisId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Troca_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Troca_Usuario_UsuarioUmId",
                        column: x => x.UsuarioUmId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEndereco",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEndereco", x => new { x.UsuarioId, x.EnderecoId });
                    table.ForeignKey(
                        name: "FK_UsuarioEndereco_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEndereco_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProduto",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProduto", x => new { x.UsuarioId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_UsuarioProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioProduto_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Troca_ProdutoId",
                table: "Troca",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Troca_ProdutosUsuarioDoisId",
                table: "Troca",
                column: "ProdutosUsuarioDoisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Troca_ProdutosUsuarioUmId",
                table: "Troca",
                column: "ProdutosUsuarioUmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Troca_UsuarioDoisId",
                table: "Troca",
                column: "UsuarioDoisId");

            migrationBuilder.CreateIndex(
                name: "IX_Troca_UsuarioId",
                table: "Troca",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Troca_UsuarioUmId",
                table: "Troca",
                column: "UsuarioUmId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEndereco_EnderecoId",
                table: "UsuarioEndereco",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProduto_ProdutoId",
                table: "UsuarioProduto",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Troca");

            migrationBuilder.DropTable(
                name: "UsuarioEndereco");

            migrationBuilder.DropTable(
                name: "UsuarioProduto");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
