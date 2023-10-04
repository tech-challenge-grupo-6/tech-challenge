using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;


namespace DatabaseAdapters.Repositories
{
  public class CategoriaProdutoRepository : ICategoriaProdutoRepository
  {
    private DatabaseContext _dbContext;

    public CategoriaProdutoRepository(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoriaProduto>> GetAll()
    {
      return await _context.CategoriaProdutos.AsNoTracking().ToListAsync();
    }
    public async Task<CategoriaProduto> GetById(int id)
    {
      return await _context.CategoriaProdutos.FindAsync(id);
    }
    public void Add(CategoriaProduto CategoriaProduto)
    {
      _context.CategoriaProdutos.Add(CategoriaProduto);
    }
    public void Update(CategoriaProduto CategoriaProduto)
    {
      _context.CategoriaProdutos.Update(CategoriaProduto);
    }
    public void Delete(CategoriaProduto CategoriaProduto)
    {
      _context.CategoriaProdutos.Delete(CategoriaProduto);
    }
  }
}