using Domain.Entities;
using Domain.Interfaces.Sql;
using Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories
{
    public class SimulacaoInvestimentoRepository : ISimulacaoInvestimentoRepository
    {
        private readonly InvestimentosDbContext _context;

        public SimulacaoInvestimentoRepository(InvestimentosDbContext context)
        {
            _context = context;
        }

        public async Task<SimulacaoInvestimento?> ObterPorIdAsync(long id)
        {
            return await _context.SimulacaoInvestimentos
                .AsNoTracking()
                .Include(s => s.Cliente)
                .Include(s => s.Produto)
                    .ThenInclude(p => p.Tipo)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SimulacaoInvestimento>> ListarTodosAsync()
        {
            return await _context.SimulacaoInvestimentos
                .AsNoTracking()
                .Include(s => s.Cliente)
                .Include(s => s.Produto)
                    .ThenInclude(p => p.Tipo)
                .ToListAsync();
        }

        public async Task<IEnumerable<SimulacaoInvestimento>> ListarPorClienteAsync(long clienteId)
        {
            return await _context.SimulacaoInvestimentos
                .AsNoTracking()
                .Include(s => s.Cliente)
                .Include(s => s.Produto)
                    .ThenInclude(p => p.Tipo)
                .Where(s => s.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SimulacaoInvestimento>> ListarPorDiaAsync(
            DateTimeOffset inicioUtc, DateTimeOffset fimUtc)
        {
            return await _context.SimulacaoInvestimentos
                .AsNoTracking()
                .Include(s => s.Cliente)
                .Include(s => s.Produto)
                    .ThenInclude(p => p.Tipo)
                .Where(s => s.DataSimulacao >= inicioUtc &&
                            s.DataSimulacao < fimUtc)
                .ToListAsync();
        }

        public async Task<SimulacaoInvestimento> AdicionarAsync(SimulacaoInvestimento simulacao)
        {
            _context.SimulacaoInvestimentos.Add(simulacao);
            await _context.SaveChangesAsync();
            return simulacao;
        }

        public async Task<SimulacaoInvestimento> AtualizarAsync(SimulacaoInvestimento simulacao)
        {
            _context.SimulacaoInvestimentos.Update(simulacao);
            await _context.SaveChangesAsync();
            return simulacao;
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var simulacao = await _context.SimulacaoInvestimentos.FindAsync(id);
            if (simulacao == null)
                return false;

            _context.SimulacaoInvestimentos.Remove(simulacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
