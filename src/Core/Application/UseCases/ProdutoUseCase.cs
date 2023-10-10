using Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases;

public class ProdutoUseCase : IProdutoUseCase
{
  private readonly IProdutoRepository _produtoRepository;
  private readonly ILogger<ProdutoUseCase> _logger;
  public ProdutoUseCase(IProdutoRepository produtoRepository, ILogger<ProdutoUseCase> logger)
  {
    _produtoRepository = produtoRepository;
    _logger = logger;
  }

  public async Task<IEnumerable<Produto>> TodosProdutosPorCategoria(Guid categoriaId)
  {
    _logger.LogInformation("Buscando produtos por Categoria");
    try
    {
      var result = await _produtoRepository.GetByCategoria(categoriaId) ?? throw new NotFoundException("Produtos não encontrados");
      return result;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao buscar produtos por categoria");
      throw;
    }
  }
}
