using ControleContas.Domain.Entities;
using ControleContas.Infra.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleContas.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CategoriasConfiguration());
            builder.ApplyConfiguration(new ContasConfiguration());
            builder.ApplyConfiguration(new ContasTiposConfiguration());
            builder.ApplyConfiguration(new LancamentosConfiguration());
            builder.ApplyConfiguration(new ParcelasConfiguration());
        }
    }
}
