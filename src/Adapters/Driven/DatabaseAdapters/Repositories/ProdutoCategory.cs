using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class ProdutoCategory : IProdutoRepository
  {
    private readonly DatabaseContext _dbContext;

    public ProdutoCategory(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Produto>> GetAll()
    {
      return await _dbContext.Produtos.AsNoTracking().ToListAsync();
    }
    public async Task<IEnumerable<Produto>> GetByCategoria(int categoriaId)
    {
      return await _dbContext.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.CategoriaProduto.Id == categoriaId).ToListAsync();
    }
    public async Task<Produto> GetById(int id)
    {
      return await _dbContext.Produtos.FindAsync(id);
    }

    public void Add(Produto Produto)
    {
      _dbContext.Produtos.Add(Produto);
      _dbContext.SaveChanges();
    }
    public void Update(Produto Produto)
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
  }
}