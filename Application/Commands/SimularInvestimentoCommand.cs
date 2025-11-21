using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class SimularInvestimentoCommand : IRequest<SimularInvestimentoResponse>
    {
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public int PrazoMeses { get; set; }
        public string TipoProduto { get; set; }
    }
}
