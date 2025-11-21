
using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ObterClientePorIdQuery : IRequest<ClienteResponse?>
    {
        public long Id { get; set; }
    }
}
