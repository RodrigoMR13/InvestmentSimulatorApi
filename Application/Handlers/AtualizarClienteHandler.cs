using Application.Commands;
using Application.Exceptions;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class AtualizarClienteHandler : IRequestHandler<AtualizarClienteCommand, ClienteResponse?>
    {
        private readonly IClienteRepository _repository;
        public AtualizarClienteHandler(IClienteRepository repository) => _repository = repository;

        public async Task<ClienteResponse?> Handle(
            AtualizarClienteCommand request,
            CancellationToken cancellationToken)
        {
            Cliente existente = await _repository.ObterPorIdAsync(request.Id) 
                ?? throw new ObjectNotFoundException(nameof(Cliente), request.Id);

            existente.Nome = request.Nome;
            existente.Email = request.Email;
            existente.Cpf = request.Cpf;

            var atualizado = await _repository.AtualizarAsync(existente);
            return atualizado.ToClienteResponse();
        }
    }
}
