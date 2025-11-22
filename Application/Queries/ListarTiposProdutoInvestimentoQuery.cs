using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ListarTiposProdutoInvestimentoQuery
    : IRequest<IEnumerable<TipoProdutoInvestimentoResponse>>
    {
    }
}
