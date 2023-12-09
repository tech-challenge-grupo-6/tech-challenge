using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.UseCases.Interfaces;

public interface IProdutoUseCase
{
  Task<IEnumerable<Produto>> TodosProdutosPorCategoria(Guid categoriaId);
  Task RemoverProduto(Guid id);
  Task EditarProduto(Guid id, Produto produto);
  Task CriarProduto(Produto produto);
}
