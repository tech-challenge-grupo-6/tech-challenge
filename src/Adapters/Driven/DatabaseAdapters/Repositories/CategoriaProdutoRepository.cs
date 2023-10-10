using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class CategoriaProdutoRepository : ICategoriaProdutoRepository
  {
    private readonly DatabaseContext _dbContext;

    public CategoriaProdutoRepository(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoriaProduto>> GetAll()
    {
      return await _dbContext.CategoriaProdutos.ToListAsync();
    }
    public async Task<CategoriaProduto> GetById(Guid id)
    {
      return await _dbContext.CategoriaProdutos.FindAsync(id);
    }
    public void Add(CategoriaProduto CategoriaProduto)
    {
      _dbContext.CategoriaProdutos.Add(CategoriaProduto);
      _dbContext.SaveChanges();
    }
    public void Update(CategoriaProduto CategoriaProduto)
    {
      _dbContext.CategoriaProdutos.Update(CategoriaProduto);
      _dbContext.SaveChanges();
    }
  }
}