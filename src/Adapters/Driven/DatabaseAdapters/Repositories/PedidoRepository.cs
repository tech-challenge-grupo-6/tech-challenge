using System;
using System.Threading.Tasks;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class PedidoCategory : IPedidoRepository
  {
    private readonly DatabaseContext _dbContext;

    public PedidoCategory(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Pedido>> GetAll()
    {
      return await _dbContext.Pedidos.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Pedido>> GetBySatus(Status status)
    {
      return await _dbContext.Pedidos.AsNoTracking().Include(p => p.Status).Where(s => s.Status == status).ToListAsync();
    }

    public async Task<IEnumerable<Pedido>> GetByCliente(Cliente cliente)
    {
      return await _dbContext.Pedidos.AsNoTracking().Include(p => p.Cliente).Where(c => c.Cliente.Id == cliente).ToListAsync();
    }

    public async Task<Pedido> GetById(int id)
    {
      return await _dbContext.Pedidos.FindAsync(id);
    }

    public void Add(Pedido Pedido)
    {
      _dbContext.Pedidos.Add(Pedido);
    }
    public void UpdateStatus(Status status)
    {
      _dbContext.Pedidos.Update(status);
    }
  }
}