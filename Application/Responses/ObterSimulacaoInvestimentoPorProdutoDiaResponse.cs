namespace Application.Responses
{
    public class ObterSimulacaoInvestimentoPorProdutoDiaResponse
    {
        public string Produto { get; set; }
        public DateOnly Data { get; set; }
        public long QuantidadeSimulacoes { get; set; }
        public decimal MediaValorFinal { get; set; }
    }
}
