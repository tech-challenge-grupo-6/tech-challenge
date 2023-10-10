
using Domain;

namespace Application.UseCases;

public interface IProdutoUseCase
{
  Task<IEnumerable<Produto>> TodosProdutosPorCategoria(Guid categoriaId);
}
