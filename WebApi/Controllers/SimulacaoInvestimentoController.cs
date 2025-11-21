using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("investimentos")]
    [Authorize]
    public class SimulacaoInvestimentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SimulacaoInvestimentoController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("simular-investimento")]
        public async Task<IActionResult> SimularInvestimento([FromBody] SimularInvestimentoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("simulacoes")]
        public async Task<IActionResult> ObterSimulacoes()
        {
            var result = await _mediator.Send(new ObterSimulacoesInvestimentoQuery());
            return Ok(result);
        }

        [HttpGet("simulacoes/por-produto-dia")]
        public async Task<IActionResult> ObterSimulacoesPorProdutoDia([FromQuery] ObterSimulacoesInvestimentoPorProdutoDiaQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{clienteId:long}")]
        public async Task<IActionResult> GetHistoricoInvestimentos(long clienteId)
        {
            var result = await _mediator.Send(new ObterInvestimentosClienteQuery() { ClienteId = clienteId});
            return Ok(result);
        }
    }
}
