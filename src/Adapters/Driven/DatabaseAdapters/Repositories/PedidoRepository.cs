using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class PedidoRepository : IPedidoRepository
  {
    private readonly DatabaseContext _dbContext;

    public PedidoRepository(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Pedido?>> GetAll()
    {
      return await _dbContext.Pedidos.ToListAsync();
    }

    public async Task<IEnumerable<Pedido?>> GetByStatus(Status status)
    {
      return await _dbContext.Pedidos.Where(p => p.Status == status).ToListAsync();
    }

    public async Task<IEnumerable<Pedido?>> GetByCliente(Guid clienteId)
    {
      return await _dbContext.Pedidos.Where(p => p.ClienteId == clienteId).ToListAsync();
    }

    public async Task<Pedido?> GetById(Guid id)
    {
      return await _dbContext
        .Pedidos
        .Include(p => p.Produtos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Add(Pedido Pedido)
    {
      _dbContext.Pedidos.Add(Pedido);
      await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateStatus(Pedido pedido)
    {
      _dbContext.Pedidos.Update(pedido);
      await _dbContext.SaveChangesAsync();
    }
  }
}