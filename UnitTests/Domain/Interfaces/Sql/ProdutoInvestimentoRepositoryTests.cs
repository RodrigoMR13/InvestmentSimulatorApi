using Domain.Entities;
using Domain.Interfaces.Sql;
using FluentAssertions;
using Moq;

namespace UnitTests.Domain.Interfaces.Sql
{
    public class ProdutoInvestimentoRepositoryTests
    {
        private readonly Mock<IProdutoInvestimentoRepository> _repositoryMock;

        public ProdutoInvestimentoRepositoryTests()
        {
            _repositoryMock = new Mock<IProdutoInvestimentoRepository>();
        }

        [Fact]
        public async Task ListarPorTipoAsync_DeveRetornarProdutosDoTipo()
        {
            // Arrange
            var produtos = new List<ProdutoInvestimento>
            {
                new ProdutoInvestimento { Id = 1, Nome = "CDB", TipoId = 1 },
                new ProdutoInvestimento { Id = 2, Nome = "LCI", TipoId = 1 }
            };
            _repositoryMock.Setup(r => r.ListarPorTipoAsync("Renda Fixa")).ReturnsAsync(produtos);

            // Act
            var resultado = await _repositoryMock.Object.ListarPorTipoAsync("Renda Fixa");

            // Assert
            resultado.Should().HaveCount(2);
            resultado.All(p => p.TipoId == 1).Should().BeTrue();
        }

        [Fact]
        public async Task ListarPorRiscoAsync_DeveRetornarProdutosComRiscosEspecificados()
        {
            // Arrange
            var riscos = new[] { "Baixo", "Médio" };
            var produtos = new List<ProdutoInvestimento>
            {
                new ProdutoInvestimento { Id = 1, Nome = "CDB", Risco = "Baixo" },
                new ProdutoInvestimento { Id = 2, Nome = "Debênture", Risco = "Médio" }
            };
            _repositoryMock.Setup(r => r.ListarPorRiscoAsync(riscos)).ReturnsAsync(produtos);

            // Act
            var resultado = await _repositoryMock.Object.ListarPorRiscoAsync(riscos);

            // Assert
            resultado.Should().HaveCount(2);
            resultado.All(p => riscos.Contains(p.Risco)).Should().BeTrue();
        }

        [Fact]
        public async Task ObterPorIdAsync_DeveRetornarProduto_QuandoExiste()
        {
            // Arrange
            var produto = new ProdutoInvestimento { Id = 1, Nome = "CDB" };
            _repositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(produto);

            // Act
            var resultado = await _repositoryMock.Object.ObterPorIdAsync(1);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Should().Be(produto);
        }

        [Fact]
        public async Task AdicionarAsync_DeveRetornarProdutoAdicionado()
        {
            // Arrange
            var novoProduto = new ProdutoInvestimento { Nome = "LCA" };
            var produtoAdicionado = new ProdutoInvestimento { Id = 1, Nome = "LCA" };
            _repositoryMock.Setup(r => r.AdicionarAsync(novoProduto)).ReturnsAsync(produtoAdicionado);

            // Act
            var resultado = await _repositoryMock.Object.AdicionarAsync(novoProduto);

            // Assert
            resultado.Id.Should().Be(1);
            resultado.Nome.Should().Be("LCA");
        }
    }

}
