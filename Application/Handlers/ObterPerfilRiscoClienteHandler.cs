using Application.Queries;
using Application.Responses;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Handlers
{
    public class ObterPerfilRiscoClienteHandler
        : IRequestHandler<ObterPerfilRiscoClienteQuery, PerfilRiscoClienteResponse>
    {
        private readonly ISimulacaoInvestimentoRepository _simulacaoInvestimentoRepository;

        public ObterPerfilRiscoClienteHandler(
            ISimulacaoInvestimentoRepository simulacaoInvestimentoRepository)
        {
            _simulacaoInvestimentoRepository = simulacaoInvestimentoRepository;
        }

        public async Task<PerfilRiscoClienteResponse> Handle(
            ObterPerfilRiscoClienteQuery request,
            CancellationToken cancellationToken)
        {
            IEnumerable<SimulacaoInvestimento> historicoInvestimentos = await _simulacaoInvestimentoRepository
                .ListarPorClienteAsync(request.ClienteId);

            if (!historicoInvestimentos.Any())
            {
                return new PerfilRiscoClienteResponse
                {
                    ClienteId = request.ClienteId,
                    Perfil = "Indefinido",
                    Pontuacao = 0,
                    Descricao = "O cliente não possui histórico de investimentos para definição de perfil de risco."
                };
            }

            short pontuacao = RiskCalculatorService.CalcularPontuacao(historicoInvestimentos);
            string perfil = RiskCalculatorService.DefinirPerfil(pontuacao);
            string descricao = RiskCalculatorService.DescricaoPerfil(perfil);

            return new PerfilRiscoClienteResponse
            {
                ClienteId = request.ClienteId,
                Perfil = perfil,
                Pontuacao = pontuacao,
                Descricao = descricao
            };
        }   
    }
}
