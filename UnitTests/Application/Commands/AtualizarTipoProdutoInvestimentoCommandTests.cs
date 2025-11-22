using Application.Commands;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class AtualizarTipoProdutoInvestimentoCommandTests
    {
        [Fact]
        public void AtualizarTipoProdutoInvestimentoCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new AtualizarTipoProdutoInvestimentoCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<TipoProdutoInvestimentoResponse?>>();
        }

        [Fact]
        public void AtualizarTipoProdutoInvestimentoCommand_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var command = new AtualizarTipoProdutoInvestimentoCommand
            {
                Id = 1,
                Nome = "Renda Fixa"
            };

            // Assert
            command.Id.Should().Be(1);
            command.Nome.Should().Be("Renda Fixa");
        }
    }
}
