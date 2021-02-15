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
    public class ParcelasConfiguration : IEntityTypeConfiguration<Parcelas>
    {
        public void Configure(EntityTypeBuilder<Parcelas> builder)
        {
            builder.HasKey(p => p.Id).HasName("PK_Parcelas");
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.ParcelaNumero).IsRequired();
            builder.Property(p => p.ParcelaValor).HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.AnoCobranca).IsRequired();
            builder.Property(p => p.MesCobranca).IsRequired();
            builder.Property(p => p.LancamentosId).IsRequired();
        }
    }
}
