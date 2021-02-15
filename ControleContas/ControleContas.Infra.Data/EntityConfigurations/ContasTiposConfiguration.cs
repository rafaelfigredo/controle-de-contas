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
    public class ContasTiposConfiguration : IEntityTypeConfiguration<ContasTipos>
    {
        public void Configure(EntityTypeBuilder<ContasTipos> builder)
        {
            builder.HasKey(p => p.Id).HasName("PK_ContasTipos");
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();

            //Foreing Key
            builder.HasMany(e => e.Contas).WithOne(x => x.ContasTipos).HasForeignKey(s => s.ContasTiposId);
        }
    }
}
