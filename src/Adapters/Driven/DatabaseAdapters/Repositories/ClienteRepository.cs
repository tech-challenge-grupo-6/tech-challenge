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

    public async Task<Cliente> GetById(int id)
    {
      return await _dbContext.Clientes.FindAsync(id);
    }

    public async Task<Cliente> GetByCpf(string cpf)
    {
      return await _dbContext.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public void Add(Cliente Cliente)
    {
      _dbContext.Clientes.Add(Cliente);
      _dbContext.SaveChanges();
    }
    public void Update(Cliente Cliente)
    {
      _dbContext.Clientes.Update(Cliente);
      _dbContext.SaveChanges();
    }
  }
}