using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.Contracts;

public interface IClienteUseCase
{
  Task CriarAsync(Cliente cliente);
  Task<Cliente> BuscarPorCpf(string cpf);
}
