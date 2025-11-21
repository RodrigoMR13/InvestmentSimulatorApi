namespace Application.Telemetry
{
    public interface IMetricsService
    {
        void RegistrarChamada(string servico, long tempoRespostaMs);
        Task<IEnumerable<ServicoTelemetriaDto>> ObterTelemetriaAsync(DateOnly inicio, DateOnly fim);
    }
}
