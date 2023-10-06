using System;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
  public interface IClienteRepository
  {
    Task<Cliente> GetById(int id);
    Task<Cliente> GetByCpf(string cpf);

    void Add(Cliente cliente);
    void Update(Cliente cliente);
  }
}