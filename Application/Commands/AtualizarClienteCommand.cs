using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class AtualizarClienteCommand : IRequest<ClienteResponse>
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
    }
}
