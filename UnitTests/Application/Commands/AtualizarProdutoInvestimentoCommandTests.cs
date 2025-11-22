using Application.Commands;
using Application.Responses;
using FluentAssertions;
using MediatR;

namespace UnitTests.Application.Commands
{
    public class AtualizarProdutoInvestimentoCommandTests
    {
        [Fact]
        public void AtualizarProdutoInvestimentoCommand_DeveImplementarIRequest()
        {
            // Arrange & Act
            var command = new AtualizarProdutoInvestimentoCommand();

            // Assert
            command.Should().BeAssignableTo<IRequest<ProdutoInvestimentoResponse?>>();
        }

        [Fact]
        public void AtualizarProdutoInvestimentoCommand_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange & Act
            var command = new AtualizarProdutoInvestimentoCommand
            {
                Id = 1,
                Nome = "CDB Premium",
                Rentabilidade = 0.15m,
                TipoId = 1,
                PrazoMinimoMeses = 6,
                PrazoMaximoMeses = 24,
                ValorMinimoInvestimento = 1000m,
                ValorMaximoInvestimento = 100000m,
                Risco = "Baixo"
            };

            // Assert
            command.Id.Should().Be(1);
            command.Nome.Should().Be("CDB Premium");
            command.Rentabilidade.Should().Be(0.15m);
            command.TipoId.Should().Be(1);
            command.PrazoMinimoMeses.Should().Be(6);
            command.PrazoMaximoMeses.Should().Be(24);
            command.ValorMinimoInvestimento.Should().Be(1000m);
            command.ValorMaximoInvestimento.Should().Be(100000m);
            command.Risco.Should().Be("Baixo");
        }

        [Theory]
        [InlineData(0.05)]
        [InlineData(0.12)]
        [InlineData(0.25)]
        public void AtualizarProdutoInvestimentoCommand_DeveAceitarDiferentesRentabilidades(decimal rentabilidade)
        {
            // Arrange & Act
            var command = new AtualizarProdutoInvestimentoCommand
            {
                Rentabilidade = rentabilidade
            };

            // Assert
            command.Rentabilidade.Should().Be(rentabilidade);
        }

        [Theory]
        [InlineData("Baixo")]
        [InlineData("Médio")]
        [InlineData("Alto")]
        public void AtualizarProdutoInvestimentoCommand_DeveAceitarDiferentesNiveisRisco(string risco)
        {
            // Arrange & Act
            var command = new AtualizarProdutoInvestimentoCommand
            {
                Risco = risco
            };

            // Assert
            command.Risco.Should().Be(risco);
        }
    }
}
