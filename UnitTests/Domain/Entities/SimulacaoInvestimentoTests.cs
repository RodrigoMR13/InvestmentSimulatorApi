using Domain.Entities;
using FluentAssertions;

namespace UnitTests.Domain.Entities
{
    public class SimulacaoInvestimentoTests
    {
        [Fact]
        public void SimulacaoInvestimento_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var simulacao = new SimulacaoInvestimento
            {
                Id = 1,
                ClienteId = 1,
                ProdutoId = 1,
                ValorInvestido = 10000m,
                ValorFinal = 11200m,
                PrazoMeses = 12,
                DataSimulacao = DateTimeOffset.UtcNow
            };

            // Assert
            simulacao.Id.Should().Be(1);
            simulacao.ClienteId.Should().Be(1);
            simulacao.ProdutoId.Should().Be(1);
            simulacao.ValorInvestido.Should().Be(10000m);
            simulacao.ValorFinal.Should().Be(11200m);
            simulacao.PrazoMeses.Should().Be(12);
            simulacao.DataSimulacao.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void SimulacaoInvestimento_DeveCalcularRendimentoCorretamente()
        {
            // Arrange
            var simulacao = new SimulacaoInvestimento
            {
                ValorInvestido = 10000m,
                ValorFinal = 11200m
            };

            // Act
            var rendimento = simulacao.ValorFinal - simulacao.ValorInvestido;

            // Assert
            rendimento.Should().Be(1200m);
        }

        [Fact]
        public void SimulacaoInvestimento_DevePermitirRelacionamentoComClienteEProduto()
        {
            // Arrange
            var cliente = new Cliente { Id = 1, Nome = "João", Email = "joao@email.com", Cpf = "12345678901" };
            var produto = new ProdutoInvestimento { Id = 1, Nome = "CDB" };

            // Act
            var simulacao = new SimulacaoInvestimento
            {
                ClienteId = cliente.Id,
                Cliente = cliente,
                ProdutoId = produto.Id,
                Produto = produto
            };

            // Assert
            simulacao.Cliente.Should().Be(cliente);
            simulacao.Produto.Should().Be(produto);
            simulacao.ClienteId.Should().Be(cliente.Id);
            simulacao.ProdutoId.Should().Be(produto.Id);
        }
    }
}
