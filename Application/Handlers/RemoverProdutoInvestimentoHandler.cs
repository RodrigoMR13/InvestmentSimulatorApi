using Application.Commands;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class RemoverProdutoInvestimentoHandler
    : IRequestHandler<RemoverProdutoInvestimentoCommand, bool>
    {
        private readonly IProdutoInvestimentoRepository _repository;

        public RemoverProdutoInvestimentoHandler(IProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            RemoverProdutoInvestimentoCommand request,
            CancellationToken cancellationToken)
        {
            return await _repository.RemoverAsync(request.Id);
        }
    }

}
