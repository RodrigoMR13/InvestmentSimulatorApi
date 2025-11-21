using Application.Commands;
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
            var entity = await _repository.ObterPorIdAsync(request.Id);
            if (entity == null)
                return null;

            entity.Nome = request.Nome;

            TipoProdutoInvestimento produtoInvestimentoCriado = await _repository.AtualizarAsync(entity);

            return produtoInvestimentoCriado.ToTipoProdutoInvestimentoResponse();
        }
    }

}
