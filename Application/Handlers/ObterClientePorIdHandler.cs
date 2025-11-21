using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ObterClientePorIdHandler : IRequestHandler<ObterClientePorIdQuery, ClienteResponse?>
    {
        private readonly IClienteRepository _repository;
        public ObterClientePorIdHandler(IClienteRepository repository) => _repository = repository;

        public async Task<ClienteResponse?> Handle(
            ObterClientePorIdQuery request,
            CancellationToken cancellationToken)
        {
            var cliente = await _repository.ObterPorIdAsync(request.Id);
            if (cliente == null)
                return null;

            return cliente.ToClienteResponse();
        }
    }
}
