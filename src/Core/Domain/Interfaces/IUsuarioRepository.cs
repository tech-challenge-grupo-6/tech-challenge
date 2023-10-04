using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
  public interface IUsuarioRepository<T> where Usuario<T>: class
  {
    Task<T> GetById(int id);
    Task<T> GetByLogin(string login);
    void Add(T usuario);
    void Update(T usuario);
  }
}