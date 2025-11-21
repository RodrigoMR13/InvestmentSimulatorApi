using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class ObterProdutosRecomendadosQuery : IRequest<IEnumerable<ProdutoRecomendadoResponse>>
    {
        public string Perfil { get; set; } = string.Empty;
    }
}
