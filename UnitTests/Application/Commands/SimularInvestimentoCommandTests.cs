using Application.Commands;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class SimularInvestimentoCommandTests
    {
        [Fact]
        public void SimularInvestimentoCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new SimularInvestimentoCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<SimularInvestimentoResponse>>();
        }

        [Fact]
        public void SimularInvestimentoCommand_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var command = new SimularInvestimentoCommand
            {
                ClienteId = 1,
                Valor = 10000m,
                PrazoMeses = 12,
                TipoProduto = "Renda Fixa"
            };

            // Assert
            command.ClienteId.Should().Be(1);
            command.Valor.Should().Be(10000m);
            command.PrazoMeses.Should().Be(12);
            command.TipoProduto.Should().Be("Renda Fixa");
        }

        [Theory]
        [InlineData(1000, 6)]
        [InlineData(50000, 24)]
        [InlineData(100000, 36)]
        public void SimularInvestimentoCommand_DeveAceitarDiferentesValoresEPrazos(decimal valor, int prazo)
        {
            // Arrange & Act
            var command = new SimularInvestimentoCommand
            {
                Valor = valor,
                PrazoMeses = prazo
            };

            // Assert
            command.Valor.Should().Be(valor);
            command.PrazoMeses.Should().Be(prazo);
        }

        [Theory]
        [InlineData("Renda Fixa")]
        [InlineData("Renda Variável")]
        [InlineData("Fundos")]
        public void SimularInvestimentoCommand_DeveAceitarDiferentesTiposProduto(string tipoProduto)
        {
            // Arrange & Act
            var command = new SimularInvestimentoCommand
            {
                TipoProduto = tipoProduto
            };

            // Assert
            command.TipoProduto.Should().Be(tipoProduto);
        }
    }
}
