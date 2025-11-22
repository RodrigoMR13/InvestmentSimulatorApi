using Domain.Entities;
using Domain.Interfaces.Sql;
using FluentAssertions;
using Moq;

namespace UnitTests.Domain.Interfaces.Sql
{
    public class TipoProdutoInvestimentoRepositoryTests
    {
        private readonly Mock<ITipoProdutoInvestimentoRepository> _repositoryMock;

        public TipoProdutoInvestimentoRepositoryTests()
        {
            _repositoryMock = new Mock<ITipoProdutoInvestimentoRepository>();
        }

        [Fact]
        public async Task ObterPorIdAsync_DeveRetornarTipo_QuandoExiste()
        {
            // Arrange
            var tipo = new TipoProdutoInvestimento { Id = 1, Nome = "Renda Fixa" };
            _repositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(tipo);

            // Act
            var resultado = await _repositoryMock.Object.ObterPorIdAsync(1);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Nome.Should().Be("Renda Fixa");
        }

        [Fact]
        public async Task ListarTodosAsync_DeveRetornarTodosTipos()
        {
            // Arrange
            var tipos = new List<TipoProdutoInvestimento>
            {
                new TipoProdutoInvestimento { Id = 1, Nome = "Renda Fixa" },
                new TipoProdutoInvestimento { Id = 2, Nome = "Renda Variável" }
            };
            _repositoryMock.Setup(r => r.ListarTodosAsync()).ReturnsAsync(tipos);

            // Act
            var resultado = await _repositoryMock.Object.ListarTodosAsync();

            // Assert
            resultado.Should().HaveCount(2);
        }
    }
}
