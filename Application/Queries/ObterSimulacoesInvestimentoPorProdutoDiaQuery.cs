using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ObterSimulacoesInvestimentoPorProdutoDiaQuery 
        : IRequest<IEnumerable<ObterSimulacaoInvestimentoPorProdutoDiaResponse>>
    {
        public DateTime Data { get; set; } = DateTime.Today;
    }
}
