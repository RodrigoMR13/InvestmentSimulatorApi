using Application.Mappers;
using Application.Queries;
using Application.Results;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ObterInvestimentosClienteHandler 
        : IRequestHandler<ObterInvestimentosClienteQuery, IEnumerable<InvestimentoResult>>
    {
        private readonly ISimulacaoInvestimentoRepository _simulacaoInvestimentoRepository;

        public ObterInvestimentosClienteHandler(
            ISimulacaoInvestimentoRepository simulacaoInvestimentoRepository)
        {
            _simulacaoInvestimentoRepository = simulacaoInvestimentoRepository;
        }

        public async Task<IEnumerable<InvestimentoResult>> Handle(
            ObterInvestimentosClienteQuery request,
            CancellationToken cancellationToken)
        {
            IEnumerable<SimulacaoInvestimento> investimentos = await _simulacaoInvestimentoRepository
                .ListarPorClienteAsync(request.ClienteId);

            if (!investimentos.Any())
                return [];

            return investimentos.Select(investimento => investimento.ToInvestimentoResult());
        }
    }
}
