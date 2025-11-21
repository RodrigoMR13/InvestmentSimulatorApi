using Domain.Entities;

namespace Domain.Interfaces.Sql
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObterPorIdAsync(long id);
        Task<IEnumerable<Cliente>> ListarTodosAsync();
        Task<Cliente> AdicionarAsync(Cliente cliente);
        Task<Cliente> AtualizarAsync(Cliente cliente);
        Task<bool> RemoverAsync(long id);
    }
}
