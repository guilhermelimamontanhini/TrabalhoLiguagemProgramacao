using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models.Dominio;

namespace Trabalho.Models.Mapeamento
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            // Chave primaria
            builder.HasKey(p => p.id);
            // Auto-encremento
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.nome).HasMaxLength(35).IsRequired();
            builder.Property(p => p.dataFundacao).HasColumnType("DateTime").IsRequired();
            builder.Property(p => p.sede).HasMaxLength(20).IsRequired();

            builder.HasMany(p => p.jogos).WithOne(p => p.empresa)
                .HasForeignKey(p => p.empresaID).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Empresa");
        }
    }
}
