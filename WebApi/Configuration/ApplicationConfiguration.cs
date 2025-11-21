using Application;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Services;
using Infrastructure.Time;

namespace WebApi.Configuration
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ITimeProvider, BrasilTimeProvider>();
            services.AddTransient<SimuladorInvestimentoService>();
            services.AddTransient<IProdutoInvestimentoSelector, ProdutoInvestimentoSelector>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly);
            });

            return services;
        }
    }
}
