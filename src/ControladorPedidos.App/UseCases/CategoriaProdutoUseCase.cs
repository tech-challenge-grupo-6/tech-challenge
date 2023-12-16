using ControladorPedidos.App.Contracts;
using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Exceptions;
using ControladorPedidos.App.Entities.Repositories;
using ControladorPedidos.App.Entities.Validators;

namespace ControladorPedidos.App.UseCases;

public class CategoriaProdutoUseCase(ICategoriaProdutoRepository categoriaRepository, ILogger<CategoriaProduto> logger) : ICategoriaProdutoUseCase
{
  public async Task CriarCategoriaAsync(CategoriaProduto categoria)
  {
    logger.LogInformation("Criando categoria de produto");

    try
    {
      if (CategoriaProdutoValidador.IsValid(categoria))
      {
        await categoriaRepository.Add(categoria);
      }
      else
      {
        logger.LogError("Categoria de produto inválida");
        throw new ArgumentException("Categoria de produto inválida");
      }
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao criar categoria de produto");
      throw;
    }
  }

  public async Task<IEnumerable<CategoriaProduto>> TodasCategorias()
  {
    logger.LogInformation("Buscando categorias de produto");
    try
    {
      var result = await categoriaRepository.GetAll() ?? throw new NotFoundException("Categorias não encontradas");
      return result;
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao buscar categorias de produto");
      throw;
    }
  }
}