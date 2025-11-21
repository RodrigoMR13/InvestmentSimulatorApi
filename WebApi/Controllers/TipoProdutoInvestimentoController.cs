using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("tipos-produtos")]
    [Authorize]
    public class TipoProdutoInvestimentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TipoProdutoInvestimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var result = await _mediator.Send(new ListarTiposProdutoInvestimentoQuery());
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> ObterPorId(long id)
        {
            var result = await _mediator.Send(new ObterTipoProdutoInvestimentoPorIdQuery { Id = id });
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarTipoProdutoInvestimentoCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterPorId), new { id = result.Id }, result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Atualizar(long id, [FromBody] AtualizarTipoProdutoInvestimentoCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Remover(long id)
        {
            var result = await _mediator.Send(new RemoverTipoProdutoInvestimentoCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }

}
