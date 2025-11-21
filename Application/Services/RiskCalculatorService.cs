using Domain.Entities;

namespace Application.Services
{
    public static class RiskCalculatorService
    {
        public static short CalcularPontuacao(IEnumerable<SimulacaoInvestimento> historico)
        {
            decimal volume = historico.Sum(x => x.ValorInvestido);
            int frequencia = historico.Count();
            decimal mediaRentabilidade = historico.Average(x => (x.ValorFinal / x.ValorInvestido) - 1);

            short pontuacao = 0;

            if (volume < 5000) pontuacao += 5;
            else if (volume < 20000) pontuacao += 10;
            else pontuacao += 20;

            if (frequencia <= 2) pontuacao += 5;
            else if (frequencia <= 5) pontuacao += 10;
            else pontuacao += 15;

            if (mediaRentabilidade < 0.07m) pontuacao += 0;
            else if (mediaRentabilidade < 0.12m) pontuacao += 5;
            else pontuacao += 10;

            decimal riscoTotal = historico.Sum(x => GetScoreByRisco(x.Produto.Risco) * x.ValorInvestido);
            decimal pesoTotal = volume == 0 ? 1 : volume;
            short riscoFinal = (short)(riscoTotal / pesoTotal);

            pontuacao += riscoFinal;

            return pontuacao;
        }

        private static short GetScoreByRisco(string risco) =>
            risco switch
            {
                "Baixo" => 0,
                "Médio" => 10,
                "Alto" => 20,
                _ => 0
            };

        public static string DefinirPerfil(short pontuacao)
        {
            if (pontuacao <= 40) return "Conservador";
            if (pontuacao <= 70) return "Moderado";
            return "Agressivo";
        }

        public static string DescricaoPerfil(string perfil) =>
            perfil switch
            {
                "Conservador" => "Perfil focado em segurança e liquidez.",
                "Moderado" => "Perfil equilibrado entre segurança e rentabilidade.",
                "Agressivo" => "Busca máxima rentabilidade assumindo maior risco.",
                _ => "Não identificado"
            };
    }
}
