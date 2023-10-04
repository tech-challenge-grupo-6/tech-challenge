using System;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
  public interface IPedidoRepository
  {
    Task<IEnumerable<Pedido>> GetAll();
    Task<IEnumerable<Pedido>> GetBySatus(Status status);
    Task<IEnumerable<Pedido>> GetByCliente(Cliente cliente);
    Task<Pedido> GetById(int id);

    void UpdateStatus(Status status);
    void Add(Pedido pedido);
  }
}