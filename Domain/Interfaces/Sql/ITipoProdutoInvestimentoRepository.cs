using Domain.Entities;

namespace Domain.Interfaces.Sql
{
    public interface ITipoProdutoInvestimentoRepository
    {
        Task<TipoProdutoInvestimento?> ObterPorIdAsync(long id);
        Task<IEnumerable<TipoProdutoInvestimento>> ListarTodosAsync();
        Task<TipoProdutoInvestimento> AdicionarAsync(TipoProdutoInvestimento tipoProduto);
        Task<TipoProdutoInvestimento> AtualizarAsync(TipoProdutoInvestimento tipoProduto);
        Task<bool> RemoverAsync(long id);
    }
}
