using Domain.Interfaces.Sql;
using Infrastructure.SqlServer.Context;
using Infrastructure.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configuration
{
    public static class SqlDbConfiguration
    {
        public static IServiceCollection AddSqlDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("InvestimentosSqlDb");

            services.AddDbContext<InvestimentosDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoInvestimentoRepository, ProdutoInvestimentoRepository>();
            services.AddScoped<ISimulacaoInvestimentoRepository, SimulacaoInvestimentoRepository>();
            services.AddScoped<ITipoProdutoInvestimentoRepository, TipoProdutoInvestimentoRepository>();

            return services;
        }
    }
}
