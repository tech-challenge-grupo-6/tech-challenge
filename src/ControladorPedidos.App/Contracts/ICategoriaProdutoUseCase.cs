using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.Contracts;

public interface ICategoriaProdutoUseCase
{
  Task CriarCategoriaAsync(CategoriaProduto categoria);
  Task<IEnumerable<CategoriaProduto>> TodasCategorias();
}