using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IProdutoInvestimentoSelector
    {
        ProdutoInvestimento? SelecionarProdutoApropriado(
            IEnumerable<ProdutoInvestimento> produtos,
            decimal valorInvestimento,
            int prazoMeses);
    }
}
