using Application.Commands;
using Application.Interfaces;
using Application.Mappers;
using Application.Responses;
using Application.Telemetry;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces.Sql;
using MediatR;
using Application.Exceptions;

namespace Application.Handlers
{
    public class SimularInvestimentoHandler : IRequestHandler<SimularInvestimentoCommand, SimularInvestimentoResponse>
    {
        private readonly ISimulacaoInvestimentoRepository _simulacaoInvestimentoRepository;
        private readonly IProdutoInvestimentoRepository _produtoInvestimentoRepository;
        private readonly IProdutoInvestimentoSelector _produtoInvestimentoSelector;
        private readonly SimuladorInvestimentoService _simuladorInvestimentoService;
        private readonly ITimeProvider _time;

        public SimularInvestimentoHandler(
            ISimulacaoInvestimentoRepository simulacaoInvestimentoRepository,
            IProdutoInvestimentoRepository produtoInvestimentoRepository,
            IProdutoInvestimentoSelector produtoInvestimentoSelector,
            SimuladorInvestimentoService simuladorInvestimentoService,
            ITimeProvider timeProvider)
        {
            _simulacaoInvestimentoRepository = simulacaoInvestimentoRepository;
            _produtoInvestimentoRepository = produtoInvestimentoRepository;
            _produtoInvestimentoSelector = produtoInvestimentoSelector;
            _simuladorInvestimentoService = simuladorInvestimentoService;
            _time = timeProvider;
        }

        public async Task<SimularInvestimentoResponse> Handle(
            SimularInvestimentoCommand request,
            CancellationToken cancellationToken)
        {
            IEnumerable<ProdutoInvestimento> produtos = await _produtoInvestimentoRepository
                .ListarPorTipoAsync(request.TipoProduto);

            if (!produtos.Any())
                throw new Exception("Não há produtos de investimento na base de dados para simular");

            ProdutoInvestimento produtoApropriado = _produtoInvestimentoSelector
                .SelecionarProdutoApropriado(produtos, request.Valor, request.PrazoMeses)
                ?? throw new Exception("Não existe Produto de Investimento apropriado para esses parâmetros");

            ProdutoValidadoResult produtoValidado = produtoApropriado.ToProdutoValidadoResult();

            SimulacaoInvestimentoResult resultadoSimulacao = _simuladorInvestimentoService.SimularInvestimento(
                    request.Valor,
                    request.PrazoMeses,
                    produtoValidado);

            SimulacaoInvestimento simulacao = new()
            {
                ClienteId = request.ClienteId,
                ProdutoId = produtoApropriado.Id,
                ValorInvestido = request.Valor,
                ValorFinal = resultadoSimulacao.ValorFinal,
                PrazoMeses = request.PrazoMeses
            };

            await (_ = _simulacaoInvestimentoRepository.AdicionarAsync(simulacao));

            return new SimularInvestimentoResponse(
                produtoValidado,
                resultadoSimulacao,
                _time.BrazilNow);
        }
    }
}
