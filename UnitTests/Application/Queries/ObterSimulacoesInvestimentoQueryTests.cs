using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterSimulacoesInvestimentoQueryTests
    {
        [Fact]
        public void ObterSimulacoesInvestimentoQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterSimulacoesInvestimentoQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<ObterSimulacoesInvestimentoResponse?>>();
        }

        [Fact]
        public void ObterSimulacoesInvestimentoQuery_DeveSerInstanciada()
        {
            // Arrange & Act
            var query = new ObterSimulacoesInvestimentoQuery();

            // Assert
            query.Should().NotBeNull();
        }
    }
}
