using System;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
  public interface IClienteRepository
  {
    Task<Cliente?> GetById(Guid id);
    Task<Cliente?> GetByCpf(string cpf);

    Task Add(Cliente cliente);
    Task Update(Cliente cliente);
  }
}