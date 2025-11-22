using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ListarTiposProdutoInvestimentoHandler
    : IRequestHandler<ListarTiposProdutoInvestimentoQuery, IEnumerable<TipoProdutoInvestimentoResponse>>
    {
        private readonly ITipoProdutoInvestimentoRepository _repository;

        public ListarTiposProdutoInvestimentoHandler(ITipoProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoProdutoInvestimentoResponse>> Handle(
            ListarTiposProdutoInvestimentoQuery request,
            CancellationToken cancellationToken)
        {
            var list = await _repository.ListarTodosAsync();
            if (!list.Any())
                return [];

            return list.Select(entity => entity.ToTipoProdutoInvestimentoResponse());
        }
    }

}
