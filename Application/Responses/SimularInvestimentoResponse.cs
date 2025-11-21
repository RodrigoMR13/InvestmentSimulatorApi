using Application.Telemetry;

namespace Application.Responses
{
    public class SimularInvestimentoResponse
    {
        public ProdutoValidadoResult ProdutoValidado { get; set; }
        public SimulacaoInvestimentoResult ResultadoSimulacao { get; set; }
        public DateTimeOffset DataSimulacao { get; set; }

        public SimularInvestimentoResponse(
            ProdutoValidadoResult produtoValidado,
            SimulacaoInvestimentoResult resultadoSimulacao,
            DateTimeOffset dataSimulacao) 
        {
            ProdutoValidado = produtoValidado;
            ResultadoSimulacao = resultadoSimulacao;
            DataSimulacao = dataSimulacao;
        }
    }
}
