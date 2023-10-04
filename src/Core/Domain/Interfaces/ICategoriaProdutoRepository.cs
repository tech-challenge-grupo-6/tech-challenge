using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Models

namespace Domain
{
  public interface ICategoriaProdutoRepository<T> where CategoriaProduto<T>: class
  {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    void Add(T categoria);
    void Update(T categoria);
    void Delete(int id);
  }
}