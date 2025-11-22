using Application.Exceptions;
using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Entities;
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
            Cliente cliente = await _repository.ObterPorIdAsync(request.Id)
                ?? throw new ObjectNotFoundException(nameof(Cliente), request.Id);

            return cliente.ToClienteResponse();
        }
    }
}
