using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterClientePorIdQueryTests
    {
        [Fact]
        public void ObterClientePorIdQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterClientePorIdQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<ClienteResponse?>>();
        }

        [Fact]
        public void ObterClientePorIdQuery_DeveInicializarIdCorretamente()
        {
            // Arrange & Act
            var query = new ObterClientePorIdQuery { Id = 42 };

            // Assert
            query.Id.Should().Be(42);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(999)]
        public void ObterClientePorIdQuery_DeveAceitarDiferentesIds(long id)
        {
            // Arrange & Act
            var query = new ObterClientePorIdQuery { Id = id };

            // Assert
            query.Id.Should().Be(id);
        }
    }
}
