using Application.Responses;
using Application.Results;
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

        public static InvestimentoResult ToInvestimentoResult(this SimulacaoInvestimento investimento)
        {
            return new InvestimentoResult
            {
                Id = investimento.Id,
                Tipo = investimento.Produto.Tipo.Nome,
                Valor = investimento.ValorInvestido,
                Rentabilidade = investimento.ValorInvestido == 0 ? 0 : (investimento.ValorFinal / investimento.ValorInvestido) - 1,
                Data = DateOnly.FromDateTime(investimento.DataSimulacao.UtcDateTime)
            };
        }
    }
}
