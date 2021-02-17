using ControleContas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleContas.Infra.Data.EntityConfigurations
{
    public class CategoriasConfiguration : IEntityTypeConfiguration<Categorias>
    {
        public void Configure(EntityTypeBuilder<Categorias> builder)
        {
            builder.HasKey(p => p.Id).HasName("PK_Categorias");
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Cor).HasMaxLength(7).IsRequired();

            builder.HasData(
                new Categorias
                {
                    Id = 1,
                    Nome = "Sem Categoria",
                    Cor = "#AAAAAA"
                },
                new Categorias
                {
                    Id = 2,
                    Nome = "Alimentação",
                    Cor = "#F56269"
                },
                new Categorias
                {
                    Id = 3,
                    Nome = "Transporte",
                    Cor = "#8E68D4"
                },
                new Categorias
                {
                    Id = 4,
                    Nome = "Lazer",
                    Cor = "#88BD60"
                },
                new Categorias
                {
                    Id = 5,
                    Nome = "Saúde",
                    Cor = "#62BCF5"
                },
                new Categorias
                {
                    Id = 6,
                    Nome = "Moradia",
                    Cor = "#F5DF62"
                },
                new Categorias
                {
                    Id = 7,
                    Nome = "Pessoal",
                    Cor = "#F562C8"
                });
        }
    }
}