using Application.Exceptions;
using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ObterProdutoInvestimentoPorIdHandler
    : IRequestHandler<ObterProdutoInvestimentoPorIdQuery, ProdutoInvestimentoResponse?>
    {
        private readonly IProdutoInvestimentoRepository _repository;

        public ObterProdutoInvestimentoPorIdHandler(IProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoInvestimentoResponse?> Handle(ObterProdutoInvestimentoPorIdQuery request, CancellationToken cancellationToken)
        {
            ProdutoInvestimento entity = await _repository.ObterPorIdAsync(request.Id)
                ?? throw new ObjectNotFoundException(nameof(ProdutoInvestimento), request.Id);

            return entity.ToProdutoInvestimentoResponse();
        }
    }

}
