using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories;

public class CategoriaProdutoRepository(DatabaseContext dbContext) : ICategoriaProdutoRepository
{
  public async Task<IEnumerable<CategoriaProduto>> GetAll()
  {
    return await dbContext.CategoriaProdutos.ToListAsync();
  }

  public async Task<CategoriaProduto?> GetById(Guid id)
  {
    return await dbContext.CategoriaProdutos.FindAsync(id);
  }

  public async Task Add(CategoriaProduto CategoriaProduto)
  {
    dbContext.CategoriaProdutos.Add(CategoriaProduto);
    await dbContext.SaveChangesAsync();
  }

  public async Task Update(CategoriaProduto CategoriaProduto)
  {
    dbContext.CategoriaProdutos.Update(CategoriaProduto);
    await dbContext.SaveChangesAsync();
  }
}