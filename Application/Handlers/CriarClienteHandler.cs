using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class CriarClienteHandler : IRequestHandler<CriarClienteCommand, ClienteResponse>
    {
        private readonly IClienteRepository _repository;
        public CriarClienteHandler(IClienteRepository repository) => _repository = repository;

        public async Task<ClienteResponse> Handle(
            CriarClienteCommand request,
            CancellationToken cancellationToken)
        {
            Cliente cliente = new()
            {
                Nome = request.Nome,
                Email = request.Email,
                Cpf = request.Cpf
            };

            Cliente clienteCriado = await _repository.AdicionarAsync(cliente);
            return clienteCriado.ToClienteResponse();
        }
    }
}
