using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Exceptions;
using ControladorPedidos.App.Presenters;
using ControladorPedidos.App.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.App.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController(ILogger<ClienteController> logger, IClienteUseCase clienteUseCase) : ControllerBase
{
    /// <summary>
    /// Consulta Cliente por CPF
    /// </summary>
    /// <param name="cpf">Filtra o cliente por CPF</param>
    /// <returns>Retorna cliente por CPF.</returns>
    /// <response code="200">Retorno dados do cliente.</response>
    /// <response code="404">Não encontrado.</response>
    /// <response code="500">Erro interno.</response>
    [HttpGet("{cpf}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarPorCpf(string cpf)
    {
        logger.LogInformation("Buscando cliente pelo cpf");
        try
        {
            var cliente = await clienteUseCase.BuscarPorCpf(cpf);
            return Ok(cliente);
        }
        catch (ArgumentException ex)
        {
            logger.LogError(ex, "Erro ao buscar cliente pelo cpf");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Buscando cliente pelo cpf");
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
    }

    /// <summary>
    /// Cria um novo cliente
    /// </summary>
    /// <param name="clienteDto">Dados do novo cliente</param>
    /// <returns>Retorna o ID do novo cliente.</returns>
    /// <response code="201">Cliente criado com sucesso.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="500">Erro interno.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CriarClienteDto clienteDto)
    {
        logger.LogInformation("Criando cliente: {ClienteDto}", clienteDto);
        try
        {
            var cliente = (Cliente)clienteDto;
            await clienteUseCase.CriarAsync(cliente);
            return CreatedAtAction(nameof(Post), new { id = cliente.Id });
        }
        catch (ArgumentException ex)
        {
            logger.LogError(ex, "Erro ao criar cliente: {ClienteDto}", clienteDto);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao criar cliente: {ClienteDto}", clienteDto);
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
    }
}