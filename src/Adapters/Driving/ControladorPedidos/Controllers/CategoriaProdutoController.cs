using Application.UseCases;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly ILogger<CategoriaProdutoController> _logger;
        private readonly ICategoriaProdutoUseCase _categoriaUseCase;

        public CategoriaProdutoController(ILogger<CategoriaProdutoController> logger, ICategoriaProdutoUseCase categoriaUseCase = null)
        {
            _logger = logger;
            _categoriaUseCase = categoriaUseCase;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Listando categorias de produto");
            try
            {
                var categorias = await _categoriaUseCase.TodasCategorias();
                return Ok(categorias);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Listando categorias de produto");
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
        public async Task<IActionResult> Post([FromBody] CategoriaProduto categoria)
        {
            try
            {
                await _categoriaUseCase.CriarCategoriaAsync(categoria);
                return Created($"/CategoriaProduto/{categoria.Id}", categoria);
            }

            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            catch (Exception ex)
            {
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
}