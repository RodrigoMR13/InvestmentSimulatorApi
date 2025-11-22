using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterProdutoInvestimentoPorIdQueryTests
    {
        [Fact]
        public void ObterProdutoInvestimentoPorIdQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterProdutoInvestimentoPorIdQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<ProdutoInvestimentoResponse?>>();
        }

        [Fact]
        public void ObterProdutoInvestimentoPorIdQuery_DeveInicializarIdCorretamente()
        {
            // Arrange & Act
            var query = new ObterProdutoInvestimentoPorIdQuery { Id = 7 };

            // Assert
            query.Id.Should().Be(7);
        }
    }
}
