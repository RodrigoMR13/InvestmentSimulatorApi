using Application.Exceptions;
using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ListarClientesHandler : IRequestHandler<ListarClientesQuery, IEnumerable<ClienteResponse>>
    {
        private readonly IClienteRepository _repository;
        public ListarClientesHandler(IClienteRepository repository) => _repository = repository;

        public async Task<IEnumerable<ClienteResponse>> Handle(
            ListarClientesQuery request,
            CancellationToken cancellationToken)
        {
            IEnumerable<Cliente> list = await _repository.ListarTodosAsync();
            if (!list.Any())
                return [];

            return list.Select(entity => entity.ToClienteResponse());
        }
    }
}
