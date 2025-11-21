using MediatR;

namespace Application.Commands
{
    public class RemoverClienteCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
