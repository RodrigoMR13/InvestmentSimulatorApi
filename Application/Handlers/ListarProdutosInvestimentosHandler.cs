using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ListarProdutosInvestimentosHandler
    : IRequestHandler<ListarProdutosInvestimentosQuery, IEnumerable<ProdutoInvestimentoResponse>>
    {
        private readonly IProdutoInvestimentoRepository _repository;

        public ListarProdutosInvestimentosHandler(IProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProdutoInvestimentoResponse>> Handle(ListarProdutosInvestimentosQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.ListarTodosAsync();

            return list.Select(entity => entity.ToProdutoInvestimentoResponse());
        }
    }

}
