using Application.Responses;
using Domain.Entities;

namespace Application.Mappers
{
    public static class SimulacaoInvestimentoMapper
    {
        public static ObterSimulacoesInvestimentoResponse ToGetSimulacoesInvestimentoResponse(
            this IEnumerable<SimulacaoInvestimento> simulacoes)
        {
            IEnumerable<ObterSimulacaoInvestimentoResponse> simulacoesResponse = simulacoes.Select(simulacao => new ObterSimulacaoInvestimentoResponse(
                simulacao.Id,
                simulacao.ClienteId,
                simulacao.Produto.Nome,
                simulacao.ValorInvestido,
                simulacao.ValorFinal,
                simulacao.PrazoMeses,
                simulacao.DataSimulacao
                ));

            return new ObterSimulacoesInvestimentoResponse(simulacoesResponse);
        }
    }
}
