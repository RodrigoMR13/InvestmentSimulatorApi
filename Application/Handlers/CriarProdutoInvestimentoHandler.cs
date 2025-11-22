using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class CriarProdutoInvestimentoHandler
    : IRequestHandler<CriarProdutoInvestimentoCommand, ProdutoInvestimentoResponse>
    {
        private readonly IProdutoInvestimentoRepository _repository;

        public CriarProdutoInvestimentoHandler(IProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoInvestimentoResponse> Handle(
            CriarProdutoInvestimentoCommand request,
            CancellationToken cancellationToken)
        {
            ProdutoInvestimento entity = new()
            {
                Nome = request.Nome,
                Rentabilidade = request.Rentabilidade,
                TipoId = request.TipoId,
                PrazoMinimoMeses = request.PrazoMinimoMeses,
                PrazoMaximoMeses = request.PrazoMaximoMeses,
                ValorMinimoInvestimento = request.ValorMinimoInvestimento,
                ValorMaximoInvestimento = request.ValorMaximoInvestimento,
                Risco = request.Risco
            };

            ProdutoInvestimento produtoCriado = await _repository.AdicionarAsync(entity);

            return produtoCriado.ToProdutoInvestimentoResponse();
        }
    }

}
