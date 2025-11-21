namespace Application.Telemetry
{
    public class SimulacaoInvestimentoResult
    {
        public decimal ValorFinal { get; set; }
        public decimal RentabilidadeEfetiva { get; set; }
        public int PrazoMeses { get; set; }

        public SimulacaoInvestimentoResult(decimal valorFinal, decimal rentabilidadeEfetiva, int prazoMeses)
        {
            ValorFinal = valorFinal;
            RentabilidadeEfetiva = rentabilidadeEfetiva;
            PrazoMeses = prazoMeses;
        }
    }
}
