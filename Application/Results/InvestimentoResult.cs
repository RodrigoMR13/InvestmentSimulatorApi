namespace Application.Results
{
    public class InvestimentoResult
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal Rentabilidade { get; set; }
        public DateOnly Data { get; set; }
    }
}
