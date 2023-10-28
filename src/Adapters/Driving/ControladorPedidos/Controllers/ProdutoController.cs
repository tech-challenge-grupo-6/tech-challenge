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

    public ProdutoController(ILogger<ProdutoController> logger, IProdutoUseCase produtoUseCase)
    {
        _logger = logger;
        _produtoUseCase = produtoUseCase;
    }

    /// <summary>
    /// Consulta produtos por categoria
    /// </summary>
    /// <param name="categoriaId">Filtra produtos por categoria</param>
    /// <returns>Retorna produtos por categoria.</returns>
    /// <response code="200">Retorno dados do produto.</response>
    /// <response code="404">Não encontrado.</response>
    /// <response code="500">Erro interno.</response>
    [HttpGet("{categoriaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListarPorCategoria(Guid categoriaId)
    {
        _logger.LogInformation("Listando produtos por categoria");
        try
        {
            var produtos = await _produtoUseCase.TodosProdutosPorCategoria(categoriaId);
            return Ok(produtos);
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

    /// <summary>
    /// Criar um produto
    /// </summary>
    /// <param name="produtoDto">Dados do novo produto</param>
    /// <returns>Retorna ID novo produto.</returns>
    /// <response code="201">Produto criado com sucesso</response>
    /// <response code="400">Bad request</response>
    /// <response code="500">Erro Interno.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post([FromBody] CriarEditarProdutoDto produtoDto)
    {
        _logger.LogInformation("Produto produto: {ProdutoDto}", produtoDto);
        try
        {
            var produto = (Produto)produtoDto;
            await _produtoUseCase.CriarProduto(produto);
            return CreatedAtAction(nameof(Post), new { id = produto.Id }, null);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Erro ao criar produto: {ProdutoDto}", produtoDto);
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar produto: {ClienteDto}", produtoDto);
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
    }

    /// <summary>
    /// Editar um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <param name="produtoDto">Dados do produto</param>
    /// <returns>Retorna ID novo produto.</returns>
    /// <response code="200">Produto editado com sucesso</response>
    /// <response code="404">Produto não encontrado</response>
    /// <response code="400">Bad request.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Put(Guid id, [FromBody] CriarEditarProdutoDto produtoDto)
    {
        _logger.LogInformation("Produto editado: {id}", id);
        try
        {
            await _produtoUseCase.EditarProduto(id, (Produto)produtoDto);
            return StatusCode(StatusCodes.Status204NoContent, "Editado com sucesso!");
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Erro ao editar produto: {id}", id);
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
    }

    /// <summary>
    /// Deletar um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>Retorna ID novo produto.</returns>
    /// <response code="200">Produto deletado com sucesso</response>
    /// <response code="404">Produto não encontrado</response>
    /// <response code="400">Bad request.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Produto removido: {id}", id);
        try
        {
            await _produtoUseCase.RemoverProduto(id);
            return StatusCode(StatusCodes.Status204NoContent, "Removido com sucesso!");
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Erro ao remover produto: {id}", id);
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
    }
}