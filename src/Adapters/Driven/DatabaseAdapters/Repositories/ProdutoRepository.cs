using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories;

public class ProdutoRepository(DatabaseContext dbContext) : IProdutoRepository
{
  public async Task<IEnumerable<Produto>> GetAll()
  {
    return await dbContext.Produtos.ToListAsync();
  }

  public async Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId)
  {
    return await dbContext.Produtos.Where(p => p.CategoriaId == categoriaId).ToListAsync();
  }

  public async Task<Produto?> GetById(Guid id)
  {
    return await dbContext.Produtos.FindAsync(id);
  }

  public async Task Add(Produto Produto)
  {
    dbContext.Produtos.Add(Produto);
    await dbContext.SaveChangesAsync();
  }

  public void UpdateProduct(Produto Produto)
  {
    dbContext.Produtos.Update(Produto);
    dbContext.SaveChanges();
  }

  public void Add(CategoriaProduto Categoria)
  {
    dbContext.CategoriaProdutos.Add(Categoria);
    dbContext.SaveChanges();
  }

  public void Update(CategoriaProduto Categoria)
  {
    dbContext.CategoriaProdutos.Update(Categoria);
    dbContext.SaveChanges();
  }

  public void Remove(Produto produto)
  {
    dbContext.Produtos.Remove(produto);
    dbContext.SaveChanges();
  }
}