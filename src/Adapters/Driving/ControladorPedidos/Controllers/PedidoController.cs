using Application.UseCases;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{

    private readonly IPedidoUseCase _pedidoUseCase;
    private readonly ILogger<PedidoController> _logger;

    public PedidoController(IPedidoUseCase pedidoUseCase, ILogger<PedidoController> logger)
    {
        _pedidoUseCase = pedidoUseCase;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Listando todos os pedidos");
        try
        {
            var pedidos = await _pedidoUseCase.TodosPedidos();
            return Ok(pedidos);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar os pedidos");
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public void Delete(int id)
    {
    }

    [HttpPatch("{id}/status/emprogresso")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutEmProgresso(Guid id)
    {
        try
        {
            _logger.LogInformation("Mudando status do pedido {pedido} para 'Em Pregresso'", id);
            await _pedidoUseCase.AlterarStatusPedido(id, Status.EmProgresso);
            return NoContent();
        }
        catch (Exception ex) when (ex.GetType() == typeof(BusinessException) || ex.GetType() == typeof(NotFoundException))
        {
            _logger.LogError(ex, "Erro ao mudar status do pedido {pedido} para 'Em Pregresso'", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao mudar status do pedido {pedido} para 'Em Pregresso'", id);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPatch("{id}/status/pronto")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutPronto(Guid id)
    {
        try
        {
            _logger.LogInformation("Mudando status do pedido {pedido} para 'Pronto'", id);
            await _pedidoUseCase.AlterarStatusPedido(id, Status.Pronto);
            return NoContent();
        }
        catch (Exception ex) when (ex.GetType() == typeof(BusinessException) || ex.GetType() == typeof(NotFoundException))
        {
            _logger.LogError(ex, "Erro ao mudar status do pedido {pedido} para 'Em Pregresso'", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao mudar status do pedido {pedido} para 'Pronto'", id);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPatch("{id}/status/finalizado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutFinalizado(Guid id)
    {
        try
        {
            _logger.LogInformation("Mudando status do pedido {pedido} para 'Finalizado'", id);
            await _pedidoUseCase.AlterarStatusPedido(id, Status.Finalizado);
            return NoContent();
        }
        catch (Exception ex) when (ex.GetType() == typeof(BusinessException) || ex.GetType() == typeof(NotFoundException))
        {
            _logger.LogError(ex, "Erro ao mudar status do pedido {pedido} para 'Em Pregresso'", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao mudar status do pedido {pedido} para 'Finalizado'", id);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}