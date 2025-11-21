using Application.Responses;
using Application.Telemetry;
using Domain.Entities;

namespace Application.Mappers
{
    public static class ProdutoInvestimentoMapper
    {
        public static ProdutoValidadoResult ToProdutoValidadoResult(this ProdutoInvestimento produto)
        {
            return new ProdutoValidadoResult
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Tipo = produto.Tipo?.Nome ?? string.Empty,
                Rentabilidade = produto.Rentabilidade,
                Risco = produto.Risco
            };
        }

        public static ProdutoInvestimentoResponse ToProdutoInvestimentoResponse(this ProdutoInvestimento produto)
        {
            return new ProdutoInvestimentoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Rentabilidade = produto.Rentabilidade,
                TipoId = produto.TipoId,
                TipoNome = produto.Tipo?.Nome ?? string.Empty,
                PrazoMinimoMeses = produto.PrazoMinimoMeses,
                PrazoMaximoMeses = produto.PrazoMaximoMeses,
                ValorMinimoInvestimento = produto.ValorMinimoInvestimento,
                ValorMaximoInvestimento = produto.ValorMaximoInvestimento,
                Risco = produto.Risco
            };
        }
    }
}
