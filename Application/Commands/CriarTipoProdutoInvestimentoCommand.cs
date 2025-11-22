using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class CriarTipoProdutoInvestimentoCommand : IRequest<TipoProdutoInvestimentoResponse>
    {
        public string Nome { get; set; }
    }
}
