using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models.Dominio;

namespace Trabalho.Models.Mapeamento
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Chave-primaria
            builder.HasKey(p => p.id);
            // Auto-encremento
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.nome).HasMaxLength(40).IsRequired();
            builder.Property(p => p.email).HasMaxLength(30).IsRequired();

            builder.HasMany(p => p.jogos).WithOne(p => p.usuario)
                .HasForeignKey(p => p.usuarioID).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Usuario");
        }
    }
}
