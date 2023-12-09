using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.UseCases.Interfaces;

public interface ICategoriaProdutoUseCase
{
  Task CriarCategoriaAsync(CategoriaProduto categoria);
  Task<IEnumerable<CategoriaProduto>> TodasCategorias();
}