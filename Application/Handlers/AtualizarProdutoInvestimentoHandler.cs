using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class AtualizarProdutoInvestimentoHandler
    : IRequestHandler<AtualizarProdutoInvestimentoCommand, ProdutoInvestimentoResponse?>
    {
        private readonly IProdutoInvestimentoRepository _repository;

        public AtualizarProdutoInvestimentoHandler(IProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoInvestimentoResponse?> Handle(AtualizarProdutoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.ObterPorIdAsync(request.Id);
            if (entity == null)
                return null;

            entity.Nome = request.Nome;
            entity.Rentabilidade = request.Rentabilidade;
            entity.TipoId = request.TipoId;
            entity.PrazoMinimoMeses = request.PrazoMinimoMeses;
            entity.PrazoMaximoMeses = request.PrazoMaximoMeses;
            entity.ValorMinimoInvestimento = request.ValorMinimoInvestimento;
            entity.ValorMaximoInvestimento = request.ValorMaximoInvestimento;
            entity.Risco = request.Risco;

            ProdutoInvestimento produtoCriado = await _repository.AtualizarAsync(entity);

            return produtoCriado.ToProdutoInvestimentoResponse();
        }
    }

}
