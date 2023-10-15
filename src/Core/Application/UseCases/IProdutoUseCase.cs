using Domain;

namespace Application.UseCases;

public interface IProdutoUseCase
{
  Task<IEnumerable<Produto>> TodosProdutosPorCategoria(Guid categoriaId);
  Task RemoverProduto(Guid id);
  Task EditarProduto(Guid id, Produto produto);
}
