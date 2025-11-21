using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ObterTipoProdutoInvestimentoPorIdHandler
    : IRequestHandler<ObterTipoProdutoInvestimentoPorIdQuery, TipoProdutoInvestimentoResponse?>
    {
        private readonly ITipoProdutoInvestimentoRepository _repository;

        public ObterTipoProdutoInvestimentoPorIdHandler(ITipoProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoProdutoInvestimentoResponse?> Handle(
            ObterTipoProdutoInvestimentoPorIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.ObterPorIdAsync(request.Id);
            if (entity == null)
                return null;

            return entity.ToTipoProdutoInvestimentoResponse();
        }
    }

}
