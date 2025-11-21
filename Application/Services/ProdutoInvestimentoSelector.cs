using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class ProdutoInvestimentoSelector : IProdutoInvestimentoSelector
    {
        public ProdutoInvestimento? SelecionarProdutoApropriado(
            IEnumerable<ProdutoInvestimento> produtos,
            decimal valorInvestimento,
            int prazoMeses)
        {
            return produtos.FirstOrDefault(p =>
                p.PrazoMinimoMeses <= prazoMeses &&
                p.PrazoMaximoMeses >= prazoMeses &&
                p.ValorMinimoInvestimento <= valorInvestimento &&
                p.ValorMaximoInvestimento >= valorInvestimento
                );
        }
    }
}
