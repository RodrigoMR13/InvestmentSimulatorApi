using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterProdutosRecomendadosQueryTests
    {
        [Fact]
        public void ObterProdutosRecomendadosQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterProdutosRecomendadosQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<IEnumerable<ProdutoRecomendadoResponse>>>();
        }

        [Fact]
        public void ObterProdutosRecomendadosQuery_DeveInicializarPerfilCorretamente()
        {
            // Arrange & Act
            var query = new ObterProdutosRecomendadosQuery { Perfil = "Conservador" };

            // Assert
            query.Perfil.Should().Be("Conservador");
        }

        [Theory]
        [InlineData("Conservador")]
        [InlineData("Moderado")]
        [InlineData("Agressivo")]
        public void ObterProdutosRecomendadosQuery_DeveAceitarDiferentesPerfis(string perfil)
        {
            // Arrange & Act
            var query = new ObterProdutosRecomendadosQuery { Perfil = perfil };

            // Assert
            query.Perfil.Should().Be(perfil);
        }

        [Fact]
        public void ObterProdutosRecomendadosQuery_DeveInicializarPerfilVazioPorPadrao()
        {
            // Arrange & Act
            var query = new ObterProdutosRecomendadosQuery();

            // Assert
            query.Perfil.Should().BeEmpty();
        }
    }
}
