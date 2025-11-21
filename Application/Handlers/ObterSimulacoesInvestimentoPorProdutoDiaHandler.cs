using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ObterSimulacoesInvestimentoPorProdutoDiaHandler
        : IRequestHandler<
            ObterSimulacoesInvestimentoPorProdutoDiaQuery, 
            IEnumerable<ObterSimulacaoInvestimentoPorProdutoDiaResponse>>
    {
        private readonly ISimulacaoInvestimentoRepository _simulacaoInvestimentoRepository;
        private readonly IProdutoInvestimentoRepository _produtoInvestimentoRepository;

        public ObterSimulacoesInvestimentoPorProdutoDiaHandler(
            ISimulacaoInvestimentoRepository simulacaoInvestimentoRepository,
            IProdutoInvestimentoRepository produtoInvestimentoRepository)
        {
            _simulacaoInvestimentoRepository = simulacaoInvestimentoRepository;
            _produtoInvestimentoRepository = produtoInvestimentoRepository;
        }

        public async Task<IEnumerable<ObterSimulacaoInvestimentoPorProdutoDiaResponse>> Handle(
            ObterSimulacoesInvestimentoPorProdutoDiaQuery request,
            CancellationToken cancellationToken)
        {
            var diaLocal = DateTime.SpecifyKind(request.Data, DateTimeKind.Unspecified);
            var inicioLocal = new DateTimeOffset(diaLocal, TimeSpan.FromHours(-3));
            var fimLocal = inicioLocal.AddDays(1);

            var inicioUtc = inicioLocal.ToUniversalTime();
            var fimUtc = fimLocal.ToUniversalTime();

            IEnumerable<SimulacaoInvestimento> simulacoes = await _simulacaoInvestimentoRepository
                    .ListarPorDiaAsync(inicioUtc, fimUtc);

            var simulacoesPorId = simulacoes.GroupBy(s => s.ProdutoId).ToList();

            var resultado = new List<ObterSimulacaoInvestimentoPorProdutoDiaResponse>();

            foreach (var simulacao in simulacoesPorId)
            {
                var produto = await _produtoInvestimentoRepository.ObterPorIdAsync(simulacao.Key);

                if (produto == null)
                    continue;

                resultado.Add(new ObterSimulacaoInvestimentoPorProdutoDiaResponse
                {
                    Produto = produto.Nome,
                    Data = DateOnly.FromDateTime(request.Data),
                    QuantidadeSimulacoes = simulacao.Count(),
                    MediaValorFinal = simulacao.Average(s => s.ValorFinal)
                });
            }

            return resultado;
        }
    }
}
