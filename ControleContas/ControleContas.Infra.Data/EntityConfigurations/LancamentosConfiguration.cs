using ControleContas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Infra.Data.EntityConfigurations
{
    public class LancamentosConfiguration : IEntityTypeConfiguration<Lancamentos>
    {
        public void Configure(EntityTypeBuilder<Lancamentos> builder)
        {
            builder.HasKey(p => p.Id).HasName("PK_Lancamentos");
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ValorTotal).HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.ParcelasTotal).IsRequired();
            builder.Property(p => p.ContasId).IsRequired();
            builder.Property(p => p.CategoriasId).IsRequired();
            builder.Property(p => p.DataCompra).IsRequired();

            //Foreing Key
            builder.HasMany(e => e.Parcelas).WithOne(x => x.Lancamentos).HasForeignKey(s => s.LancamentosId);
        }
    }
}
