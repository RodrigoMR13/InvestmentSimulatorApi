namespace Application.Responses
{
    public class ProdutoInvestimentoResponse
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Rentabilidade { get; set; }
        public long TipoId { get; set; }
        public string TipoNome { get; set; }
        public int PrazoMinimoMeses { get; set; }
        public int PrazoMaximoMeses { get; set; }
        public decimal ValorMinimoInvestimento { get; set; }
        public decimal ValorMaximoInvestimento { get; set; }
        public string Risco { get; set; }
    }
}
