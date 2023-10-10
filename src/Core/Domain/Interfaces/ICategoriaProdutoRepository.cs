using System;
using System.Threading.Tasks;

namespace Domain
{
  public interface ICategoriaProdutoRepository
  {
    Task<IEnumerable<CategoriaProduto>> GetAll();
    Task<CategoriaProduto> GetById(Guid id);

    void Add(CategoriaProduto categoria);
    void Update(CategoriaProduto categoria);
  }
}