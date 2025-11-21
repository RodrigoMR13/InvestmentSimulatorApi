using Application.Results;
using MediatR;

namespace Application.Queries
{
    public class ObterInvestimentosClienteQuery : IRequest<IEnumerable<InvestimentoResult>>
    {
        public long ClienteId { get; set; }
    }
}
