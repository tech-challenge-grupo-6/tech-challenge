using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories;

public class UsuarioCategory(DatabaseContext dbContext) : IUsuarioRepository
{
  public async Task<Usuario?> GetByLoginAndPassword(string login, string password)
  {
    return await dbContext.Usuarios.FirstOrDefaultAsync(p => p.Login == login && p.Senha == password);
  }

  public void Add(Usuario Usuario)
  {
    dbContext.Usuarios.Add(Usuario);
    dbContext.SaveChanges();
  }

  public void Update(Usuario Usuario)
  {
    dbContext.Usuarios.Update(Usuario);
    dbContext.SaveChanges();
  }
}