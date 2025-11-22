using Serilog;
using Serilog.Sinks.Grafana.Loki;
using WebApi.Configuration;
using WebApi.Middleware;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var configuration = builder.Configuration;

    builder.Host.UseSerilog((ctx, lc) => lc
            .ReadFrom.Configuration(ctx.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Application", "InvestimentosAPI")
            .WriteTo.Console()
            .WriteTo.GrafanaLoki(ctx.Configuration["Logging:GrafanaLoki:Url"]));

    Log.Information("Iniciando a aplicação...");

    builder.Services.AddControllers();
    builder.Services.AddOpenApi();
    builder.Services.AddApplication();
    builder.Services.AddSqlDb(configuration);
    builder.Services.AddRepositories();
    builder.Services.AddOpenTelemetryConfig(configuration);
    builder.Services.AddAuthConfig(configuration);
    builder.Services.AddCustomSwaggerWithAuth(configuration);

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseMiddleware<RequestMetricsMiddleware>();
    app.UseMiddleware<GlobalExceptionMiddleware>();

    app.MapPrometheusScrapingEndpoint();

    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvestmentSimulatorApi v1");
    });

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "A aplicação terminou de forma inesperada!");
}
finally
{
    Log.CloseAndFlush();
}