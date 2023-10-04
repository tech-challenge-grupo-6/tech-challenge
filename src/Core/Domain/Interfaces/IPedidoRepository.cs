using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
  public interface IPedidoRepository<T> where Pedido<T>: class
  {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetBySatus(Status status);
    Task<IEnumerable<T>> GetByCliente(Cliente cliente);

    void Add(T cliente);
    void Update(T cliente);
  }
}