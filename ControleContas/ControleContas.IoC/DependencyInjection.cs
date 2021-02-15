using ControleContas.Application.Interfaces;
using ControleContas.Application.Services;
using ControleContas.Domain.Interfaces;
using ControleContas.Infra.Data.Context;
using ControleContas.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleContas.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ICategoriasRepository, CategoriasRepository>();
            services.AddScoped<ICategoriasService, CategoriasService>();

            services.AddScoped<IContasTiposRepository, ContasTiposRepository>();
            services.AddScoped<IContasTiposService, ContasTiposService>();

            return services;
        }
    }
}
