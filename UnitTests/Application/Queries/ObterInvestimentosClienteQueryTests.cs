using Application.Queries;
using Application.Results;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterInvestimentosClienteQueryTests
    {
        [Fact]
        public void ObterInvestimentosClienteQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterInvestimentosClienteQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<IEnumerable<InvestimentoResult>>>();
        }

        [Fact]
        public void ObterInvestimentosClienteQuery_DeveInicializarClienteIdCorretamente()
        {
            // Arrange & Act
            var query = new ObterInvestimentosClienteQuery { ClienteId = 10 };

            // Assert
            query.ClienteId.Should().Be(10);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(1000)]
        public void ObterInvestimentosClienteQuery_DeveAceitarDiferentesClienteIds(long clienteId)
        {
            // Arrange & Act
            var query = new ObterInvestimentosClienteQuery { ClienteId = clienteId };

            // Assert
            query.ClienteId.Should().Be(clienteId);
        }
    }
}
