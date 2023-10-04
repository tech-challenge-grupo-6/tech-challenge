using System;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
  public interface IProdutoRepository
  {
    Task<IEnumerable<Produto>> GetAll();
    Task<Produto> GetById(int id);
    Task<IEnumerable<Produto>> GetByCategoria(int categoriaId);

    void Add(Produto produto);
    void Update(Produto produto);

    void Add(CategoriaProduto categoria);
    void Update(CategoriaProduto categoria);
  }
}