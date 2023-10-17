using Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases
{
  public class CategoriaProdutoUseCase : ICategoriaProdutoUseCase
  {
    private readonly ICategoriaProdutoRepository _categoriaRepository;
    private readonly ILogger<CategoriaProduto> _logger;

    public CategoriaProdutoUseCase(ICategoriaProdutoRepository categoriaRepository, ILogger<CategoriaProduto> logger)
    {
      _categoriaRepository = categoriaRepository;
      _logger = logger;
    }

    public async Task CriarCategoriaAsync(CategoriaProduto categoria)
    {
      try
      {
        if (CategoriaProdutoValidador.IsValid(categoria))
        {
          await _categoriaRepository.Add(categoria);
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<IEnumerable<CategoriaProduto>> TodasCategorias()
    {
      _logger.LogInformation("Buscando categorias de produto");
      try
      {
        var result = await _categoriaRepository.GetAll() ?? throw new NotFoundException("Categorias não encontradas");
        return result;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Erro ao buscar categorias de produto");
        throw;
      }
    }
  }
}