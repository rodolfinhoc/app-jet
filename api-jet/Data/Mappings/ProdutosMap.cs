using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Mappings
{
    public class ProdutosMap : IEntityTypeConfiguration<ProdutosModel>
    {
        public void Configure(EntityTypeBuilder<ProdutosModel> builder)
        {
            // Tabela
            builder.ToTable("tb_cad_produto");

            // Chave Primária
            builder.HasKey(x => x.codigo);
            
            // Identity
            builder.Property(x => x.codigo)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.nome)
                //.IsRequired()
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.imagem)
                //.IsRequired()
                .HasColumnName("imagem")
                .HasColumnType("LONGBLOB");

            builder.Property(x => x.descricao)
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(2000);

            builder.Property(x => x.estoque)
                .HasColumnName("estoque")
                .HasColumnType("INT");

            builder.Property(x => x.status)
                .HasColumnName("status")
                .HasColumnType("BIT"); 
            
            builder.Property(x => x.preco)
                .HasColumnName("preco")
                .HasColumnType("FLOAT");

            builder.Property(x => x.preco_promocao)
                .HasColumnName("preco_promocao")
                .HasColumnType("FLOAT");


        }


    }
}