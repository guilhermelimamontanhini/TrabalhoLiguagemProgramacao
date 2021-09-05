using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models.Dominio;

namespace Trabalho.Models.Mapeamento
{
    public class JogoMap : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            // Chave primaria
            builder.HasKey(p => p.id);
            // Auto-encremento
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.nome).HasMaxLength(35).IsRequired();
            builder.Property(p => p.preco).HasColumnType("float").IsRequired();
            builder.Property(p => p.genero).HasMaxLength(20).IsRequired();
            builder.Property(p => p.lancamento).HasColumnType("DateTime").IsRequired();

            builder.HasOne(p => p.usuario).WithMany(p => p.jogos).HasForeignKey(p => p.usuarioID);
            builder.HasOne(p => p.plataforma).WithMany(p => p.jogos).HasForeignKey(p => p.plataforma);
            builder.HasOne(p => p.empresa).WithMany(p => p.jogos).HasForeignKey(p => p.empresa);
            
            builder.ToTable("Jogo");
        }
    }
}
