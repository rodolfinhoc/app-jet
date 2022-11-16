using api.Models.Upload;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Mappings
{
    public class UploadImagemMap : IEntityTypeConfiguration<UploadImagemModel>
    {
        public void Configure(EntityTypeBuilder<UploadImagemModel> builder)
        {
            // Tabela
            builder.ToTable("tb_cad_pedido_anexo");

            // Chave Primária
            builder.HasKey(x => x.codigo);

            // Identity
            builder.Property(x => x.codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.codigo_pedido)
                .IsRequired()
                .HasColumnName("codigo_pedido")
                .HasColumnType("INT");

            builder.Property(x => x.base64imagem)
               .IsRequired()
               .HasColumnName("base64imagem")
               .HasColumnType("LONGBLOB");

            builder.Property(x => x.descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.data_input)
                .IsRequired()
                .HasColumnName("data_input")
                .HasColumnType("DATETIME")
                .HasMaxLength(150);

        }

    }
}
