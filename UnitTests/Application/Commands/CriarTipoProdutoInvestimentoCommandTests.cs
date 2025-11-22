using Application.Commands;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class CriarTipoProdutoInvestimentoCommandTests
    {
        [Fact]
        public void CriarTipoProdutoInvestimentoCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new CriarTipoProdutoInvestimentoCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<TipoProdutoInvestimentoResponse>>();
        }

        [Fact]
        public void CriarTipoProdutoInvestimentoCommand_DeveInicializarNomeCorretamente()
        {
            // Arrange & Act
            var command = new CriarTipoProdutoInvestimentoCommand
            {
                Nome = "Fundos Imobiliários"
            };

            // Assert
            command.Nome.Should().Be("Fundos Imobiliários");
        }

        [Theory]
        [InlineData("Renda Fixa")]
        [InlineData("Renda Variável")]
        [InlineData("Fundos")]
        [InlineData("Criptomoedas")]
        public void CriarTipoProdutoInvestimentoCommand_DeveAceitarDiferentesTipos(string nome)
        {
            // Arrange & Act
            var command = new CriarTipoProdutoInvestimentoCommand
            {
                Nome = nome
            };

            // Assert
            command.Nome.Should().Be(nome);
        }
    }
}
