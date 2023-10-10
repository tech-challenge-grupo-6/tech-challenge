using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class ClienteRepository : IClienteRepository
  {
    private readonly DatabaseContext _dbContext;

    public ClienteRepository(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<Cliente?> GetById(Guid id)
    {
      return await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente?> GetByCpf(string cpf)
    {
      return await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public async Task Add(Cliente Cliente)
    {
      _dbContext.Clientes.Add(Cliente);
      await _dbContext.SaveChangesAsync();
    }
    public async Task Update(Cliente Cliente)
    {
      _dbContext.Clientes.Update(Cliente);
      await _dbContext.SaveChangesAsync();
    }
  }
}