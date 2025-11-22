using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ListarTiposProdutoInvestimentoQueryTests
    {
        [Fact]
        public void ListarTiposProdutoInvestimentoQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ListarTiposProdutoInvestimentoQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<IEnumerable<TipoProdutoInvestimentoResponse>>>();
        }

        [Fact]
        public void ListarTiposProdutoInvestimentoQuery_DeveSerInstanciada()
        {
            // Arrange & Act
            var query = new ListarTiposProdutoInvestimentoQuery();

            // Assert
            query.Should().NotBeNull();
        }
    }
}
