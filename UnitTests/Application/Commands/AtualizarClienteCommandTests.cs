using Application.Commands;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class AtualizarClienteCommandTests
    {
        [Fact]
        public void AtualizarClienteCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new AtualizarClienteCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<ClienteResponse>>();
        }

        [Fact]
        public void AtualizarClienteCommand_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var command = new AtualizarClienteCommand
            {
                Id = 1,
                Nome = "João Silva",
                Email = "joao.silva@email.com",
                Cpf = "12345678901"
            };

            // Assert
            command.Id.Should().Be(1);
            command.Nome.Should().Be("João Silva");
            command.Email.Should().Be("joao.silva@email.com");
            command.Cpf.Should().Be("12345678901");
        }

        [Fact]
        public void AtualizarClienteCommand_DevePermitirValoresVaziosPorPadrao()
        {
            // Arrange & Act
            var command = new AtualizarClienteCommand();

            // Assert
            command.Id.Should().Be(0);
            command.Nome.Should().BeEmpty();
            command.Email.Should().BeEmpty();
            command.Cpf.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1, "Maria", "maria@email.com", "11111111111")]
        [InlineData(999, "Pedro Santos", "pedro@test.com", "99999999999")]
        public void AtualizarClienteCommand_DeveAceitarDiferentesValores(long id, string nome, string email, string cpf)
        {
            // Arrange & Act
            var command = new AtualizarClienteCommand
            {
                Id = id,
                Nome = nome,
                Email = email,
                Cpf = cpf
            };

            // Assert
            command.Id.Should().Be(id);
            command.Nome.Should().Be(nome);
            command.Email.Should().Be(email);
            command.Cpf.Should().Be(cpf);
        }
    }
}
