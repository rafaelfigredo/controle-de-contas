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
        public DbSet<Contas> Contas { get; set; }
        public DbSet<ContasTipos> ContasTipos { get; set; }
        public DbSet<Lancamentos> Lancamentos { get; set; }
        public DbSet<Parcelas> Parcelas { get; set; }

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
