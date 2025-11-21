using Application.Telemetry;
using System.Collections.Concurrent;
using System.Diagnostics.Metrics;

namespace Infrastructure.Telemetry
{
    public class MetricsService : IMetricsService
    {
        private static readonly Meter Meter = new("Investimentos.Metrics");

        private static readonly Counter<long> ChamadaCounter =
            Meter.CreateCounter<long>("servico_chamadas_total", description: "Total de chamadas por serviço");

        private static readonly Histogram<double> TempoRespostaHist =
            Meter.CreateHistogram<double>("servico_tempo_resposta_ms", unit: "ms", description: "Tempo de resposta por serviço");

        private readonly ConcurrentDictionary<string, List<double>> _tempoPorServico = new();
        private readonly ConcurrentDictionary<string, long> _quantidadePorServico = new();

        public void RegistrarChamada(string servico, long tempoRespostaMs)
        {
            ChamadaCounter.Add(1, KeyValuePair.Create<string, object?>("servico", servico));
            TempoRespostaHist.Record(tempoRespostaMs, KeyValuePair.Create<string, object?>("servico", servico));

            _quantidadePorServico.AddOrUpdate(servico, 1, (_, v) => v + 1);

            _tempoPorServico.AddOrUpdate(servico,
                key => new List<double> { tempoRespostaMs },
                (_, list) =>
                {
                    list.Add(tempoRespostaMs);
                    return list;
                });
        }

        public Task<IEnumerable<ServicoTelemetriaDto>> ObterTelemetriaAsync(DateOnly inicio, DateOnly fim)
        {
            var lista = _quantidadePorServico.Select(s =>
                new ServicoTelemetriaDto
                {
                    Nome = s.Key,
                    QuantidadeChamadas = s.Value,
                    MediaTempoRespostaMs = _tempoPorServico[s.Key].Average()
                });

            return Task.FromResult(lista);
        }
    }
}
