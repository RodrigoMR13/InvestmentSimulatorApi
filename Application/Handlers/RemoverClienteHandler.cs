using Application.Commands;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class RemoverClienteHandler : IRequestHandler<RemoverClienteCommand, bool>
    {
        private readonly IClienteRepository _repository;
        public RemoverClienteHandler(IClienteRepository repository) => _repository = repository;

        public async Task<bool> Handle(
            RemoverClienteCommand request,
            CancellationToken cancellationToken)
        {
            return await _repository.RemoverAsync(request.Id);
        }
    }
}
