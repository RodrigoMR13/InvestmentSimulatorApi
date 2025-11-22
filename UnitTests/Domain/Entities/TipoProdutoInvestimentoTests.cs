using Domain.Entities;
using FluentAssertions;

namespace UnitTests.Domain.Entities
{
    public class TipoProdutoInvestimentoTests
    {
        [Fact]
        public void TipoProdutoInvestimento_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var tipo = new TipoProdutoInvestimento
            {
                Id = 1,
                Nome = "Renda Fixa"
            };

            // Assert
            tipo.Id.Should().Be(1);
            tipo.Nome.Should().Be("Renda Fixa");
        }

        [Theory]
        [InlineData("Renda Fixa")]
        [InlineData("Renda Variável")]
        [InlineData("Fundos")]
        public void TipoProdutoInvestimento_DeveAceitarDiferentesTipos(string nome)
        {
            // Arrange & Act
            var tipo = new TipoProdutoInvestimento { Nome = nome };

            // Assert
            tipo.Nome.Should().Be(nome);
        }
    }
}
