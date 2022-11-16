using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cad_menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_empresa = table.Column<int>(type: "INT", nullable: false),
                    title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    router = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<int>(type: "INT", nullable: true),
                    children = table.Column<string>(type: "VARCHAR(5000)", maxLength: 5000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    admin = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_menu", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cad_pedido_anexo",
                columns: table => new
                {
                    codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_pedido = table.Column<int>(type: "INT", nullable: false),
                    base64imagem = table.Column<byte[]>(type: "LONGBLOB", nullable: false),
                    descricao = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_input = table.Column<DateTime>(type: "DATETIME", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_pedido_anexo", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cad_produto",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_empresa = table.Column<int>(type: "INT", nullable: true),
                    codigo_item = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_produto", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cad_usuario",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_empresa = table.Column<int>(type: "INT", nullable: true),
                    usuario = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    admin = table.Column<int>(type: "INT", nullable: true),
                    empresa = table.Column<int>(type: "INT", nullable: true),
                    ativo = table.Column<int>(type: "INT", nullable: true),
                    codigo_vendedor = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_usuario", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cad_vendedor",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_vendedor", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_stc_forma_pagamento",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_stc_forma_pagamento", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_ven_evento_remessa",
                columns: table => new
                {
                    codigo_identificador = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_evento = table.Column<int>(type: "INT", nullable: false),
                    codigo_empresa = table.Column<int>(type: "INT", nullable: true),
                    codigo = table.Column<int>(type: "INT", nullable: false),
                    codigo_item = table.Column<int>(type: "INT", nullable: false),
                    lote = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantidade = table.Column<float>(type: "FLOAT", nullable: false),
                    valor_unitario = table.Column<float>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ven_evento_remessa", x => x.codigo_identificador);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_ven_pedido",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_empresa = table.Column<int>(type: "INT", nullable: true),
                    identificacao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    celular = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_evento = table.Column<int>(type: "INT", nullable: true),
                    codigo_forma_pagamento = table.Column<int>(type: "INT", nullable: true),
                    razao_social = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cnpj_cpf = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pais = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uf = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    municipio = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logradouro = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_usuario = table.Column<int>(type: "INT", nullable: true),
                    data_input = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    tipo_inscricao_estadual = table.Column<int>(type: "INT", nullable: true),
                    inscricao_estadual = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ven_pedido", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_ven_pedido_item",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_pedido = table.Column<int>(type: "INT", nullable: false),
                    codigo_produto = table.Column<int>(type: "INT", nullable: false),
                    numero_lote = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantidade = table.Column<decimal>(type: "DECIMAL(15,2)", precision: 15, scale: 2, nullable: false),
                    valor_unitario = table.Column<decimal>(type: "DECIMAL(15,2)", precision: 15, scale: 2, nullable: false),
                    bonificacao = table.Column<int>(type: "INT", nullable: false),
                    codigo_usuario = table.Column<int>(type: "INT", nullable: false),
                    valor_total = table.Column<decimal>(type: "DECIMAL(15,2)", precision: 15, scale: 2, nullable: false),
                    desconto = table.Column<decimal>(type: "DECIMAL(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ven_pedido_item", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cad_evento",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uf = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logradouro = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    observacao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_inicio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    data_termino = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ativo = table.Column<int>(type: "INT", nullable: true),
                    pais = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    municipio = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_entidade = table.Column<int>(type: "INT", nullable: true),
                    codigo_vendedor = table.Column<int>(type: "INT", nullable: false),
                    UsuarioModelcodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_evento", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_tb_cad_evento_tb_cad_usuario_UsuarioModelcodigo",
                        column: x => x.UsuarioModelcodigo,
                        principalTable: "tb_cad_usuario",
                        principalColumn: "codigo");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_evento_UsuarioModelcodigo",
                table: "tb_cad_evento",
                column: "UsuarioModelcodigo");

            migrationBuilder.CreateIndex(
                name: "IX_usuario",
                table: "tb_cad_usuario",
                column: "usuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cad_evento");

            migrationBuilder.DropTable(
                name: "tb_cad_menu");

            migrationBuilder.DropTable(
                name: "tb_cad_pedido_anexo");

            migrationBuilder.DropTable(
                name: "tb_cad_produto");

            migrationBuilder.DropTable(
                name: "tb_cad_vendedor");

            migrationBuilder.DropTable(
                name: "tb_stc_forma_pagamento");

            migrationBuilder.DropTable(
                name: "tb_ven_evento_remessa");

            migrationBuilder.DropTable(
                name: "tb_ven_pedido");

            migrationBuilder.DropTable(
                name: "tb_ven_pedido_item");

            migrationBuilder.DropTable(
                name: "tb_cad_usuario");
        }
    }
}
