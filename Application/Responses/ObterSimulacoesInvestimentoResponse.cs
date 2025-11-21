namespace Application.Responses
{
    public class ObterSimulacoesInvestimentoResponse
    {
        public IEnumerable<ObterSimulacaoInvestimentoResponse> Simulacoes { get; set; }

        public ObterSimulacoesInvestimentoResponse(IEnumerable<ObterSimulacaoInvestimentoResponse> simulacoes)
        {
            Simulacoes = simulacoes;
        }
    }
}
