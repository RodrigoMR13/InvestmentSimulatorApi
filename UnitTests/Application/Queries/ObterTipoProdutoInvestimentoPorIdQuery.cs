using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterTipoProdutoInvestimentoPorIdQueryTests
    {
        [Fact]
        public void ObterTipoProdutoInvestimentoPorIdQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterTipoProdutoInvestimentoPorIdQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<TipoProdutoInvestimentoResponse?>>();
        }

        [Fact]
        public void ObterTipoProdutoInvestimentoPorIdQuery_DeveInicializarIdCorretamente()
        {
            // Arrange & Act
            var query = new ObterTipoProdutoInvestimentoPorIdQuery { Id = 3 };

            // Assert
            query.Id.Should().Be(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void ObterTipoProdutoInvestimentoPorIdQuery_DeveAceitarDiferentesIds(long id)
        {
            // Arrange & Act
            var query = new ObterTipoProdutoInvestimentoPorIdQuery { Id = id };

            // Assert
            query.Id.Should().Be(id);
        }
    }
}
