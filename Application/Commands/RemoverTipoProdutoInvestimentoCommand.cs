using MediatR;

namespace Application.Commands
{
    public class RemoverTipoProdutoInvestimentoCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

}
