using Application.Commands;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class CriarClienteCommandTests
    {
        [Fact]
        public void CriarClienteCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new CriarClienteCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<ClienteResponse>>();
        }

        [Fact]
        public void CriarClienteCommand_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var command = new CriarClienteCommand
            {
                Nome = "Ana Paula",
                Email = "ana.paula@email.com",
                Cpf = "11122233344"
            };

            // Assert
            command.Nome.Should().Be("Ana Paula");
            command.Email.Should().Be("ana.paula@email.com");
            command.Cpf.Should().Be("11122233344");
        }

        [Fact]
        public void CriarClienteCommand_DevePermitirValoresVaziosPorPadrao()
        {
            // Arrange & Act
            var command = new CriarClienteCommand();

            // Assert
            command.Nome.Should().BeEmpty();
            command.Email.Should().BeEmpty();
            command.Cpf.Should().BeEmpty();
        }

        [Theory]
        [InlineData("João", "joao@test.com", "12345678901")]
        [InlineData("Maria", "maria@test.com", "98765432109")]
        public void CriarClienteCommand_DeveAceitarDiferentesCombinacoesDeDados(string nome, string email, string cpf)
        {
            // Arrange & Act
            var command = new CriarClienteCommand
            {
                Nome = nome,
                Email = email,
                Cpf = cpf
            };

            // Assert
            command.Nome.Should().Be(nome);
            command.Email.Should().Be(email);
            command.Cpf.Should().Be(cpf);
        }
    }
}
