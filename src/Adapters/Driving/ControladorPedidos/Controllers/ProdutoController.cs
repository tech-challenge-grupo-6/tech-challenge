using Application.UseCases;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{

    private readonly ILogger<ProdutoController> _logger;
    private readonly IProdutoUseCase _produtoUseCase;

    public ProdutoController(ILogger<ProdutoController> logger, IProdutoUseCase produtoUseCase = null)
    {
        _logger = logger;
        _produtoUseCase = produtoUseCase;
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

    [HttpGet("{categoriaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListarPorCategoria(Guid categoriaId)
    {
        _logger.LogInformation("Listando produtos por categoria");
        try
        {
            var produtos = await _produtoUseCase.TodosProdutosPorCategoria(categoriaId);
            if (produtos != null)
            {
                return Ok(produtos);
            }
            else
            {
                return NotFound("Produtos não encontrados");
            }
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Listando produtos por categoria");
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
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
}