using Application.Exceptions;
using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Entities;
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
            TipoProdutoInvestimento entity = await _repository.ObterPorIdAsync(request.Id)
                ?? throw new ObjectNotFoundException(nameof(TipoProdutoInvestimento), request.Id);

            return entity.ToTipoProdutoInvestimentoResponse();
        }
    }

}
