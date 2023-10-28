namespace Domain;

public interface ICategoriaProdutoRepository
{
  Task<IEnumerable<CategoriaProduto>> GetAll();
  Task<CategoriaProduto?> GetById(Guid id);

  Task Add(CategoriaProduto categoria);
  Task Update(CategoriaProduto categoria);
}