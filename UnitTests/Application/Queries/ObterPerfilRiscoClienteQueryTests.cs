using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterPerfilRiscoClienteQueryTests
    {
        [Fact]
        public void ObterPerfilRiscoClienteQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterPerfilRiscoClienteQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<PerfilRiscoClienteResponse>>();
        }

        [Fact]
        public void ObterPerfilRiscoClienteQuery_DeveInicializarClienteIdCorretamente()
        {
            // Arrange & Act
            var query = new ObterPerfilRiscoClienteQuery { ClienteId = 25 };

            // Assert
            query.ClienteId.Should().Be(25);
        }
    }
}
