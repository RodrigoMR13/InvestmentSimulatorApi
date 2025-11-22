using Application.Commands;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class RemoverTipoProdutoInvestimentoCommandTests
    {
        [Fact]
        public void RemoverTipoProdutoInvestimentoCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new RemoverTipoProdutoInvestimentoCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<bool>>();
        }

        [Fact]
        public void RemoverTipoProdutoInvestimentoCommand_DeveInicializarIdCorretamente()
        {
            // Arrange & Act
            var command = new RemoverTipoProdutoInvestimentoCommand { Id = 5 };

            // Assert
            command.Id.Should().Be(5);
        }
    }
}
