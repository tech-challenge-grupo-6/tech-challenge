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

  public async Task EditarProduto(Guid id, Produto produto)
  {
    _logger.LogInformation("Editando Produto");

    try
    {
      var result = await _produtoRepository.GetById(id) ?? throw new NotFoundException("Produto não encontrado");

      if (ProdutoValidador.IsValid(produto))
      {
        result.Nome = produto.Nome;
        result.Preco = produto.Preco;
        result.Descricao = produto.Descricao;
        result.Imagem = produto.Imagem;
        result.CategoriaId = produto.CategoriaId;
        _produtoRepository.UpdateProduct(result);
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao editar produto");
      throw;
    }
  }  

  public async Task RemoverProduto(Guid id)
  {
    _logger.LogInformation("Removendo Produto");

    try
    {
      var result = await _produtoRepository.GetById(id) ?? throw new NotFoundException("Produto não encontrado");
      _produtoRepository.Remove(result);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao remover produto");
      throw;
    }
  }

  public async Task CriarProduto(Produto produto)
  {
    _logger.LogInformation("Criando Produto");

    try
    {
      if (ProdutoValidador.IsValid(produto))
      {
        await _produtoRepository.Add(produto);
      }
    }
    catch (Exception ex)
    {
      _logger.LogInformation(ex, "Erro ao criar produto");
      throw;
    }
  }
}
