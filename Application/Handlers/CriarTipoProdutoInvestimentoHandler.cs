using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class CriarTipoProdutoInvestimentoHandler
    : IRequestHandler<CriarTipoProdutoInvestimentoCommand, TipoProdutoInvestimentoResponse>
    {
        private readonly ITipoProdutoInvestimentoRepository _repository;

        public CriarTipoProdutoInvestimentoHandler(ITipoProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoProdutoInvestimentoResponse> Handle(
            CriarTipoProdutoInvestimentoCommand request,
            CancellationToken cancellationToken)
        {
            TipoProdutoInvestimento entity = new()
            {
                Nome = request.Nome
            };

            TipoProdutoInvestimento tipoProdutoCriado = await _repository.AdicionarAsync(entity);

            return tipoProdutoCriado.ToTipoProdutoInvestimentoResponse();
        }
    }

}
