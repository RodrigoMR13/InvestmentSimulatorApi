using Domain.Entities;
using Domain.Interfaces.Sql;
using FluentAssertions;
using Moq;

namespace UnitTests.Domain.Interfaces.Sql
{
    public class SimulacaoInvestimentoRepositoryTests
    {
        private readonly Mock<ISimulacaoInvestimentoRepository> _repositoryMock;

        public SimulacaoInvestimentoRepositoryTests()
        {
            _repositoryMock = new Mock<ISimulacaoInvestimentoRepository>();
        }

        [Fact]
        public async Task ListarPorClienteAsync_DeveRetornarSimulacoesDoCliente()
        {
            // Arrange
            var simulacoes = new List<SimulacaoInvestimento>
            {
                new SimulacaoInvestimento { Id = 1, ClienteId = 1, ProdutoId = 1, ValorInvestido = 1000m },
                new SimulacaoInvestimento { Id = 2, ClienteId = 1, ProdutoId = 2, ValorInvestido = 2000m }
            };
            _repositoryMock.Setup(r => r.ListarPorClienteAsync(1)).ReturnsAsync(simulacoes);

            // Act
            var resultado = await _repositoryMock.Object.ListarPorClienteAsync(1);

            // Assert
            resultado.Should().HaveCount(2);
            resultado.All(s => s.ClienteId == 1).Should().BeTrue();
        }

        [Fact]
        public async Task ListarPorDiaAsync_DeveRetornarSimulacoesNoPeriodo()
        {
            // Arrange
            var inicio = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var fim = new DateTimeOffset(2025, 1, 31, 23, 59, 59, TimeSpan.Zero);
            var simulacoes = new List<SimulacaoInvestimento>
            {
                new SimulacaoInvestimento { Id = 1, DataSimulacao = new DateTimeOffset(2025, 1, 15, 10, 0, 0, TimeSpan.Zero) }
            };
            _repositoryMock.Setup(r => r.ListarPorDiaAsync(inicio, fim)).ReturnsAsync(simulacoes);

            // Act
            var resultado = await _repositoryMock.Object.ListarPorDiaAsync(inicio, fim);

            // Assert
            resultado.Should().HaveCount(1);
            resultado.First().DataSimulacao.Should().BeOnOrAfter(inicio).And.BeOnOrBefore(fim);
        }

        [Fact]
        public async Task AdicionarAsync_DeveRetornarSimulacaoAdicionada()
        {
            // Arrange
            var novaSimulacao = new SimulacaoInvestimento { ClienteId = 1, ProdutoId = 1, ValorInvestido = 5000m };
            var simulacaoAdicionada = new SimulacaoInvestimento { Id = 1, ClienteId = 1, ProdutoId = 1, ValorInvestido = 5000m };
            _repositoryMock.Setup(r => r.AdicionarAsync(novaSimulacao)).ReturnsAsync(simulacaoAdicionada);

            // Act
            var resultado = await _repositoryMock.Object.AdicionarAsync(novaSimulacao);

            // Assert
            resultado.Id.Should().Be(1);
            resultado.ValorInvestido.Should().Be(5000m);
        }
    }
}
