namespace Application.Telemetry
{
    public class TelemetriaResponse
    {
        public List<ServicoTelemetriaDto> Servicos { get; set; } = new();
        public PeriodoTelemetriaDto Periodo { get; set; } = new();

        public TelemetriaResponse(List<ServicoTelemetriaDto> servicos, PeriodoTelemetriaDto periodo)
        {
            Servicos = servicos;
            Periodo = periodo;
        }
    }
}
