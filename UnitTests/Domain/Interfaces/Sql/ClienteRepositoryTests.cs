using Domain.Entities;
using Domain.Interfaces.Sql;
using FluentAssertions;
using Moq;

namespace UnitTests.Domain.Interfaces.Sql
{
    public class ClienteRepositoryTests
    {
        private readonly Mock<IClienteRepository> _repositoryMock;

        public ClienteRepositoryTests()
        {
            _repositoryMock = new Mock<IClienteRepository>();
        }

        [Fact]
        public async Task ObterPorIdAsync_DeveRetornarCliente_QuandoClienteExiste()
        {
            // Arrange
            var clienteEsperado = new Cliente { Id = 1, Nome = "João", Email = "joao@email.com", Cpf = "12345678901" };
            _repositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(clienteEsperado);

            // Act
            var resultado = await _repositoryMock.Object.ObterPorIdAsync(1);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Should().Be(clienteEsperado);
            _repositoryMock.Verify(r => r.ObterPorIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task ObterPorIdAsync_DeveRetornarNull_QuandoClienteNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ObterPorIdAsync(999)).ReturnsAsync((Cliente?)null);

            // Act
            var resultado = await _repositoryMock.Object.ObterPorIdAsync(999);

            // Assert
            resultado.Should().BeNull();
        }

        [Fact]
        public async Task ListarTodosAsync_DeveRetornarListaDeClientes()
        {
            // Arrange
            var clientes = new List<Cliente>
            {
                new Cliente { Id = 1, Nome = "João", Email = "joao@email.com", Cpf = "11111111111" },
                new Cliente { Id = 2, Nome = "Maria", Email = "maria@email.com", Cpf = "22222222222" }
            };
            _repositoryMock.Setup(r => r.ListarTodosAsync()).ReturnsAsync(clientes);

            // Act
            var resultado = await _repositoryMock.Object.ListarTodosAsync();

            // Assert
            resultado.Should().HaveCount(2);
            resultado.Should().BeEquivalentTo(clientes);
        }

        [Fact]
        public async Task AdicionarAsync_DeveRetornarClienteAdicionado()
        {
            // Arrange
            var novoCliente = new Cliente { Nome = "Pedro", Email = "pedro@email.com", Cpf = "33333333333" };
            var clienteAdicionado = new Cliente { Id = 1, Nome = "Pedro", Email = "pedro@email.com", Cpf = "33333333333" };
            _repositoryMock.Setup(r => r.AdicionarAsync(novoCliente)).ReturnsAsync(clienteAdicionado);

            // Act
            var resultado = await _repositoryMock.Object.AdicionarAsync(novoCliente);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(1);
            resultado.Nome.Should().Be("Pedro");
        }

        [Fact]
        public async Task AtualizarAsync_DeveRetornarClienteAtualizado()
        {
            // Arrange
            var clienteAtualizado = new Cliente { Id = 1, Nome = "João Silva", Email = "joao.silva@email.com", Cpf = "12345678901" };
            _repositoryMock.Setup(r => r.AtualizarAsync(clienteAtualizado)).ReturnsAsync(clienteAtualizado);

            // Act
            var resultado = await _repositoryMock.Object.AtualizarAsync(clienteAtualizado);

            // Assert
            resultado.Should().Be(clienteAtualizado);
        }

        [Fact]
        public async Task RemoverAsync_DeveRetornarTrue_QuandoClienteRemovidoComSucesso()
        {
            // Arrange
            _repositoryMock.Setup(r => r.RemoverAsync(1)).ReturnsAsync(true);

            // Act
            var resultado = await _repositoryMock.Object.RemoverAsync(1);

            // Assert
            resultado.Should().BeTrue();
        }

        [Fact]
        public async Task RemoverAsync_DeveRetornarFalse_QuandoClienteNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.RemoverAsync(999)).ReturnsAsync(false);

            // Act
            var resultado = await _repositoryMock.Object.RemoverAsync(999);

            // Assert
            resultado.Should().BeFalse();
        }
    }
}
