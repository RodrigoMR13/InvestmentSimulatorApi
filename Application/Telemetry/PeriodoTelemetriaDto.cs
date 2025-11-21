namespace Application.Telemetry
{
    public class PeriodoTelemetriaDto
    {
        public DateOnly Inicio { get; set; }
        public DateOnly Fim { get; set; }

        public PeriodoTelemetriaDto() { }

        public PeriodoTelemetriaDto(DateOnly inicio, DateOnly fim)
        {
            Inicio = inicio;
            Fim = fim;
        }
    }
}
