using Application.Commands;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class CriarProdutoInvestimentoCommandTests
    {
        [Fact]
        public void CriarProdutoInvestimentoCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new CriarProdutoInvestimentoCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<ProdutoInvestimentoResponse>>();
        }

        [Fact]
        public void CriarProdutoInvestimentoCommand_DeveInicializarTodasPropriedades()
        {
            // Arrange & Act
            var command = new CriarProdutoInvestimentoCommand
            {
                Nome = "LCI",
                Rentabilidade = 0.10m,
                TipoId = 1,
                PrazoMinimoMeses = 12,
                PrazoMaximoMeses = 36,
                ValorMinimoInvestimento = 5000m,
                ValorMaximoInvestimento = 500000m,
                Risco = "Médio"
            };

            // Assert
            command.Nome.Should().Be("LCI");
            command.Rentabilidade.Should().Be(0.10m);
            command.TipoId.Should().Be(1);
            command.PrazoMinimoMeses.Should().Be(12);
            command.PrazoMaximoMeses.Should().Be(36);
            command.ValorMinimoInvestimento.Should().Be(5000m);
            command.ValorMaximoInvestimento.Should().Be(500000m);
            command.Risco.Should().Be("Médio");
        }

        [Fact]
        public void CriarProdutoInvestimentoCommand_DevePermitirValoresDecimaisPrecisosParaRentabilidade()
        {
            // Arrange & Act
            var command = new CriarProdutoInvestimentoCommand
            {
                Rentabilidade = 0.123456m
            };

            // Assert
            command.Rentabilidade.Should().Be(0.123456m);
        }
    }
}
