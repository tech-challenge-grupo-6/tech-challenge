using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Repositories;
using ControladorPedidos.App.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ControladorPedidos.App.Gateways;

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