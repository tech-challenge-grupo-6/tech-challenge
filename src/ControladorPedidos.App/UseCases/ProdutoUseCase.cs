using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Exceptions;
using ControladorPedidos.App.Entities.Repositories;
using ControladorPedidos.App.Entities.Validators;
using ControladorPedidos.App.UseCases.Interfaces;

namespace ControladorPedidos.App.UseCases;

public class ProdutoUseCase(IProdutoRepository produtoRepository, ILogger<ProdutoUseCase> logger) : IProdutoUseCase
{
  public async Task<IEnumerable<Produto>> TodosProdutosPorCategoria(Guid categoriaId)
  {
    logger.LogInformation("Buscando produtos por Categoria");
    try
    {
      var result = await produtoRepository.GetByCategoria(categoriaId) ?? throw new NotFoundException("Produtos não encontrados");
      return result;
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao buscar produtos por categoria");
      throw;
    }
  }

  public async Task EditarProduto(Guid id, Produto produto)
  {
    logger.LogInformation("Editando Produto");

    try
    {
      var result = await produtoRepository.GetById(id) ?? throw new NotFoundException("Produto não encontrado");

      if (ProdutoValidador.IsValid(produto))
      {
        result.Nome = produto.Nome;
        result.Preco = produto.Preco;
        result.Descricao = produto.Descricao;
        result.Imagem = produto.Imagem;
        result.CategoriaId = produto.CategoriaId;
        produtoRepository.UpdateProduct(result);
      }
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao editar produto");
      throw;
    }
  }

  public async Task RemoverProduto(Guid id)
  {
    logger.LogInformation("Removendo Produto");

    try
    {
      var result = await produtoRepository.GetById(id) ?? throw new NotFoundException("Produto não encontrado");
      produtoRepository.Remove(result);
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao remover produto");
      throw;
    }
  }

  public async Task CriarProduto(Produto produto)
  {
    logger.LogInformation("Criando Produto");

    try
    {
      if (ProdutoValidador.IsValid(produto))
      {
        await produtoRepository.Add(produto);
      }
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao criar produto");
      throw;
    }
  }
}
