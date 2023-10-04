using System;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
  public interface IUsuarioRepository
  {
    Task<Usuario> GetByLoginAndPassword(string login, string password);

    void Add(Usuario usuario);
    void Update(Usuario usuario);
  }
}