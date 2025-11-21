namespace Application.Telemetry
{
    public class ServicoTelemetriaDto
    {
        public required string Nome { get; set; }
        public long QuantidadeChamadas { get; set; }
        public double MediaTempoRespostaMs { get; set; }
    }
}
