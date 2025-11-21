using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ListarClientesQuery : IRequest<IEnumerable<ClienteResponse>> { }
}
