using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ObterPerfilRiscoClienteQuery : IRequest<PerfilRiscoClienteResponse>
    {
        public long ClienteId { get; set; }
    }
}
