using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("produtos-investimentos")]
    [Authorize]
    public class ProdutoInvestimentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoInvestimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var result = await _mediator.Send(new ListarProdutosInvestimentosQuery());
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> ObterPorId(long id)
        {
            var result = await _mediator.Send(new ObterProdutoInvestimentoPorIdQuery { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoInvestimentoCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterPorId), new { id = result.Id }, result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Atualizar(long id, [FromBody] AtualizarProdutoInvestimentoCommand command)
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
            var result = await _mediator.Send(new RemoverProdutoInvestimentoCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }

}
