using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models.Dominio;

namespace Trabalho.Models.Mapeamento
{
    public class PlataformaMap : IEntityTypeConfiguration<Plataforma>
    {
        public void Configure(EntityTypeBuilder<Plataforma> builder)
        {
            // Chave primaria
            builder.HasKey(p => p.id);
            // Auto-encremento
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.nome).HasMaxLength(35).IsRequired();

            builder.HasMany(p => p.jogos).WithOne(p => p.plataforma)
                .HasForeignKey(p => p.plataformaID).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.usuarios).WithOne(p => p.plataforma)
                .HasForeignKey(p => p.plataformaID).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Plataforma");
        }
    }
}
