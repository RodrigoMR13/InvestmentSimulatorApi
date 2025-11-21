using Application.Commands;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class RemoverTipoProdutoInvestimentoHandler
    : IRequestHandler<RemoverTipoProdutoInvestimentoCommand, bool>
    {
        private readonly ITipoProdutoInvestimentoRepository _repository;

        public RemoverTipoProdutoInvestimentoHandler(ITipoProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            RemoverTipoProdutoInvestimentoCommand request,
            CancellationToken cancellationToken)
        {
            return await _repository.RemoverAsync(request.Id);
        }
    }

}
