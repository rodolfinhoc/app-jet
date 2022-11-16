using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            // Tabela
            builder.ToTable("tb_cad_usuario");

            // Chave Primária
            builder.HasKey(x => x.codigo);
            
            // Identity
            builder.Property(x => x.codigo)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.usuario)
                .IsRequired()
                .HasColumnName("usuario")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.senha)
                .IsRequired()
                .HasColumnName("senha")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.nome)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

        }


    }
}