using ControleContas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleContas.Infra.Data.EntityConfigurations
{
    public class ContasConfiguration : IEntityTypeConfiguration<Contas>
    {
        public void Configure(EntityTypeBuilder<Contas> builder)
        {
            builder.HasKey(p => p.Id).HasName("PK_Contas");
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.ContasTiposId).IsRequired();
            builder.Property(p => p.Cor).HasMaxLength(7).IsRequired();
            builder.Property(p => p.VencimentoDia).HasMaxLength(6).IsRequired();

            //Foreing Key
            builder.HasMany(e => e.Lancamentos).WithOne(x => x.Contas).HasForeignKey(s => s.ContasId);
        }
    }
}
