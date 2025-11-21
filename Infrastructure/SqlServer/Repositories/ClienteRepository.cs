using Domain.Entities;
using Domain.Interfaces.Sql;
using Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly InvestimentosDbContext _context;

        public ClienteRepository(InvestimentosDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> ObterPorIdAsync(long id)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cliente>> ListarTodosAsync()
        {
            return await _context.Clientes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> AdicionarAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> AtualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
