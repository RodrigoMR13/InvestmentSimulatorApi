using Application.Telemetry;

namespace Application.Services
{
    public class SimuladorInvestimentoService
    {
        public SimuladorInvestimentoService()
        {
        }

        public SimulacaoInvestimentoResult SimularInvestimento(
            decimal valorInicial,
            int prazoMeses,
            ProdutoValidadoResult produto)
        {
            var taxaAnual = produto.Rentabilidade;

            decimal taxaMensal = (decimal)Math.Pow(1 + (double)taxaAnual, 1d / 12d) - 1m;

            decimal multiplicador = (decimal)Math.Pow((double)(1 + taxaMensal), prazoMeses);

            decimal valorFinal = valorInicial * multiplicador;

            var result = new SimulacaoInvestimentoResult(
                decimal.Round(valorFinal, 2),
                decimal.Round(multiplicador - 1, 4),
                prazoMeses);

            return result;
        }
    }
}
