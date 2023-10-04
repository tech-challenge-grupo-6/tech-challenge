using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
  public interface IClienteRepository<T> where Cliente<T>: class
  {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> GetByCpf(int id);
    void Add(T cliente);
    void Update(T cliente);
  }
}