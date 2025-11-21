using Application.Telemetry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("telemetria")]
    [Authorize]
    public class TelemetriaController : ControllerBase
    {
        private readonly IMetricsService _metricsService;

        public TelemetriaController(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTelemetria([FromQuery] DateOnly inicio, [FromQuery] DateOnly fim)
        {
            IEnumerable<ServicoTelemetriaDto> servicos = await _metricsService.ObterTelemetriaAsync(inicio, fim);

            return Ok(new TelemetriaResponse([.. servicos], new PeriodoTelemetriaDto(inicio, fim)));
        }
    }

}
