using Domain.Entities;

namespace Domain.Interfaces.Sql
{
    public interface ISimulacaoInvestimentoRepository
    {
        Task<SimulacaoInvestimento?> ObterPorIdAsync(long id);
        Task<IEnumerable<SimulacaoInvestimento>> ListarTodosAsync();
        Task<IEnumerable<SimulacaoInvestimento>> ListarPorClienteAsync(long clienteId);
        Task<IEnumerable<SimulacaoInvestimento>> ListarPorDiaAsync(DateTimeOffset inicioUtc, DateTimeOffset fimUtc);
        Task<SimulacaoInvestimento> AdicionarAsync(SimulacaoInvestimento simulacao);
        Task<SimulacaoInvestimento> AtualizarAsync(SimulacaoInvestimento simulacao);
        Task<bool> RemoverAsync(long id);
    }
}
