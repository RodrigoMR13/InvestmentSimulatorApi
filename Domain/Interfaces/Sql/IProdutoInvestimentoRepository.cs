using Domain.Entities;

namespace Domain.Interfaces.Sql
{
    public interface IProdutoInvestimentoRepository
    {
        Task<IEnumerable<ProdutoInvestimento>> ListarPorTipoAsync(string tipoProduto);
        Task<IEnumerable<ProdutoInvestimento>> ListarPorRiscoAsync(string[] riscos);
        Task<IEnumerable<ProdutoInvestimento>> ListarTodosAsync();
        Task<ProdutoInvestimento?> ObterPorIdAsync(long produtoId);
        Task<ProdutoInvestimento> AdicionarAsync(ProdutoInvestimento produto);
        Task<ProdutoInvestimento> AtualizarAsync(ProdutoInvestimento produto);
        Task<bool> RemoverAsync(long produtoId);
    }
}
