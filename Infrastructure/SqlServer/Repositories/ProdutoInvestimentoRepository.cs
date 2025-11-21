using Domain.Entities;
using Domain.Interfaces.Sql;
using Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories
{
    public class ProdutoInvestimentoRepository : IProdutoInvestimentoRepository
    {
        private readonly InvestimentosDbContext _context;

        public ProdutoInvestimentoRepository(InvestimentosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoInvestimento>> ListarPorTipoAsync(string tipoProduto)
        {
            return await _context.ProdutosInvestimentos
                .AsNoTracking()
                .Include(p => p.Tipo)
                .Where(p => p.Tipo.Nome.ToLower() == tipoProduto.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<ProdutoInvestimento>> ListarTodosAsync()
        {
            return await _context.ProdutosInvestimentos
                .AsNoTracking()
                .Include(p => p.Tipo)
                .ToListAsync();
        }

        public async Task<ProdutoInvestimento?> ObterPorIdAsync(long produtoId)
        {
            return await _context.ProdutosInvestimentos
                .AsNoTracking()
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(p => p.Id == produtoId);
        }

        public async Task<ProdutoInvestimento> AdicionarAsync(ProdutoInvestimento produto)
        {
            _context.ProdutosInvestimentos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoInvestimento> AtualizarAsync(ProdutoInvestimento produto)
        {
            _context.ProdutosInvestimentos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task<bool> RemoverAsync(long produtoId)
        {
            var produto = await _context.ProdutosInvestimentos
                .FirstOrDefaultAsync(p => p.Id == produtoId);

            if (produto == null)
                return false;

            _context.ProdutosInvestimentos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
