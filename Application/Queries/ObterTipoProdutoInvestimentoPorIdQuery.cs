using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ObterTipoProdutoInvestimentoPorIdQuery : IRequest<TipoProdutoInvestimentoResponse?>
    {
        public long Id { get; set; }
    }

}
