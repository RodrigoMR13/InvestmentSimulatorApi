using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ObterProdutoInvestimentoPorIdQuery : IRequest<ProdutoInvestimentoResponse?>
    {
        public long Id { get; set; }
    }

}
