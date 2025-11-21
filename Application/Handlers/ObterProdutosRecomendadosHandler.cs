using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Sql;
using MediatR;

namespace Application.Handlers
{
    public class ObterProdutosRecomendadosHandler
        : IRequestHandler<ObterProdutosRecomendadosQuery, IEnumerable<ProdutoRecomendadoResponse>>
    {
        private readonly IProdutoInvestimentoRepository _produtoInvestimentoRepository;

        public ObterProdutosRecomendadosHandler(IProdutoInvestimentoRepository produtoInvestimentoRepository)
        {
            _produtoInvestimentoRepository = produtoInvestimentoRepository;
        }

        public async Task<IEnumerable<ProdutoRecomendadoResponse>> Handle(
            ObterProdutosRecomendadosQuery request,
            CancellationToken cancellationToken)
        {
            string perfil = request.Perfil.ToLower();

            string[] riscosPermitidos = perfil switch
            {
                "conservador" => ["Muito Baixo", "Baixo"],
                "moderado" => ["Muito Baixo", "Baixo", "Médio", "Moderado"],
                "agressivo" => ["Muito Baixo", "Baixo", "Médio", "Moderado", "Alto"],
                _ => throw new ArgumentException("Perfil não identificado")
            };

            IEnumerable<ProdutoInvestimento> produtos = await _produtoInvestimentoRepository
                .ListarPorRiscoAsync(riscosPermitidos);

            return produtos.Select(p => p.ToProdutoRecomendadoResponse());
        }
    }
}
