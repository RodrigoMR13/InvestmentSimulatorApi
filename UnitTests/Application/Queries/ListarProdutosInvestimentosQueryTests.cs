using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ListarProdutosInvestimentosQueryTests
    {
        [Fact]
        public void ListarProdutosInvestimentosQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ListarProdutosInvestimentosQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<IEnumerable<ProdutoInvestimentoResponse>>>();
        }

        [Fact]
        public void ListarProdutosInvestimentosQuery_DeveSerInstanciada()
        {
            // Arrange & Act
            var query = new ListarProdutosInvestimentosQuery();

            // Assert
            query.Should().NotBeNull();
        }
    }
}
