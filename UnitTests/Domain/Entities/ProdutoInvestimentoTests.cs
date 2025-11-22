using Domain.Entities;
using FluentAssertions;

namespace UnitTests.Domain.Entities
{
    public class ProdutoInvestimentoTests
    {
        [Fact]
        public void ProdutoInvestimento_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var produto = new ProdutoInvestimento
            {
                Id = 1,
                Nome = "CDB Bancário",
                TipoId = 1,
                PrazoMinimoMeses = 6,
                PrazoMaximoMeses = 24,
                ValorMinimoInvestimento = 1000m,
                ValorMaximoInvestimento = 100000m,
                Rentabilidade = 0.12m,
                Risco = "Baixo",
                DataCadastro = DateTimeOffset.UtcNow
            };

            // Assert
            produto.Id.Should().Be(1);
            produto.Nome.Should().Be("CDB Bancário");
            produto.TipoId.Should().Be(1);
            produto.PrazoMinimoMeses.Should().Be(6);
            produto.PrazoMaximoMeses.Should().Be(24);
            produto.ValorMinimoInvestimento.Should().Be(1000m);
            produto.ValorMaximoInvestimento.Should().Be(100000m);
            produto.Rentabilidade.Should().Be(0.12m);
            produto.Risco.Should().Be("Baixo");
        }

        [Theory]
        [InlineData("Baixo")]
        [InlineData("Médio")]
        [InlineData("Alto")]
        public void ProdutoInvestimento_DeveAceitarDiferentesNiveisRisco(string risco)
        {
            // Arrange & Act
            var produto = new ProdutoInvestimento { Risco = risco };

            // Assert
            produto.Risco.Should().Be(risco);
        }

        [Fact]
        public void ProdutoInvestimento_DevePermitirValoresDecimaisPrecisosParaRentabilidade()
        {
            // Arrange & Act
            var produto = new ProdutoInvestimento { Rentabilidade = 0.123456m };

            // Assert
            produto.Rentabilidade.Should().Be(0.123456m);
        }
    }
}
