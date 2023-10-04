using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repository;
using Ecommerce.Core.Data;

namespace Domain
{
  public interface IProdutoRepository<T> where Produto<T>: class
  {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetByCategory(int categoriaId);
    Task<Categoria> GetCategoria();
    void Add(Produto produto);
    void Update(Produto produto);
    void Delete(int id);

    void Add(Categoria categoria);
    void Update(Categoria categoria);
  }
}