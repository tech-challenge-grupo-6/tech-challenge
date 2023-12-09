using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControladorPedidos.App.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriaProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProduto", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PedidoId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Preco = table.Column<double>(type: "double", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Imagem = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CategoriaProduto_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "double", nullable: false),
                    PagamentoId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoProduto",
                columns: table => new
                {
                    PedidosId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProduto", x => new { x.PedidosId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Pedido_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PagamentoId",
                table: "Pedido",
                column: "PagamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_ProdutosId",
                table: "PedidoProduto",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            Seed(migrationBuilder);
        }

        private void Seed(MigrationBuilder migrationBuilder)
        {
            // Cliente
            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Nome", "Email", "Cpf", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "John Doe", "johndoe@email.com", "35042084061", DateTime.Now, DateTime.Now}
                });
            // Usuario
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Nome", "Email", "Login", "Senha", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "John Doe Admin", "johndoe-admin@email.com", "john_admin", "1234", DateTime.Now, DateTime.Now}
                });
            // Categoria Produto
            var LancheId = Guid.NewGuid();
            var BebidaId = Guid.NewGuid();
            var ComplementoId = Guid.NewGuid();
            migrationBuilder.InsertData(
                table: "CategoriaProduto",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {LancheId, "Lanche", DateTime.Now, DateTime.Now}
                });
            migrationBuilder.InsertData(
                table: "CategoriaProduto",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {BebidaId, "Bebida", DateTime.Now, DateTime.Now}
                });
            migrationBuilder.InsertData(
                table: "CategoriaProduto",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {ComplementoId, "Complemento", DateTime.Now, DateTime.Now}
                });
            // Produtos
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "CategoriaId", "Preco", "Descricao", "Imagem", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Coca-cola", BebidaId, 10, "Coca-cola", "coca-cola.png", DateTime.Now, DateTime.Now}
                });
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "CategoriaId", "Preco", "Descricao", "Imagem", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Pepsi", BebidaId, 10, "Pepsi", "pepsi.png", DateTime.Now, DateTime.Now}
                });
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "CategoriaId", "Preco", "Descricao", "Imagem", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Hámburguer", LancheId, 35, "Hámburguer", "hamburguer.png", DateTime.Now, DateTime.Now}
                });
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "CategoriaId", "Preco", "Descricao", "Imagem", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Pizza", LancheId, 50, "Pizza", "pizza.png", DateTime.Now, DateTime.Now}
                });
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "CategoriaId", "Preco", "Descricao", "Imagem", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Bacon", ComplementoId, 1, "Bacon", "bacon.png", DateTime.Now, DateTime.Now}
                });
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "CategoriaId", "Preco", "Descricao", "Imagem", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Ketchup", ComplementoId, 1, "Ketchup", "ketchup.png", DateTime.Now, DateTime.Now}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProduto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "CategoriaProduto");
        }
    }
}
