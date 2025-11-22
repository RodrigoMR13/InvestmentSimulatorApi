using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ObterSimulacoesInvestimentoHandler 
        : IRequestHandler<ObterSimulacoesInvestimentoQuery, ObterSimulacoesInvestimentoResponse?>
    {
        private readonly ISimulacaoInvestimentoRepository _simulacaoInvestimentoRepository;

        public ObterSimulacoesInvestimentoHandler(
            ISimulacaoInvestimentoRepository simulacaoInvestimentoRepository)
        {
            _simulacaoInvestimentoRepository = simulacaoInvestimentoRepository;
        }

        public async Task<ObterSimulacoesInvestimentoResponse?> Handle(
            ObterSimulacoesInvestimentoQuery request,
            CancellationToken cancellationToken)
        {
            IEnumerable<SimulacaoInvestimento> simulacoes = await _simulacaoInvestimentoRepository.ListarTodosAsync();
            if (!simulacoes.Any())
                return null;

            return simulacoes.ToGetSimulacoesInvestimentoResponse();
        }
    }
}
