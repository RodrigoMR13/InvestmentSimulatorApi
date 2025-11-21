using Application.Commands;
using Application.Mappers;
using Application.Responses;
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
            var existente = await _repository.ObterPorIdAsync(request.Id);
            if (existente == null)
                return null;

            existente.Nome = request.Nome;
            existente.Email = request.Email;
            existente.Cpf = request.Cpf;

            var atualizado = await _repository.AtualizarAsync(existente);
            return atualizado.ToClienteResponse();
        }
    }
}
