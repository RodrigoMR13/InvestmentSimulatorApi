using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class AtualizarTipoProdutoInvestimentoCommand : IRequest<TipoProdutoInvestimentoResponse?>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }

}
