using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ListarClientesQueryTests
    {
        [Fact]
        public void ListarClientesQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ListarClientesQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<IEnumerable<ClienteResponse>>>();
        }

        [Fact]
        public void ListarClientesQuery_DeveSerInstanciada()
        {
            // Arrange & Act
            var query = new ListarClientesQuery();

            // Assert
            query.Should().NotBeNull();
        }
    }
}
