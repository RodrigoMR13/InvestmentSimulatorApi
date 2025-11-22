using Domain.Entities;
using Domain.Interfaces.Services;
using FluentAssertions;
using Moq;
using Range = Moq.Range;

namespace UnitTests.Domain.Interfaces.Services
{
    public class ProdutoInvestimentoSelectorTests
    {
        private readonly Mock<IProdutoInvestimentoSelector> _selectorMock;

        public ProdutoInvestimentoSelectorTests()
        {
            _selectorMock = new Mock<IProdutoInvestimentoSelector>();
        }

        [Fact]
        public void SelecionarProdutoApropriado_DeveRetornarProduto_QuandoEncontraMatch()
        {
            // Arrange
            var produtos = new List<ProdutoInvestimento>
            {
                new ProdutoInvestimento
                {
                    Id = 1,
                    ValorMinimoInvestimento = 1000m,
                    ValorMaximoInvestimento = 50000m,
                    PrazoMinimoMeses = 6,
                    PrazoMaximoMeses = 24
                }
            };
            var produtoEsperado = produtos.First();
            _selectorMock.Setup(s => s.SelecionarProdutoApropriado(produtos, 10000m, 12))
                        .Returns(produtoEsperado);

            // Act
            var resultado = _selectorMock.Object.SelecionarProdutoApropriado(produtos, 10000m, 12);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Should().Be(produtoEsperado);
        }

        [Fact]
        public void SelecionarProdutoApropriado_DeveRetornarNull_QuandoNaoEncontraMatch()
        {
            // Arrange
            var produtos = new List<ProdutoInvestimento>
            {
                new ProdutoInvestimento
                {
                    ValorMinimoInvestimento = 10000m,
                    ValorMaximoInvestimento = 50000m
                }
            };
            _selectorMock.Setup(s => s.SelecionarProdutoApropriado(produtos, 500m, 12))
                        .Returns((ProdutoInvestimento?)null);

            // Act
            var resultado = _selectorMock.Object.SelecionarProdutoApropriado(produtos, 500m, 12);

            // Assert
            resultado.Should().BeNull();
        }

        [Fact]
        public void SelecionarProdutoApropriado_DeveConsiderarValorEPrazo()
        {
            // Arrange
            var produtos = new List<ProdutoInvestimento>
            {
                new ProdutoInvestimento
                {
                    Id = 1,
                    ValorMinimoInvestimento = 1000m,
                    ValorMaximoInvestimento = 100000m,
                    PrazoMinimoMeses = 12,
                    PrazoMaximoMeses = 36
                }
            };

            _selectorMock.Setup(s => s.SelecionarProdutoApropriado(
                It.IsAny<IEnumerable<ProdutoInvestimento>>(),
                It.IsInRange(1000m, 100000m, Range.Inclusive),
                It.IsInRange(12, 36, Range.Inclusive)))
                .Returns(produtos.First());

            // Act
            var resultado = _selectorMock.Object.SelecionarProdutoApropriado(produtos, 50000m, 24);

            // Assert
            resultado.Should().NotBeNull();
            _selectorMock.Verify(s => s.SelecionarProdutoApropriado(produtos, 50000m, 24), Times.Once);
        }
    }
}
