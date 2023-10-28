using Application.UseCases;
using Domain;
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

    /// <summary>
    /// Consulta todos os pedidos
    /// </summary>
    /// <returns>Retorna todos os pedidos.</returns>
    /// <response code="200">Retorno todos os pedidos.</response>
    /// <response code="404">Não encontrado.</response>
    /// <response code="500">Erro interno.</response>
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

    /// <summary>
    /// Cria um novo pedido
    /// </summary>
    /// <param name="pedidoDto">Dados do novo pedido.</param>
    /// <returns>Retorna o ID do novo pedido.</returns>
    /// <response code="201">Pedido criado com sucesso.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="500">Erro interno.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post([FromBody] CriarPedidoDto pedidoDto)
    {
        _logger.LogInformation("Pedido pedido: {PedidoDto}", pedidoDto);
        try
        {
            var pedido = (Pedido)pedidoDto;

            await _pedidoUseCase.MontarPedido(pedido);
            return CreatedAtAction(nameof(Post), new { id = pedido.Id });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Erro ao criar pedido: {PedidoDto}", pedidoDto);
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar pedido: {PedidoDto}", pedidoDto);
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }

    }

    /// <summary>
    /// Atualiza o status do pedido para "Em progresso".
    /// </summary>
    /// <param name="id">Recebe o Id para atualizar o pedido.</param>
    /// <response code="204">Sem nenhum retorno.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="500">Erro interno.</response>
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

    /// <summary>
    /// Atualiza o status do pedido para "Pronto"
    /// </summary>
    /// <param name="id">Recebe o Id para atualizar o pedido.</param>
    /// <response code="204">Sem nenhum retorno.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="500">Erro interno.</response>
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

    /// <summary>
    /// Atualiza o status do pedido para "Finalizado"
    /// </summary>
    /// <param name="id">Recebe o Id para atualizar o pedido.</param>
    /// <response code="204">Sem nenhum retorno.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="500">Erro interno.</response>
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