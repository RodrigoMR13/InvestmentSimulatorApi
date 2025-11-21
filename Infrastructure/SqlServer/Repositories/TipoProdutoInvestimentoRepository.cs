using Domain.Entities;
using Domain.Interfaces.Sql;
using Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories
{
    public class TipoProdutoInvestimentoRepository : ITipoProdutoInvestimentoRepository
    {
        private readonly InvestimentosDbContext _context;

        public TipoProdutoInvestimentoRepository(InvestimentosDbContext context)
        {
            _context = context;
        }

        public async Task<TipoProdutoInvestimento?> ObterPorIdAsync(long id)
        {
            return await _context.TiposProdutoInvestimentos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TipoProdutoInvestimento>> ListarTodosAsync()
        {
            return await _context.TiposProdutoInvestimentos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TipoProdutoInvestimento> AdicionarAsync(TipoProdutoInvestimento tipoProduto)
        {
            _context.TiposProdutoInvestimentos.Add(tipoProduto);
            await _context.SaveChangesAsync();
            return tipoProduto;
        }

        public async Task<TipoProdutoInvestimento> AtualizarAsync(TipoProdutoInvestimento tipoProduto)
        {
            _context.TiposProdutoInvestimentos.Update(tipoProduto);
            await _context.SaveChangesAsync();
            return tipoProduto;
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var tipo = await _context.TiposProdutoInvestimentos.FindAsync(id);
            if (tipo == null)
                return false;

            _context.TiposProdutoInvestimentos.Remove(tipo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
