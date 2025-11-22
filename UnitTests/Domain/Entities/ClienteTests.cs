using Domain.Entities;
using FluentAssertions;

namespace UnitTests.Domain.Entities
{
    public class ClienteTests
    {
        [Fact]
        public void Cliente_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var cliente = new Cliente
            {
                Id = 1,
                Nome = "João Silva",
                Email = "joao.silva@email.com",
                Cpf = "12345678901",
                DataCadastro = DateTimeOffset.UtcNow
            };

            // Assert
            cliente.Id.Should().Be(1);
            cliente.Nome.Should().Be("João Silva");
            cliente.Email.Should().Be("joao.silva@email.com");
            cliente.Cpf.Should().Be("12345678901");
            cliente.DataCadastro.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(1));
            cliente.Simulacoes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Cliente_DevePermitirAdicionarSimulacoes()
        {
            // Arrange
            var cliente = new Cliente { Id = 1, Nome = "Teste", Email = "teste@email.com", Cpf = "12345678901" };
            var simulacao = new SimulacaoInvestimento { Id = 1, ClienteId = 1, ProdutoId = 1 };

            // Act
            cliente.Simulacoes.Add(simulacao);

            // Assert
            cliente.Simulacoes.Should().HaveCount(1);
            cliente.Simulacoes.First().Should().Be(simulacao);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Cliente_DeveAceitarNomeVazio(string nome)
        {
            // Arrange & Act
            var cliente = new Cliente { Nome = nome };

            // Assert
            cliente.Nome.Should().Be(nome);
        }
    }
}
