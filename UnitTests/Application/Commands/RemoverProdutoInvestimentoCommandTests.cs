using Application.Commands;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class RemoverProdutoInvestimentoCommandTests
    {
        [Fact]
        public void RemoverProdutoInvestimentoCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new RemoverProdutoInvestimentoCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<bool>>();
        }

        [Fact]
        public void RemoverProdutoInvestimentoCommand_DeveInicializarIdCorretamente()
        {
            // Arrange & Act
            var command = new RemoverProdutoInvestimentoCommand { Id = 10 };

            // Assert
            command.Id.Should().Be(10);
        }
    }
}
