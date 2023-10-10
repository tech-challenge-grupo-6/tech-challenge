using Application.UseCases;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IClienteUseCase _clienteUseCase;

    public ClienteController(ILogger<ClienteController> logger, IClienteUseCase clienteUseCase = null)
    {
        _logger = logger;
        _clienteUseCase = clienteUseCase;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public string Get(int id)
    {
        return "value";
    }*/

    [HttpGet("{cpf}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarPorCpf(string cpf)
    {
        _logger.LogInformation("Buscando cliente pelo cpf");
        try
        {
            var cliente = await _clienteUseCase.BuscarPorCpf(cpf);
            return Ok(cliente);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Erro ao buscar cliente pelo cpf");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Buscando cliente pelo cpf");
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CriarClienteDto clienteDto)
    {
        _logger.LogInformation("Criando cliente: {ClienteDto}", clienteDto);
        try
        {
            var cliente = (Cliente)clienteDto;
            await _clienteUseCase.CriarAsync(cliente);
            return CreatedAtAction(nameof(Post), new { id = cliente.Id }, null);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Erro ao criar cliente: {ClienteDto}", clienteDto);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar cliente: {ClienteDto}", clienteDto);
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
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
}