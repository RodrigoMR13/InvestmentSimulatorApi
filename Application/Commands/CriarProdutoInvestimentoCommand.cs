using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class CriarProdutoInvestimentoCommand : IRequest<ProdutoInvestimentoResponse>
    {
        public string Nome { get; set; }
        public decimal Rentabilidade { get; set; }
        public long TipoId { get; set; }
        public int PrazoMinimoMeses { get; set; }
        public int PrazoMaximoMeses { get; set; }
        public decimal ValorMinimoInvestimento { get; set; }
        public decimal ValorMaximoInvestimento { get; set; }
        public string Risco { get; set; }
    }
}
