using Application.Commands;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class RemoverClienteCommandTests
    {
        [Fact]
        public void RemoverClienteCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new RemoverClienteCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<bool>>();
        }

        [Fact]
        public void RemoverClienteCommand_DeveInicializarIdCorretamente()
        {
            // Arrange & Act
            var command = new RemoverClienteCommand { Id = 42 };

            // Assert
            command.Id.Should().Be(42);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(999)]
        public void RemoverClienteCommand_DeveAceitarDiferentesIds(long id)
        {
            // Arrange & Act
            var command = new RemoverClienteCommand { Id = id };

            // Assert
            command.Id.Should().Be(id);
        }

        [Fact]
        public void RemoverClienteCommand_DeveInicializarComIdZero()
        {
            // Arrange & Act
            var command = new RemoverClienteCommand();

            // Assert
            command.Id.Should().Be(0);
        }
    }
}
