
using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ListarProdutosInvestimentosQuery : IRequest<IEnumerable<ProdutoInvestimentoResponse>>
    {
    }
}
