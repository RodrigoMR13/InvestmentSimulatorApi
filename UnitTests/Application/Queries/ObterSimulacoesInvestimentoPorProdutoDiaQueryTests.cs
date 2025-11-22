using Application.Queries;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Queries
{
    public class ObterSimulacoesInvestimentoPorProdutoDiaQueryTests
    {
        [Fact]
        public void ObterSimulacoesInvestimentoPorProdutoDiaQuery_DeveImplementarIRequest()
        {
            // Arrange & Act
            var query = new ObterSimulacoesInvestimentoPorProdutoDiaQuery();

            // Assert
            query.Should().BeAssignableTo<IRequest<IEnumerable<ObterSimulacaoInvestimentoPorProdutoDiaResponse>>>();
        }

        [Fact]
        public void ObterSimulacoesInvestimentoPorProdutoDiaQuery_DeveInicializarDataComHoje()
        {
            // Arrange & Act
            var query = new ObterSimulacoesInvestimentoPorProdutoDiaQuery();

            // Assert
            query.Data.Should().Be(DateTime.Today);
        }

        [Fact]
        public void ObterSimulacoesInvestimentoPorProdutoDiaQuery_DevePermitirDefinirDataEspecifica()
        {
            // Arrange
            var dataEspecifica = new DateTime(2025, 11, 20);

            // Act
            var query = new ObterSimulacoesInvestimentoPorProdutoDiaQuery
            {
                Data = dataEspecifica
            };

            // Assert
            query.Data.Should().Be(dataEspecifica);
        }

        [Theory]
        [InlineData(2025, 1, 1)]
        [InlineData(2025, 6, 15)]
        [InlineData(2025, 12, 31)]
        public void ObterSimulacoesInvestimentoPorProdutoDiaQuery_DeveAceitarDiferentasDatas(int ano, int mes, int dia)
        {
            // Arrange
            var data = new DateTime(ano, mes, dia);

            // Act
            var query = new ObterSimulacoesInvestimentoPorProdutoDiaQuery
            {
                Data = data
            };

            // Assert
            query.Data.Should().Be(data);
        }
    }
}
