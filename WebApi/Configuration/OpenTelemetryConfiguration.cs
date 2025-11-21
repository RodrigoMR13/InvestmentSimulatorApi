using Application.Telemetry;
using Infrastructure.Telemetry;
using OpenTelemetry.Metrics;

namespace WebApi.Configuration
{
    public static class OpenTelemetryConfiguration
    {
        public static IServiceCollection AddOpenTelemetryConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddOpenTelemetry()
                .WithMetrics(metrics =>
                {
                    metrics
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddRuntimeInstrumentation()
                        //.AddProcessInstrumentation()
                        .AddMeter("Investimentos.Metrics");

                    metrics.AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(config["OpenTelemetry:OtlpEndpoint"]);
                    });
                    metrics.AddPrometheusExporter();
                });

            services.AddSingleton<IMetricsService, MetricsService>();

            return services;
        }
    }
}
