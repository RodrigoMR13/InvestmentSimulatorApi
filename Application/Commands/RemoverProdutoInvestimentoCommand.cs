using MediatR;

namespace Application.Commands
{
    public class RemoverProdutoInvestimentoCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
