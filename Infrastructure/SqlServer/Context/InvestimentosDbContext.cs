using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Context
{
    public class InvestimentosDbContext : DbContext
    {
        public InvestimentosDbContext(DbContextOptions<InvestimentosDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoInvestimento> ProdutosInvestimentos { get; set; }
        public DbSet<TipoProdutoInvestimento> TiposProdutoInvestimentos { get; set; }
        public DbSet<SimulacaoInvestimento> SimulacaoInvestimentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ProdutoInvestimento
            modelBuilder.Entity<ProdutoInvestimento>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProdutoInvestimento>()
                .Property(p => p.Rentabilidade)
                .HasPrecision(18, 6);

            modelBuilder.Entity<ProdutoInvestimento>()
                .Property(p => p.ValorMinimoInvestimento)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProdutoInvestimento>()
                .Property(p => p.ValorMaximoInvestimento)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProdutoInvestimento>()
                .Property(p => p.DataCadastro)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            modelBuilder.Entity<ProdutoInvestimento>()
                .HasOne(p => p.Tipo)
                .WithMany()
                .HasForeignKey(p => p.TipoId)
                .OnDelete(DeleteBehavior.Restrict);

            // TipoProdutoInvestimento
            modelBuilder.Entity<TipoProdutoInvestimento>()
                .HasKey(t => t.Id);

            // SimulacaoInvestimento
            modelBuilder.Entity<SimulacaoInvestimento>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<SimulacaoInvestimento>()
                .Property(s => s.ValorInvestido)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SimulacaoInvestimento>()
                .Property(s => s.ValorFinal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SimulacaoInvestimento>()
                .Property(p => p.DataSimulacao)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            modelBuilder.Entity<SimulacaoInvestimento>()
                .HasOne(s => s.Cliente)
                .WithMany(c => c.Simulacoes)
                .HasForeignKey(s => s.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SimulacaoInvestimento>()
                .HasOne(s => s.Produto)
                .WithMany()
                .HasForeignKey(s => s.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cliente
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .HasMaxLength(150);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Email)
                .HasMaxLength(150);

            modelBuilder.Entity<Cliente>()
                .Property(p => p.DataCadastro)
                .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
