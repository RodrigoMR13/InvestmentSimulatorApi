using Application.Commands;
using Application.Exceptions;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class AtualizarTipoProdutoInvestimentoHandler
    : IRequestHandler<AtualizarTipoProdutoInvestimentoCommand, TipoProdutoInvestimentoResponse?>
    {
        private readonly ITipoProdutoInvestimentoRepository _repository;

        public AtualizarTipoProdutoInvestimentoHandler(ITipoProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoProdutoInvestimentoResponse?> Handle(
            AtualizarTipoProdutoInvestimentoCommand request,
            CancellationToken cancellationToken)
        {
            TipoProdutoInvestimento entity = await _repository.ObterPorIdAsync(request.Id)
                ?? throw new ObjectNotFoundException(nameof(TipoProdutoInvestimento), request.Id);

            entity.Nome = request.Nome;

            TipoProdutoInvestimento produtoInvestimentoCriado = await _repository.AtualizarAsync(entity);

            return produtoInvestimentoCriado.ToTipoProdutoInvestimentoResponse();
        }
    }

}
