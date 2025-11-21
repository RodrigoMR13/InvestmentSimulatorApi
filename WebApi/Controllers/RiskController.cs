using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("risco")]
    [Authorize]
    public class RiskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RiskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("perfil-risco/{clienteId:long}")]
        public async Task<IActionResult> ObterPerfilRiscoCliente(long clienteId)
        {
            var result = await _mediator.Send(new ObterPerfilRiscoClienteQuery { ClienteId = clienteId });
            return Ok(result);
        }
    }
}
