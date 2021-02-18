using ControleContas.Application.Interfaces;
using ControleContas.Application.Interfaces.Utils;
using ControleContas.Application.Services;
using ControleContas.Application.Services.Utils;
using ControleContas.Domain.Interfaces;
using ControleContas.Domain.Interfaces.Utils;
using ControleContas.Infra.Data.Context;
using ControleContas.Infra.Data.Repositories;
using ControleContas.Infra.Data.Repositories.Utils;
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

            services.AddScoped<IDropdownRepository, DropdownRepository>();
            services.AddScoped<IDropdownService, DropdownService>();

            services.AddScoped<ICategoriasRepository, CategoriasRepository>();
            services.AddScoped<ICategoriasService, CategoriasService>();

            services.AddScoped<IContasTiposRepository, ContasTiposRepository>();
            services.AddScoped<IContasTiposService, ContasTiposService>();

            services.AddScoped<IContasRepository, ContasRepository>();
            services.AddScoped<IContasService, ContasService>();

            services.AddScoped<ILancamentosRepository, LancamentosRepository>();
            services.AddScoped<ILancamentosService, LancamentosService>();

            services.AddScoped<IParcelasRepository, ParcelasRepository>();
            services.AddScoped<IParcelasService, ParcelasService>();

            services.AddScoped<IDashboardService, DashboardService>();

            return services;
        }
    }
}
