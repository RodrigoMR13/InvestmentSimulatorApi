namespace Application.Responses
{
    public class ObterSimulacaoInvestimentoResponse
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public string Produto { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorFinal { get; set; }
        public int PrazoMeses { get; set; }
        public DateTimeOffset DataSimulacao { get; set; }

        public ObterSimulacaoInvestimentoResponse(long id, long clienteId, string produto, decimal valorInvestido,
            decimal valorFinal, int prazoMeses, DateTimeOffset dataSimulacao) 
        {
            Id = id;
            ClienteId = clienteId;
            Produto = produto;
            ValorInvestido = valorInvestido;
            ValorFinal = valorFinal;
            PrazoMeses = prazoMeses;
            DataSimulacao = dataSimulacao;
        }
    }
}
