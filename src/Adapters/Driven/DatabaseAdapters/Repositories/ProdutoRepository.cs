using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class ProdutoRepository : IProdutoRepository
  {
    private readonly DatabaseContext _dbContext;

    public ProdutoRepository(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<IEnumerable<Produto>> GetAll()
    {
      return await _dbContext.Produtos.ToListAsync();
    }
    public async Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId)
    {
      return await _dbContext.Produtos.Where(p => p.CategoriaId == categoriaId).ToListAsync();
    }
    public async Task<Produto> GetById(Guid id)
    {
      return await _dbContext.Produtos.FindAsync(id);
    }
    public async Task Add(Produto Produto)
    {
      _dbContext.Produtos.Add(Produto);
      await _dbContext.SaveChangesAsync();
    }
    public void UpdateProduct(Produto Produto)
    {
      _dbContext.Produtos.Update(Produto);
      _dbContext.SaveChanges();
    }
    public void Add(CategoriaProduto Categoria)
    {
      _dbContext.CategoriaProdutos.Add(Categoria);
      _dbContext.SaveChanges();
    }
    public void Update(CategoriaProduto Categoria)
    {
      _dbContext.CategoriaProdutos.Update(Categoria);
      _dbContext.SaveChanges();
    }
    public void Remove(Produto produto)
    {
      _dbContext.Produtos.Remove(produto);
      _dbContext.SaveChanges();
    }
  }
}