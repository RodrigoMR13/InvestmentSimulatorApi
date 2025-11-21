using Application.Responses;
using Domain.Entities;

namespace Application.Mappers
{
    public static class TipoProdutoInvestimentoMapper
    {
        public static TipoProdutoInvestimentoResponse ToTipoProdutoInvestimentoResponse(
            this TipoProdutoInvestimento entity)
        {
            return new TipoProdutoInvestimentoResponse
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }   
    }
}
